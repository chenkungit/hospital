package com.sinotao.util;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.Random;

import org.apache.commons.lang3.StringUtils;
import org.springframework.web.multipart.MultipartFile;

public class UploadUtil {

	/**
	 * 
	 * @param file
	 * @param maxSize
	 *            上传文件大小上限(Byte)
	 * @return
	 * @throws Exception
	 */
	public static String saveFile(MultipartFile file, String baseDir,
			String basePath, Long maxSize, String[] suffix) throws Exception {
		String saveUrl = null;
		if (file != null && file.getSize() > 0) {
			if (baseDir == null || baseDir.trim().length() == 0) {
				throw new Exception("未设置上传文件保存的物理地址。");
			} else if (maxSize > 0 && file.getSize() > maxSize) {
				throw new Exception("上传文件大小超过限制。");
			} else {
				// 得到文件名
				String filename = file.getOriginalFilename();
				String fileExt = filename.substring(
						filename.lastIndexOf(".") + 1).toLowerCase();

				if (suffix != null && suffix.length > 0
						&& !Arrays.asList(suffix).contains(fileExt)) {
					throw new Exception("上传文件扩展名是不允许的扩展名。\n只允许["
							+ StringUtils.join(suffix, ",") + "]格式。");
				}

				if (!basePath.startsWith("/") && !basePath.startsWith("\\"))
					basePath = "/" + basePath;
				if (!basePath.endsWith("/") && !basePath.endsWith("\\"))
					basePath = basePath + "/";
				basePath += new SimpleDateFormat("yyyyMMdd").format(new Date())
						+ "/";
				File dirFile = new File(baseDir + basePath);
				if (!dirFile.exists()) {
					dirFile.mkdirs();
				}

				SimpleDateFormat df = new SimpleDateFormat("yyyyMMddHHmmss");
				String newFileName = df.format(new Date()) + "_"
						+ new Random().nextInt(1000) + "." + fileExt;

				file.transferTo(new File(dirFile.getPath() + "/" + newFileName));
				// SaveFileFromInputStream(file.getInputStream(), saveBasePath +
				// path, newFileName);
				saveUrl = basePath + newFileName;
			}
		} else {
			throw new Exception("上传文件不能为空");
		}
		return saveUrl;
	}

	public static void SaveFileFromInputStream(InputStream stream, String path,
			String filename) throws IOException {

		FileOutputStream fs = new FileOutputStream(path + "/" + filename);
		byte[] buffer = new byte[1024 * 1024];
		@SuppressWarnings("unused")
		int bytesum = 0;
		int byteread = 0;
		while ((byteread = stream.read(buffer)) != -1) {
			bytesum += byteread;
			fs.write(buffer, 0, byteread);
			fs.flush();
		}
		fs.close();
		stream.close();
	}

}
