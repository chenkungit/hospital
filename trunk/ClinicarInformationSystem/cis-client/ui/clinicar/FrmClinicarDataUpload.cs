using cis_business.util;
using SCommon.SQL;
using SCommon.SUtil;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using UComponentLib.Component.Extension;

namespace cis_client.ui.clinicar
{
    public partial class FrmClinicarDataUpload : SCommon.SControl.SBaseForm
    {
        /// <summary>
        /// FTP服务器地址
        /// </summary>
        private string ftpUristring = null;

        /// <summary>
        /// 需要上传的本地文件固定路径前缀
        /// </summary>
        private string strLocalFilePath = "D:\\uploadFolder\\";

        #region + 构造方法
        public FrmClinicarDataUpload()
        {
            InitializeComponent();
        }
        #endregion

        private void FrmClinicarDataUpload_Load(object sender, EventArgs e)
        {
            //上传项目
            uCbo_UploadItem.DataSource = Constant.GetUploadItemData(DicSort.UploadItem).ToList();
            uCbo_UploadItem.DisplayMember = "Value";
            uCbo_UploadItem.ValueMember = "Key";
            uCbo_UploadItem.SelectedIndex = -1;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == this.btn_close)
            {
                this.Close();
            }
            else if (sender == this.btn_save)
            {
                if (this.CheckBeforeSave())//保存前的校验
                {
                    save();
                }
            }
        }

