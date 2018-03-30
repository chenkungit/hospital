package com.sinotao.business.biz.bo;

import java.util.LinkedHashMap;

public class UrineBo {
	
	private String date;
	
	private String time;
	
	/**
	 * 样本号，这里是检查号的后4位
	 */
	private String code;
	
	private LinkedHashMap<String, String> dataMap;
	
	private String data;
	
	/**
	 * @return the date
	 */
	public String getDate() {
		return date;
	}

	/**
	 * @param date the date to set
	 */
	public void setDate(String date) {
		this.date = date;
	}

	/**
	 * @return the time
	 */
	public String getTime() {
		return time;
	}

	/**
	 * @param time the time to set
	 */
	public void setTime(String time) {
		this.time = time;
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
	 * @return the dataMap
	 */
	public LinkedHashMap<String, String> getDataMap() {
		return dataMap;
	}

	/**
	 * @param dataMap the dataMap to set
	 */
	public void setDataMap(LinkedHashMap<String, String> dataMap) {
		this.dataMap = dataMap;
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

	public static UrineBo createUrineBo(String strData){
		UrineBo bo = new UrineBo();
		bo.setData(strData);
		bo.setDataMap(new LinkedHashMap<String, String>());
		
		String sp_row = new String(new byte[]{0x0D, 0X0A});
		String sp_field = new String(new byte[]{0x09});
		
		String[] rows = strData.split(sp_row);
		for(int i=0; i<rows.length; i++){
			if(i == 0){
				bo.setDate(rows[i]);
			} else if(i == 1){
				bo.setTime(rows[i]);
			} else if(i == 2){
				bo.setCode(rows[i]);
			} else {
				if(rows[i].trim().length()>0){
					String[] fields = rows[i].split(sp_field);
					bo.getDataMap().put(fields[0], fields[1]);
				}
			}
		}
		
		return bo;
	}
}
