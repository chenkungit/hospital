package com.sinotao;

import java.io.IOException;
import java.util.HashMap;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.bridge.SLF4JBridgeHandler;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.sinotao.bioc.MyTask;
import com.sinotao.bioc.TcpServer;

public class Main {
	private final static Logger logger = LoggerFactory.getLogger(Main.class);
	private static ClassPathXmlApplicationContext context;
	private static HashMap<String, String> viewConfig = null;

	public static MyTask task;
//	private static Hl7Server server;
	private static TcpServer server;
	
	public static Object getSpringBean(String beanName){
		return context.getBean(beanName);
	}

	@SuppressWarnings("unchecked")
	public static void main(String[] args) throws IOException {
		SLF4JBridgeHandler.install();// 初始化日志模块
		logger.info("==================== 采集端启动 ====================");
		context = new ClassPathXmlApplicationContext(new String[]{
				"classpath:spring/root-context.xml",
				"classpath:spring/datasource-context.xml"
		});// 加载spring的xml
		
		viewConfig = (HashMap<String, String>)context.getBean("viewConfig");
		// 循环周期：隔多少秒检查有无接收数据并上传
		int taskPeriod = Integer.parseInt(viewConfig.get("taskPeriod"));
		// 监听的端口号
		int port = Integer.parseInt(viewConfig.get("hl7ReceivingPort"));
		// HL7数据的字符集
		String charset = viewConfig.get("hl7Charset");

		task = new MyTask(taskPeriod);
		task.start();

		server = new TcpServer(port, charset);
		server.start();
	}

	public static void exit(String[] args) {
		server.stop();
		task.stop();

		context.close();// 关闭spring
		logger.info("==================== 采集端停止 ====================");
		SLF4JBridgeHandler.uninstall();

		System.exit(0);
	}

}
