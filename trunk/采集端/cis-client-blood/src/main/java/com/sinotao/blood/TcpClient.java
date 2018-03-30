package com.sinotao.blood;

import java.io.IOException;
import java.io.InputStream;
import java.net.Socket;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import ca.uhn.hl7v2.HL7Exception;
import ca.uhn.hl7v2.model.v231.message.ORU_R01;

import com.sinotao.util.Hl7Util;
import com.sinotao.util.TelnetUtil;
import com.sinotao.util.buffer.ByteBuffer;
import com.sinotao.util.net.SocketUtil;

public class TcpClient {

	private final static Logger logger = LoggerFactory.getLogger(TcpClient.class);

	private String host = "127.0.0.1";
	private int port = 5100;
	private String charset = "";

	private Socket socket = null;
	private InputStream inputStream = null;
	
	private Thread tRecv = null;
	private boolean isRun = false;
	private boolean isAutoInitSocket = true;

	public TcpClient(String _host, int _port, String _charset) {
		this.host = _host;
		this.port = _port;
		this.charset = _charset;
		this.init();
	}
	
    private void init() {
    	this.initSocket();
    }

	private void initSocket() {
    	logger.info("初始化Socket["+this.host+":"+this.port+"]...");
		boolean isInit = false;
		while(this.isAutoInitSocket && isInit == false){
			try {
				boolean telnet = TelnetUtil.telnet(this.host, this.port);
				if(telnet){
					this.socket = new Socket(this.host, this.port);
		            logger.info("创建套接字的连接");
		            
					this.inputStream = this.socket.getInputStream();
		            logger.info("获取输入流");
					
					isInit = true;
			    	logger.info("初始化Socket["+this.host+":"+this.port+"]...完成");
				} else {
		        	logger.error("telnet[" + this.host + ":" + this.port + "]不通！！");
				}
			} catch (IOException e) {
	        	logger.error("无法连接[" + this.host + ":" + this.port + "]！！" + e.getMessage(), e);
			}
		}
	}
    
    private void releaseSocket(){
    	try {
			socket.shutdownInput(); //关闭输入流
		} catch (IOException e) {
        	logger.error(e.getMessage(), e);
		}
    	
    	try {
			inputStream.close();// 关闭相对应的资源
		} catch (IOException e) {
        	logger.error(e.getMessage(), e);
		}
    	
    	try {
			socket.close();// 关闭相对应的资源
		} catch (IOException e) {
        	logger.error(e.getMessage(), e);
		}
    }
    
    public void start() {
        logger.info("==============开始接收数据===============");
        this.tRecv = new Thread(new RecvThread());
	    this.isRun = true;
	    this.tRecv.start();
    }
    
    public void stop(){
        logger.info("==============停止接收数据===============");
	    this.isAutoInitSocket = false;
	    this.isRun = false;
	    this.tRecv.interrupt();
	    
	    this.releaseSocket();
    }

	private class RecvThread implements Runnable {
		
		public void run() {
			read();
		}

		private void read(){
			while (isRun) {
				try {
					int r = inputStream.read();
					if(r == 0x02){
						logger.info("接收到仪器发送的心跳控制字(0x02)");
						
					} else if(r == 0x0B){
						StringBuffer sb = new StringBuffer();
						ByteBuffer bb = new ByteBuffer();
						
						int line = -1;  
						while((line = inputStream.read()) != 0x1C) {  
							sb.append((char)line);
							bb.appendByte(line);
						}
						
						try {
							logger.info("待转换的字符串，解析前会将NM替换为IS，避免5个星号(*****)的数据：\n" + sb.toString() + "\n");
							ORU_R01 msg = Hl7Util.processMessage(sb.toString(), bb.elems, bb.length, charset);
							
							logger.debug("HL7消息：\n" + msg.encode() + "\n");
							com.sinotao.Main.task.addData(msg);//加入到队列，等待任务线程去解析
	
						} catch (IOException e) {
				        	logger.error(e.getMessage(), e);
						} catch (HL7Exception e) {
				        	logger.error(e.getMessage(), e);
						}
			            
					} else if(r == -1){
						if(SocketUtil.isRemoteClose(socket)){
						    releaseSocket();
							logger.info("客户端连接断开！！！！");
							initSocket();
						}
					}
				} catch (IOException e) {
		        	logger.error(e.getMessage(), e);
				}
			}
		}
	}
}
