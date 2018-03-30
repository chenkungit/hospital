package com.sinotao.util.net;

import java.net.Socket;

public class SocketUtil {

	/**
	 * 判断是否远程连接断开，断开返回true,没有返回false
	 * @param socket
	 * @param b 测试连接状态的数据
	 * @return
	 */
	public static boolean isRemoteClose(Socket socket, int testData) {
		try {
			socket.sendUrgentData(testData);// 发送1个字节的紧急数据，默认情况下，服务器端没有开启紧急数据处理，不影响正常通信
			return false;
		} catch (Exception se) {
			return true;
		}
	}

	/**
	 * 判断是否远程连接断开，断开返回true,没有返回false
	 * @param socket
	 * @return
	 */
	public static boolean isRemoteClose(Socket socket) {
		return isRemoteClose(socket, 0xFF);
	}
}
