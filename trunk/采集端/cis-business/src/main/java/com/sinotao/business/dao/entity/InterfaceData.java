package com.sinotao.business.dao.entity;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import org.springframework.format.annotation.DateTimeFormat;

@Table(name = "t_interface_data")
public class InterfaceData {

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
	private String code;
	
	/**
	 * 科室代码
	 */
	@Column(name = "device_code")
	private String dptCode;
	
	/**
	 * 接收时间
	 */
	@Column(name = "receipt_time")
    @DateTimeFormat(pattern="yyyy-MM-dd HH:mm:ss")
	private Date receiptTime;
	
	/**
	 * 接收的数据
	 */
	private String data;
	
	/**
	 * 附件名称（多个英文逗号隔开）
	 */
	@Column(name = "attachment_names")
	private String attachmentNames;

	/**
	 * 附件地址（多个英文逗号隔开）
	 */
	@Column(name = "attachment_paths")
	private String attachmentPaths;
	
	/**
	 * 是否已经解析
	 */
	private Boolean analyzed;

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
	 * @return the receiptTime
	 */
	public Date getReceiptTime() {
		return receiptTime;
	}

	/**
	 * @param receiptTime the receiptTime to set
	 */
	public void setReceiptTime(Date receiptTime) {
		this.receiptTime = receiptTime;
	}

	/**
	 * @return the data
	 */
	public String getData() {
		return data;
	}

	/**
	 * @param data the data to set
	 */
	public void setData(String data) {
		this.data = data;
	}

	/**
	 * @return the attachmentNames
	 */
	public String getAttachmentNames() {
		return attachmentNames;
	}

	/**
	 * @param attachmentNames the attachmentNames to set
	 */
	public void setAttachmentNames(String attachmentNames) {
		this.attachmentNames = attachmentNames;
	}

	/**
	 * @return the attachmentPaths
	 */
	public String getAttachmentPaths() {
		return attachmentPaths;
	}

	/**
	 * @param attachmentPaths the attachmentPaths to set
	 */
	public void setAttachmentPaths(String attachmentPaths) {
		this.attachmentPaths = attachmentPaths;
	}

	/**
	 * @return the analyzed
	 */
	public Boolean getAnalyzed() {
		return analyzed;
	}

	/**
	 * @param analyzed the analyzed to set
	 */
	public void setAnalyzed(Boolean analyzed) {
		this.analyzed = analyzed;
	}
}
