package com.sinotao.bioc;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;
import java.util.Timer;
import java.util.TimerTask;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import ca.uhn.hl7v2.model.v231.group.ORU_R01_ORCOBRNTEOBXNTECTI;
import ca.uhn.hl7v2.model.v231.message.ORU_R01;
import ca.uhn.hl7v2.model.v231.segment.OBX;

import com.sinotao.business.biz.ClinicarCheckResultBiz;
import com.sinotao.business.dao.entity.ClinicarCheckResult;
import com.sinotao.util.DateUtil;

public class MyTask {

	private final Logger logger = LoggerFactory.getLogger(MyTask.class);

	private int taskPeriod = 1;
	private Timer timer;
	private ClinicarCheckResultBiz clinicarCheckResultBiz;

	/**
	 * 队列
	 */
	private Queue<ORU_R01> data2upload = new LinkedList<ORU_R01>();
	public void addData(ORU_R01 data){
		data2upload.offer(data);
	}
	
	public MyTask(int _taskPeriod){
		this.taskPeriod = _taskPeriod;
		this.timer = new Timer();
		this.clinicarCheckResultBiz = (ClinicarCheckResultBiz)com.sinotao.Main.getSpringBean("clinicarCheckResultBiz");
	}
	
	public void start(){
		this.timer.schedule(new TimerTask() {
			@Override
			public void run() {
				upload();
			}
		}, 0, this.taskPeriod*1000);
	}
	
	public void stop(){
		this.timer.cancel();
	}

	
	private void upload(){
		//如果有队列里有数据，开始上传
		while(this.data2upload.size()>0){
			String taskId = "bioc_" + DateUtil.getNowByFormat("yyyyMMddHHmmss");
			logger.info("【任务"+taskId+"】开始！");
			
			ORU_R01 msg = this.data2upload.poll();
			logger.info("【任务"+taskId+"】数据：" + msg.toString());
			ORU_R01_ORCOBRNTEOBXNTECTI m1 = msg.getPIDPD1NK1NTEPV1PV2ORCOBRNTEOBXNTECTI().getORCOBRNTEOBXNTECTI();
			
			String checkNumber = m1.getOBR().getObr2_PlacerOrderNumber().getEi1_EntityIdentifier().getValue();
			logger.info("【任务"+taskId+"】检查号：" + checkNumber);
			List<ClinicarCheckResult> ccrList = new ArrayList<ClinicarCheckResult>();
			for(int i=0; i<m1.getOBXNTEReps(); i++){
				OBX obx = m1.getOBXNTE(i).getOBX();
				String itemDetailCode = obx.getObx4_ObservationSubID().getValue();
				String result = obx.getObx5_ObservationValue(0).getData().toString();
				String units = obx.getObx6_Units().getCe1_Identifier().getValue();
				String referencesRange = obx.getObx7_ReferencesRange().getValue();
				String conclusion = obx.getObx8_AbnormalFlags(0).getValue();
				logger.info("【任务"+taskId+"】明细项"+i
						+"：代码=" + itemDetailCode
						+"，结果值=" + result
						+"，单位=" + units
						+"，范围=" + referencesRange
						+"，结论=" + conclusion);
						
				ClinicarCheckResult ccr = new ClinicarCheckResult();
				ccr.setItemDetailCode(itemDetailCode);
				ccr.setItemDetailName(itemDetailCode);
				ccr.setResult(result);
				ccr.setUnit(units);
				ccr.setReferencesRange(referencesRange);
				ccr.setConclusion(conclusion);
				ccrList.add(ccr);
			}
			this.clinicarCheckResultBiz.insertBiocData(checkNumber, msg.toString(), ccrList);
			
			logger.info("【任务"+taskId+"】结束！");
		}
	}
}
