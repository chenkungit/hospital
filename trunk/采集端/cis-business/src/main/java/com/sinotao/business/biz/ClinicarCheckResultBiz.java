package com.sinotao.business.biz;

import java.util.List;
import java.util.Map;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.sinotao.business.biz.bo.UrineBo;
import com.sinotao.business.dao.ClinicarCheckDao;
import com.sinotao.business.dao.ClinicarCheckItemDao;
import com.sinotao.business.dao.ClinicarCheckResultDao;
import com.sinotao.business.dao.ClinicarItemDao;
import com.sinotao.business.dao.ClinicarItemDetailDao;
import com.sinotao.business.dao.InterfaceDataDao;
import com.sinotao.business.dao.entity.ClinicarCheck;
import com.sinotao.business.dao.entity.ClinicarCheckItem;
import com.sinotao.business.dao.entity.ClinicarCheckResult;
import com.sinotao.business.dao.entity.ClinicarItemDetail;
import com.sinotao.business.dao.entity.InterfaceData;
import com.sinotao.business.enums.DptEnum;

@Service
public class ClinicarCheckResultBiz {

	private final static Logger logger = LoggerFactory.getLogger(ClinicarCheckResultBiz.class);

	@Autowired
	private ClinicarCheckDao clinicarCheckDao;
	
	@Autowired
	private ClinicarCheckItemDao clinicarCheckItemDao;

	@Autowired
	private ClinicarCheckResultDao clinicarCheckResultDao;

	@Autowired
	private InterfaceDataDao interfaceDataDao;

	@Autowired
	private ClinicarItemDao clinicarItemDao;

	@Autowired
	private ClinicarItemDetailDao clinicarItemDetailDao;
	
	/**
     * 新增文件类的检查结果数据
     * @param clinicarCheckResult
     * @return
     */
	@Transactional
	public int insertByFileData(InterfaceData interfaceData, List<String> attachmentPathList){
		int count = 0;

		//按照科室code和检查号，查询检查项目
		List<ClinicarCheckItem> clinicarCheckItemList = this.clinicarCheckItemDao.selectByCheckNumberAndDptCode(
				interfaceData.getCode(), interfaceData.getDptCode());
			
		if(clinicarCheckItemList!=null && clinicarCheckItemList.size()>0){
			ClinicarCheckItem clinicarCheckItem = clinicarCheckItemList.get(0);
			logger.info("有"+clinicarCheckItemList.size()+"条【检查号="+interfaceData.getCode()+"，科室号="+interfaceData.getDptCode()+"】"
					+ "的检查项目信息，取第一条【ClinicarCheckItem.id="+clinicarCheckItem.getId()+"】");
			
			// 循环插入
			for(String attachmentPath : attachmentPathList){
				ClinicarCheckResult ccr = new ClinicarCheckResult();
				ccr.setCheckNumber(interfaceData.getCode());
				ccr.setAttachmentPath(attachmentPath);
				ccr.setItemCode(clinicarCheckItem.getItemCode());
				ccr.setItemName(clinicarCheckItem.getItemName());
				count += this.clinicarCheckResultDao.insertSelective(ccr);
			}
			
			// 更新原始数据的解析状态
			if(count > 0){
				InterfaceData record = new InterfaceData();
				record.setId(interfaceData.getId());
				record.setAnalyzed(true);
				this.interfaceDataDao.updateByPrimaryKeySelective(record);
				
				//设置该项检查完成
//				clinicarCheckItem.setCompleted(true);
//				this.clinicarCheckItemDao.updateByPrimaryKeySelective(clinicarCheckItem);
			}
		} else {
			logger.error("不存在【检查号="+interfaceData.getCode()+"，科室号="+interfaceData.getDptCode()+"】"
					+ "的检查项目信息，无法解析检查结果数据【InterfaceData.id="+interfaceData.getId()+"】");
		}
		
		return count;
	}
	
