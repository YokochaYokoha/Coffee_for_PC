﻿using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coffee
{
    public partial class Form1 : Form
    {
        private string returnbousi = "0";
        private string keijokioku = "0";
        Form2 mkqr;
        Form3 tokei;
        Form4 bunri;
        Form5 osl;
        Form6 thx;
        private System.Diagnostics.Process exts = new System.Diagnostics.Process();
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Profile.ClearBrowsingDataAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            { 
            panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void kanketsu(object sender,CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true;
            webView21.CoreWebView2.Navigate(e.Uri);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoBack();
            
        }

        private void webView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webView21.CoreWebView2.NewWindowRequested += kanketsu;
            timer2.Enabled = true;
            fullscdetect.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
          //QRコード生成from速作成QR
            mkqr = new Form2();
            mkqr.label1.Text = "https://api.qrserver.com/v1/create-qr-code/?data=" + webView21.CoreWebView2.Source;
            mkqr.Show();
        }

        private void time_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            label1.Text = now.ToString("tthh:mm:ss");
            label3.Text = now.ToLongDateString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://yokochayokoha.github.io/CoffeeSub");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoForward();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Reload();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProcessStartInfo gobr = new ProcessStartInfo();
            gobr.FileName = webView21.CoreWebView2.Source;
            gobr.UseShellExecute = true;
            Process.Start(gobr);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(webView21.CoreWebView2.Source, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(webView21.CoreWebView2.DocumentTitle,true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            temp4session.Text = Properties.Settings.Default.last;
            textBox1.Text = Properties.Settings.Default.lasttitle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tokei = new Form3();
            tokei.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            notifyIcon2.BalloonTipTitle = "サイト翻訳機能";
            notifyIcon2.BalloonTipText = "メイン画面のURLをサイト翻訳URLに自動でセットしました。移動しています...";
            notifyIcon2.ShowBalloonTip(6);
            if (domainUpDown1.Text == "日本語から英語")
            {
                string ur = webView21.CoreWebView2.Source;
                string moto = "https://translate.google.com/translate?sl=ja&tl=en&u=";
                webView21.CoreWebView2.Navigate(moto + ur);
            }
            else if (domainUpDown1.Text == "英語から日本語")
            {
                string ur = webView21.CoreWebView2.Source;
                string moto = "https://translate.google.com/translate?sl=en&tl=ja&u=";
                webView21.CoreWebView2.Navigate(moto + ur);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            notifyIcon2.BalloonTipTitle = "サイト翻訳機能";
            notifyIcon2.BalloonTipText = "EdgeSearchURLをサイト翻訳URLに自動でセットしました。移動しています...";
            notifyIcon2.ShowBalloonTip(6);

            if (domainUpDown1.Text == "日本語から英語")
            {
                string ur = webView21.CoreWebView2.Source;
                string moto = "https://translate.google.com/translate?sl=ja&tl=en&u=";
              /*  bunri =new Form4();
                bunri.label1.Text = moto + ur;
                bunri.Show();
              */
             webView22.CoreWebView2.Navigate(moto + ur);
            }
            else if (domainUpDown1.Text == "英語から日本語")
            {
                string ur = webView21.CoreWebView2.Source;
                string moto = "https://translate.google.com/translate?sl=en&tl=ja&u=";
              /*  bunri = new Form4();
                bunri.label1.Text = moto + ur;
                bunri.Show();
              */
                webView22.CoreWebView2.Navigate(moto + ur);
            }
            if (webView22.Visible == false)
            {
                ESshowhide();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            osl=new Form5();
            osl.Show();
        }

        private void kagemusya_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate(receiver.Text);
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            Properties.Settings.Default.last = webView21.CoreWebView2.Source;
            Properties.Settings.Default.lasttitle = webView21.CoreWebView2.DocumentTitle;
            Properties.Settings.Default.Save();
            timer2.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled= false;
            webView21.CoreWebView2.Navigate(Properties.Settings.Default.last);

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.last = webView21.CoreWebView2.Source;
            Properties.Settings.Default.lasttitle = webView21.CoreWebView2.DocumentTitle;
            Properties.Settings.Default.Save();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate(temp4session.Text);


        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
            if (domainUpDown2.Text == "iOS16")
            {
                textBox2.Text = "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.0 Mobile/15E148 Safari/604.1";
            }
            else if (domainUpDown2.Text == "Chrome(116)")
            {
                textBox2.Text = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36";
            }
            else if (domainUpDown2.Text == "Safari(16)")
            {
                textBox2.Text = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.3 Safari/605.1.15";
            }
            else if (domainUpDown2.Text == "Firefox(117)")
            {
                textBox2.Text = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/119.0";
            }
            else if (domainUpDown2.Text == "Android™13 Tiramisu")
            {
                textBox2.Text = "Mozilla/5.0 (Linux; Android 13; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Mobile Safari/537.36";
            }
            else
            {
                //例外処理です
                textBox2.Text = "";
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            bunri = new Form4();
            bunri.label1.Text = webView21.CoreWebView2.Source;
            bunri.Show();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox2.Text!="")
            {
                webView21.CoreWebView2.Settings.UserAgent=textBox2.Text;
                webView21.CoreWebView2.Reload();
            }
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("簡易広告ブロック機能を有効化しました。このメッセージを閉じると適用され、ページが更新されます。この機能の使用によって多くのサイトで正常に閲覧できなります。金銭取引に関わるサイトでは絶対に使用しないでください。この機能を使用したことで発生した全ての事柄について製作者は一切の責任を負いかねます。ご利用の際は十分に注意してください。");

                webView21.CoreWebView2.Settings.IsScriptEnabled = false;
                webView21.CoreWebView2.Reload();
            }
            else
            {
                MessageBox.Show("簡易広告ブロック機能を無効化しました。");

                webView21.CoreWebView2.Settings.IsScriptEnabled = true;
                webView21.CoreWebView2.Reload();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.OpenDefaultDownloadDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.ShowPrintUI();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.OpenTaskManagerWindow();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.CookieManager.DeleteAllCookies();
            MessageBox.Show("Cookieの削除が完了しました。");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.OpenDevToolsWindow();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2.Source.Contains("outube"))
            {
                if (webView21.CoreWebView2.Source.Contains("watch?v="))
                {
                    //[Recreation:Android Coffee]YouTubeID extractor script Developed by YokochaYokoha  ©YokochaYokoha All Rights Reserved.
                    try
                    {
                        string term1 = webView21.CoreWebView2.Source.Replace("youtu.be/", "");
                        string term2 = term1.Replace("embed/", "");
                        string term3 = term2.Replace("https://www.youtube.com/", "");
                        string term4 = term3.Replace("http://m.youtube.com/", "");
                        string term5 = term4.Replace("watch?v=", "");
                        string term6 = term5.Replace("&feature=emb_rel_pause", "");
                        string term7 = term6.Replace("&feture=emb_rel_pause", "");
                        string term8 = term7.Replace("https://", "");
                        string ID = term8.Substring(0, 11);
                        //make comments window instance
                        bunri = new Form4();
                        bunri.TopMost = false;
                        bunri.label1.Text = "https://www.youtube.com/live_chat?v=" + ID;
                        bunri.Show();
                        MessageBox.Show("チャット枠をポップアップ表示しました。この機能はライブ配信動画でのみ正常に動作します。通常の動画では動作しません。");
                    }
                    catch (Exception ex)
                    {
                        //例外処理
                        MessageBox.Show("例外が発生しました。非対応のURLである可能性があります。開発者向けコード:" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("非対応のサイトです。YouTubeのライブ配信動画のみ対応しています。");
                }
            }
            else
            {
                MessageBox.Show("非対応のサイトです。YouTubeのライブ配信動画のみ対応しています。");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2.Source.Contains("outube"))
            {
                if (webView21.CoreWebView2.Source.Contains("watch?v="))
                {
                    //[Recreation:Android Coffee]YouTubeID extractor script Developed by YokochaYokoha  ©YokochaYokoha All Rights Reserved.
                    try
                    {
                        string term1 = webView21.CoreWebView2.Source.Replace("youtu.be/", "");
                        string term2 = term1.Replace("embed/", "");
                        string term3 = term2.Replace("https://www.youtube.com/", "");
                        string term4 = term3.Replace("http://m.youtube.com/", "");
                        string term5 = term4.Replace("watch?v=", "");
                        string term6 = term5.Replace("&feature=emb_rel_pause", "");
                        string term7 = term6.Replace("&feture=emb_rel_pause", "");
                        string term8 = term7.Replace("https://", "");
                        string ID = term8.Substring(0, 11);
                        //make comments window instance
                        bunri = new Form4();
                        bunri.TopMost = true;
                        bunri.label1.Text = "https://www.youtube.com/live_chat?v=" + ID;
                        bunri.Show();
                        MessageBox.Show("チャット枠をポップアップ表示しました。この機能はライブ配信動画でのみ正常に動作します。通常の動画では動作しません。");
                    }
                    catch (Exception ex)
                    {
                        //例外処理
                        MessageBox.Show("例外が発生しました。非対応のURLである可能性があります。開発者向けコード:" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("非対応のサイトです。YouTubeのライブ配信動画のみ対応しています。");
                }
            }
            else
            {
                MessageBox.Show("非対応のサイトです。YouTubeのライブ配信動画のみ対応しています。");
            }
        }

        private void receiver_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://yokochayokoha.github.io/CoffeeSub/read");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Text = "Coffee for PC Ver.2.0  ||  " + webView21.CoreWebView2.DocumentTitle + "  ||  " + webView21.CoreWebView2.Source;
            textBox3.Text = webView21.CoreWebView2.Source;
            if (webView22.Visible)
            {
                textBox4.Text = webView22.CoreWebView2.Source;
            }
            else
            {
                textBox4.Text = "EdgeSearch";
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            thx=new Form6();
            thx.Show();
        }

        private void interval_Tick(object sender, EventArgs e)
        {

           //not inuse
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel5.Visible = false;
            panel13.Visible = false;
            this.FormBorderStyle = FormBorderStyle.None;
            notifyIcon1.ShowBalloonTip(5);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            panel13.Visible = true;
            panel5.Visible = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.OpenDefaultDownloadDialog();
        }

        private void button33_Click(object sender, EventArgs e)
        {
               webView21.CoreWebView2.Reload();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoBack();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://yokochayokoha.github.io/CoffeeSub");
            //HP変更機能は後ほど
        }

        private void button31_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoBack();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.SelectAll();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.DeselectAll();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {

            textBox3.SelectAll();
            timer2.Enabled = false;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (panel13.Visible)
            {
                panel13.Visible = false;
            }
            else
            { 
            panel13.Visible=true;
            }
        }
        private void ESshowhide()
        {
            if (webView22.Visible)
            {
                webView22.Visible = false;
            }
            else
            {
                notifyIcon2.BalloonTipTitle = "EdgeSearch利用案内";
                notifyIcon2.BalloonTipText = "EdgeSearchは画面上部専用ボタンにて操作できます。";
                notifyIcon2.ShowBalloonTip(6);
                webView22.Visible = true;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
           ESshowhide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.SelectAll();
            timer2.Enabled = false;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            webView22.CoreWebView2.OpenDefaultDownloadDialog();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
    
            if (e.KeyChar==(char)Keys.Enter)
            { 
                if (textBox3.Text == webView21.CoreWebView2.Source)
                {
                    //do nothing!なーんにもしない!
                }
                else if (textBox3.Text.Contains("."))
                {
                    if (textBox3.Text.Contains("http"))
                    {
                        //URLキタ!
                        webView21.CoreWebView2.Navigate(textBox3.Text);
                    }
                    else
                    {
                        webView21.CoreWebView2.Navigate("https://"+textBox3.Text);
                    }
                }
                else
                {
                    //ユーザー入力文字列変数usr→URLエンコード処理済みはusr6に格納。
                    string usr = this.textBox3.Text;
                    string usr2 = usr.Replace("+", "%2B");
                    string usr3 = usr2.Replace("　", "+");
                    string usr4 = usr3.Replace(" ", "+");
                    string usr5 = usr4.Replace("#", "%23");
                    string usr6 = usr5.Replace("*", "%2A");
                    //先頭付加用検索エンジンURL(Google)
                    string baseline = "https://www.google.com/search?q=";
                    webView21.CoreWebView2.Navigate(baseline + usr6);
                    //自動検索開始
                   
                }

            }
      

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
  
                if (textBox4.Text == webView22.CoreWebView2.Source)
                {
                    //do nothing!なーんにもしない!
                }
                else if (textBox4.Text.Contains("."))
                {
                    //URLキタ!
                    if (textBox4.Text.Contains("http"))
                    {
                        //URLキタ!
                        webView21.CoreWebView2.Navigate(textBox4.Text);
                    }
                    else
                    {
                        webView21.CoreWebView2.Navigate("https://" + textBox4.Text);
                    }
                }
                else
                {
                    //ユーザー入力文字列変数usr→URLエンコード処理済みはusr6に格納。
                    string usr = this.textBox4.Text;
                    string usr2 = usr.Replace("+", "%2B");
                    string usr3 = usr2.Replace("　", "+");
                    string usr4 = usr3.Replace(" ", "+");
                    string usr5 = usr4.Replace("#", "%23");
                    string usr6 = usr5.Replace("*", "%2A");
                    //先頭付加用検索エンジンURL(Google)
                    string baseline = "https://www.google.com/search?q=";
                    webView22.CoreWebView2.Navigate(baseline + usr6);
                    //自動検索開始

                }

            }
          
        }

        private void textBox3_Leave_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void webView22_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            timer2.Enabled = true;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2.Source.Contains("outube"))
            {
                if (webView21.CoreWebView2.Source.Contains("watch?v="))
                {
                    //[Recreation:Android Coffee]YouTubeID extractor script Developed by YokochaYokoha  ©YokochaYokoha All Rights Reserved.
                    try
                    {
                        string term1 = webView21.CoreWebView2.Source.Replace("youtu.be/", "");
                        string term2 = term1.Replace("embed/", "");
                        string term3 = term2.Replace("https://www.youtube.com/", "");
                        string term4 = term3.Replace("http://m.youtube.com/", "");
                        string term5 = term4.Replace("watch?v=", "");
                        string term6 = term5.Replace("&feature=emb_rel_pause", "");
                        string term7 = term6.Replace("&feture=emb_rel_pause", "");
                        string term8 = term7.Replace("https://", "");
                        string ID = term8.Substring(0, 11);
                        webView22.Visible = true;
                        webView22.CoreWebView2.Navigate("https://www.youtube.com/live_chat?v=" + ID);

                      
 
                        MessageBox.Show("チャット枠をEdgeSearchに表示しました。この機能はライブ配信動画でのみ正常に動作します。通常の動画では動作しません。");
                    }
                    catch (Exception ex)
                    {
                        //例外処理
                        MessageBox.Show("例外が発生しました。非対応のURLである可能性があります。開発者向けコード:" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("非対応のサイトです。YouTubeのライブ配信動画のみ対応しています。");
                }
            }
            else
            {
                MessageBox.Show("非対応のサイトです。YouTubeのライブ配信動画のみ対応しています。");
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            webView22.CoreWebView2.GoBack();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            webView22.CoreWebView2.Navigate("https://yokochayokoha.github.io/fastportal");
        }

        private void button38_Click(object sender, EventArgs e)
        {
            webView22.CoreWebView2.GoForward();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            webView22.CoreWebView2.Reload();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            bunri = new Form4();
            bunri.label1.Text = webView22.CoreWebView2.Source;
            bunri.Show();
        }

        private void webView23_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
     
        }

        private void webView23_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            textBox5.Text = webView23.CoreWebView2.DocumentTitle;
          
        }

        private void button44_Click(object sender, EventArgs e)
        {
            notifyIcon2.BalloonTipTitle = "EdgeSearch転送操作";
            notifyIcon2.BalloonTipText = "EdgeSearchとメイン画面のURLを相互転送(交換)します。";
            notifyIcon2.ShowBalloonTip(5);
            string swap1 = webView21.CoreWebView2.Source;
            string swap2= webView22.CoreWebView2.Source;
            webView21.CoreWebView2.Navigate(swap2);
            webView22.CoreWebView2.Navigate(swap1);
        }

        private void tensointervaltimer_Tick(object sender, EventArgs e)
        {

        }

        private void button46_Click(object sender, EventArgs e)
        {
            MessageBox.Show("各配布元からダウンロードした拡張機能(exe)を、Coffee for PCの実行ファイル(exe)があるディレクトリ(フォルダ)内に移動してください。ダウンロードした拡張機能のファイル名(例:kinou.exe)の拡張子部分を除いた連携先名(例ではkinouとなります)を入力し、連携ボタンを押すことで、拡張機能を利用できるようになります。");
        }

        private void button45_Click(object sender, EventArgs e)
        {
            try
            {
                string currenturl=webView21.CoreWebView2.Source;
                string currenttitle = webView21.CoreWebView2.DocumentTitle;
                string escu=webView22.CoreWebView2.Source;
                string esct = webView22.CoreWebView2.DocumentTitle;
                string renkeisaki = textBox6.Text;

                string compatiblever = "1";
                //このcompatibleverの値で、送られる情報数をコントロールします。
                //現在はVer.1なので、9の順で引数としてMainのArgs [1]番で取得できる一行の文字列で送信されます。
                //この並び順に変更を加えた場合(Ver.1も順番は基礎なので変わらない...と思います)、Ver番号が上がります。変更した場合はその都度報告します!
                exts.StartInfo.FileName = ".\\"+renkeisaki+".exe";
                exts.StartInfo.WorkingDirectory = ".\\\\";
                exts.StartInfo.Arguments = currenturl+"C4P:value:"+currenttitle+ "C4P:value:"+escu+ "C4P:value:"+esct+ "C4P:value:"+compatiblever;
                exts.Start();
         
            }
            catch
            {
                MessageBox.Show("拡張機能を開けません。恐れ入りますが、拡張機能が正しく配置されているか(詳しくは使い方ボタンをクリックしてください)、または連携先名が正しく入力されているかを再度ご確認ください。");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://github.com/topics/coffeeextensions");
        }

        private void button47_Click(object sender, EventArgs e)
        {
            MessageBox.Show("[ブラウジングBGM機能]Wav形式の音楽ファイルを選択してください。");
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "すべてのファイル|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
              string path = dialog.FileName;
             webView22.CoreWebView2.Navigate(path);
            }
        }

        private void fullscdetect_Tick(object sender, EventArgs e)
        {

            if (webView21.CoreWebView2.ContainsFullScreenElement)
            {

                if (returnbousi == "0")
                {
                    notifyIcon2.BalloonTipTitle = "全画面コンテンツ表示中";
                    notifyIcon2.BalloonTipText = "全画面コンテンツが終了すると自動的に元に戻ります。";
                    notifyIcon2.ShowBalloonTip(5);
                    if (panel1.Visible)
                    {
                       keijokioku = "1";
                    }
                    else
                    {
                        keijokioku = "0";
                    }
                }

                this.WindowState = FormWindowState.Maximized;
                panel1.Visible = false;
                panel5.Visible = false;
                panel13.Visible = false;
                this.FormBorderStyle = FormBorderStyle.None;
               
                returnbousi = "1";
            }
            else
            {
                if (returnbousi == "1")
                {
                    this.WindowState = FormWindowState.Normal;
                    if (keijokioku == "1")
                    {
                        panel1.Visible = true;
                    }
                    panel5.Visible = true;
                    panel13.Visible = true;
                    this.FormBorderStyle = FormBorderStyle.Sizable;


                    returnbousi = "0";
                }
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (fullscdetect.Enabled)
            {
                fullscdetect.Enabled = false;
                MessageBox.Show("全画面自動移行を無効化しました。動画サイト上のコンテンツを全画面表示するボタンを押した際の動作を無視します。");
            }
            else
            {
                fullscdetect.Enabled = true;
                MessageBox.Show("全画面自動移行を有効化しました。");
            }
        }
        private void kanketsu2(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true;
            webView22.CoreWebView2.Navigate(e.Uri);
        }
        private void webView22_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webView22.CoreWebView2.NewWindowRequested += kanketsu2;
        }

        private void updater_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            //アップデート確認スクリプト Ported from Coffee App
            //©YokochaYokoha
            if (updater.CoreWebView2.DocumentTitle.Contains("C4P"))
            {
                if (version.Text.Replace("Ver.","") != updater.CoreWebView2.DocumentTitle.Replace("C4P",""))//比較フォーム化
                {
                    string currentver = version.Text.Replace("Ver.", "");
                    string newver = updater.CoreWebView2.DocumentTitle.Replace("C4P", "");
                    MessageBox.Show("[現在:Ver."+currentver+"/最新版:Ver."+newver+"]"+"Coffee for PCのアップデートが利用可能です!不具合修正等のアップデートも含まれる場合があります!アップデートをお願い致します!");
                    //自動アップデート機能は今後実装するかもです....
                }
            }
        }
    }
    }

