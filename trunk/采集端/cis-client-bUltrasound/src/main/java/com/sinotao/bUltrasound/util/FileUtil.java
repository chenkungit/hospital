package com.sinotao.bUltrasound.util;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.List;

public class FileUtil {
	
	/**
	 * 获得该文件及其下级所有子文件
	 * @param file
	 * @return
	 */
	public static void getAllFiles(File file, List<File> list) {
		try {
			// 判断文件是否是文件，如果是文件，获取路径，并计数
			if (file.isFile()) {
				list.add(file);
			} else {
				// 如果是文件夹，声明一个数组放文件夹和他的子文件
				File[] f = file.listFiles();
				// 遍历文件件下的文件，并获取路径
				for (File file2 : f) {
					getAllFiles(file2, list);
				}
			}
		} catch (RuntimeException e) {
			e.printStackTrace();
		}
	}

	// readFile方法用来读取文件filePath中的数据，并返回这个数据
	public static List<String> readFile(String filePath) {
		List<String> list = new ArrayList<String>();
		File file = new File(filePath);
		if(file.exists()){
			BufferedReader br = null;
			try {
				// 创建新的BufferedReader对象
				br = new BufferedReader(new FileReader(file));
				String data = null;
				// 读取一行数据并保存到data变量中
				while ((data = br.readLine()) != null) {
					list.add(data);
				}
	
			} catch (FileNotFoundException e) {
				System.out.println("读取文件错误 " + e.getMessage());
			} catch (IOException e) {
				System.out.println("读取文件错误 " + e.getMessage());
				
			} finally {
				if(br != null){
					try {
						br.close();
					} catch (IOException e) {
						System.out.println("读取文件错误 " + e.getMessage());
					}
				}
			}
		}
		return list;
	}

	public static boolean writeFile(String filePath, String data) {
		BufferedWriter bw = null;
		try {
			File file = new File(filePath);
			if(!file.exists()){
				if (!file.getParentFile().exists()) {
					if (!file.getParentFile().mkdirs()) {
						return false;
					}
				}
				if (!file.createNewFile()) { 
					return false; 
				}
			}
			bw = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file, true)));
			bw.write(data);
			bw.newLine();// 换行
			bw.flush();
			
		} catch (IOException e) {
			System.out.println("写入文件错误 " + e.getMessage());
		} finally{
			if(bw != null){
				try {
					bw.close();
				} catch (IOException e) {
					System.out.println("写入文件错误 " + e.getMessage());
				}
			}
		}
		return true;
	}

	public static void main(String[] args) {
		List<File> list = new ArrayList<File>();
		// TODO Auto-generated method stub
		File file = new File("D:\\WORK\\03_MYWORK\\05交大研究室\\07监督检查管理信息系统\\svn_182.92.167.67\\doc\\01需求");
		FileUtil.getAllFiles(file, list);
		System.out.println("文件个数为：" + list.size());
	}
}