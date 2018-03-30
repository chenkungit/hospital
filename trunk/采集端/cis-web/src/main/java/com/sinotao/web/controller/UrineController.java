package com.sinotao.web.controller;

import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

import com.sinotao.business.biz.ClinicarCheckResultBiz;
import com.sinotao.business.biz.InterfaceDataBiz;
import com.sinotao.business.biz.bo.UrineBo;
import com.sinotao.util.DateUtil;
import com.sinotao.util.dto.ResultDTO;

/**
 * <b>功能描述：尿液分析仪Controller
 * 
 * @version V1.0.0
 * @author 佟磊
 */ 
@Controller
@RequestMapping("/urine/") 
public class UrineController extends BaseDeviceController{
	
	private final static Logger logger= LoggerFactory.getLogger(UrineController.class);

	@Autowired
    private InterfaceDataBiz interfaceDataBiz;
	
	@Autowired
    private ClinicarCheckResultBiz clinicarCheckResultBiz;

	/**
	 * 功能描述: 接收数据
     * @return ModelAndView
	 * @author 佟磊
     */
    @RequestMapping("receiveData")
    @ResponseBody
    public ResultDTO receiveData(HttpServletRequest request, @RequestParam("data") String strData){
    	ResultDTO result = new ResultDTO();
    	String reqId = "urine-"+DateUtil.getNowByFormat("yyyyMMddHHmmss");
    	logger.info("收到请求" + reqId + "：上传数据=" + strData);
    	
    	UrineBo bo = UrineBo.createUrineBo(strData);
    	int count = this.clinicarCheckResultBiz.insertUrineData(bo);
    	if(count > 0){
        	logger.info("收到请求" + reqId + "：数据解析成功。");
    	} else {
        	logger.info("收到请求" + reqId + "：数据解析失败！");
        }
		result.setSuccess(true);
		result.setMessage("上传成功！");
    	return result;
    }
}
