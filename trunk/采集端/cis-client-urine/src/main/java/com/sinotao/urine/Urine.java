package com.sinotao.urine;

import gnu.io.NoSuchPortException;
import gnu.io.PortInUseException;
import gnu.io.SerialPort;
import gnu.io.SerialPortEvent;
import gnu.io.SerialPortEventListener;
import gnu.io.UnsupportedCommOperationException;

import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.Map;
import java.util.Queue;
import java.util.Timer;
import java.util.TimerTask;
import java.util.TooManyListenersException;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.bridge.SLF4JBridgeHandler;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.sinotao.urine.util.FileUtil;
import com.sinotao.urine.util.sp.SerialTool;
import com.sinotao.urine.util.sp.exception.NotASerialPort;
import com.sinotao.util.DateUtil;
import com.sinotao.util.HttpClient;
import com.sinotao.util.JacksonMapperUtil;
import com.sinotao.util.TelnetUtil;
import com.sinotao.util.dto.ResultDTO;

public class Urine implements SerialPortEventListener {

	private final static Logger logger = LoggerFactory.getLogger(Urine.class);
	private ClassPathXmlApplicationContext context;
	private HashMap<String, String> viewConfig = null;

	private int taskPeriod = -1;
	private String uploadPath = null;
	private String uploadIp = null;
	private int uploadPort = -1;
	private String uploadLogPath = null;
	

	private Timer timer;
	private Thread thdOpenPort;
	
	private String portName;
	private int baudrate;
	
	/**
	 * 串口
	 */
	private SerialPort serialPort = null;
	/**
	 * 接收到的数据
	 */
	private StringBuffer inputBuffer = new StringBuffer();
	/**
	 * 队列
	 */
	private Queue<String> data2upload = new LinkedList<String>();
	/**
	 * 上传失败的队列
	 */
	private Queue<String> fail2upload = new LinkedList<String>();
	
	public Urine(){
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
		
		// 初始化上传地址：上传数据的url
		this.uploadPath = viewConfig.get("webStaticServer") + viewConfig.get("webRelativeUrl");
		this.uploadIp = viewConfig.get("webStaticServerIp");
		this.uploadPort = Integer.parseInt(viewConfig.get("webStaticServerPort"));

		// 循环周期：隔多少秒检查有无接收数据并上传
		this.taskPeriod = Integer.parseInt(viewConfig.get("taskPeriod"));
		// 上传日志文件地址
		this.uploadLogPath = viewConfig.get("uploadLogPath");

		this.portName = viewConfig.get("portName");
		this.baudrate = Integer.parseInt(viewConfig.get("baudrate"));

	}
	
	private void destroy() {
		this.stop();
		// 关闭spring
		this.context.close();
		SLF4JBridgeHandler.uninstall();
	}
	
	private void stop(){
		if(this.thdOpenPort!=null){
			this.thdOpenPort.interrupt();
		}
		if(this.timer!=null){
			this.timer.cancel();
		}
	}

	private void start(){
		this.timer = new Timer();
		timer.schedule(new TimerTask() {
			@Override
			public void run() {
				upload();
			}
		}, 0, this.taskPeriod*1000);
		
		this.thdOpenPort = new Thread(new Runnable() {
			@Override
			public void run() {
				boolean isPortConnected = false;
				do{
					try {
						serialPort = SerialTool.openPort(portName, baudrate, SerialPort.DATABITS_8,
								SerialPort.STOPBITS_1, SerialPort.PARITY_ODD);
					} catch (NoSuchPortException e) {
						logger.error(e.getMessage(), e);
					} catch (PortInUseException e) {
						logger.error(e.getMessage(), e);
					} catch (UnsupportedCommOperationException e) {
						logger.error(e.getMessage(), e);
					} catch (NotASerialPort e) {
						logger.error(e.getMessage(), e);
					}
					
					if(serialPort != null){
						try {
							SerialTool.addListener(serialPort, app);
							isPortConnected = true;
						} catch (TooManyListenersException e) {
							logger.error(e.getMessage(), e);
						}
					}
					
					if(!isPortConnected){
						logger.info("启动串口监听功能失败！");
						try {
							Thread.sleep(2000); //如果端口启动失败，每隔2s循环打开
						} catch (InterruptedException e) {
							logger.error(e.getMessage(), e);
						}
					} else {
						logger.info("启动串口监听功能成功！");
					}
				} while(!isPortConnected);
			}
		});
		this.thdOpenPort.start();
	}

