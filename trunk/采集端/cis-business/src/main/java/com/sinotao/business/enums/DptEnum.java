package com.sinotao.business.enums;

/**
 * 检查设备
 * @author 佟磊
 */
public enum DptEnum implements ValueEnum<String> {
	/**
	 * X光
	 */
	XRAY("529", "X光"),
	/**
	 * 心电图
	 */
	HEART("540", "心电图"),
	/**
	 * B超
	 */
	BUTRA("510", "b超"),
	/**
	 * 阴道镜
	 */
	COLPOSCOPE("606", "电子阴道镜"),
	/**
	 * 尿分析仪
	 */
	URINE("605", "尿分析仪"),
	/**
	 * 血分析仪
	 */
	BLOOD("603", "血细胞分析仪"),
	/**
	 * 生化分析仪
	 */
	BIOC("604", "生化分析仪");

	DptEnum(String value, String name) {
		this.name = name;
		this.value = value;
	}
	
	private String name;
	
	private String value;
	
	public String getValue() {
		return value;
	}

	public String getName() {
		return name;
	}
}
