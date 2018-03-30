package com.sinotao.heart;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;

import org.apache.commons.net.ftp.FTPFile;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.bridge.SLF4JBridgeHandler;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.sinotao.heart.util.FileUtil;
import com.sinotao.util.DateUtil;
import com.sinotao.util.HttpClient;
import com.sinotao.util.JacksonMapperUtil;
import com.sinotao.util.TelnetUtil;
import com.sinotao.util.ZipUtil;
import com.sinotao.util.dto.ResultDTO;
import com.sinotao.util.file.ftp.FtpManager;

public class Heart {

	private final static Logger logger = LoggerFactory.getLogger(Heart.class);
	private ClassPathXmlApplicationContext context;
	private HashMap<String, String> viewConfig = null;
	private FtpManager ftpManager = null;
	
	private int taskPeriod = -1;
	private String uploadPath = null;
	private String uploadIp = null;
	private int uploadPort = -1;
	private String scanPath = null;
	private String uploadLogPath = null;
	/**
	 * 当前是否正在上传
	 */
	private boolean isUploading = false;
	
	public Heart(){
		this.init();
	}
	
	private void init(){
		// 初始化日志模块
		SLF4JBridgeHandler.install();
		// 初始化spring
		this.initSpring();
	}

	@SuppressWarnings("unchecked")
	private void initSpring(){
		
		// 加载spring的xml
		this.context = new ClassPathXmlApplicationContext("classpath:spring/root-context.xml");
		this.viewConfig = (HashMap<String, String>)context.getBean("viewConfig");
		this.ftpManager = (FtpManager)context.getBean("ftpManager");
		
		// 初始化上传地址：上传数据的url
		this.uploadPath = viewConfig.get("webStaticServer") + viewConfig.get("webRelativeUrl");
		this.uploadIp = viewConfig.get("webStaticServerIp");
		this.uploadPort = Integer.parseInt(viewConfig.get("webStaticServerPort"));
		
		// 初始化扫描路径：获取要上传文件所在路径
		this.scanPath = viewConfig.get("scanPath");
		
		// 初始化循环周期：获取扫描时间周期（秒）
		this.taskPeriod = Integer.parseInt(viewConfig.get("taskPeriod"));

		// 数据上传日志地址：记录扫描路径下，哪些已上传
		this.uploadLogPath = viewConfig.get("uploadLogPath");
	}
	
	private void destroy() {
		// 关闭spring
		this.context.close();
		SLF4JBridgeHandler.uninstall();
	}

	private void start(){
		Timer timer = new Timer();
		timer.schedule(new TimerTask() {
			@Override
			public void run() {
				String taskId = "heart_" + DateUtil.getNowByFormat("yyyyMMddHHmmss");
				logger.info("【任务"+taskId+"】开始！");
				
				if(isUploading == false){
					isUploading = true;
					
					//1.扫描文件（只扫描一级目录即可）
					FTPFile[] ftpFiles= ftpManager.getFiles(scanPath);
					logger.info("【任务"+taskId+"】扫描【"+scanPath+"】下有"+ftpFiles.length+"个文件！");
					
					//2.比较上传日志，需要上传的加入至集合
					// 上传日志每行格式：上传文件全名称+","+修改时间
					List<String> logs = FileUtil.readFile(uploadLogPath);
//					Map<String, File> file2upload = new HashMap<String, File>();
					List<FTPFile> file2upload = new ArrayList<FTPFile>();
					if(ftpFiles!=null && ftpFiles.length>0) {
						for(FTPFile ftpF : ftpFiles){
							boolean hasUpload = false;
							for(String uploadrecord : logs){
								String str = createUploadLogRow(ftpF);
								if (uploadrecord.endsWith(str)) {
									logger.info("【任务"+taskId+"】本次不用上传：" + ftpF.getName() + "。");
									hasUpload = true;
									break;
								}
							}
							if(!hasUpload && ftpF.getName().toLowerCase().endsWith(".pdf")){
								file2upload.add(ftpF);
//								try {
//									File tmpFile = createTmpFile(File.separator, ftpF.getName());
//									ftpManager.download(scanPath, tmpFile);
//									file2upload.put(createUploadLogRow(ftpF), tmpFile);
//								} catch (IOException e) {
//									logger.error("【任务"+taskId+"】从FTP下载文件【"+ftpF.getName()+"】失败："+e.getMessage(), e);
//								}
							}
						}
					}
					logger.info("【任务"+taskId+"】需要上传"+file2upload.size()+"个！");
	
					if(file2upload.size()>0){
						int i = -1;
//						for(Map.Entry<String, File> entry : file2upload.entrySet()){
						for(FTPFile ftpF : file2upload){
							i++;
							File file = null;
							String currlog = "";
//							file = entry.getValue();
//							currlog = entry.getKey();
							
							//下载ftp文件到本地
							try {
								file = createTmpFile(File.separator, ftpF.getName());
								ftpManager.download(scanPath, file);
								currlog = createUploadLogRow(ftpF);
							} catch (IOException e) {
								logger.error("【任务"+taskId+"】从FTP下载文件【"+ftpF.getName()+"】失败："+e.getMessage(), e);
								continue;
							}
							
							String zipPath = "/" + taskId + "_" + i + ".zip";
							
							//3.需要上传的进行压缩
							ZipUtil.zipFolder(file.getAbsolutePath(), zipPath);
							File uploadFile = new File(zipPath);
							
							//4.上传
							try {
								boolean telnet = TelnetUtil.telnet(uploadIp, uploadPort);
								if(telnet){
									//4.1上传
									Map<String, String> maps = new HashMap<String, String>();
									maps.put("code", file.getName().substring(0, 9));//心电图名称前9位是检查号
									Map<String, File> fileLists = new HashMap<String, File>();
									fileLists.put("attachment", uploadFile);
									String rst = HttpClient.getInstance().sendHttpPost(uploadPath, maps, fileLists);
									logger.info("【任务"+taskId+"】上传结果："+rst);
									
									//4.2上传成功，记录上传日志
									ResultDTO dto = JacksonMapperUtil.jsonToBean(rst, ResultDTO.class);
									if( dto!=null && Boolean.TRUE.equals(dto.getSuccess()) ){
										FileUtil.writeFile(uploadLogPath, currlog);
									}
								} else {
									logger.error("【任务"+taskId+"】本次上传失败！无法telnet通服务器！");
								}

							} catch (IOException e) {
								logger.error("【任务"+taskId+"】本次上传失败！无法联通服务器："+e.getMessage());
							}

							//5.删除压缩文件
							ZipUtil.deletefile(zipPath);
			                file.delete();//删除从ftp下载到本地的文件
						}
					}
					
					isUploading = false;
					logger.info("【任务"+taskId+"】结束！");
					
				} else {
					logger.error("【任务"+taskId+"】结束！上次任务未结束！");
				}
			}
		}, 0, this.taskPeriod*1000);
	}
	
	private String createUploadLogRow(FTPFile f){
		return f.getName() + "," + f.getTimestamp().getTimeInMillis();
	}
	
	private File createTmpFile(String localPath, String fileName) throws IOException{
		File fl1 = new File(localPath);
		if (!fl1.exists()) {
			fl1.mkdirs();
		}
		File file = new File(localPath + fileName);
		file.createNewFile();
		return file;
	}

	public static Heart app;
	public static void main(String[] args) {
		app = new Heart();
		logger.info("==================== 采集端启动 ====================");
		app.start();
	}
	public static void exit(String[] args) {
		app.destroy();
		logger.info("==================== 采集端停止 ====================");
		System.exit(0);
	}
}