	/**
	 * 插入尿液分析仪数据
	 * @param urineData
	 */
	@Transactional
	public int insertUrineData(UrineBo urineBo){
		int count = 0;
		
		//1、插入原始数据
		InterfaceData interfaceData = new InterfaceData();
		interfaceData.setCode(urineBo.getCode());
		interfaceData.setDptCode(DptEnum.URINE.getValue());
		interfaceData.setData(urineBo.getData());
		count = this.interfaceDataDao.insertSelective(interfaceData);
		
		//解析并插入检查结果
		if(count > 0){
			count = 0;
			//2、查询最后一个未完成的登记检查项
			Integer checkItemId = this.clinicarCheckResultDao.selectLastCheckItemId(urineBo.getCode(), interfaceData.getDptCode());
			
			if(checkItemId!=null && checkItemId>0){
				ClinicarCheckItem clinicarCheckItem = this.clinicarCheckItemDao.selectByPrimaryKey(checkItemId);
				ClinicarCheck clinicarCheck = this.clinicarCheckDao.selectByPrimaryKey(clinicarCheckItem.getCheckId());

				//3、查询对应的明细项
				ClinicarItemDetail record2 = new ClinicarItemDetail();
				record2.setItemCode(clinicarCheckItem.getItemCode());
				List<ClinicarItemDetail> itemDetailList = this.clinicarItemDetailDao.select(record2);
				
				//4、循环插入检查结果
				for(Map.Entry<String, String> kv : urineBo.getDataMap().entrySet()){
					ClinicarCheckResult ccr = new ClinicarCheckResult();
					ccr.setCheckNumber(clinicarCheck.getCheckNumber());
					ccr.setItemCode(clinicarCheckItem.getItemCode());
					ccr.setItemName(clinicarCheckItem.getItemName());
					ccr.setItemDetailCode(kv.getKey().trim());
					ccr.setItemDetailName(kv.getKey().trim());
					ccr.setResult(kv.getValue());
					
					if(itemDetailList!=null && itemDetailList.size()>0){
						for(ClinicarItemDetail detail : itemDetailList){
							if(detail.getCode().equalsIgnoreCase(kv.getKey().trim())){
								ccr.setItemDetailName(detail.getName());
								break;
							}
						}
					}
					count += this.clinicarCheckResultDao.insertSelective(ccr);
				}
				
				if(count > 0){
					//5、更新原始数据的解析状态
					InterfaceData record = new InterfaceData();
					record.setId(interfaceData.getId());
					record.setAnalyzed(true);
					this.interfaceDataDao.updateByPrimaryKeySelective(record);
					
					//6、设置该项检查完成
//					clinicarCheckItem.setCompleted(true);
//					this.clinicarCheckItemDao.updateByPrimaryKeySelective(clinicarCheckItem);
				}
			}
		}
		return count;
	}

	/**
	 * 插入生化分析仪数据
	 * @param urineData
	 */
	@Transactional
	public int insertBiocData(String checkNumber, String strData, List<ClinicarCheckResult> ccrList){
		InterfaceData interfaceData = new InterfaceData();
		interfaceData.setCode(checkNumber);
		interfaceData.setDptCode(DptEnum.BIOC.getValue());
		interfaceData.setData(strData);
		return this.insertHl7Data(interfaceData, ccrList);
	}

	/**
	 * 插入血细胞分析仪数据
	 * @param urineData
	 */
	@Transactional
	public int insertBloodData(String checkNumber, String strData, List<ClinicarCheckResult> ccrList){
		InterfaceData interfaceData = new InterfaceData();
		interfaceData.setCode(checkNumber);
		interfaceData.setDptCode(DptEnum.BLOOD.getValue());
		interfaceData.setData(strData);
		return this.insertHl7Data(interfaceData, ccrList);
	}

