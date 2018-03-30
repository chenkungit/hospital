package com.sinotao.util;

import java.text.ParseException;
import java.text.ParsePosition;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

/**
 * 
 * 时间工具类<br>
 * 
 * @author wangkaining
 * @see [相关类/方法]（可选）
 * @since [产品/模块版本] （可选）
 */
public class DateUtil {
	/**
	 * 根据格式，获得当前系统时间
	 * @return
	 */
	public static String getNowByFormat(String format) {
		Date date = new Date();
		SimpleDateFormat sdf = new SimpleDateFormat(format);
		return sdf.format(date);
	}

	/**
	 * 获得当前系统日期
	 * @return
	 */
	public static String getNowDate() {
		return DateUtil.getNowByFormat("yyyy-MM-dd");
	}

	/**
	 * 获得当前系统时间
	 * @return
	 */
	public static String getNowDatetime() {
		return DateUtil.getNowByFormat("yyyy-MM-dd HH:mm:ss");
	}

	/**
	 * 
	 * 功能描述: 比较日期<br>
	 *
	 * @autor wangkaining
	 * @param format
	 * @return
	 * @throws ParseException
	 * @see [相关类/方法](可选)
	 * @since [产品/模块版本](可选)
	 */
	public static Date compareDate(String date) throws ParseException {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		Date result = sdf.parse(date);
		return result;
	}

	/**
	 * 获取几天之后的日期
	 * 
	 * @param day
	 * @return
	 */
	public static Date getAfterDays(int day) {
		Calendar c = Calendar.getInstance();
		c.setTime(new Date());
		c.add(Calendar.DAY_OF_YEAR, day);
		return c.getTime();
	}

	public static Date parse(String date, String pattern) {
		SimpleDateFormat format = new SimpleDateFormat(pattern);
		ParsePosition pos = new ParsePosition(0);
		return format.parse(date, pos);
	}

	public static Date parse(String date) {
		SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
		ParsePosition pos = new ParsePosition(0);
		return format.parse(date, pos);
	}

	/**
	 * 返回固定日期格式：yyyyMMddHHmmssSSS
	 * 
	 * @return
	 */
	public static String getFileDatetime() {
		Date date = new Date();
		SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmssSSS");
		return sdf.format(date);
	}

	public static String getNowDateByFormat(String format) {
		Date date = new Date();
		SimpleDateFormat sdf = new SimpleDateFormat(format);
		return sdf.format(date);
	}

	/**
	 * 格式化日期
	 * 
	 * @param date
	 *            需要格式化的日期
	 * @param format
	 *            格式,eg：yyyy-MM-dd
	 * @return 格式化之后的日期
	 */
	public static String formatDateToString(Date date, String format) {
		if (format == null) {
			format = "yyyy-MM-dd";
		}
		if (date == null) {
			date = new Date();
		}
		SimpleDateFormat sdf = new SimpleDateFormat(format, Locale.ENGLISH);
		return sdf.format(date);
	}

	/**
	 * 获取某年某月多少天
	 * 
	 * @param month
	 * @param year
	 * @return
	 */
	public static int countMonthDays(int month, int year) {
		int count = -1;
		switch (month) {
		case 1:
		case 3:
		case 5:
		case 7:
		case 8:
		case 10:
		case 12:
			count = 31;
			break;
		case 4:
		case 6:
		case 9:
		case 11:
			count = 30;
			break;
		case 2:
			if (year % 4 == 0)
				count = 29;
			else
				count = 28;
			if ((year % 100 == 0) & (year % 400 != 0))
				count = 28;
		}
		return count;
	}

	/*
	 * 根据当前日期和出生日期得到年龄
	 */
	public static String getAge(String birthDay) {
		String age = "00";
		if (birthDay != null && !birthDay.equals("")) {
			String nowDate = getNowDate();
			age = String.valueOf(Integer.valueOf(nowDate.substring(0, 4))
					- Integer.valueOf(birthDay.substring(0, 4)));
		}
		return age;
	}

	/**
	 * 返回毫秒
	 * 
	 * @param date
	 *            日期
	 * @return 返回毫秒
	 */
	public static long getMillis(java.util.Date date) {
		java.util.Calendar c = java.util.Calendar.getInstance();
		c.setTime(date);
		return c.getTimeInMillis();
	}

	/**
	 * 日期减去分钟
	 * 
	 * @param date
	 *            日期
	 * @param minutes
	 *            分钟
	 * @return 返回相减后的日期
	 */
	public static String minusDateByMinutes(Date date, String format,
			Long minutes) {
		if (format == null) {
			format = "yyyy-MM-dd";
		}
		java.util.Calendar c = java.util.Calendar.getInstance();
		c.setTimeInMillis(getMillis(date) - minutes * 60 * 1000);
		return formatDateToString(c.getTime(), format);
	}

	/**
	 * 日期减去分钟
	 * 
	 * @param date
	 * @param format
	 * @param minutes
	 * @return
	 */
	public static Date minusDateByMinutes(Date date, Long minutes) {
		java.util.Calendar c = java.util.Calendar.getInstance();
		c.setTimeInMillis(getMillis(date) - minutes * 60 * 1000);
		return c.getTime();
	}

