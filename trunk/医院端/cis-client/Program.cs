using cis_client.ui;
using SCommon.SUtil;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace cis_client
{
    static class Program
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 初始化日志
            log4net.Config.XmlConfigurator.Configure();
            logger.Info("系统初始化开始...");
            #endregion

            #region 初始化数据库
            SCommon.SInit.InitDataBase(SCommon.SUtil.SConstants.S_DbType.MySQL,
                System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString,
                SCommon.SUtil.SConstants.S_ORM_TYPE.CastleActiveRecord,
                typeof(cis_model.sys.SysUser).Assembly);

            #endregion

            // 进入主界面
            Application.Run(new FrmMain());
            System.Environment.Exit(0); //无论在主线程和其它线程，只要执行了这句，都可以把程序结束干净
        }
    }
}
