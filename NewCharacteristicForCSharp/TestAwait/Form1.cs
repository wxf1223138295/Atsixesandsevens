using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private async void button1_Click(object sender, EventArgs e)
        {
            await getstring1();

         
          
            getstring2();
    
            //==============================
            textBox3.Text = "线程已启动";
        }

        public async Task getstring1()
        {
            string date="";
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                date = DateTime.Now.ToString();
            });
            Action<string> changetime = (str) => { textBox1.Text = str; };
            textBox1.Invoke(changetime, date);
        }
        public async Task getstring2()
        {
            string date = "";
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                date = DateTime.Now.ToString();
            });

            Action<string> changetime = (str) => { textBox2.Text = str; };
            textBox2.Invoke(changetime, date);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // load();
        }

        public void load()
        {
            System.Timers.Timer timer = new System.Timers.Timer(3000);

            timer.Elapsed += Timer_Elapsed;

            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public static int i;
        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            await getstring1();

            await getstring2();

            Action<string> changetime = (str) => { textBox3.Text = str; };
            i = i + 1;
            textBox3.Invoke(changetime, "定时器程已启动"+i);
        }
        
        private async void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += String.Format("\r\nMyAsync({0}).\r\n",
                Thread.CurrentThread.ManagedThreadId);
            while (true)
                richTextBox1.Text += String.Format("\r\nMyAsync({0}): {1}.\r\n",
                    Thread.CurrentThread.ManagedThreadId, await MyAsync());
        }
        public Task<string> MyAsync()
        {
            var t = new Task<string>((str) =>
            {
                var dt = DateTime.Now;
                Thread.Sleep(4000);

                return String.Format("({0}){1} - {2}",
                    Thread.CurrentThread.ManagedThreadId, dt, DateTime.Now);
            }, null);

            t.Start();

            return t;
        }
    }
}