	/**
	 * 插入Hl7数据
	 * @param urineData
	 */
	@Transactional
	public int insertHl7Data(InterfaceData interfaceData, List<ClinicarCheckResult> ccrList){
		int count = 0;
		
		//1、插入原始数据
		count = this.interfaceDataDao.insertSelective(interfaceData);

		//解析并插入检查结果
		if(count > 0){
			count = 0;
			//按照科室code和检查号，查询检查项目
			List<ClinicarCheckItem> clinicarCheckItemList = this.clinicarCheckItemDao.selectByCheckNumberAndDptCode(
					interfaceData.getCode(), interfaceData.getDptCode());
			
			if(clinicarCheckItemList!=null && clinicarCheckItemList.size()>0){
				ClinicarCheckItem clinicarCheckItem = clinicarCheckItemList.get(0);//业务上控制每个登记有且只有1条对应的生化检查项目
				logger.info("有"+clinicarCheckItemList.size()+"条【检查号="+interfaceData.getCode()+"，科室号="+interfaceData.getDptCode()+"】"
						+ "的检查项目信息，取第一条【ClinicarCheckItem.id="+clinicarCheckItem.getId()+"】");
				
				//查询对应的明细项
				ClinicarItemDetail record2 = new ClinicarItemDetail();
				record2.setItemCode(clinicarCheckItem.getItemCode());
				List<ClinicarItemDetail> itemDetailList = this.clinicarItemDetailDao.select(record2);
				
				// 循环插入
				for(ClinicarCheckResult ccr : ccrList){
					ccr.setCheckNumber(interfaceData.getCode());
					ccr.setItemCode(clinicarCheckItem.getItemCode());
					ccr.setItemName(clinicarCheckItem.getItemName());
					
//					“N”- 正常
//					“A”- 非正常
//					“H”- 结果高于参考范围上限
//					“L”– 结果低于参考范围下限
					if("N".equals(ccr.getConclusion())){
						ccr.setConclusion("正常");
					} else if("A".equals(ccr.getConclusion())){
						ccr.setConclusion("非正常");
					} else if("H".equals(ccr.getConclusion())){
						ccr.setConclusion("结果高于参考范围上限");
					} else if("L".equals(ccr.getConclusion())){
						ccr.setConclusion("结果低于参考范围下限");
					} else if(ccr.getConclusion()!=null && ccr.getConclusion().split("~").length==2){
						String[] arr = ccr.getConclusion().split("~");
						if(("A".equals(arr[0]) && "H".equals(arr[1])) || ("A".equals(arr[1]) && "H".equals(arr[0]))){
							ccr.setConclusion("非正常，且结果高于参考范围上限");
						} else if(("A".equals(arr[0]) && "L".equals(arr[1])) || ("A".equals(arr[1]) && "L".equals(arr[0]))){
							ccr.setConclusion("非正常，且结果低于参考范围下限");
						}
					}
					
					count += this.clinicarCheckResultDao.insertSelective(ccr);
					
					if(itemDetailList!=null && itemDetailList.size()>0){
						for(ClinicarItemDetail detail : itemDetailList){
							if(detail.getCode().equalsIgnoreCase(ccr.getItemDetailCode().trim())){
								ccr.setItemDetailName(detail.getName());
								break;
							}
						}
					}
				}
				
				// 更新原始数据的解析状态
				if(count > 0){
					InterfaceData record = new InterfaceData();
					record.setId(interfaceData.getId());
					record.setAnalyzed(true);
					this.interfaceDataDao.updateByPrimaryKeySelective(record);
					
					//设置该项检查完成
//					clinicarCheckItem.setCompleted(true);
//					this.clinicarCheckItemDao.updateByPrimaryKeySelective(clinicarCheckItem);
				}
			} else {
				logger.error("不存在【检查号="+interfaceData.getCode()+"，科室号="+interfaceData.getDptCode()+"】"
						+ "的检查项目信息，无法解析检查结果数据【InterfaceData.id="+interfaceData.getId()+"】");
			}
		}
		return count;
	}
}
