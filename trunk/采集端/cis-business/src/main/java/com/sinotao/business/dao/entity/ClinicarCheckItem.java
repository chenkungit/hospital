package com.sinotao.business.dao.entity;

import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * 检查项目信息表
 * @author 佟磊
 */
@Table(name = "t_clinicar_check_item")
public class ClinicarCheckItem {

	/**
	 * 代理主键
	 */
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Integer id;
	
	/**
	 * 删除标记
	 */
	private Boolean deleted;
	
	/**
	 * 登记表ID
	 */
	@Column(name = "check_id")
	private Integer checkId;
	
	/**
	 * 检查项目编号
	 */
	@Column(name = "item_code")
	private String itemCode;
	
	/**
	 * 检查项目名称
	 */
	@Column(name = "item_name")
	private String itemName;

	/**
	 * 科室编号
	 */
	@Column(name = "dpt_code")
	private String dptCode;

	/**
	 * 科室名称
	 */
	@Column(name = "dpt_name")
	private String dptName;
	
	/**
	 * 该项检查是否完成
	 */
	private Boolean completed;
	
	/**
	 * 弃检
	 */
	private Boolean canceled;

	/**
	 * 小结
	 */
	private String summary;
	
	/**
	 * 结论
	 */
	private String conclusion;
	
	/**
	 * 建议
	 */
	private String advice;

	/**
	 * @return the id
	 */
	public Integer getId() {
		return id;
	}

	/**
	 * @param id the id to set
	 */
	public void setId(Integer id) {
		this.id = id;
	}

	/**
	 * @return the deleted
	 */
	public Boolean getDeleted() {
		return deleted;
	}

	/**
	 * @param deleted the deleted to set
	 */
	public void setDeleted(Boolean deleted) {
		this.deleted = deleted;
	}

	/**
	 * @return the checkId
	 */
	public Integer getCheckId() {
		return checkId;
	}

	/**
	 * @param checkId the checkId to set
	 */
	public void setCheckId(Integer checkId) {
		this.checkId = checkId;
	}

	/**
	 * @return the itemCode
	 */
	public String getItemCode() {
		return itemCode;
	}

	/**
	 * @param itemCode the itemCode to set
	 */
	public void setItemCode(String itemCode) {
		this.itemCode = itemCode;
	}

	/**
	 * @return the itemName
	 */
	public String getItemName() {
		return itemName;
	}

	/**
	 * @param itemName the itemName to set
	 */
	public void setItemName(String itemName) {
		this.itemName = itemName;
	}

	/**
	 * @return the dptCode
	 */
	public String getDptCode() {
		return dptCode;
	}

	/**
	 * @param dptCode the dptCode to set
	 */
	public void setDptCode(String dptCode) {
		this.dptCode = dptCode;
	}

	/**
	 * @return the dptName
	 */
	public String getDptName() {
		return dptName;
	}

	/**
	 * @param dptName the dptName to set
	 */
	public void setDptName(String dptName) {
		this.dptName = dptName;
	}

	/**
	 * @return the completed
	 */
	public Boolean getCompleted() {
		return completed;
	}

	/**
	 * @param completed the completed to set
	 */
	public void setCompleted(Boolean completed) {
		this.completed = completed;
	}

	/**
	 * @return the canceled
	 */
	public Boolean getCanceled() {
		return canceled;
	}

	/**
	 * @param canceled the canceled to set
	 */
	public void setCanceled(Boolean canceled) {
		this.canceled = canceled;
	}

	/**
	 * @return the summary
	 */
	public String getSummary() {
		return summary;
	}

	/**
	 * @param summary the summary to set
	 */
	public void setSummary(String summary) {
		this.summary = summary;
	}

	/**
	 * @return the conclusion
	 */
	public String getConclusion() {
		return conclusion;
	}

	/**
	 * @param conclusion the conclusion to set
	 */
	public void setConclusion(String conclusion) {
		this.conclusion = conclusion;
	}

	/**
	 * @return the advice
	 */
	public String getAdvice() {
		return advice;
	}

	/**
	 * @param advice the advice to set
	 */
	public void setAdvice(String advice) {
		this.advice = advice;
	}
}
