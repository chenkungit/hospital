package com.sinotao.business.util;

/**
 * 环境变量配置读取
 * @author
 */
public class Configuration {
	/**
	 * 上传文件夹路径
	 */
	private String richFolder;
	/**
	 * 上传文件夹路径
	 */
	private String fileFolder;
	/**
	 * 上传文件盘符
	 */
	private String drivePath;

	public String getRichFolder() {
		return richFolder;
	}

	public void setRichFolder(String richFolder) {
		this.richFolder = richFolder;
	}

	public String getFileFolder() {
		return fileFolder;
	}

	public void setFileFolder(String fileFolder) {
		this.fileFolder = fileFolder;
	}

	public String getDrivePath() {
		return drivePath;
	}

	public void setDrivePath(String drivePath) {
		this.drivePath = drivePath;
	}

}