        /// <summary>
        /// 保存前的校验方法
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeSave()
        {
            if (uCbo_UploadItem.SelectedIndex < 0)
            {
                UcMessageBox.Warning("请选择上传项目！", "提示");
                this.uCbo_UploadItem.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        private void save()
        {
            bool blSuccess = false;

            #region + 会诊记录表

            //申请会诊记录表
            if (uCbo_UploadItem.SelectedValue.Equals("t_clinicar_consultation"))
            {
                StringBuilder strOutId = new StringBuilder();
                //取出外网已有数据的id
                DataTable _dtOutSide = MySQLHelper.ExecuteDataTable(SqlUtil.F_OutsideConnectionString, CommandType.Text, "select id from t_clinicar_consultation");
                if (_dtOutSide != null && Convert.IsDBNull(_dtOutSide) == false && _dtOutSide.Rows.Count > 0)
                {
                    for (int i=0;i< _dtOutSide.Rows.Count;i++)
                    {
                        strOutId.Append(_dtOutSide.Rows[i]["id"]);
                        strOutId.Append(",");
                    }
                }
                if (strOutId.Length > 0)
                {
                    strOutId.Remove(strOutId.Length-1,1);
                }
                else
                {
                    strOutId.Append("0");
                }
                //获取本地数据，并过滤掉服务器已有的数据
                DataTable _dt = MySQLHelper.ExecuteDataTable(SqlUtil.F_LocalConnectionString, CommandType.Text, "select * from t_clinicar_consultation where id not in (" + strOutId + ")");
                if (_dt != null && Convert.IsDBNull(_dt) == false && _dt.Rows.Count > 0)
                { 
                    try
                    {
                        for (int i = 0; i < _dt.Rows.Count; i++)
                        {
                            string sql = "insert into t_clinicar_consultation values ("
                                       + "'" + _dt.Rows[i][0] + "',"
                                       + "'" + _dt.Rows[i][1] + "',"
                                       + "'" + _dt.Rows[i][2] + "',"
                                       + "'" + _dt.Rows[i][3] + "',"
                                       + "'" + _dt.Rows[i][4] + "',"
                                       + "'" + _dt.Rows[i][5] + "',"
                                       + "'" + _dt.Rows[i][6] + "',"
                                       + "'" + _dt.Rows[i][7] + "',"
                                       + "'" + _dt.Rows[i][8] + "',"
                                       + "'" + _dt.Rows[i][9] + "',"
                                       + "'" + _dt.Rows[i][10] + "',"
                                       + "'" + _dt.Rows[i][11] + "',"
                                       + "'" + _dt.Rows[i][12] + "',"
                                       + "'" + _dt.Rows[i][13] + "',"
                                       + "'" + _dt.Rows[i][14] + "',"
                                       + "'" + _dt.Rows[i][15] + "',"
                                       + "'" + _dt.Rows[i][16] + "',"
                                       + "'" + _dt.Rows[i][17] + "',"
                                       + "'" + _dt.Rows[i][18] + "',"
                                       + "'" + _dt.Rows[i][19] + "',"
                                       + "'" + _dt.Rows[i][20] + "',"
                                       + "'" + _dt.Rows[i][21] + "'"
                                       + " )";
                            MySQLHelper.ExecuteNonQuery(SqlUtil.F_OutsideConnectionString, CommandType.Text, sql);
                            blSuccess = true;
                        }
                    }
                    catch (Exception exception)
                    {
                        blSuccess = false;
                        UcMessageBox.Error("数据上传失败 -- ", exception.Message + "\r\n" + exception.StackTrace + "\r\n" + exception.Source);
                    }
                    finally
                    {
                        if (blSuccess)
                        {
                            UcMessageBox.Information("上传成功.","提示");
                        }
                    }
                }
                else
                {
                    UcMessageBox.Information("没有需要上传的新增数据.", "提示");
                }
            }
            #endregion

            #region + 检查结果表
            //申请会诊记录表
            else if (uCbo_UploadItem.SelectedValue.Equals("t_clinicar_check_result"))
            {
                StringBuilder strOutId = new StringBuilder();
                //取出外网已有数据的id
                DataTable _dtOutSide = MySQLHelper.ExecuteDataTable(SqlUtil.F_OutsideConnectionString, CommandType.Text, "select id from t_clinicar_check_result");
                if (_dtOutSide != null && Convert.IsDBNull(_dtOutSide) == false && _dtOutSide.Rows.Count > 0)
                {
                    for (int i = 0; i < _dtOutSide.Rows.Count; i++)
                    {
                        strOutId.Append(_dtOutSide.Rows[i]["id"]);
                        strOutId.Append(",");
                    }
                }
                if (strOutId.Length > 0)
                {
                    strOutId.Remove(strOutId.Length - 1, 1);
                }
                else
                {
                    strOutId.Append("0");
                }
                //获取本地数据，并过滤掉服务器已有的数据
                DataTable _dt = MySQLHelper.ExecuteDataTable(SqlUtil.F_LocalConnectionString, CommandType.Text, "select * from t_clinicar_check_result where id not in (" + strOutId + ")");
                if (_dt != null && Convert.IsDBNull(_dt) == false && _dt.Rows.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i < _dt.Rows.Count; i++)
                        {
                            string sql = "insert into t_clinicar_check_result values ("
                                       + "'" + _dt.Rows[i][0] + "',"
                                       +       _dt.Rows[i][1] + ","
                                       + "'" + _dt.Rows[i][2] + "',"
                                       + "'" + _dt.Rows[i][3] + "',"
                                       + "'" + _dt.Rows[i][4] + "',"
                                       + "'" + _dt.Rows[i][5] + "',"
                                       + "'" + _dt.Rows[i][6] + "',"
                                       + "'" + _dt.Rows[i][7] + "',"
                                       + "'" + _dt.Rows[i][8] + "',"
                                       + "'" + _dt.Rows[i][9] + "',"
                                       + "'" + _dt.Rows[i][10] + "',"
                                       + "'" + _dt.Rows[i][11].ToString().Replace(@"\",@"\\") + "'"
                                       + " )";
                            
                            this.uploadFile(_dt.Rows[i][11].ToString());     //上传文件
                            MySQLHelper.ExecuteNonQuery(SqlUtil.F_OutsideConnectionString, CommandType.Text, sql);
                            blSuccess = true;
                        }
                    }
                    catch (Exception exception)
                    {
                        blSuccess = false;
                        UcMessageBox.Error("数据上传失败 -- " + exception.Message + "\r\n" + exception.StackTrace + "\r\n" + exception.Source);
                    }
                    if (blSuccess)
                    {
                        UcMessageBox.Information("上传成功.", "提示");
                    }
                }
                else
                {
                    UcMessageBox.Information("没有需要上传的新增数据.", "提示");
                }
            }
            #endregion
        }

        #region + 文件类上传相关
        /// <summary>
        /// 上传文件方法
        /// relativePath ：数据库中文件的相对路径
        /// </summary>
        private void uploadFile(string relativePath)
        {
            string strFilePath = strLocalFilePath;          //需要上传的本地文件固定路径前缀
            strFilePath = strFilePath + relativePath;           //拼接路径
            if (!File.Exists(strFilePath)) return;

            //获取外网ftp地址
            int indexStart = SqlUtil.F_OutsideConnectionString.IndexOf("=") + 1;
            int indexEnd = SqlUtil.F_OutsideConnectionString.IndexOf(";");
            ftpUristring = "ftp://" + SqlUtil.F_OutsideConnectionString.Substring(indexStart, indexEnd - indexStart);
            
            FileInfo fileinfo = new FileInfo(strFilePath);
            try
            {
                string uri = GetUriString(relativePath.Replace("\\","/"));
                //检查目录是否存在，不存在创建
                FtpCheckDirectoryExist(relativePath);
                FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.UploadFile);
                request.ContentLength = fileinfo.Length;
                int buflength = 8196;
                byte[] buffer = new byte[buflength];
                FileStream filestream = fileinfo.OpenRead();
                Stream responseStream = request.GetRequestStream();
                //lstbxFtpState.Items.Add("打开上传流，文件上传中...");
                int contenlength = filestream.Read(buffer, 0, buflength);
                while (contenlength != 0)
                {
                    responseStream.Write(buffer, 0, contenlength);
                    contenlength = filestream.Read(buffer, 0, buflength);
                }

                responseStream.Close();
                filestream.Close();
                FtpWebResponse response = GetFtpResponse(request);
                if (response == null)
                {
                    UcMessageBox.Warning("服务器未响应...", "提示");
                }
            }
            catch (WebException ex)
            {
                UcMessageBox.Error("上传发生错误，返回信息为：" + ex.Status, "提示");
            }
        }

