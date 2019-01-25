namespace RecordCarCounts
{
    partial class Recording
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClick = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.labTxt = new System.Windows.Forms.Label();
            this.Number = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(83, 114);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(75, 23);
            this.btnClick.TabIndex = 0;
            this.btnClick.Text = "确认加1";
            this.btnClick.UseVisualStyleBackColor = true;
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(240, 114);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "确认减1";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // labTxt
            // 
            this.labTxt.AutoSize = true;
            this.labTxt.Location = new System.Drawing.Point(116, 57);
            this.labTxt.Name = "labTxt";
            this.labTxt.Size = new System.Drawing.Size(95, 12);
            this.labTxt.TabIndex = 2;
            this.labTxt.Text = "当前通过车辆数:";
            // 
            // Number
            // 
            this.Number.AutoSize = true;
            this.Number.Location = new System.Drawing.Point(223, 57);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(11, 12);
            this.Number.TabIndex = 3;
            this.Number.Text = "0";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(13, 13);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(59, 12);
            this.time.TabIndex = 4;
            this.time.Text = "当前时间:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 21);
            this.textBox1.TabIndex = 5;
            // 
            // Recording
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 212);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.time);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.labTxt);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnClick);
            this.Name = "Recording";
            this.Text = "Recording";
            this.Load += new System.EventHandler(this.Recording_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClick;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label labTxt;
        private System.Windows.Forms.Label Number;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.TextBox textBox1;
    }
}