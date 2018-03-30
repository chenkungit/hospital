package com.sinotao.business.dao.entity;

import javax.persistence.Column;
import javax.persistence.Id;
import javax.persistence.Table;

@Table(name = "t_clinicar_item")
public class ClinicarItem {

	/**
	 * 检查项目编号
	 */
	@Id
	private String code;
	
	/**
	 * 检查项目名称
	 */
	private String name;
	
	/**
	 * 是否启用
	 */
	private Boolean enabled;
	
	/**
	 * 科室编号
	 */
	@Column(name = "dpt_code")
	private String dptCode;
	
	/**
	 * 科室
	 */
	@Column(name = "dpt_name")
	private String dptName;

	/**
	 * 备注
	 */
	private String remark;
	
	/**
	 * 检查设备编号，用于接口对接
	 */
	@Column(name = "device_code")
	private String deviceCode;

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
	 * @return the enabled
	 */
	public Boolean getEnabled() {
		return enabled;
	}

	/**
	 * @param enabled the enabled to set
	 */
	public void setEnabled(Boolean enabled) {
		this.enabled = enabled;
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
	 * @return the remark
	 */
	public String getRemark() {
		return remark;
	}

	/**
	 * @param remark the remark to set
	 */
	public void setRemark(String remark) {
		this.remark = remark;
	}

	/**
	 * @return the deviceCode
	 */
	public String getDeviceCode() {
		return deviceCode;
	}

	/**
	 * @param deviceCode the deviceCode to set
	 */
	public void setDeviceCode(String deviceCode) {
		this.deviceCode = deviceCode;
	}
}
