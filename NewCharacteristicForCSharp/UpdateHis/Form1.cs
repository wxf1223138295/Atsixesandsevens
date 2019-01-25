using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateHis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string destinationConnection = "Data Source = " + textBox1.Text + "; Initial Catalog = FGHIS5; " +
                                           "User ID = " + textBox2.Text + "; Password = " + textBox3.Text+";";

            string sql1 = @"delete from 系统_访问配置表";

            string sql2 = @"insert into 系统_访问配置表(访问ID, 名称, 配置, 状态, 添加时间, 修改时间) values (
0,'本地','<?xml version="+"1.0"+ " encoding=\"utf - 8\"?><configuration><client><endpoint address=\"localhost | 60002 | HisService\" name=\"HisHostEndpoint_tcp\" /><endpoint address=\"localhost | 9502 | XTSZService\" name=\"XTSZEndpoint_tcp\" /><endpoint address=\"localhost | 60005 | MZDZBLService\" name=\"MZDZBLEndpoint_tcp\" /><endpoint address=\"localhost | 60006 | DZSQService\" name=\"DZSQEndpoint_tcp\" /><endpoint address=\"localhost | 60008 | BizCISWHService\" name=\"CISWHEndpoint_tcp\" /><endpoint address=\"localhost | 60009 | CISBLService\" name=\"CISBLEndpoint_tcp\" /><endpoint address=\"localhost | 60007 | CISPublicService\" name=\"CISPublicEndpoint_tcp\" /><endpoint address=\"localhost | 9016 | YJXTService\" name=\"YJXTEndpoint_tcp\" /><endpoint address=\"localhost | 60607 | CFDPService\" name=\"CFDPEndpoint_tcp\" /><endpoint address=\"localhost | 60604 | MZGLService\" name=\"MZGLEndpoint_tcp\" /><endpoint address=\"localhost | 9508 | SYGLService\" name=\"SYGLEndpoint_tcp\" /><endpoint address=\"localhost | 8401 | CWGLService\" name=\"CWGLEndpoint_tcp\" /><endpoint address=\"localhost | 9395 | GHSfService\" name=\"GhSfEndpoint_tcp\" /><endpoint address=\"localhost | 9123 | MZKFZXService\" name=\"MZKFZXEndpoint_tcp\" /></client><appSettings><add key=\"URI\" value=\"tcp://127.0.0.1:61616?wireFormat.maxInactivityDuration=0;maxInactivityDurationInitalDelay=30000;connection.AsyncSend=true\" /><add key=\"USERNAME\" value=\"system\" /><add key=\"PASSWORD\" value=\"manager\" /></appSettings></configuration>',1,getdate(),getdate())";

            string sql3 = @"insert into 系统_访问配置表(访问ID, 名称, 配置, 状态, 添加时间, 修改时间) values (
1,'生产环境','<?xml version=" + "1.0" + " encoding=\"utf - 8\"?><configuration><client><endpoint address="+textBox4.Text+" | 60002 | HisService\" name=\"HisHostEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 9502 | XTSZService\" name=\"XTSZEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 60005 | MZDZBLService\" name=\"MZDZBLEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 60006 | DZSQService\" name=\"DZSQEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 60008 | BizCISWHService\" name=\"CISWHEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 60009 | CISBLService\" name=\"CISBLEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 60007 | CISPublicService\" name=\"CISPublicEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 9016 | YJXTService\" name=\"YJXTEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 60607 | CFDPService\" name=\"CFDPEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 60604 | MZGLService\" name=\"MZGLEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 9508 | SYGLService\" name=\"SYGLEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 8401 | CWGLService\" name=\"CWGLEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 9395 | GHSfService\" name=\"GhSfEndpoint_tcp\" /><endpoint address="+textBox4.Text+" | 9123 | MZKFZXService\" name=\"MZKFZXEndpoint_tcp\" /></client><appSettings><add key=\"URI\" value=\"tcp://127.0.0.1:61616?wireFormat.maxInactivityDuration=0;maxInactivityDurationInitalDelay=30000;connection.AsyncSend=true\" /><add key=\"USERNAME\" value=\"system\" /><add key=\"PASSWORD\" value=\"manager\" /></appSettings></configuration>',1,getdate(),getdate())";

            if (!ExcuteSql.UpdateSqlServerConfig(destinationConnection, sql1))
            {
                MessageBox.Show("清空表失败");
            }
            else{MessageBox.Show("清空表成功");}
            
            if (!ExcuteSql.UpdateSqlServerConfig(destinationConnection, sql2))
            {
                MessageBox.Show("插入本地配置失败");
            }
            else { MessageBox.Show("插入本地配置成功"); }
            if (!ExcuteSql.UpdateSqlServerConfig(destinationConnection, sql3))
            {
                MessageBox.Show("插入服务器配合失败");
            }
            else { MessageBox.Show("插入服务器配合成功"); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CommomFunc.FindSameType(textBox1.Text,textBox2.Text,textBox3.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
