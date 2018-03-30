package com.sinotao.urine.util.sp.exception;

public class SerialPortOutputStreamCloseFailure extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = 6202003845655624950L;

	public SerialPortOutputStreamCloseFailure() {
    	super("关闭串口对象的输出流出错！");
    }
}