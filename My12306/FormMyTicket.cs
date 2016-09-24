using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Web;
using System.Runtime.InteropServices;
using System.Net;
using System.Diagnostics;

namespace My12306
{
    public partial class FormMyTicket : Form
    {
        public FormMyTicket()
        {
            InitializeComponent();
        }
        RequestClass request = new RequestClass();
        string strURL = "";
        string strArgs = string.Empty;
        string strReferer = "https://dynamic.12306.cn/otsweb/loginAction.do?method=init";
        string code = "utf-8";
        string method = "post";
        string dlip = "";
        string randCode = "";

        string loginRand = "";
        string randError = "";

        string[,] stations = null; //全部车站名称
       // string[,] ststrainall = null;//根据出发地和到达地对应的车次
        string[,] programs = new  string[10,14];//方案
        string fromletter = "";//出发站字母简写
        string toletter = "";//到达站字母简写
        System.Collections.ArrayList listTrain = null;//根据出发地和到达地对应的车次
        System.Collections.ArrayList listFrom = null;
        System.Collections.ArrayList listTo = null;
        List<Passenger> passengers = new List<Passenger>();
        bool buyticket = true;//是否购票
        string leftTicketStr = "";
        string htmlTOKEN="";
        WebBrowser wbrws;
        HtmlDocument hd;
        HtmlElement he;
        bool isRun = false;
        private void FormMain_Load(object sender, EventArgs e)
        {
            FormMyTicket.CheckForIllegalCrossThreadCalls = false;
            Thread th = new Thread(loading);
            th.IsBackground = true;
            th.Start();

            //wbrws = new WebBrowser();
            //wbrws.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(getTag);
        }
        private void getTag(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            hd = wbrws.Document;
            //he = hd.GetElementById("leftTicketStr");
            //leftTicketStr = he.GetAttribute("value");
            HtmlElementCollection hec=hd.GetElementsByTagName("input");
            foreach(HtmlElement h in hec)
            {
                if (h.Name == "leftTicketStr")
                    leftTicketStr = h.GetAttribute("value");
                if (h.Name == "org.apache.struts.taglib.html.TOKEN")
                    htmlTOKEN = h.GetAttribute("value");
            }
            if (string.IsNullOrEmpty(leftTicketStr) || string.IsNullOrEmpty(htmlTOKEN))
            {
                MessageBox.Show("预定失败！");
                return;
            }
            toolStripStatusLabel1.Text = "完成预定，等待提交..";
        }
        string[,] seats = { { "--请选择--", "0", "0" }, { "商务座", "9", "1" }, { "特等座", "P", "2" }, { "一等座", "M", "3" }, { "二等座", "O", "4" }, { "高级软卧", "6", "5" }, { "软卧", "4", "6" }, { "硬卧", "3", "7" }, { "软座", "2", "8" }, { "硬座", "1", "9" }};//, { "无座", "empty", "10" }, { "其他", "QT", "11" }
        //加载数据
        private void loading()
        {
            //获取验证码
            Getpic();
            //绑定席别      
            listTrain = new System.Collections.ArrayList();
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                ListItem listItem = new ListItem();
                listItem.TextField = seats[i,0];
                listItem.ValueField = seats[i,2];
                listTrain.Add(listItem);
            }
            cboSeat.DataSource = listTrain;
            cboSeat.DisplayMember = "TextField";
            cboSeat.ValueMember = "ValueField";
            cboSeat.SelectedIndex = 0;
            //加载所有站名信息
            string stationName = Properties.Resources.station_name;
            string[] temp1 = stationName.Split('@');
            stations = new string[temp1.Length,6]; 
            for (int i = 0; i < temp1.Length; i++)
            {
                string[] temp2 = temp1[i].Split('|');
                for (int j = 0; j < temp2.Length; j++)
                {
                    stations[i, j] = temp2[j];
                }
            }
        }
        private string GetStationCode(string stationName)
        {
            string code="";
            for (int i = 0; i < stations.GetLength(0); i++)
            {
                if (stations[i, 1] == stationName)
                {
                    code = stations[i, 2];
                    break;
                }
            }
            return code;
        }
        private string GetSeatCode(string index)
        {
            string code = "";
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                if (seats[i, 2] == index)
                {
                    code=seats[i,1];
                    break;
                }
            }
            return code;
        }
        //获取登陆验证图片
        private void Getpic()
        {
            //先清空 
            randCode = "";

            strArgs = "";
            strURL = "https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew?module=login&rand=sjrand&"+new Random().NextDouble();
            string resImg = request.PostData(strURL, strArgs, "get");
            string strImg = resImg.Substring(resImg.IndexOf("|") + 1);
            byte[] bImg = Convert.FromBase64String(strImg);
            MemoryStream ms = new MemoryStream(bImg);
            picCode.Image = Image.FromStream(ms);           
        }

        //获取提交定单验证图片
        private void GetSubpic()
        {
            method = "get";
            strArgs = "";
            strURL = "https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=randp";
            string resImg = request.PostData(strURL, strArgs, "get");
            string strImg = resImg.Substring(resImg.IndexOf("|") + 1);
            if (string.IsNullOrEmpty(strImg))
            {
                MessageBox.Show("获取验证码失败！");
                return;
            }
            byte[] bImg = Convert.FromBase64String(strImg);
            MemoryStream ms = new MemoryStream(bImg);
            picRandCode.Image = Image.FromStream(ms);
            
        }

       

        
        //登陆
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoginName.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()) || string.IsNullOrEmpty(randCode))
            {
                MessageBox.Show("请填写完整！");
                return;
            }
            randCode = randCode.Substring(0,randCode.Length - 1);
            //登陆初始化
            strURL = "https://kyfw.12306.cn/otn/login/init";
            request.PostData(strURL, "", "get");

            //验证码验证        
            strArgs = "randCode=" + HttpUtility.UrlEncode(randCode) +"&rand=sjrand";
            strURL = "https://kyfw.12306.cn/otn/passcodeNew/checkRandCodeAnsyn";
            string resCode = request.PostData(strURL, strArgs, "post");
            resCode = resCode.Substring(resCode.IndexOf("|") + 1);
            JObject joCode = JObject.Parse(resCode);
            if(joCode["data"]["result"].ToString()!="1")
            {
                lbMsg.Text = "验证码错误！请重新点击。";
                Getpic();
                return;
            }
           
            lbMsg.Text = "验证通过，登陆中..";          
            //login           
            strURL = "https://kyfw.12306.cn/otn/login/loginAysnSuggest";
            strArgs = "loginUserDTO.user_name=" + txtLoginName.Text.Trim()+ "&userDTO.password=" + txtPassword.Text.Trim()+"&randCode=" + HttpUtility.UrlEncode(randCode);
           
            string resC;
            try
            {
                resC = request.PostData(strURL, strArgs, "post");
                resC = resC.Substring(resC.IndexOf("|") + 1);
                JObject joC = JObject.Parse(resC);             
                if (joC["data"] != null&&joC["data"]["loginCheck"].ToString() == "Y")  
                { 
                    lbMsg.Text = "登陆成功！";
                    
                    gboLogin.Enabled = false;
                    gboLinkMan.Enabled = true;
                    //GetLinkMan();

                    //foreach (Cookie cookie in post.cc.GetCookies(new Uri(strURL)))
                    //{
                    //    InternetSetCookie("https://" + cookie.Domain.ToString(), cookie.Name.ToString(), cookie.Value.ToString()+ ";expires=Sun,22-Feb-2099 00:00:00 GMT");//
                    //}
                    //Process.Start("IExplore.exe", "https://dynamic.12306.cn/otsweb/");
                }              
                else
                {
                    lbMsg.Text = joC["messages"].First.ToString();
                    //gboLogin.Enabled = false;      
                    btnLogin.Enabled = false;
                    btnLogin.BackColor = Color.Gray;
                }
            }
            catch(Exception e0)
            { MessageBox.Show(e0.Message); }
        }
        //获取联系人
        private void GetLinkMan()
        { 
            method = "get";
            strArgs = "";
            strReferer = "https://dynamic.12306.cn/otsweb/order/confirmPassengerAction.do?method=init";
            strURL = "https://dynamic.12306.cn/otsweb/order/confirmPassengerAction.do?method=getpassengerJson";
            string resLR;
            try
            {
                resLR = request.PostData(strURL, strArgs, "get");
                string retLR = resLR.Substring(resLR.IndexOf('|') + 1);
                JObject o = JObject.Parse(retLR);
                CheckBox cbx = checkBox1;

                while (o["passengerJson"].HasValues)
                {
                    cbx.Text = (string)o["passengerJson"].First["passenger_name"];
                    cbx.Tag = o["passengerJson"].First;
                    cbx.Visible = true;
                    cbx = (CheckBox)gboLinkMan.GetNextControl(cbx, true);
                    if (cbx == null)
                        break;
                    o["passengerJson"].First.Remove();
                }
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.Message);
            }
        }
        //确定联系人
        private void btnSelectOK_Click(object sender, EventArgs e)
        {
            CheckBox cbx;
            int n = 0;
            for (int i = 0; i < gboLinkMan.Controls.Count; i++)
            {
                if (gboLinkMan.Controls[i] is CheckBox)
                {
                    cbx=(CheckBox)gboLinkMan.Controls[i];
                    if (cbx.Checked)
                    {
                        JObject jo = (JObject)cbx.Tag;
                        Passenger psg = new Passenger();
                        psg.index = n;
                        psg.first_letter = jo["first_letter"].ToString();
                        psg.isUserSelf = jo["isUserSelf"].ToString();
                        psg.mobile_no = jo["mobile_no"].ToString();
                        psg.old_passenger_id_no = jo["old_passenger_id_no"].ToString();
                        psg.old_passenger_id_type_code = jo["old_passenger_id_type_code"].ToString();
                        psg.old_passenger_name = jo["old_passenger_name"].ToString();
                        psg.passenger_flag = jo["passenger_flag"].ToString();
                        psg.passenger_id_no = jo["passenger_id_no"].ToString();
                        psg.passenger_id_type_code = jo["passenger_id_type_code"].ToString();
                        psg.passenger_id_type_name = jo["passenger_id_type_name"].ToString();
                        psg.passenger_name = jo["passenger_name"].ToString();
                        psg.passenger_type = jo["passenger_type"].ToString();
                        psg.passenger_type_name = jo["passenger_type_name"].ToString();
                        psg.recordCount = jo["recordCount"].ToString();
                        passengers.Add(psg);
                    }
                    n++;
                }
            }
            if (passengers.Count == 0)
            {
                MessageBox.Show("请至少选择一位乘客！");
                return;
            }
            //MessageBox.Show("已选定"+passengers.Count+"人");
            gboLinkMan.Enabled = false;
            gboFromTo.Enabled = true;
        }
        //根据出发地和到达地对应的车次
        private void cboTrainNum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrom.Text.Trim()) || string.IsNullOrEmpty(txtTo.Text.Trim()))
            {
                MessageBox.Show("请填写出发地和到达地！"); return;
            }
            fromletter =toletter= "";

            fromletter = lbxFrom.SelectedValue == null ? "" : lbxFrom.SelectedValue.ToString();
            toletter = lbxTo.SelectedValue == null ? "" : lbxTo.SelectedValue.ToString();
            if (fromletter == "" || toletter == "")
            {
                MessageBox.Show("请填写正确的出发地和到达地！"); return;
            }
            method = "post";
            strReferer = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init";
            strArgs = "date="+dtpDate.Value.ToString("yyyy-MM-dd")+"&fromstation="+fromletter+"&tostation="+toletter+"&starttime=00%3A00--24%3A00";
            strURL = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=queryststrainall";
            string resSTA;//queryststrainall
            try
            {
                resSTA = request.PostData(strURL, strArgs, "get");
                string retSTA = resSTA.Substring(resSTA.IndexOf('|') + 1);
                if (string.IsNullOrEmpty(retSTA))
                { MessageBox.Show("没有对应车次！"); return; }
                JArray ja = JArray.Parse(retSTA);
                listTrain = new System.Collections.ArrayList();
                for (int i = 0; i < ja.Count;i++ )
                {
                    ListItem listItem = new ListItem();
                    listItem.TextField = ja[i]["value"] + "(" + ja[i]["start_station_name"] + ja[i]["start_time"] + "→" + ja[i]["end_station_name"] + ja[i]["end_time"] + ")";
                    listItem.ValueField = ja[i]["id"].ToString();
                    listTrain.Add(listItem);
                }
                cboTrainNum.DataSource = listTrain;
                cboTrainNum.DisplayMember = "TextField";
                cboTrainNum.ValueMember = "ValueField";
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.Message);
            }
        }
        //列表项对象
        public class ListItem
        {

            private string textField;

            public string TextField
            {
                get { return textField; }
                set { textField = value; }
            }

            private string valueField;

            public string ValueField
            {
                get { return valueField; }
                set { valueField = value; }
            }
        }
        int currentprogramsIndex = 0;
        //启动
        private void btnStart_Click(object sender, EventArgs e)
        {
            isRun = true;
            btnFromToAdd.Enabled = false;
            chxIsBuy.Enabled = false;
            btnStart.Enabled = false;
            numUD.Enabled = false;
            btnStop.Enabled = true;
            //Start();
            Thread th = new Thread(Start);
            th.IsBackground = true;
            th.Start();
        }
        private void Start()
        {
            if (programs[0, 0] == null)
            {
                MessageBox.Show("请先添加购票方案！");
                return;
            }         
            for (int i = 0; i < programs.GetLength(0)&&isRun; i++)
            {
                if (programs[i, 0] != null)
                {
                    toolStripStatusLabel1.Text = "正在查询余票...";
                    //querySingleAction Init  
                    method = "get";
                    strArgs = "";
                    strReferer = "https://dynamic.12306.cn/otsweb/loginAction.do?method=login";
                    strURL = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init";
                    string resQSAI = request.PostData(strURL, strArgs, "get");
                    //ueryLeftTicket
                    method = "get";
                    strArgs = "";
                    strReferer = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init";
                    strURL = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=queryLeftTicket&orderRequest.train_date=" + programs[i, 3] + "&orderRequest.from_station_telecode=" + fromletter + "&orderRequest.to_station_telecode=" + toletter + "&orderRequest.train_no=" + programs[i, 4] + "&trainPassType=QB&trainClass=QB%23D%23Z%23T%23K%23QT%23&includeStudent=00&seatTypeAndNum=&orderRequest.start_time_str=" + programs[i, 1];
                    string resLT;//queryLeftTicket
                    try
                    {
                        resLT = request.PostData(strURL, strArgs, "get");
                        string retLT = resLT.Substring(resLT.IndexOf('|') + 1);
                        if (string.IsNullOrEmpty(retLT))
                            continue;
                        // JObject jo = JObject.Parse(retLT);
                        string ja = retLT;
                        if (string.IsNullOrEmpty(ja))
                            continue;
                        if (ja == "-10")
                        {
                            MessageBox.Show("需要重新登陆！");
                            Application.Restart();
                            //gboLogin.Enabled = true;
                            //gboFromTo.Enabled = false;
                            //txtPassword.Text = "";
                            //randCode = "";
                            //Getpic();
                            //break;
                        }
                        string[] datas = ja.Split(',');

                        string scount = datas[int.Parse(programs[i, 5]) + 4];
                        int icount = 0;
                        if (int.TryParse(scount, out icount) || scount.Contains("有"))
                        {
                            toolStripStatusLabel1.Text = "已发现余票...";
                            string SubOrderArgStr = datas[16].Substring(datas[16].IndexOf('(') + 2, datas[16].IndexOf(')') - datas[16].IndexOf('(') - 3);//提交定单参数
                            string[] SubOrdArgs = SubOrderArgStr.Split('#');
                            programs[i, 11] = SubOrdArgs[0];
                            programs[i, 0] = SubOrdArgs[4];
                            programs[i, 2] = SubOrdArgs[5];
                            programs[i, 7] = SubOrdArgs[2];
                            programs[i, 8] = SubOrdArgs[6];
                            programs[i, 9] = SubOrdArgs[7];
                            programs[i, 10] = SubOrdArgs[8];
                            currentprogramsIndex = i;
                            string lefttickets = getTicketCountDesc(SubOrdArgs[11], GetSeatCode(programs[i, 5]));//余票数
                            if (buyticket)
                            {
                                //预定按钮  submutOrderRequest 
                                toolStripStatusLabel1.Text = "正在预定...";

                                //string confirmInit = 
                                //submutOrderRequest   
                                method = "post";
                                strReferer = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init";
                                strURL = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=submutOrderRequest";
                                strArgs = "station_train_code=" + programs[i, 11] + "&train_date=" + programs[i, 3] + "&seattype_num=&from_station_telecode=" + SubOrdArgs[4] + "&to_station_telecode=" + SubOrdArgs[5] + "&include_student=00&from_station_telecode_name=" + HttpUtility.UrlEncode(programs[i, 12], Encoding.UTF8).ToUpper() + "&to_station_telecode_name=" + HttpUtility.UrlEncode(programs[i, 13], Encoding.UTF8).ToUpper() + "&round_train_date=" + programs[i, 3] + "&round_start_time_str=00%3A00--24%3A00&single_round_type=1&train_pass_type=QB&train_class_arr=QB%23D%23Z%23T%23K%23QT%23&start_time_str=00%3A00--24%3A00&lishi=" + HttpUtility.UrlEncode(SubOrdArgs[1], Encoding.UTF8).ToUpper() + "&train_start_time=" + HttpUtility.UrlEncode(SubOrdArgs[2], Encoding.UTF8).ToUpper() + "&trainno4=" + SubOrdArgs[3] + "&arrive_time=" + HttpUtility.UrlEncode(SubOrdArgs[6], Encoding.UTF8).ToUpper() + "&from_station_name=" + HttpUtility.UrlEncode(SubOrdArgs[7], Encoding.UTF8).ToUpper() + "&to_station_name=" + HttpUtility.UrlEncode(SubOrdArgs[8], Encoding.UTF8).ToUpper() + "&from_station_no=" + SubOrdArgs[9] + "&to_station_no=" + SubOrdArgs[10] + "&ypInfoDetail=" + SubOrdArgs[11] + "&mmStr=" + SubOrdArgs[12] + "&locationCode=" + SubOrdArgs[13];
                                string resSOR = request.PostData(strURL, strArgs, "get");

                                //confirmInit
                                method = "get";
                                strArgs = "";
                                strReferer = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init";
                                strURL = "https://dynamic.12306.cn/otsweb/order/confirmPassengerAction.do?method=init";
                                string resCI = request.PostData(strURL, strArgs, "get");
                                string retCI = resCI.Substring(resCI.IndexOf('|') + 1);
                                if (retCI.Contains("leftTicketStr"))
                                {
                                    string leftTicket1 = retCI.Substring(retCI.IndexOf("id=\"left_ticket\""),70);
                                    leftTicketStr = leftTicket1.Substring(leftTicket1.IndexOf("value=\"") + 7, leftTicket1.IndexOf("\" />") - leftTicket1.IndexOf("value=\"")-7);
                                    htmlTOKEN = retCI.Substring(retCI.IndexOf("name=\"org.apache.struts.taglib.html.TOKEN\"")+50,32);
                                    //wbrws.ScriptErrorsSuppressed = true;
                                    //wbrws.DocumentText = retCI;
                                    ////交给窗体Load事件中DocumentCompleted事件处理
                                    MessageBox.Show("发现 " + programs[i, 11] + " 车有【" + programs[i, 6] + "】余票 " + lefttickets + "，请输入验证码提交定单！");
                                    GetSubpic();
                                    panel1.Enabled = true;
                                }
                                else
                                {
                                    MessageBox.Show("缺少数据：leftTicketStr");
                                }
                            }
                            else
                            {
                                MessageBox.Show("发现 " + programs[i, 11] + " 车有【" + programs[i, 6] + "】余票 " + lefttickets + "，请登陆12306网站购票！");
                            }
                            break;
                        }
                    }
                    catch (Exception e0)
                    { MessageBox.Show("queryLeftTicket：" + e0.Message); break; }
                }
                else
                {
                    Thread.Sleep(1000);
                    int numWait = (int)numUD.Value < 5 ? 5 : (int)numUD.Value;
                    
                    toolStripStatusLabel1.Text = "等待中...";
                    for (int j = 0; j < numWait; j++)
                    {
                        btnStart.Text = (numWait - j) + " 秒后刷新";
                        Thread.Sleep(1000);
                    }
                    btnStart.Text = " 刷新中...";
                    i = -1;
                    //MessageBox.Show("暂时末发现所需车票，请不要灰心。"); break;
                }
            }
            btnStop.Enabled = false;
            isRun = false;     

            btnStart.Text = "启 动";
            toolStripStatusLabel1.Text = "等待";
            btnStart.Enabled = true;        
            chxIsBuy.Enabled = true;
            numUD.Enabled = true;
            btnFromToAdd.Enabled = true;
        }
        //添加方案到列表
        private void btnFromToAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboTrainNum.Text.Trim()))
            {
                MessageBox.Show("请选择车次！");
                return;
            }
            if (cboSeat.SelectedIndex == 0)
            {
                MessageBox.Show("请选择席别！");
                return;
            }
            if (programs[programs.GetLength(0)-1, 0] != null)
            {
                MessageBox.Show("最多只能添加" + programs.GetLength(0) + "个！");
                return;
            }
            for (int i = 0; i < programs.GetLength(0); i++)
            {
                if (programs[i, 0] == null)
                {
                    programs[i, 7] = cboTrainNum.Text.Substring(cboTrainNum.Text.IndexOf('→') - 5, 5); //开车时间
                    programs[i, 8] = cboTrainNum.Text.Substring(cboTrainNum.Text.IndexOf(')') - 5, 5); //结束时间
                    programs[i, 9] = cboTrainNum.Text.Substring(cboTrainNum.Text.IndexOf('(') + 1, cboTrainNum.Text.IndexOf('→') - cboTrainNum.Text.IndexOf('(') - 6); //开始车站
                    programs[i, 10] = cboTrainNum.Text.Substring(cboTrainNum.Text.IndexOf('→') + 1, cboTrainNum.Text.IndexOf(')') - cboTrainNum.Text.IndexOf('→') - 6); //结束车站
                    programs[i, 11] = cboTrainNum.Text.Substring(0, cboTrainNum.Text.IndexOf('('));//车次

                    programs[i, 0] = GetStationCode(programs[i,9]);
                    programs[i, 1] = "00%3A00--24%3A00";
                    programs[i, 2] = GetStationCode(programs[i,10]);
                    programs[i, 3] = dtpDate.Value.ToString("yyyy-MM-dd");
                    programs[i, 4] = (string)cboTrainNum.SelectedValue; //车次ID
                    programs[i, 5] = (string)cboSeat.SelectedValue;
                    programs[i, 6] = cboSeat.Text; 
        
                    programs[i,12]=txtFrom.Text.Trim();//出发地
                    programs[i,13]=txtTo.Text.Trim();//到达地
                    break;
                }
            }
            lbxProgram.Items.Clear();
            for (int i = 0; i < programs.GetLength(0); i++)
            {
                if (programs[i, 0] != null)
                lbxProgram.Items.Add((i+1)+"、"+DateTime.Parse(programs[i,3]).Day+"日 "+programs[i,11]+" "+programs[i,6]+" "+programs[i,7]);
            }
            lbxProgram.Show();
        }

        private void lbxFrom_Click(object sender, EventArgs e)
        {
            txtFrom.Text = ((ListItem)lbxFrom.SelectedItem).TextField;
            lbxFrom.Visible = false;
        }

        private void txtFrom_KeyUp(object sender, KeyEventArgs e)
        {
            txtFrom.ForeColor = Color.Black;
            if (e.KeyCode == Keys.Enter && lbxFrom.Visible == true)
            {
                txtFrom.Text = ((ListItem)lbxFrom.SelectedItem).TextField;
                lbxFrom.Visible = false;
                return;
            }
            if (e.KeyCode == Keys.Down && lbxFrom.Visible == true&&lbxFrom.SelectedIndex<lbxFrom.Items.Count-1)
            {
                lbxFrom.SelectedIndex++;
                return;
            }
            if (e.KeyCode == Keys.Up && lbxFrom.Visible == true && lbxFrom.SelectedIndex >0)
            {
                lbxFrom.SelectedIndex--;
                return;
            }
            listFrom = new System.Collections.ArrayList();
            for (int i = 0; i < stations.GetLength(0); i++)
            {
                ListItem listItem = new ListItem();
                if (stations[i, 4].StartsWith(txtFrom.Text.Trim().ToLower()))
                {
                    listItem.TextField = stations[i, 1];
                    listItem.ValueField = stations[i, 2];
                    listFrom.Add(listItem);
                }
            }
            if (listFrom.Count > 0)
            {
                lbxFrom.DataSource = listFrom;
                lbxFrom.DisplayMember = "TextField";
                lbxFrom.ValueMember = "ValueField";
                lbxFrom.Visible = true;
            }
            else
            { lbxFrom.Visible = false; }
        }

        private void txtTo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lbxTo.Visible == true)
            {
                txtTo.Text = ((ListItem)lbxTo.SelectedItem).TextField;
                lbxTo.Visible = false;
                return;
            }
            if (e.KeyCode == Keys.Down && lbxTo.Visible == true && lbxTo.SelectedIndex < lbxTo.Items.Count - 1)
            {
                lbxTo.SelectedIndex++;
                return;
            }
            if (e.KeyCode == Keys.Up && lbxTo.Visible == true && lbxTo.SelectedIndex > 0)
            {
                lbxTo.SelectedIndex--;
                return;
            }
            listTo = new System.Collections.ArrayList();
            for (int i = 0; i < stations.GetLength(0); i++)
            {
                ListItem listItem = new ListItem();
                if (stations[i, 4].StartsWith(txtTo.Text.Trim().ToLower()))
                {
                    listItem.TextField = stations[i, 1];
                    listItem.ValueField = stations[i, 2];
                    listTo.Add(listItem);
                }
            }
            if (listTo.Count > 0)
            {
                lbxTo.DataSource = listTo;
                lbxTo.DisplayMember = "TextField";
                lbxTo.ValueMember = "ValueField";
                lbxTo.Visible = true;
            }
            else
            { lbxTo.Visible = false; }
        }

        private void lbxTo_Click(object sender, EventArgs e)
        {
            txtTo.Text = ((ListItem)lbxTo.SelectedItem).TextField;
            lbxTo.Visible = false;
        }

        private void txtFrom_Click(object sender, EventArgs e)
        { 
            txtFrom.SelectAll();
        }

        private void txtTo_Click(object sender, EventArgs e)
        {
            txtTo.SelectAll();
        }

        private void lbxProgram_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int posindex = lbxProgram.IndexFromPoint(new Point(e.X, e.Y));
                lbxProgram.ContextMenuStrip = null;
                if (posindex >= 0 && posindex < lbxProgram.Items.Count)
                {
                    lbxProgram.SelectedIndex = posindex;
                    //contextMenuStrip1.Show(lbxProgram, new Point(e.X, e.Y));
                }
                else
                {
                    contextMenuStrip2.Show(lbxProgram, new Point(e.X, e.Y));
                }
            }
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbxProgram.Items.Clear();
            programs = new string[10, 14];
        }

        private void chxIsBuy_CheckedChanged(object sender, EventArgs e)
        {
            if (chxIsBuy.Checked)
            {
                panel1.Visible = true;
                buyticket = true;
                //picRandCode.Visible = true;
                //txtRandCode.Visible = true;
                //btnSubmit.Visible = true;
            }
            else 
            {
                panel1.Visible = false;
                buyticket = false;
                //picRandCode.Visible = false;
                //txtRandCode.Visible = false;
                //btnSubmit.Visible = false;
            }
        }
        //提交定单
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(Submint);
            th.IsBackground = true;
            th.Start();
        }
        private void Submint()
        {
            if (txtRandCode.Text.Trim() == "")
            {
                MessageBox.Show("请输入验证码！");
                return;
            }
            if (string.IsNullOrEmpty(leftTicketStr) || string.IsNullOrEmpty(htmlTOKEN))
            {
                MessageBox.Show("预定失败！");
                return;
            }
            string oldPassengers = "";
            string passengerTickets = "";

            string passenger_seat = GetSeatCode(programs[currentprogramsIndex, 5]);   //多人购票，席别在些一致
            string passenger_ticket = "1"; //（成人票）票种默认
            string orderRequest_train_no = programs[currentprogramsIndex, 4]; //车次ID
            string orderRequest_from_station_name = HttpUtility.UrlEncode(programs[currentprogramsIndex, 9], Encoding.UTF8).ToUpper();
            string orderRequest_from_station_telecode = programs[currentprogramsIndex, 0];
            string orderRequest_start_time = HttpUtility.UrlEncode(programs[currentprogramsIndex, 7], Encoding.UTF8).ToUpper();
            string orderRequest_to_station_name = HttpUtility.UrlEncode(programs[currentprogramsIndex, 10], Encoding.UTF8).ToUpper();
            string orderRequest_to_station_telecode = programs[currentprogramsIndex, 2];
            string orderRequest_end_time = HttpUtility.UrlEncode(programs[currentprogramsIndex, 8], Encoding.UTF8).ToUpper();
            string orderRequest_train_date = programs[currentprogramsIndex, 3];
            string orderRequest_station_train_code = programs[currentprogramsIndex, 11];//车次

            string randcode = txtRandCode.Text.Trim();

            //string checkOrderInfo = "org.apache.struts.taglib.html.TOKEN=11758e81d34fdeb261d904589f8cd19f&leftTicketStr=O010550485M012650036O010553084&textfield=%E4%B8%AD%E6%96%87%E6%88%96%E6%8B%BC%E9%9F%B3%E9%A6%96%E5%AD%97%E6%AF%8D&checkbox0=0&orderRequest.train_date=2013-03-06&orderRequest.train_no=4e0000D66400&orderRequest.station_train_code=D664&orderRequest.from_station_telecode=WHN&orderRequest.to_station_telecode=HFH&orderRequest.seat_type_code=&orderRequest.ticket_type_order_num=&orderRequest.bed_level_order_num=000000000000000000000000000000&orderRequest.start_time=05%3A54&orderRequest.end_time=08%3A13&orderRequest.from_station_name=%E6%AD%A6%E6%B1%89&orderRequest.to_station_name=%E5%90%88%E8%82%A5&orderRequest.cancel_flag=1&orderRequest.id_mode=Y&passengerTickets=O%2C0%2C1%2C%E5%AD%99%E5%A4%A7%E9%81%93%2C1%2C429006196208074511%2C13508713350%2CY&oldPassengers=%E5%AD%99%E5%A4%A7%E9%81%93%2C1%2C429006196208074511&passenger_1_seat=O&passenger_1_ticket=1&passenger_1_name=%E5%AD%99%E5%A4%A7%E9%81%93&passenger_1_cardtype=1&passenger_1_cardno=429006196208074511&passenger_1_mobileno=13508713350&checkbox9=Y&oldPassengers=&checkbox9=Y&oldPassengers=&checkbox9=Y&oldPassengers=&checkbox9=Y&oldPassengers=&checkbox9=Y&randCode=4y3b&orderRequest.reserve_flag=A";
            string checkOrderInfo = "org.apache.struts.taglib.html.TOKEN=" + htmlTOKEN + "&leftTicketStr=" + leftTicketStr + "&textfield=%E4%B8%AD%E6%96%87%E6%88%96%E6%8B%BC%E9%9F%B3%E9%A6%96%E5%AD%97%E6%AF%8D&orderRequest.train_date=" + orderRequest_train_date + "&orderRequest.train_no=" + orderRequest_train_no + "&orderRequest.station_train_code=" + orderRequest_station_train_code + "&orderRequest.from_station_telecode=" + orderRequest_from_station_telecode + "&orderRequest.to_station_telecode=" + orderRequest_to_station_telecode + "&orderRequest.seat_type_code=&orderRequest.ticket_type_order_num=&orderRequest.bed_level_order_num=000000000000000000000000000000&orderRequest.start_time=" + orderRequest_start_time + "&orderRequest.end_time=" + orderRequest_end_time + "&orderRequest.from_station_name=" + orderRequest_from_station_name + "&orderRequest.to_station_name=" + orderRequest_to_station_name + "&orderRequest.cancel_flag=1&orderRequest.id_mode=Y&checkbox9=Y&checkbox9=Y&checkbox9=Y&checkbox9=Y&checkbox9=Y&randCode=" + randcode + "&orderRequest.reserve_flag=A";
            // checkOrderInfo = checkOrderInfa;
            for (int i = 0; i < passengers.Count; i++)
            {
                checkOrderInfo += "&checkbox" + i + "=" + i;
                checkOrderInfo += "&passenger_" + (i + 1) + "_seat=" + passenger_seat;
                checkOrderInfo += "&passenger_" + (i + 1) + "_ticket=" + passenger_ticket;
                checkOrderInfo += "&passenger_" + (i + 1) + "_name=" + HttpUtility.UrlEncode(passengers[i].passenger_name, Encoding.UTF8).ToUpper();
                checkOrderInfo += "&passenger_" + (i + 1) + "_cardtype=" + passengers[i].passenger_id_type_code;
                checkOrderInfo += "&passenger_" + (i + 1) + "_cardno=" + passengers[i].passenger_id_no;
                checkOrderInfo += "&passenger_" + (i + 1) + "_mobileno=" + passengers[i].mobile_no;
                oldPassengers = HttpUtility.UrlEncode(passengers[i].passenger_name, Encoding.UTF8).ToUpper() + "%2C" + passengers[i].passenger_id_type_code + "%2C" + passengers[i].passenger_id_no;
                passengerTickets = passenger_seat + "%2C0%2C" + passenger_ticket + "%2C" + HttpUtility.UrlEncode(passengers[i].passenger_name, Encoding.UTF8).ToUpper() + "%2C" + passengers[i].passenger_id_type_code + "%2C" + passengers[i].passenger_id_no + "%2C" + passengers[i].mobile_no + "%2CY";
                checkOrderInfo += "&passengerTickets=" + passengerTickets;
                checkOrderInfo += "&oldPassengers=" + oldPassengers;
            }
            for (int i = 0; i < 5 - passengers.Count; i++)
            {
                checkOrderInfo += "&oldPassengers=";
            }
            try
            {
                //提交定单按钮   
                //checkOrderInfo      {"checkHuimd":"Y","check608":"Y","msg":"","errMsg":"Y"}   {"checkHuimd":"N","check608":"Y","msg":"对不起，由于您取消次数过多，今日将不能继续受理您的订票请求！","errMsg":"Y"}
                toolStripStatusLabel1.Text = "正在提交定单...";
                method = "post";
                strReferer = "https://dynamic.12306.cn/otsweb/order/confirmPassengerAction.do?method=init";
                strURL = "https://dynamic.12306.cn/otsweb/order/confirmPassengerAction.do?method=checkOrderInfo&rand=" + randcode;
                strArgs = checkOrderInfo + "&tFlag=dc";
                string resCOI = request.PostData(strURL, strArgs, "get");
                string retCOI = resCOI.Substring(resCOI.IndexOf('|') + 1);
                if (string.IsNullOrEmpty(retCOI))
                {
                    MessageBox.Show("请求失败：checkOrderInfo");
                    return;
                }
                JObject jCOI = JObject.Parse(retCOI);
                string checkHuimd = jCOI["checkHuimd"].ToString();
                string check608 = jCOI["check608"].ToString();
                string errMsg = jCOI["errMsg"].ToString();
                string msg = jCOI["msg"].ToString();
                if (checkHuimd != "Y" || check608 != "Y" || errMsg != "Y" || msg != "")
                {
                    MessageBox.Show("checkOrderInfo:" + (checkHuimd + check608 + errMsg + msg).Replace("Y", ""));
                    GetSubpic();
                    return;
                }
                //getQueueCount   {"countT":0,"count":0,"ticket":"1*****30444*****00011*****00003*****0055","op_1":false,"op_2":false}
                toolStripStatusLabel1.Text = "正在获取队列数量...";
                method = "get";
                strArgs = "";
                strURL = "https://dynamic.12306.cn/otsweb/order/confirmPassengerAction.do?method=getQueueCount&train_date=" + programs[currentprogramsIndex, 3] + "&train_no=" + programs[currentprogramsIndex, 4] + "&station=" + programs[currentprogramsIndex, 11] + "&seat=" + GetSeatCode(programs[currentprogramsIndex, 5]) + "&from=" + programs[currentprogramsIndex, 0] + "&to=" + programs[currentprogramsIndex, 2] + "&ticket=" + leftTicketStr;     
                string resGQC = request.PostData(strURL, strArgs, "get");
                string retGQC = resGQC.Substring(resGQC.IndexOf('|') + 1);
                if (string.IsNullOrEmpty(retGQC))
                {
                    MessageBox.Show("请求失败：getQueueCount");
                    return;
                }
                JObject jGQC = JObject.Parse(retGQC);
                string count = jGQC["count"].ToString();
                bool op_2 = bool.Parse(jGQC["op_2"].ToString());
                if (op_2)
                {
                    MessageBox.Show("目前排队人数已经超过余票张数，请您选择其他席别或车次，特此提醒。");
                    toolStripStatusLabel1.Text = "等待";
                    return;
                }
                //确认定单框中的确定按钮
                //confirmSingleForQueue       {"errMsg":"Y"}
                toolStripStatusLabel1.Text = "正在确认定单（下定单）...";
                System.Threading.Thread.Sleep(1500);
                method = "post";
                strURL = "https://dynamic.12306.cn/otsweb/order/confirmPassengerAction.do?method=confirmSingleForQueue";
                strArgs = checkOrderInfo;
                string resGFQ = request.PostData(strURL, strArgs, "get");
                string retGFQ = resGFQ.Substring(resGFQ.IndexOf('|') + 1);
                if (string.IsNullOrEmpty(retGFQ))
                {
                    MessageBox.Show("请求失败：confirmSingleForQueue");
                    return;
                }
                JObject jGFQ = JObject.Parse(retGFQ);
                string GFQ_errMsg = jGFQ["errMsg"].ToString();
                if (GFQ_errMsg != "Y")
                {
                    MessageBox.Show("confirmSingleForQueue:" + GFQ_errMsg);
                    GetSubpic();
                    toolStripStatusLabel1.Text = "等待";
                    return;
                }
                //queryOrderWaitTime       {"tourFlag":"dc","waitTime":-1,"waitCount":0,"orderId":"E744949127","requestId":5712441674113765581,"count":0}
                toolStripStatusLabel1.Text = "获取等待时间...";
            OrderWait:
                method = "get";
                strURL = "https://dynamic.12306.cn/otsweb/order/myOrderAction.do?method=queryOrderWaitTime&tourFlag=dc";
                strArgs = "";
                string resOWT = request.PostData(strURL, strArgs, "get");
                string retOWT = resOWT.Substring(resOWT.IndexOf('|') + 1);
                if (string.IsNullOrEmpty(retOWT))
                {
                    MessageBox.Show("请求失败：queryOrderWaitTime");
                    return;
                }
                JObject jOWT = JObject.Parse(retOWT);
                string waitTime = jOWT["waitTime"].ToString();
                string waitCount = jOWT["waitCount"].ToString();
                if (waitTime == "-1" && waitCount == "0")
                {
                    toolStripStatusLabel1.Text = "订票成功";
                    MessageBox.Show("恭喜！订票成功，请速去12306网站付款！");
                }
                else
                {
                    goto OrderWait;
                }
            }
            catch (Exception e0)
            { MessageBox.Show("错误：" + e0.Message); }
        }
        private void picRandCode_Click(object sender, EventArgs e)
        {
            GetSubpic();
        }
        //解析各余票数ticketsStr
        private string getTicketCountDesc(string mark, string seat)
        {
            string rt="";
            int seat_1=-1;
            int seat_2=-1;
            int i=0;
            while(i<mark.Length)
            {
                string s=mark.Substring(i,10);
                string c_seat=s.Substring(0,1);
                if (c_seat == seat)
                {
                    string count = s.Substring(6, 4);
                    //while(count.Length>1&&count.Substring(0,1)=="0")
                    //{
                    //    count=count.Substring(1,count.Length);
                    //}
                    int icount = int.Parse(count);
                    if (icount < 3000)
                    {
                        seat_1 = icount;
                    }
                    else
                    {
                        seat_2 = icount - 3000;
                    }
                }
                i=i+10;
            }
            if(seat_1>-1)
                rt+=seat_1+"张";
            if (seat_2 > -1)
                rt += "，无座" + seat_2+"张";
            return rt;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isRun = false;
            btnStop.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Getpic();
        }

        int tabindex = 101;
        private void picCode_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
           // MessageBox.Show(e.X+"-" +e.Y);
            randCode += e.X+",";
            randCode += (e.Y-30)+",";
        }

    }
}
