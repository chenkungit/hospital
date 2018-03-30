package com.sinotao.urine.util.sp.exception;

public class SerialPortInputStreamCloseFailure extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = 5126647686576638114L;

	public SerialPortInputStreamCloseFailure() {
    	super("关闭串口对象输入流出错！");
    }
}