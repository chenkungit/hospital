package com.sinotao.web.util;

public class UploadConfig {
	/**
	 * 上传文件保存地址基本路径
	 */
	private String basePath;
	
	/**
	 * “x光”上传文件保存地址相对路径
	 */
	private String xRayFolder;
	
	/**
	 * “心电图”上传文件保存地址相对路径
	 */
	private String heartFolder;
	
	/**
	 * “B超”上传文件保存地址相对路径
	 */
	private String bUtraFolder;
	
	/**
	 * “阴道镜”上传文件保存地址相对路径
	 */
	private String colposcopeFolder;

	/**
	 * @return the basePath
	 */
	public String getBasePath() {
		return basePath;
	}

	/**
	 * @param basePath the basePath to set
	 */
	public void setBasePath(String basePath) {
		this.basePath = basePath;
	}

	/**
	 * @return the xRayFolder
	 */
	public String getxRayFolder() {
		return xRayFolder;
	}

	/**
	 * @param xRayFolder the xRayFolder to set
	 */
	public void setxRayFolder(String xRayFolder) {
		this.xRayFolder = xRayFolder;
	}

	/**
	 * @return the heartFolder
	 */
	public String getHeartFolder() {
		return heartFolder;
	}

	/**
	 * @param heartFolder the heartFolder to set
	 */
	public void setHeartFolder(String heartFolder) {
		this.heartFolder = heartFolder;
	}

	/**
	 * @return the bUtraFolder
	 */
	public String getbUtraFolder() {
		return bUtraFolder;
	}

	/**
	 * @param bUtraFolder the bUtraFolder to set
	 */
	public void setbUtraFolder(String bUtraFolder) {
		this.bUtraFolder = bUtraFolder;
	}

	/**
	 * @return the colposcopeFolder
	 */
	public String getColposcopeFolder() {
		return colposcopeFolder;
	}

	/**
	 * @param colposcopeFolder the colposcopeFolder to set
	 */
	public void setColposcopeFolder(String colposcopeFolder) {
		this.colposcopeFolder = colposcopeFolder;
	}
}
