package com.sinotao.util;

import java.io.IOException;
import java.io.UnsupportedEncodingException;

import org.springframework.util.StringUtils;

import ca.uhn.hl7v2.HL7Exception;
import ca.uhn.hl7v2.model.v231.message.ACK;
import ca.uhn.hl7v2.model.v231.message.ORU_R01;
import ca.uhn.hl7v2.model.v231.segment.MSA;
import ca.uhn.hl7v2.model.v231.segment.MSH;
import ca.uhn.hl7v2.parser.PipeParser;
import ca.uhn.hl7v2.util.StringUtil;

public class Hl7Util {

	/**
	 * 处理字符串，生成Hl7消息对象
	 * 
	 * @param parser
	 * @param strMessage
	 * @param defaultCharset
	 * @return
	 * @throws HL7Exception
	 * @throws UnsupportedEncodingException
	 */
	public static ORU_R01 processMessage(String strMessage, byte[] bData, int bLen,
			String defaultCharset) throws HL7Exception, UnsupportedEncodingException {
		
		PipeParser parser = new PipeParser();
		ORU_R01 msg = (ORU_R01) parser.parse(strMessage);
		// 字符串编码方式
		if (StringUtil.isNotBlank(defaultCharset)) {
			if ("auto".equalsIgnoreCase(defaultCharset)) {
				String tmpCharset = msg.getMSH().getCharacterSet(0).getValue();
				strMessage = new String(bData, 0, bLen, tmpCharset);
			} else {
				strMessage = new String(bData, 0, bLen, defaultCharset);
			}
			msg = (ORU_R01) parser.parse(strMessage);
		}
		return msg;
	}

	/**
	 * 生成Hl7消息对应的响应对象的字节数组
	 * 
	 * @param message
	 * @return
	 * @throws IOException
	 * @throws HL7Exception
	 */
	public static byte[] getAckBytes(ORU_R01 msg) throws HL7Exception, IOException {

//		String msgId = msg.getMSH().getMsh10_MessageControlID().getValue();
		String date = DateUtil.getNowDateByFormat("yyyyMMddHHmmss");

		StringBuffer rst = new StringBuffer();
		ACK ack = (ACK) msg.generateACK();

		MSH msh = ack.getMSH();
		msh.getMsh7_DateTimeOfMessage().parse(date);
		// msh.getMsh10_MessageControlID().setValue(msgId);
		msh.getMsh16_ApplicationAcknowledgmentType().setValue("0");
		msh.getMsh18_CharacterSet(0).setValue("ASCII");
		// msh.getMsh20_AlternateCharacterSetHandlingScheme().setValue(" ");//必须要有空格，不然非必填的项目如果是空值，不会生成到字符串中
		rst.append(msh.encode().trim()).append("|||\r");

		MSA msa = ack.getMSA();
		String msa6 = msa.getMsa6_ErrorCondition().getCe1_Identifier()
				.getValue();
		if (StringUtils.isEmpty(msa6)) {
			msa.getMsa6_ErrorCondition().getCe1_Identifier().setValue("0");
		}
		rst.append(msa.encode().trim()).append("|\r");

		// 测试成功的返回数据
		// sb1.append("MSH|^~\\&|||||")
		// .append(DateUtil.getNowDateByFormat("yyyyMMddHHmmss"))
		// .append("||ACK^R01|1|P|2.3.1||||0||ASCII|||")
		// .append("\r")
		// .append("MSA|AA|1|Message accepted|||0|")
		// .append("\r");

		byte[] byteData = rst.toString().getBytes();
		int len = byteData.length;
		byte[] byteAck = new byte[3 + len];
		byteAck[0] = 0x0B;
		for (int i = 0; i < len; i++) {
			byteAck[i + 1] = byteData[i];
		}
		byteAck[len + 1] = 0x1C;
		byteAck[len + 2] = 0x0D;

		return byteAck;
	}
}
