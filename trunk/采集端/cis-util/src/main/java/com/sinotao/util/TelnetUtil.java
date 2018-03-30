package com.sinotao.util;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.net.Socket;

public class TelnetUtil {
	
	public static boolean telnet(String ip, int port) throws IOException {
		boolean flag = false;
		Socket server = null;
		try {
			server = new Socket();
			InetSocketAddress address = new InetSocketAddress(ip, port);
			server.connect(address, 5000);
			flag = true;
			
		} finally {
			if (server != null)
				server.close();
		}
		return flag;
	}
	
	public static void main(String[] args) throws IOException{
		String ip = "182.50.8.68";
		int port = 7004;
		boolean b = TelnetUtil.telnet(ip, port);
		System.out.println("=="+b);
	}
}
