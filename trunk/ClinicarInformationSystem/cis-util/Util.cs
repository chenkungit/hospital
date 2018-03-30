using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace cis_util
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Util
    {
        #region + 属性

        /// <summary>
        /// 图片类型集合
        /// </summary>
        private enum imageType
        {
            X光,
            B超
        }

        /// <summary>
        /// PDF类型集合
        /// </summary>
        private enum PDFType
        {
            心电图,
            电子阴道镜
        }

        /// <summary>
        /// 图片类型
        /// </summary>
        public const string image = "image";

        /// <summary>
        /// pdf 类型
        /// </summary>
        public const string pdf = "pdf";

        /// <summary>
        /// 数据类型
        /// </summary>
        public const string data = "data";

        /// <summary>
        /// 图片、pdf基本路径
        /// </summary>
        public const string basePath = "D:\\uploadFolder\\";

        #endregion

        #region + 方法

        /// <summary>
        /// 根据选择的科室，判断需要展示的类型
        /// 类型：图片、pdf、表格
        /// </summary>
        /// <returns></returns>
        public static string showType(string dpt)
        {
            if (Enum.IsDefined(typeof(imageType), dpt))
            {
                return image;
            }
            else if (Enum.IsDefined(typeof(PDFType), dpt))
            {
                return pdf;
            }
            else
            {
                return data;
            }
        }

        /// <summary>
        /// 连接远程共享文件夹
        /// </summary>
        /// <param name="path">远程共享文件夹的路径</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public static bool connectState(string path, string userName, string passWord)
        {
            bool Flag = false;
            Process proc = new Process();
            Process proc1 = new Process();
            //先删除链接
            try
            {
                proc1.StartInfo.FileName = "cmd.exe";
                proc1.StartInfo.UseShellExecute = false;
                proc1.StartInfo.RedirectStandardInput = true;
                proc1.StartInfo.RedirectStandardOutput = true;
                proc1.StartInfo.RedirectStandardError = true;
                proc1.StartInfo.CreateNoWindow = true;
                proc1.Start();
                //先删除后连接
                string doDel = "net use " + path + " /del";
                proc1.StandardInput.WriteLine(doDel);
            }
            catch
            {
                while (!proc1.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc1.StandardError.ReadToEnd();
                proc1.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
            }

            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                string dosLine = "net use " + path + " " + passWord + " /user:" + userName;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }


        /// <summary>
        /// 是否能 Ping 通指定的主机
        /// </summary>
        /// <param name="ip">ip 地址或主机名或域名</param>
        /// <returns>true 通，false 不通</returns>
        public static bool Ping(string ip)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "Test Data!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000; // Timeout 时间，单位：毫秒
            System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        public static void WriteLog(Exception ex, string LogAddress = "")
        {
            //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
            if (LogAddress == "")
            {
                LogAddress = Environment.CurrentDirectory + "\\logs\\b-ultra.log_" +
                    DateTime.Now.Year + '-' +
                    DateTime.Now.Month + '-' +
                    DateTime.Now.Day + ".log";
            }

            //把异常信息输出到文件
            StreamWriter fs = new StreamWriter(LogAddress, true);
            fs.WriteLine("当前时间：" + DateTime.Now.ToString());
            fs.WriteLine("异常信息：" + ex.Message);
            fs.WriteLine("异常对象：" + ex.Source);
            fs.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
            fs.WriteLine("触发方法：" + ex.TargetSite);
            fs.WriteLine();
            fs.Close();
        }

        /// <summary>
        /// 将信息打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        public static void WriteLog(string str, string LogAddress = "")
        {
            //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
            if (LogAddress == "")
            {
                LogAddress = Environment.CurrentDirectory + "\\logs\\b-ultra.log_" +
                    DateTime.Now.Year + '-' +
                    DateTime.Now.Month + '-' +
                    DateTime.Now.Day + ".log";
            }

            //把异常信息输出到文件
            StreamWriter fs = new StreamWriter(LogAddress, true);
            fs.WriteLine("当前时间：" + DateTime.Now.ToString());
            fs.WriteLine("异常信息：" + str);
            fs.WriteLine();
            fs.Close();
        }

       
        #endregion
    }
}
