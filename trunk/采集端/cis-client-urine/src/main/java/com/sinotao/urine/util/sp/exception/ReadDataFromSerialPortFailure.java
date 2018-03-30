package com.sinotao.urine.util.sp.exception;

public class ReadDataFromSerialPortFailure extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = 5756945174292393808L;

	public ReadDataFromSerialPortFailure() {
    	super("从串口读取数据时出错！");
    }
}