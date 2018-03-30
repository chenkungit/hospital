package com.sinotao.urine.util.sp.exception;

public class NotASerialPort extends Exception {

    /**
	 * 
	 */
	private static final long serialVersionUID = -6155742068136586878L;

	public NotASerialPort() {
    	super("不是串口！");
    }
}