	/**
	 * 日期减去小时
	 * 
	 * @param date
	 *            日期
	 * @param hours
	 *            小时
	 * @return 返回相减后的日期
	 */
	public static String minusDateByHours(Date date, String format, Long hours) {
		return minusDateByMinutes(date, format, hours * 60);
	}

	/**
	 * 日期减去小时
	 * 
	 * @param date
	 * @param hours
	 * @return
	 */
	public static Date minusDateByHours(Date date, Long hours) {
		return minusDateByMinutes(date, hours * 60);
	}

	/**
	 * 日期减去天数
	 * 
	 * @param date
	 *            日期
	 * @param days
	 *            天数
	 * @return 返回相减后的日期
	 */
	public static String minusDateByDays(Date date, String format, Long days) {
		return minusDateByHours(date, format, days * 24);
	}

	/**
	 * 日期减去指定天数
	 * 
	 * @param date
	 * @param days
	 * @return
	 */
	public static Date minusDateByDays(Date date, Long days) {
		return minusDateByHours(date, days * 24);
	}

	/**
	 * 根据日期,月份中的周次,具体周几计算出周几的具体日期
	 * 
	 * @param yearMonth
	 *            yyyy-MM
	 * @param weekCount
	 *            本月中的第几个周次
	 * @param week
	 *            具体的周几
	 * @return yyyy-MM-dd 具体日期
	 */
	public static String findStrDateByYearMonthDayWeek(String yearMonth,
			String weekCount, String week) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM F E");
		try {
			// "2003-05 4 星期五"
			Date date = sdf.parse(yearMonth + " " + weekCount + " " + week);
			SimpleDateFormat sdf2 = new SimpleDateFormat("yyyy-MM-dd");
			String strDate = sdf2.format(date);
			System.out.println(strDate);
			return strDate;
		} catch (ParseException e) {
			e.printStackTrace();
		}

		return "";
	}

	/**
	 * 格式化日期
	 * 
	 * @param dateStr
	 *            字符型日期
	 * @param formatStr
	 *            格式
	 * @return 返回日期
	 */
	public static Date parseDate(String dateStr, String formatStr) {
		SimpleDateFormat format = new SimpleDateFormat(formatStr,
				Locale.ENGLISH);
		try {
			return format.parse(dateStr);
		} catch (ParseException e) {
			e.printStackTrace();
			return null;
		}
	}

	/**
	 * 根据日期计算星期几
	 * 
	 * @param DateStr
	 * @return
	 */
	public static String getWeekDay(String DateStr) {
		SimpleDateFormat formatYMD = new SimpleDateFormat("yyyy-MM-dd");// formatYMD表示的是yyyy-MM-dd格式
		SimpleDateFormat formatD = new SimpleDateFormat("E");// "E"表示"day in week"
		Date d = null;
		String weekDay = "";
		try {
			d = formatYMD.parse(DateStr);// 将String 转换为符合格式的日期
			weekDay = formatD.format(d);
		} catch (Exception e) {
			e.printStackTrace();
		}
		System.out.println("日期:" + DateStr + " ： " + weekDay);
		if (weekDay != null && weekDay.equals("星期一")) {
			weekDay = weekDay + ",1";
		} else if (weekDay != null && weekDay.equals("星期二")) {
			weekDay = weekDay + ",2";
		} else if (weekDay != null && weekDay.equals("星期三")) {
			weekDay = weekDay + ",3";
		} else if (weekDay != null && weekDay.equals("星期四")) {
			weekDay = weekDay + ",4";
		} else if (weekDay != null && weekDay.equals("星期五")) {
			weekDay = weekDay + ",5";
		} else if (weekDay != null && weekDay.equals("星期六")) {
			weekDay = weekDay + ",6";
		} else if (weekDay != null && weekDay.equals("星期日")) {
			weekDay = weekDay + ",7";
		}
		return weekDay;
	}

	/**
	 * 根据日期计算星期几
	 * 
	 * @param DateStr
	 * @return 贾晓松
	 */
	public static String getWeekDays(String DateStr) {
		SimpleDateFormat formatYMD = new SimpleDateFormat("yyyy-MM-dd");// formatYMD表示的是yyyy-MM-dd格式
		SimpleDateFormat formatD = new SimpleDateFormat("E");// "E"表示"day in week"
		Date d = null;
		String weekDay = "";
		try {
			d = formatYMD.parse(DateStr);// 将String 转换为符合格式的日期
			weekDay = formatD.format(d);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return weekDay;
	}

	/**
	 * 比较两个日期大小
	 * 
	 * @param date1
	 * @param date2
	 * @return true:date1 < date2<br/>
	 *         false:date1 > date2
	 */
	public static boolean compareDate(Date date1, Date date2) {
		boolean flag = date1.before(date2);
		return flag;
	}

	public static void main(String[] args) {
		Date date1 = new Date();
		Date date11 = DateUtil.minusDateByDays(date1, 1l);
		Date date2 = DateUtil.parseDate("2014-11-03 14:54:11", "yyyy-MM-dd HH:mm:ss");
		// true 超时 false 时间范围内
		System.out.println(DateUtil.compareDate(date2, date11));
	}
}
