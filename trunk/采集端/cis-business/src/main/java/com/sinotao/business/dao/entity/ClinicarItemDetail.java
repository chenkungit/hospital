package com.sinotao.business.dao.entity;

import javax.persistence.Column;
import javax.persistence.Id;
import javax.persistence.Table;

@Table(name = "t_clinicar_item_detail")
public class ClinicarItemDetail {

	/**
	 * 具体检查项目代码
	 */
	@Id
	private String code;
	
	/**
	 * 具体检查项目名称
	 */
	private String name;
	
	/**
	 * 检查项目代码
	 */
	@Column(name = "item_code")
	private String itemCode;
	
	/**
	 * 单位
	 */
	private String unit;

	/**
	 * @return the code
	 */
	public String getCode() {
		return code;
	}

	/**
	 * @param code the code to set
	 */
	public void setCode(String code) {
		this.code = code;
	}

	/**
	 * @return the name
	 */
	public String getName() {
		return name;
	}

	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		this.name = name;
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
}
