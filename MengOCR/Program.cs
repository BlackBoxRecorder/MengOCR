using NLog;
using System;
using System.Text;
using System.Windows.Forms;

namespace MengOCR
{
    internal static class Program
    {
        private static System.Threading.Mutex _mutex;
        private static readonly Logger logger = LogManager.GetLogger("Program");
        private static readonly string ERROR_MSG = "出现位置异常，请重启程序！";
        private static readonly string REPEAT_MSG = "已经有一个实例正在运行！";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            _mutex = new System.Threading.Mutex(true, "mengmengdaocr", out bool createNew);
            if (false == createNew)
            {
                MessageBox.Show(REPEAT_MSG);
                _mutex.ReleaseMutex();
                return;
            }

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }



        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            logger.Error(str);
            MessageBox.Show(ERROR_MSG, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            logger.Error(str);
            MessageBox.Show(ERROR_MSG, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }

    }
}
