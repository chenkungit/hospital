package com.sinotao.bioc;

import java.io.IOException;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import ca.uhn.hl7v2.HL7Exception;
import ca.uhn.hl7v2.model.v231.message.ORU_R01;

import com.sinotao.util.Hl7Util;
import com.sinotao.util.buffer.ByteBuffer;
import com.sinotao.util.net.SocketUtil;

public class TcpServer {

	private final static Logger logger = LoggerFactory.getLogger(TcpServer.class);

	private int port = 5300;
	private String charset = "";

	private ServerSocket serverSocket = null;
	private Socket socket = null;
	private PrintWriter printWriter = null;
	
	private Thread tRecv = null;
	private boolean isRun = false;

	public TcpServer(int _port, String _charset) throws IOException{
		this.port = _port;
		this.charset = _charset;
		this.init();
	}
	
    private void init() throws IOException {
    	this.initSocket();
    }
    
    private void initSocket() throws IOException{
        try {
            this.serverSocket = new ServerSocket(this.port);
            logger.info("1)服务端[端口"+this.port+"]已启动，等待客户端连接...");
            
            this.socket = serverSocket.accept();//侦听并接受到此套接字的连接,返回一个Socket对象
            logger.info("2)侦听并接受到此套接字的连接");
            
            this.printWriter = new PrintWriter(this.socket.getOutputStream());
            logger.info("3)获取输入流、输出流");
            
        } catch (IOException e) {
        	logger.error(e.getMessage(), e);
            throw e;
        }
    }
    
    private void releaseSocket(){
    	try {
			socket.shutdownInput(); //关闭输入流
		} catch (IOException e) {
        	logger.error(e.getMessage(), e);
		}
    	
		try {
			socket.shutdownOutput(); //关闭输出流
		} catch (IOException e) {
        	logger.error(e.getMessage(), e);
		}
    	
    	try {
    		this.printWriter.close();
    		this.socket.getOutputStream().close();// 关闭相对应的资源
		} catch (IOException e) {
        	logger.error(e.getMessage(), e);
		}
    	
    	try {
    		this.socket.getInputStream().close();// 关闭相对应的资源
		} catch (IOException e) {
        	logger.error(e.getMessage(), e);
		}
    	
    	try {
			socket.close();// 关闭相对应的资源
		} catch (IOException e) {
        	logger.error(e.getMessage(), e);
		}
    }
    
    public void start() throws IOException{
        logger.info("==============开始接收数据===============");
        this.tRecv =  new Thread(){
            public void run() {
            	read();
	        } 
	    };
	    this.isRun = true;
	    this.tRecv.start();
    }
    
    public void stop(){
        logger.info("==============停止接收数据===============");
	    this.isRun = false;
	    this.tRecv.interrupt();
	    
	    this.releaseSocket();
    }

	private void read(){
		try {
			while (isRun) {
				int r = this.socket.getInputStream().read();
				if(r == 0x0B){
					StringBuffer sb = new StringBuffer();
					ByteBuffer bb = new ByteBuffer();

					int line = -1;
					while((line = this.socket.getInputStream().read()) != 0x1C) {
						sb.append((char)line);
						bb.appendByte(line);
					}

					try {
						logger.info("收到的消息：\n" + sb.toString() + "\n");
						ORU_R01 msg = Hl7Util.processMessage(sb.toString(), bb.elems, bb.length, this.charset);
						logger.debug("HL7结果：\n" + msg.encode() + "\n");
						
						com.sinotao.Main.task.addData(msg);//加入到队列，等待任务线程去解析
						
			            byte[] byteAck = Hl7Util.getAckBytes(msg);
			            String strRst = new String(byteAck);
						logger.info("返回的消息：\n" + strRst);
			            
						this.printWriter.print(strRst);
                        this.printWriter.flush();

					} catch (IOException e) {
			        	logger.error(e.getMessage(), e);
					} catch (HL7Exception e) {
			        	logger.error(e.getMessage(), e);
					}
		            sb.setLength(0);
		            
				} else if(r == -1){
					
					if(SocketUtil.isRemoteClose(this.socket, 0x02)){
					    this.releaseSocket();
						logger.info("客户端连接断开！！！！");
					    
			            this.socket = serverSocket.accept();//侦听并接受到此套接字的连接,返回一个Socket对象
			            logger.info("重新侦听并接受到套接字的连接");
			            
			            this.printWriter = new PrintWriter(this.socket.getOutputStream());
			            logger.info("重新获取输入流、输出流");
					}
				}
			}
		} catch (IOException e) {
        	logger.error(e.getMessage(), e);
		}
	}

}
