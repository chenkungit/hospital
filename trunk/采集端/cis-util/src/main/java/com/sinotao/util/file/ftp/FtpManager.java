package com.sinotao.util.file.ftp;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.SocketException;

import org.apache.commons.net.ftp.FTP;
import org.apache.commons.net.ftp.FTPClient;
import org.apache.commons.net.ftp.FTPFile;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

@Component
public class FtpManager {
	private final String CHARSET = "GBK";
	private Logger logger = LoggerFactory.getLogger(FtpManager.class);

	private FTPClient ftpClient;
	private String host;
	private int port;
	private String username;
	private String password;

	public FtpManager(String _host, int _port, String _username, String _password) {
		this.host = _host;
		this.port = _port;
		this.username = _username;
		this.password = _password;
	}

	public void init() {
		try {
			this.ftpClient = this.connect(this.host, this.port, this.username,
					this.password);
		} catch (SocketException e) {
			this.logger.error(e.getMessage(), e);
		} catch (IOException e) {
			this.logger.error(e.getMessage(), e);
		}
	}

	public void destroy() {
		if (this.ftpClient != null && this.ftpClient.isConnected()) {
			try {
				this.disConnect(this.ftpClient);
			} catch (IOException e) {
				this.logger.error(e.getMessage(), e);
			}
		}
	}

	// 连接模式 主动还是被动
	// private static Boolean passiveMode;
	// 开启链接
	public FTPClient connect(String _host, int _port, String _username,
			String _password) throws SocketException, IOException {
		
		FTPClient fc = new FTPClient();
		//加入以下两句代码会导致当serv-u作为ftp时，调用listFiles方法获取不到
//		FTPClientConfig conf = new FTPClientConfig(FTPClientConfig.SYST_NT);
//		fc.configure(conf);
		
		fc.connect(_host, _port);
		fc.enterLocalPassiveMode();//这句代码最好放到connect后，login前
		fc.login(_username, _password);
		
		fc.setControlEncoding(CHARSET);
		fc.setFileType(FTP.BINARY_FILE_TYPE);
		return fc;
	}

	// 关闭链接
	public void disConnect(FTPClient fc) throws IOException {
		fc.logout();
		fc.disconnect();
	}

	/**
	 * 上传
	 * 
	 * @param filePath
	 * @param datas
	 * @return
	 */
	public boolean upload(String fileName, File file, String filePath) {
        if (this.ftpClient == null) {
    		return false;
		}
		if (!this.ftpClient.isConnected()) {
			return false;
		}

		InputStream fis = null;
		try {
			fis = new FileInputStream(file);
			ftpClient.setBufferSize(1024);
			ftpClient.setFileType(FTPClient.BINARY_FILE_TYPE);
			ftpClient.storeFile(filePath + File.separator + fileName, fis);
			return true;
			
		} catch (IOException e) {
			this.logger.error(e.getMessage(), e);
		} finally {
			if(fis != null){
				try {
					fis.close();
				} catch (IOException e) {
					this.logger.error(e.getMessage(), e);
				}
			}
		}
		return false;
	}

	/**
	 * 下载同步文件
	 * @param ftpPath 文件所在ftp根目录的相对路径
	 * @param fos
	 */
	public boolean download(String ftpPath, File file) {
        if (this.ftpClient == null) {
    		return false;
		}
		if (!this.ftpClient.isConnected()) {
			return false;
		}
		
		FileOutputStream fos = null;
		try {
			fos = new FileOutputStream(file);
			ftpClient.setBufferSize(1024);
			ftpClient.setFileType(FTPClient.BINARY_FILE_TYPE);
			ftpClient.retrieveFile(ftpPath + File.separator + file.getName(), fos);
			fos.flush();
			
		} catch (FileNotFoundException e) {
			this.logger.error(e.getMessage(), e);
		} catch (IOException e) {
			this.logger.error(e.getMessage(), e);
		} finally {
			if(fos!=null){
				try {
					fos.close();
				} catch (IOException e) {
					this.logger.error(e.getMessage(), e);
				}
			}
		}
		return false;
		
	}

	/**
	 * 下载同步文件
	 * @param fileName文件存储名称
	 * @param localPath本地路径
	 */
	public boolean download(String ftpPath, String localPath, String fileName) {
		try {
			File fl1 = new File(localPath);
			if (!fl1.exists()) {
				fl1.mkdirs();
			}
			File file = new File(localPath + fileName);
			file.createNewFile();
			return download(ftpPath, file);
			
		} catch (IOException e) {
			this.logger.error(e.getMessage(), e);
		}
		return false;
	}

	/**
	 * 返回FTP目录下的文件名列表
	 * 
	 * @param pathName
	 * @return
	 */
	public String[] getFileNameList(String pathName) {
		try {
			return ftpClient.listNames(pathName);
		} catch (IOException e) {
			this.logger.error(e.getMessage(), e);
			return null;
		}
	}

	/**
	 * 返回FTP目录下的文件列表
	 * 
	 * @param pathName
	 * @return
	 */
	public FTPFile[] getFiles(String pathName) {
		try {
			return ftpClient.listFiles(pathName);
		} catch (IOException e) {
			this.logger.error(e.getMessage(), e);
			return null;
		}
	}
}
