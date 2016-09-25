namespace My12306
{
    partial class FormMyTicket
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMyTicket));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.picCode = new System.Windows.Forms.PictureBox();
            this.gboLogin = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMsg = new System.Windows.Forms.Label();
            this.gboLinkMan = new System.Windows.Forms.GroupBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.btnPassengerOK = new System.Windows.Forms.Button();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.gboFromTo = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.numUD = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRandCode = new System.Windows.Forms.TextBox();
            this.picRandCode = new System.Windows.Forms.PictureBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.chxIsBuy = new System.Windows.Forms.CheckBox();
            this.lbxTo = new System.Windows.Forms.ListBox();
            this.lbxFrom = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cboSeat = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbxProgram = new System.Windows.Forms.ListBox();
            this.cboTrainNum = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.btnFromToAdd = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).BeginInit();
            this.gboLogin.SuspendLayout();
            this.gboLinkMan.SuspendLayout();
            this.gboFromTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRandCode)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "登陆名：";
            // 
            // txtLoginName
            // 
            this.txtLoginName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtLoginName.Location = new System.Drawing.Point(71, 11);
            this.txtLoginName.MaxLength = 20;
            this.txtLoginName.Multiline = true;
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(152, 20);
            this.txtLoginName.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(71, 35);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码：";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(71, 271);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(99, 39);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "登 陆";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // picCode
            // 
            this.picCode.Location = new System.Drawing.Point(6, 61);
            this.picCode.Name = "picCode";
            this.picCode.Size = new System.Drawing.Size(293, 190);
            this.picCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCode.TabIndex = 7;
            this.picCode.TabStop = false;
            this.picCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCode_MouseClick);
            // 
            // gboLogin
            // 
            this.gboLogin.Controls.Add(this.listView1);
            this.gboLogin.Controls.Add(this.button1);
            this.gboLogin.Controls.Add(this.label4);
            this.gboLogin.Controls.Add(this.lbMsg);
            this.gboLogin.Controls.Add(this.label1);
            this.gboLogin.Controls.Add(this.picCode);
            this.gboLogin.Controls.Add(this.txtLoginName);
            this.gboLogin.Controls.Add(this.btnLogin);
            this.gboLogin.Controls.Add(this.label2);
            this.gboLogin.Controls.Add(this.txtPassword);
            this.gboLogin.ForeColor = System.Drawing.Color.DarkCyan;
            this.gboLogin.Location = new System.Drawing.Point(12, 12);
            this.gboLogin.Name = "gboLogin";
            this.gboLogin.Size = new System.Drawing.Size(322, 488);
            this.gboLogin.TabIndex = 9;
            this.gboLogin.TabStop = false;
            this.gboLogin.Text = "❶登陆";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(6, 348);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(310, 133);
            this.listView1.TabIndex = 100;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 63);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 27);
            this.button1.TabIndex = 10;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(42, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "提示：密码错误次数不超过3次";
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.ForeColor = System.Drawing.Color.DarkRed;
            this.lbMsg.Location = new System.Drawing.Point(18, 260);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(47, 12);
            this.lbMsg.TabIndex = 8;
            this.lbMsg.Text = "       ";
            // 
            // gboLinkMan
            // 
            this.gboLinkMan.Controls.Add(this.checkBox20);
            this.gboLinkMan.Controls.Add(this.checkBox19);
            this.gboLinkMan.Controls.Add(this.checkBox18);
            this.gboLinkMan.Controls.Add(this.checkBox17);
            this.gboLinkMan.Controls.Add(this.checkBox16);
            this.gboLinkMan.Controls.Add(this.checkBox15);
            this.gboLinkMan.Controls.Add(this.checkBox14);
            this.gboLinkMan.Controls.Add(this.checkBox13);
            this.gboLinkMan.Controls.Add(this.checkBox12);
            this.gboLinkMan.Controls.Add(this.checkBox11);
            this.gboLinkMan.Controls.Add(this.checkBox10);
            this.gboLinkMan.Controls.Add(this.checkBox9);
            this.gboLinkMan.Controls.Add(this.btnPassengerOK);
            this.gboLinkMan.Controls.Add(this.checkBox8);
            this.gboLinkMan.Controls.Add(this.checkBox7);
            this.gboLinkMan.Controls.Add(this.checkBox6);
            this.gboLinkMan.Controls.Add(this.checkBox5);
            this.gboLinkMan.Controls.Add(this.checkBox4);
            this.gboLinkMan.Controls.Add(this.checkBox3);
            this.gboLinkMan.Controls.Add(this.checkBox2);
            this.gboLinkMan.Controls.Add(this.checkBox1);
            this.gboLinkMan.Enabled = false;
            this.gboLinkMan.ForeColor = System.Drawing.Color.DarkCyan;
            this.gboLinkMan.Location = new System.Drawing.Point(348, 12);
            this.gboLinkMan.Name = "gboLinkMan";
            this.gboLinkMan.Size = new System.Drawing.Size(505, 216);
            this.gboLinkMan.TabIndex = 10;
            this.gboLinkMan.TabStop = false;
            this.gboLinkMan.Text = "❷选择乘客(暂时最大10个)";
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.Location = new System.Drawing.Point(361, 124);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(84, 16);
            this.checkBox20.TabIndex = 19;
            this.checkBox20.Text = "checkBox20";
            this.checkBox20.UseVisualStyleBackColor = true;
            this.checkBox20.Visible = false;
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Location = new System.Drawing.Point(361, 100);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(84, 16);
            this.checkBox19.TabIndex = 18;
            this.checkBox19.Text = "checkBox19";
            this.checkBox19.UseVisualStyleBackColor = true;
            this.checkBox19.Visible = false;
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(361, 75);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(84, 16);
            this.checkBox18.TabIndex = 17;
            this.checkBox18.Text = "checkBox18";
            this.checkBox18.UseVisualStyleBackColor = true;
            this.checkBox18.Visible = false;
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(361, 49);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(84, 16);
            this.checkBox17.TabIndex = 16;
            this.checkBox17.Text = "checkBox17";
            this.checkBox17.UseVisualStyleBackColor = true;
            this.checkBox17.Visible = false;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(361, 24);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(84, 16);
            this.checkBox16.TabIndex = 15;
            this.checkBox16.Text = "checkBox16";
            this.checkBox16.UseVisualStyleBackColor = true;
            this.checkBox16.Visible = false;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(245, 124);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(84, 16);
            this.checkBox15.TabIndex = 14;
            this.checkBox15.Text = "checkBox15";
            this.checkBox15.UseVisualStyleBackColor = true;
            this.checkBox15.Visible = false;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(245, 100);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(84, 16);
            this.checkBox14.TabIndex = 13;
            this.checkBox14.Text = "checkBox14";
            this.checkBox14.UseVisualStyleBackColor = true;
            this.checkBox14.Visible = false;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(245, 75);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(84, 16);
            this.checkBox13.TabIndex = 12;
            this.checkBox13.Text = "checkBox13";
            this.checkBox13.UseVisualStyleBackColor = true;
            this.checkBox13.Visible = false;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(245, 50);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(84, 16);
            this.checkBox12.TabIndex = 11;
            this.checkBox12.Text = "checkBox12";
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.Visible = false;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(245, 24);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(84, 16);
            this.checkBox11.TabIndex = 10;
            this.checkBox11.Text = "checkBox11";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.Visible = false;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(138, 124);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(84, 16);
            this.checkBox10.TabIndex = 9;
            this.checkBox10.Text = "checkBox10";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.Visible = false;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(21, 124);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(78, 16);
            this.checkBox9.TabIndex = 8;
            this.checkBox9.Text = "checkBox9";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.Visible = false;
            // 
            // btnPassengerOK
            // 
            this.btnPassengerOK.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPassengerOK.ForeColor = System.Drawing.Color.White;
            this.btnPassengerOK.Location = new System.Drawing.Point(69, 175);
            this.btnPassengerOK.Name = "btnPassengerOK";
            this.btnPassengerOK.Size = new System.Drawing.Size(75, 26);
            this.btnPassengerOK.TabIndex = 99;
            this.btnPassengerOK.Text = "确 定";
            this.btnPassengerOK.UseVisualStyleBackColor = false;
            this.btnPassengerOK.Click += new System.EventHandler(this.btnSelectOK_Click);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(138, 100);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(78, 16);
            this.checkBox8.TabIndex = 7;
            this.checkBox8.Text = "checkBox8";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.Visible = false;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(21, 100);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(78, 16);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Text = "checkBox7";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.Visible = false;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(138, 75);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(78, 16);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "checkBox6";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.Visible = false;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(21, 74);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(78, 16);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(138, 50);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(78, 16);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(21, 49);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(78, 16);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(138, 25);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // gboFromTo
            // 
            this.gboFromTo.Controls.Add(this.btnStop);
            this.gboFromTo.Controls.Add(this.label12);
            this.gboFromTo.Controls.Add(this.numUD);
            this.gboFromTo.Controls.Add(this.label11);
            this.gboFromTo.Controls.Add(this.panel1);
            this.gboFromTo.Controls.Add(this.chxIsBuy);
            this.gboFromTo.Controls.Add(this.lbxTo);
            this.gboFromTo.Controls.Add(this.lbxFrom);
            this.gboFromTo.Controls.Add(this.btnStart);
            this.gboFromTo.Controls.Add(this.label10);
            this.gboFromTo.Controls.Add(this.cboSeat);
            this.gboFromTo.Controls.Add(this.label9);
            this.gboFromTo.Controls.Add(this.label8);
            this.gboFromTo.Controls.Add(this.lbxProgram);
            this.gboFromTo.Controls.Add(this.cboTrainNum);
            this.gboFromTo.Controls.Add(this.dtpDate);
            this.gboFromTo.Controls.Add(this.label7);
            this.gboFromTo.Controls.Add(this.label5);
            this.gboFromTo.Controls.Add(this.txtFrom);
            this.gboFromTo.Controls.Add(this.label6);
            this.gboFromTo.Controls.Add(this.txtTo);
            this.gboFromTo.Controls.Add(this.btnFromToAdd);
            this.gboFromTo.Enabled = false;
            this.gboFromTo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gboFromTo.Location = new System.Drawing.Point(348, 246);
            this.gboFromTo.Name = "gboFromTo";
            this.gboFromTo.Size = new System.Drawing.Size(505, 254);
            this.gboFromTo.TabIndex = 11;
            this.gboFromTo.TabStop = false;
            this.gboFromTo.Text = "❸启动方案";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Maroon;
            this.btnStop.Enabled = false;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(403, 221);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 27);
            this.btnStop.TabIndex = 33;
            this.btnStop.Text = "停 止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(332, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "秒";
            // 
            // numUD
            // 
            this.numUD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numUD.Location = new System.Drawing.Point(294, 221);
            this.numUD.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUD.Name = "numUD";
            this.numUD.Size = new System.Drawing.Size(35, 23);
            this.numUD.TabIndex = 31;
            this.numUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(230, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "查询间隔：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRandCode);
            this.panel1.Controls.Add(this.picRandCode);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(231, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 38);
            this.panel1.TabIndex = 29;
            // 
            // txtRandCode
            // 
            this.txtRandCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRandCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtRandCode.Location = new System.Drawing.Point(86, 9);
            this.txtRandCode.MaxLength = 4;
            this.txtRandCode.Multiline = true;
            this.txtRandCode.Name = "txtRandCode";
            this.txtRandCode.Size = new System.Drawing.Size(64, 20);
            this.txtRandCode.TabIndex = 28;
            this.txtRandCode.WordWrap = false;
            // 
            // picRandCode
            // 
            this.picRandCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRandCode.Location = new System.Drawing.Point(8, 9);
            this.picRandCode.Name = "picRandCode";
            this.picRandCode.Size = new System.Drawing.Size(63, 20);
            this.picRandCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRandCode.TabIndex = 26;
            this.picRandCode.TabStop = false;
            this.picRandCode.Click += new System.EventHandler(this.picRandCode_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(171, 6);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 27);
            this.btnSubmit.TabIndex = 27;
            this.btnSubmit.Text = "提 交";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // chxIsBuy
            // 
            this.chxIsBuy.AutoSize = true;
            this.chxIsBuy.Checked = true;
            this.chxIsBuy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxIsBuy.Location = new System.Drawing.Point(232, 159);
            this.chxIsBuy.Name = "chxIsBuy";
            this.chxIsBuy.Size = new System.Drawing.Size(204, 16);
            this.chxIsBuy.TabIndex = 25;
            this.chxIsBuy.Text = "需要下定单(如只需查票不用勾选)";
            this.chxIsBuy.UseVisualStyleBackColor = true;
            this.chxIsBuy.CheckedChanged += new System.EventHandler(this.chxIsBuy_CheckedChanged);
            // 
            // lbxTo
            // 
            this.lbxTo.FormattingEnabled = true;
            this.lbxTo.ItemHeight = 12;
            this.lbxTo.Location = new System.Drawing.Point(294, 65);
            this.lbxTo.Name = "lbxTo";
            this.lbxTo.Size = new System.Drawing.Size(120, 88);
            this.lbxTo.TabIndex = 24;
            this.lbxTo.Visible = false;
            this.lbxTo.Click += new System.EventHandler(this.lbxTo_Click);
            // 
            // lbxFrom
            // 
            this.lbxFrom.FormattingEnabled = true;
            this.lbxFrom.ItemHeight = 12;
            this.lbxFrom.Location = new System.Drawing.Point(294, 37);
            this.lbxFrom.Name = "lbxFrom";
            this.lbxFrom.Size = new System.Drawing.Size(120, 88);
            this.lbxFrom.TabIndex = 23;
            this.lbxFrom.Visible = false;
            this.lbxFrom.Click += new System.EventHandler(this.lbxFrom_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(32, 213);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(156, 34);
            this.btnStart.TabIndex = 22;
            this.btnStart.Text = "启 动";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(230, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "席别：";
            // 
            // cboSeat
            // 
            this.cboSeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSeat.FormattingEnabled = true;
            this.cboSeat.ItemHeight = 12;
            this.cboSeat.Location = new System.Drawing.Point(271, 128);
            this.cboSeat.Name = "cboSeat";
            this.cboSeat.Size = new System.Drawing.Size(105, 20);
            this.cboSeat.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "车次：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "方案列表：（优先顺序从上到下）";
            // 
            // lbxProgram
            // 
            this.lbxProgram.FormattingEnabled = true;
            this.lbxProgram.ItemHeight = 12;
            this.lbxProgram.Location = new System.Drawing.Point(21, 35);
            this.lbxProgram.Name = "lbxProgram";
            this.lbxProgram.Size = new System.Drawing.Size(202, 172);
            this.lbxProgram.TabIndex = 18;
            this.lbxProgram.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbxProgram_MouseUp);
            // 
            // cboTrainNum
            // 
            this.cboTrainNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboTrainNum.FormattingEnabled = true;
            this.cboTrainNum.ItemHeight = 12;
            this.cboTrainNum.Location = new System.Drawing.Point(271, 99);
            this.cboTrainNum.Name = "cboTrainNum";
            this.cboTrainNum.Size = new System.Drawing.Size(228, 20);
            this.cboTrainNum.TabIndex = 15;
            this.cboTrainNum.Click += new System.EventHandler(this.cboTrainNum_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(294, 72);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(177, 21);
            this.dtpDate.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "乘车日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "出发地：";
            // 
            // txtFrom
            // 
            this.txtFrom.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFrom.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtFrom.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFrom.Location = new System.Drawing.Point(293, 18);
            this.txtFrom.MaxLength = 12;
            this.txtFrom.Multiline = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(178, 20);
            this.txtFrom.TabIndex = 11;
            this.txtFrom.Text = "请输入站名拼音首字母";
            this.txtFrom.Click += new System.EventHandler(this.txtFrom_Click);
            this.txtFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFrom_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "到达地：";
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTo.Location = new System.Drawing.Point(293, 45);
            this.txtTo.MaxLength = 12;
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(178, 20);
            this.txtTo.TabIndex = 12;
            this.txtTo.Click += new System.EventHandler(this.txtTo_Click);
            this.txtTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTo_KeyUp);
            // 
            // btnFromToAdd
            // 
            this.btnFromToAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFromToAdd.ForeColor = System.Drawing.Color.White;
            this.btnFromToAdd.Location = new System.Drawing.Point(390, 125);
            this.btnFromToAdd.Name = "btnFromToAdd";
            this.btnFromToAdd.Size = new System.Drawing.Size(109, 26);
            this.btnFromToAdd.TabIndex = 17;
            this.btnFromToAdd.Text = "添加至方案";
            this.btnFromToAdd.UseVisualStyleBackColor = false;
            this.btnFromToAdd.Click += new System.EventHandler(this.btnFromToAdd_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.下移ToolStripMenuItem,
            this.删除ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "上移";
            // 
            // 下移ToolStripMenuItem
            // 
            this.下移ToolStripMenuItem.Name = "下移ToolStripMenuItem";
            this.下移ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.下移ToolStripMenuItem.Text = "下移";
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem1.Text = "删除";
            this.删除ToolStripMenuItem1.Click += new System.EventHandler(this.删除ToolStripMenuItem1_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 503);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(865, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "等待";
            // 
            // FormMyTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(865, 525);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gboFromTo);
            this.Controls.Add(this.gboLinkMan);
            this.Controls.Add(this.gboLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMyTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "h ";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).EndInit();
            this.gboLogin.ResumeLayout(false);
            this.gboLogin.PerformLayout();
            this.gboLinkMan.ResumeLayout(false);
            this.gboLinkMan.PerformLayout();
            this.gboFromTo.ResumeLayout(false);
            this.gboFromTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRandCode)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox picCode;
        private System.Windows.Forms.GroupBox gboLogin;
        private System.Windows.Forms.GroupBox gboLinkMan;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnPassengerOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gboFromTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Button btnFromToAdd;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbxProgram;
        private System.Windows.Forms.ComboBox cboTrainNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboSeat;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lbxFrom;
        private System.Windows.Forms.ListBox lbxTo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.CheckBox chxIsBuy;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.PictureBox picRandCode;
        private System.Windows.Forms.TextBox txtRandCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numUD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.ListView listView1;
    }
}