	private int lastData = 0x00;
	public void serialEvent(SerialPortEvent event) {
		switch (event.getEventType()) {

	        case SerialPortEvent.BI: // 10 通讯中断
	        case SerialPortEvent.OE: // 7 溢位（溢出）错误
	        case SerialPortEvent.FE: // 9 帧错误
	        case SerialPortEvent.PE: // 8 奇偶校验错误
	        case SerialPortEvent.CD: // 6 载波检测
	        case SerialPortEvent.CTS: // 3 清除待发送数据
	        case SerialPortEvent.DSR: // 4 待发送数据准备好了
	        case SerialPortEvent.RI: // 5 振铃指示
	        case SerialPortEvent.OUTPUT_BUFFER_EMPTY: // 2 输出缓冲区已清空
				break;
			case SerialPortEvent.DATA_AVAILABLE:
//				try {
//					byte[] data = SerialTool.readFromPort(this.serialPort);   //读取数据，存入字节数组
//					String strData = new String(data, "GBK");
//					this.data2upload.offer(strData);
//					logger.info("收到数据："+strData);
//					
//				} catch (ReadDataFromSerialPortFailure e) {
//					logger.error(e.getMessage(), e);
//				} catch (SerialPortInputStreamCloseFailure e) {
//					logger.error(e.getMessage(), e);
//				} catch (UnsupportedEncodingException e) {
//					logger.error(e.getMessage(), e);
//				} 

				InputStream in = null;
//				StringBuffer tmpBuffer = new StringBuffer();
				try {
					logger.info("接收前数据："+inputBuffer.toString());
					in = this.serialPort.getInputStream();
					while(in.available() > 0){
						int b = in.read();
						this.inputBuffer.append((char)b);
//						tmpBuffer.append((char)b);
						
						if(lastData==0x0D && b==0x0A){
							this.analysisData();
						} else {
							lastData = b;
						}
					}
					logger.info("接收后数据："+inputBuffer.toString());
				} catch (IOException e) {
					logger.error(e.getMessage(), e);
				} finally {
					try {
						if (in != null) {
							in.close();
							in = null;
						}
					} catch (IOException e) {
						logger.error(e.getMessage(), e);
					}
				}
				break;
		}
	}

	/**
	 * 分析接收到的数据
	 */
	private void analysisData(){

		if(this.inputBuffer!=null && this.inputBuffer.length()>0){
			byte[] data = this.inputBuffer.toString().getBytes();

			byte henggang = 0x2D;
			byte maohao = 0x3A;

			boolean analysisFlag = false;
			int beginIndex = -1;
			int analysis0d0aCount = 0;//0x0D 0x0A数量
			for(int i=0; i<data.length; i++){
				byte b = data[i];
				
				if(!analysisFlag
						&& b == henggang //遇见的第一个横杠，假定为：日期年份与月份之间的横杠
						&& data.length > i+13	//从“第一个横杠”到“分钟和秒之间的冒号”间隔长度为13
						&& data[i+3]==henggang	//验证日期月份与天之间的横杠
						&& data[i+10]==maohao	//验证小时和分钟之间的冒号
						&& data[i+13]==maohao	//验证分钟和秒之间的冒号
				){
					analysisFlag = true;
					beginIndex = i;
				}
				
				if(analysisFlag && (i>0 && data[i-1]==0x0D && b==0x0A)){
					analysis0d0aCount++;
					if(analysis0d0aCount==15){
						if(beginIndex>=4){
							beginIndex = beginIndex - 4;
						}
						String strData = this.inputBuffer.substring(beginIndex, i+1);
						this.inputBuffer.delete(0, i+1);
						
						this.data2upload.offer(strData);
						logger.info("匹配出可以上传的数据："+strData);
					}
				}
			}
		}
	}
	
	/**
	 * 数据上传
	 */
	private void upload(){
		//将上次上传失败的数据加入到上传队列
		while(this.fail2upload.size()>0){
			this.data2upload.offer(this.fail2upload.poll());
		}
		
		//如果有队列里有数据，开始上传
		while(this.data2upload.size()>0){
			String taskId = "urine_" + DateUtil.getNowByFormat("yyyyMMddHHmmss");
			logger.info("【任务"+taskId+"】开始！");
			
			boolean isUploadSuccess = false;
			Map<String, String> maps = new HashMap<String, String>();
			String strData = this.data2upload.poll();
			maps.put("data", strData);
			logger.info("【任务"+taskId+"】上传数据：" + strData);
			
			try {
				boolean telnet = TelnetUtil.telnet(uploadIp, uploadPort);
				if(telnet){
					String rst = HttpClient.getInstance().sendHttpPost(uploadPath, maps);
					logger.info("【任务"+taskId+"】上传结果："+rst);
					
					//4.2上传成功，记录上传日志
					String str = "[" + DateUtil.getNowDatetime() + "] 数据：【"+strData+"】";
					ResultDTO dto = JacksonMapperUtil.jsonToBean(rst, ResultDTO.class);
					if(dto!=null){
						str += dto.getMessage();
						if(Boolean.TRUE.equals(dto.getSuccess())){
							isUploadSuccess = true;
						}
					} else {
						str += "上传失败！";
					}
					FileUtil.writeFile(uploadLogPath, str);
				} else {
					logger.error("【任务"+taskId+"】上传失败！无法telnet通服务器！");
				}
			} catch (IOException e) {
				logger.error("【任务"+taskId+"】上传失败！无法联通服务器："+e.getMessage());
			}
			
			if(!isUploadSuccess){//上传失败，将数据加入到失败队列
				this.fail2upload.offer(strData);
			}
			logger.info("【任务"+taskId+"】结束！");
		}
	}

	public static Urine app;
	public static void main(String[] args) {
		app = new Urine();
		logger.info("==================== 采集端启动 ====================");
		app.start();
	}
	public static void exit(String[] args) {
		app.destroy();
		logger.info("==================== 采集端停止 ====================");
		System.exit(0);
	}
}
