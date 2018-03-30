package com.sinotao.web.controller;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.multipart.MultipartFile;

import com.sinotao.business.biz.ClinicarCheckResultBiz;
import com.sinotao.business.biz.InterfaceDataBiz;
import com.sinotao.business.dao.entity.InterfaceData;
import com.sinotao.business.enums.DptEnum;
import com.sinotao.util.DateUtil;
import com.sinotao.util.UploadUtil;
import com.sinotao.util.dto.ResultDTO;
import com.sinotao.util.file.FileUtil;

/**
 * <b>功能描述：阴道镜Controller
 * 
 * @version V1.0.0
 * @author 佟磊
 */ 
@Controller
@RequestMapping("/colposcope/") 
public class ColposcopeController extends BaseDeviceController{
	
	private final static Logger logger= LoggerFactory.getLogger(ColposcopeController.class);

	@Autowired
    private InterfaceDataBiz interfaceDataBiz;
	
	@Autowired
    private ClinicarCheckResultBiz clinicarCheckResultBiz;

	private DptEnum dpt = DptEnum.COLPOSCOPE;
	
	/**
	 * 功能描述: 接收数据
     * @return ModelAndView
	 * @author 佟磊
     */
    @RequestMapping("receiveData")
    @ResponseBody
    public ResultDTO receiveData(HttpServletRequest request, String code, MultipartFile attachment){
    	ResultDTO result = new ResultDTO();
    	String message = "";
    	
    	String reqId = "colposcope-"+DateUtil.getNowByFormat("yyyyMMddHHmmss");
    	logger.info("收到请求" + reqId + "：检查号=" + code);
		try {
			if(null!=attachment && attachment.getBytes().length>0){
				
				// 1.接收附件
				String attachmentName = attachment.getOriginalFilename();
			    // 文件保存目录相对路径
				String attachmentPath = UploadUtil.saveFile(attachment, this.uploadConfig.getBasePath(),
						this.uploadConfig.getColposcopeFolder() + sourceFolder, 0L, null);
		    	logger.info("请求"+reqId+"：附件接收完毕，名称【"+attachmentName+"】，地址【"+attachmentPath+"】");
				
		    	// 2.保存记录
				InterfaceData interfaceData = new InterfaceData();
				interfaceData.setAttachmentNames(attachmentName);
				interfaceData.setAttachmentPaths(attachmentPath);
				interfaceData.setCode(code);
				interfaceData.setDptCode(this.dpt.getValue());
				int count = interfaceDataBiz.insert(interfaceData);
				if(count > 0){
					logger.info("请求"+reqId+"：interfaceData数据保存成功");
				
					// 3.解压
					String descDir = zipAttachment(attachmentPath, this.uploadConfig.getColposcopeFolder());
					logger.info("请求"+reqId+"：数据解压成功");
				
					// 4.解析保存
					List<File> fileList = FileUtil.getAllFiles(new File(descDir));
					if(fileList!=null && fileList.size()>0){
						List<String> attachmentPathList = new ArrayList<String>();
						String basePath = this.uploadConfig.getBasePath()
								.replace("/", FileUtil.getFileSeparator())
								.replace("\\", FileUtil.getFileSeparator());
						for(File f : fileList){
							attachmentPathList.add(f.getAbsolutePath().replace(basePath, ""));
						}
						count = clinicarCheckResultBiz.insertByFileData(interfaceData, attachmentPathList);
						logger.info("请求"+reqId+"：数据解析成功，"+count+"条记录存储到检查结果表！");
					}
					message = "上传成功！";
					result.setSuccess(true);
				} else {
					logger.error("请求"+reqId+"：interfaceData数据保存失败");
					FileUtil.deleteByPath(this.uploadConfig.getBasePath() + attachmentPath);
				}
			} else {
				message = "无上传附件或上传附件大小为0。";
		    	logger.error("请求"+reqId+"：" + message);
			}
			
		} catch (IOException e) {
			message = e.getMessage();
	    	logger.error("请求"+reqId+"异常：" + message);
	    	
		} catch (Exception e) {
			message = e.getMessage();
	    	logger.error("请求"+reqId+"异常：" + message);
		}
		result.setMessage(message);
    	return result;
    }
}
