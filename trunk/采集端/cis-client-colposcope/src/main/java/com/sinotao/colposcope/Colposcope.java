package com.sinotao.colposcope;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.bridge.SLF4JBridgeHandler;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.sinotao.colposcope.util.FileUtil;
import com.sinotao.util.DateUtil;
import com.sinotao.util.HttpClient;
import com.sinotao.util.JacksonMapperUtil;
import com.sinotao.util.TelnetUtil;
import com.sinotao.util.ZipUtil;
import com.sinotao.util.dto.ResultDTO;

public class Colposcope {

	private final static Logger logger = LoggerFactory.getLogger(Colposcope.class);
	private ClassPathXmlApplicationContext context;
	private HashMap<String, String> viewConfig = null;
	
	private int taskPeriod = -1;
	private String uploadPath = null;
	private String uploadIp = null;
	private int uploadPort = -1;
	private String scanPath = null;
	private File rootFolder = null;
	private String uploadLogPath = null;
	/**
	 * 当前是否正在上传
	 */
	private boolean isUploading = false;
	
	public Colposcope(){
		this.init();
	}
	
	private void init(){
		// 初始化日志模块
		SLF4JBridgeHandler.install();
		// 初始化spring
		this.initSpring();

		this.rootFolder = new File(this.scanPath);
	}

	@SuppressWarnings("unchecked")
	private void initSpring(){
		
		// 加载spring的xml
		this.context = new ClassPathXmlApplicationContext("classpath:spring/root-context.xml");
		this.viewConfig = (HashMap<String, String>)context.getBean("viewConfig");
		
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
				String taskId = "colposcope_" + DateUtil.getNowByFormat("yyyyMMddHHmmss");
				logger.info("【任务"+taskId+"】开始！");
				
				if(isUploading == false){
					isUploading = true;
					
					//1.扫描本地文件（只扫描一级目录即可）
					File[] files = rootFolder.listFiles();
					logger.info("【任务"+taskId+"】扫描出"+files.length+"个子文件（夹）！");
					
					//2.比较上传日志，需要上传的加入至集合
					// 上传日志每行格式：上传文件全名称+","+修改时间
					List<String> logs = FileUtil.readFile(uploadLogPath);
					List<File> file2upload = new ArrayList<File>();
					if(files!=null && files.length>0) {
						for(File f : files){
							boolean hasUpload = false;
							for(String uploadrecord : logs){
								String str = createUploadLogRow(f);
								if (uploadrecord.endsWith(str)) {
									logger.info("【任务"+taskId+"】本次不用上传："+f.getAbsolutePath()+"。");
									hasUpload = true;
									break;
								}
							}
							if(!hasUpload){
								file2upload.add(f);
							}
						}
					}
					logger.info("【任务"+taskId+"】需要上传"+file2upload.size()+"个！");
	
					if(file2upload.size()>0){
						for(int i=0; i<file2upload.size(); i++){
							File file = file2upload.get(i);
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
									String code = file.getName().substring(0, file.getName().length()-file.getName().lastIndexOf("."));
									maps.put("code", code);//文件名称，即【检查号】
									Map<String, File> fileLists = new HashMap<String, File>();
									fileLists.put("attachment", uploadFile);
									String rst = HttpClient.getInstance().sendHttpPost(uploadPath, maps, fileLists);
									logger.info("【任务"+taskId+"】上传结果："+rst);
									
									//4.2上传成功，记录上传日志
									ResultDTO dto = JacksonMapperUtil.jsonToBean(rst, ResultDTO.class);
									if( dto!=null && Boolean.TRUE.equals(dto.getSuccess()) ){
										String str = createUploadLogRow(file);
										FileUtil.writeFile(uploadLogPath, str);
									}
								} else {
									logger.error("【任务"+taskId+"】本次上传失败！无法telnet通服务器！");
								}

							} catch (IOException e) {
								logger.error("【任务"+taskId+"】本次上传失败！无法联通服务器："+e.getMessage());
							}

							//5.删除压缩
							ZipUtil.deletefile(zipPath);
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
	
	private String createUploadLogRow(File f){
		return f.getAbsolutePath() + "," + f.lastModified();
	}

	public static Colposcope app;
	public static void main(String[] args) {
		app = new Colposcope();
		logger.info("==================== 采集端启动 ====================");
		app.start();
	}
	public static void exit(String[] args) {
		app.destroy();
		logger.info("==================== 采集端停止 ====================");
		System.exit(0);
	}
}
