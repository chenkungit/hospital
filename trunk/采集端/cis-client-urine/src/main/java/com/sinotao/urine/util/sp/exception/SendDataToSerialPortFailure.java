package com.sinotao.urine.util.sp.exception;

public class SendDataToSerialPortFailure extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = -9122762850844055029L;

	public SendDataToSerialPortFailure() {
    	super("向串口发送数据失败！");
    }
}