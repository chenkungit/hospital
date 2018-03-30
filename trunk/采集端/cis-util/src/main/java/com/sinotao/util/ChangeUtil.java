package com.sinotao.util;

public class ChangeUtil {
	
	public static String null2default(Object obj, String def){
		if(obj == null){
		    obj = def;
		}
        return obj.toString();
	}
	
	public static int null2default(Object obj, int def){
	    int num = def;
        try{
            num = Integer.parseInt(obj.toString());
        }
        catch(Exception ex){
            System.out.println("转换异常：" + ex.getMessage());
        }
        return num;
	}
	
	public static long null2default(Object obj, long def){
		long num = def;
        try{
            num = Long.parseLong(obj.toString());
        }
        catch(Exception ex){
            System.out.println("转换异常：" + ex.getMessage());
        }
        return num;
	}
	
	public static float null2default(Object obj, float def){
		float num = def;
        try{
            num = Float.parseFloat(obj.toString());
        }
        catch(Exception ex){
            System.out.println("转换异常：" + ex.getMessage());
        }
        return num;
	}
	
	public static double null2default(Object obj, double def){
		double num = def;
        try{
            num = Double.parseDouble(obj.toString());
        }
        catch(Exception ex){
            System.out.println("转换异常：" + ex.getMessage());
        }
        return num;
	}
	
	public static String null2empty(Object obj){
        return null2default(obj, "");
	}
	
	public static String null2String(String obj){
        if(obj==null || "null".equals(obj)){
            obj = "";
        }
        return obj.toString();
    }
	
	public static int null2int(Object obj){
        return null2default(obj, 0);
	}
	
	public static long null2long(Object obj){
        return null2default(obj, 0L);
	}
	
	public static double null2double(Object obj){
        return null2default(obj, 0.0);
	}
	
	public static float null2float(Object obj){
        return null2default(obj, 0f);
	}

	public static String enterChange(Object inputStr){
	    if(inputStr!=null){
	        if(!inputStr.equals("")){
	            return String.valueOf(inputStr).replaceAll("\n", "<br/>");
	        }else{
	            return inputStr.toString();
	        }
	    }
	    else {
	        return null;
	    }
	}
	//按逗号分割的字符串并排序,相连字符串由-链接   如  5,4,3,6,8  返回值为 3-6,8
	public static String zcChange(String inputStr){
	    String result="";
	    String[] strArray=inputStr.split(",");
	    int n = strArray.length;  
	    int temp1=0;
	    if(strArray.length==1){
	        return inputStr;
	    }
	    for (int i = 0; i < n - 1; i++) {   
	      for (int j = 0; j < n - 1; j++) {  
	        if (Integer.parseInt(strArray[j]) > Integer.parseInt(strArray[j + 1])) {   
	          String temp = strArray[j];   
	          strArray[j] = strArray[j + 1];   
	          strArray[j + 1] = temp;   
	        }   
	      }
	      
	    }
	    for (int i = 0; i < n ; i++) {   
	        if(i>0){
	              if(Integer.parseInt(strArray[i])-Integer.parseInt(strArray[i-1])==1)
	              {
	                  temp1=1;
	                  if(i==n-1){
	                      result+="-"+strArray[i];
	                  }
	              }else if(Integer.parseInt(strArray[i])-Integer.parseInt(strArray[i-1])==0){
	                  if(temp1==1){
                          result+="-"+strArray[i-1];
                      }
                      temp1=0;
	              }else{
	                  if(temp1==1){
	                      result+="-"+strArray[i-1];
	                  }
	                  temp1=0;
	                  result+=","+strArray[i];
	              }
	          }else{
	              result=strArray[i];
	          }
	    }
	    return result;
    }
	//去掉字符串中多余逗号 如  ,a,b,,  返回值为a,b
	public static String commaChange(String inputStr){
		if(inputStr!=null){
            if(inputStr.equals("")){
                return inputStr;
            }else{
                inputStr=inputStr.replace(" ", "");
                while(inputStr.contains(",,")) {
                    inputStr=inputStr.replace(",,", ",");
                }
                while(inputStr.endsWith(",")) {
                    inputStr=inputStr.substring(0, inputStr.length()-1);
                }
                while(inputStr.startsWith(",")) {
                    inputStr=inputStr.substring(1);
                }
                return inputStr; 
            }
		}else{
			return "";
		}
    }
}
