package com.sinotao.business.dao.entity;

import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Table(name = "t_clinicar_check_result")
public class ClinicarCheckResult {

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
	 * 检查号
	 */
	@Column(name = "check_number")
	private String checkNumber;
	
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
	 * 明细项编号
	 */
	@Column(name = "item_detail_code")
	private String itemDetailCode;

	/**
	 * 明细项名称
	 */
	@Column(name = "item_detail_name")
	private String itemDetailName;

	/**
	 * 项目检查结果
	 */
	private String result;
	
	/**
	 * 项目单位
	 */
	private String unit;
	
	/**
	 * 结论
	 */
	private String conclusion;
	
	/**
	 * 附件地址
	 */
	@Column(name = "attachment_path")
	private String attachmentPath;
	
	/**
	 * 检验结果范围，形式如：“参考范围下限-参考范围上限”，或“<参考范围上限”，或“>参考范围下限”。
	 */
	@Column(name = "references_range")
	private String referencesRange;

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
	 * @return the checkNumber
	 */
	public String getCheckNumber() {
		return checkNumber;
	}

	/**
	 * @param checkNumber the checkNumber to set
	 */
	public void setCheckNumber(String checkNumber) {
		this.checkNumber = checkNumber;
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
	 * @return the itemDetailCode
	 */
	public String getItemDetailCode() {
		return itemDetailCode;
	}

	/**
	 * @param itemDetailCode the itemDetailCode to set
	 */
	public void setItemDetailCode(String itemDetailCode) {
		this.itemDetailCode = itemDetailCode;
	}

	/**
	 * @return the itemDetailName
	 */
	public String getItemDetailName() {
		return itemDetailName;
	}

	/**
	 * @param itemDetailName the itemDetailName to set
	 */
	public void setItemDetailName(String itemDetailName) {
		this.itemDetailName = itemDetailName;
	}

	/**
	 * @return the result
	 */
	public String getResult() {
		return result;
	}

	/**
	 * @param result the result to set
	 */
	public void setResult(String result) {
		this.result = result;
	}

	/**
	 * @return the unit
	 */
	public String getUnit() {
		return unit;
	}

	/**
	 * @param unit the unit to set
	 */
	public void setUnit(String unit) {
		this.unit = unit;
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
	 * @return the attachmentPath
	 */
	public String getAttachmentPath() {
		return attachmentPath;
	}

	/**
	 * @param attachmentPath the attachmentPath to set
	 */
	public void setAttachmentPath(String attachmentPath) {
		this.attachmentPath = attachmentPath;
	}

	/**
	 * @return the referencesRange
	 */
	public String getReferencesRange() {
		return referencesRange;
	}

	/**
	 * @param referencesRange the referencesRange to set
	 */
	public void setReferencesRange(String referencesRange) {
		this.referencesRange = referencesRange;
	}
}