        private string GetUriString(string relativePath)
        {
            string uri = string.Empty;
            string currentDir = "/";
            uri = ftpUristring + currentDir + relativePath;
            return uri;
        }

        #region 与服务器的交互

        // 创建FTP连接
        private FtpWebRequest CreateFtpWebRequest(string uri, string requestMethod)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(uri);
            //匿名登陆
            NetworkCredential networkCredential = new NetworkCredential("anonymous", "");
            request.Credentials = networkCredential;
            request.KeepAlive = true;
            request.UseBinary = true;
            request.Method = requestMethod;
            return request;
        }

        // 获取服务器返回的响应体
        private FtpWebResponse GetFtpResponse(FtpWebRequest request)
        {
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
                return response;
            }
            catch (WebException ex)
            {
                UcMessageBox.Error("发送错误，返回信息为：" + ex.Status, "提示");
                return null;
            }
        }
        #endregion

        #region + 创建目录相关
        //判断文件的目录是否存,不存则创建
        public void FtpCheckDirectoryExist(string destFilePath)
        {
            string fullDir = FtpParseDirectory(destFilePath.Replace(@"\",@"/"));
            string[] dirs = fullDir.Split('/');
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空  
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        FtpMakeDir(curDir);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        public static string FtpParseDirectory(string destFilePath)
        {
            return destFilePath.Substring(0, destFilePath.LastIndexOf("/"));
        }

        //创建目录
        public Boolean FtpMakeDir(string localFile)
        {
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpUristring + localFile);
            req.Credentials = new NetworkCredential("anonymous", "");
            req.Method = WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                req.Abort();
                return false;
            }
            req.Abort();
            return true;
        }
        #endregion

        #endregion
    }
}
