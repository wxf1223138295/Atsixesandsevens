using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace RecordCarCounts
{
    public partial class Recording : Form
    {
        public Recording()
        {
            InitializeComponent();
        }

        private static int Count;
       
        private static object obj=new object();
        Logger logger = NLog.LogManager.GetCurrentClassLogger();
        //记录当前数字，防止意外关闭程序
        public static string filepath = Application.StartupPath.ToString() + $"/SumCount.txt";
        private void Recording_Load(object sender, EventArgs e)
        {
            logger.Info($"{DateTime.Now.ToString()} 启动 #########");
            //文件名写死 SumCount.txt
            if (File.Exists(filepath))
            {
                //读取文件里的内容
                Count = Convert.ToInt32(File.ReadAllText(filepath));
                Number.Text = Count.ToString();
                logger.Info($"{DateTime.Now.ToString()} 重启了  之前数量是 {Count} #########");
            }
            else
            {
                Count = 0;
                File.WriteAllText(filepath,"0");
                Number.Text = Count.ToString();
                logger.Info($"{DateTime.Now.ToString()} 初始化，第一次登陆 #########");
            }
            textBox1.Enabled = false;

            Task.Run(() => {
                while (true)
                {
                    //显示当前时间
                    Action<string> delegateTime = (str) => { textBox1.Text = str; };
                    textBox1.Invoke(delegateTime, DateTime.Now.ToString());
                }
            });
           
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
           var num = Convert.ToInt32(File.ReadAllText(filepath));
            Count = num + 1;
            lock (obj)
            {
                File.WriteAllText(filepath, Count.ToString());
            }

            Number.Text = Count.ToString();
            logger.Info($"{DateTime.Now.ToString()} 记录了一辆车通过 #########");
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            var num = Convert.ToInt32(File.ReadAllText(filepath));
            Count = num - 1;
            lock (obj)
            {
                File.WriteAllText(filepath, Count.ToString());
            }
            Number.Text = Count.ToString();
            logger.Info($"{DateTime.Now.ToString()} 擦除了记录一辆车通过 #########");
        }
    }
}
