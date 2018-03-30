package com.sinotao.web.controller;

import org.springframework.beans.factory.annotation.Autowired;

import com.sinotao.util.ZipUtil;
import com.sinotao.web.util.UploadConfig;

public class BaseDeviceController {
	
	@Autowired
    protected UploadConfig uploadConfig;
	
	protected String sourceFolder = "src/";
	
	protected String dataFolder = "data/";
	
	/**
	 * 解压
	 */
	public String zipAttachment(String attachmentPath, String deviceFolder){
		String zipPath = this.uploadConfig.getBasePath() + attachmentPath;
		String descDir = this.uploadConfig.getBasePath()
				+ deviceFolder
				+ this.dataFolder
				+ attachmentPath.substring(attachmentPath.lastIndexOf("/")+1, attachmentPath.lastIndexOf("."))
				+ "/";
		ZipUtil.upzipFile(zipPath, descDir);
		return descDir;
	}
}
