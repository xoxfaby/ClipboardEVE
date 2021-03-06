﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

using Microsoft.Win32;

using System.Net;
using System.Collections.Specialized;

using System.Data.SqlClient;

namespace ClipboardEVE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum Msgs
	{
		WM_NULL                   = 0x0000,
		WM_CREATE                 = 0x0001,
		WM_DESTROY                = 0x0002,
		WM_MOVE                   = 0x0003,
		WM_SIZE                   = 0x0005,
		WM_ACTIVATE               = 0x0006,
		WM_SETFOCUS               = 0x0007,
		WM_KILLFOCUS              = 0x0008,
		WM_ENABLE                 = 0x000A,
		WM_SETREDRAW              = 0x000B,
		WM_SETTEXT                = 0x000C,
		WM_GETTEXT                = 0x000D,
		WM_GETTEXTLENGTH          = 0x000E,
		WM_PAINT                  = 0x000F,
		WM_CLOSE                  = 0x0010,
		WM_QUERYENDSESSION        = 0x0011,
		WM_QUIT                   = 0x0012,
		WM_QUERYOPEN              = 0x0013,
		WM_ERASEBKGND             = 0x0014,
		WM_SYSCOLORCHANGE         = 0x0015,
		WM_ENDSESSION             = 0x0016,
		WM_SHOWWINDOW             = 0x0018,
		WM_WININICHANGE           = 0x001A,
		WM_SETTINGCHANGE          = 0x001A,
		WM_DEVMODECHANGE          = 0x001B,
		WM_ACTIVATEAPP            = 0x001C,
		WM_FONTCHANGE             = 0x001D,
		WM_TIMECHANGE             = 0x001E,
		WM_CANCELMODE             = 0x001F,
		WM_SETCURSOR              = 0x0020,
		WM_MOUSEACTIVATE          = 0x0021,
		WM_CHILDACTIVATE          = 0x0022,
		WM_QUEUESYNC              = 0x0023,
		WM_GETMINMAXINFO          = 0x0024,
		WM_PAINTICON              = 0x0026,
		WM_ICONERASEBKGND         = 0x0027,
		WM_NEXTDLGCTL             = 0x0028,
		WM_SPOOLERSTATUS          = 0x002A,
		WM_DRAWITEM               = 0x002B,
		WM_MEASUREITEM            = 0x002C,
		WM_DELETEITEM             = 0x002D,
		WM_VKEYTOITEM             = 0x002E,
		WM_CHARTOITEM             = 0x002F,
		WM_SETFONT                = 0x0030,
		WM_GETFONT                = 0x0031,
		WM_SETHOTKEY              = 0x0032,
		WM_GETHOTKEY              = 0x0033,
		WM_QUERYDRAGICON          = 0x0037,
		WM_COMPAREITEM            = 0x0039,
		WM_GETOBJECT              = 0x003D,
		WM_COMPACTING             = 0x0041,
		WM_COMMNOTIFY             = 0x0044 ,
		WM_WINDOWPOSCHANGING      = 0x0046,
		WM_WINDOWPOSCHANGED       = 0x0047,
		WM_POWER                  = 0x0048,
		WM_COPYDATA               = 0x004A,
		WM_CANCELJOURNAL          = 0x004B,
		WM_NOTIFY                 = 0x004E,
		WM_INPUTLANGCHANGEREQUEST = 0x0050,
		WM_INPUTLANGCHANGE        = 0x0051,
		WM_TCARD                  = 0x0052,
		WM_HELP                   = 0x0053,
		WM_USERCHANGED            = 0x0054,
		WM_NOTIFYFORMAT           = 0x0055,
		WM_CONTEXTMENU            = 0x007B,
		WM_STYLECHANGING          = 0x007C,
		WM_STYLECHANGED           = 0x007D,
		WM_DISPLAYCHANGE          = 0x007E,
		WM_GETICON                = 0x007F,
		WM_SETICON                = 0x0080,
		WM_NCCREATE               = 0x0081,
		WM_NCDESTROY              = 0x0082,
		WM_NCCALCSIZE             = 0x0083,
		WM_NCHITTEST              = 0x0084,
		WM_NCPAINT                = 0x0085,
		WM_NCACTIVATE             = 0x0086,
		WM_GETDLGCODE             = 0x0087,
		WM_SYNCPAINT              = 0x0088,
		WM_NCMOUSEMOVE            = 0x00A0,
		WM_NCLBUTTONDOWN          = 0x00A1,
		WM_NCLBUTTONUP            = 0x00A2,
		WM_NCLBUTTONDBLCLK        = 0x00A3,
		WM_NCRBUTTONDOWN          = 0x00A4,
		WM_NCRBUTTONUP            = 0x00A5,
		WM_NCRBUTTONDBLCLK        = 0x00A6,
		WM_NCMBUTTONDOWN          = 0x00A7,
		WM_NCMBUTTONUP            = 0x00A8,
		WM_NCMBUTTONDBLCLK        = 0x00A9,
		WM_NCXBUTTONDOWN          = 0x00AB,
		WM_NCXBUTTONUP            = 0x00AC,
		WM_KEYDOWN                = 0x0100,
		WM_KEYUP                  = 0x0101,
		WM_CHAR                   = 0x0102,
		WM_DEADCHAR               = 0x0103,
		WM_SYSKEYDOWN             = 0x0104,
		WM_SYSKEYUP               = 0x0105,
		WM_SYSCHAR                = 0x0106,
		WM_SYSDEADCHAR            = 0x0107,
		WM_KEYLAST                = 0x0108,
		WM_IME_STARTCOMPOSITION   = 0x010D,
		WM_IME_ENDCOMPOSITION     = 0x010E,
		WM_IME_COMPOSITION        = 0x010F,
		WM_IME_KEYLAST            = 0x010F,
		WM_INITDIALOG             = 0x0110,
		WM_COMMAND                = 0x0111,
		WM_SYSCOMMAND             = 0x0112,
		WM_TIMER                  = 0x0113,
		WM_HSCROLL                = 0x0114,
		WM_VSCROLL                = 0x0115,
		WM_INITMENU               = 0x0116,
		WM_INITMENUPOPUP          = 0x0117,
		WM_MENUSELECT             = 0x011F,
		WM_MENUCHAR               = 0x0120,
		WM_ENTERIDLE              = 0x0121,
		WM_MENURBUTTONUP          = 0x0122,
		WM_MENUDRAG               = 0x0123,
		WM_MENUGETOBJECT          = 0x0124,
		WM_UNINITMENUPOPUP        = 0x0125,
		WM_MENUCOMMAND            = 0x0126,
		WM_CTLCOLORMSGBOX         = 0x0132,
		WM_CTLCOLOREDIT           = 0x0133,
		WM_CTLCOLORLISTBOX        = 0x0134,
		WM_CTLCOLORBTN            = 0x0135,
		WM_CTLCOLORDLG            = 0x0136,
		WM_CTLCOLORSCROLLBAR      = 0x0137,
		WM_CTLCOLORSTATIC         = 0x0138,
		WM_MOUSEMOVE              = 0x0200,
		WM_LBUTTONDOWN            = 0x0201,
		WM_LBUTTONUP              = 0x0202,
		WM_LBUTTONDBLCLK          = 0x0203,
		WM_RBUTTONDOWN            = 0x0204,
		WM_RBUTTONUP              = 0x0205,
		WM_RBUTTONDBLCLK          = 0x0206,
		WM_MBUTTONDOWN            = 0x0207,
		WM_MBUTTONUP              = 0x0208,
		WM_MBUTTONDBLCLK          = 0x0209,
		WM_MOUSEWHEEL             = 0x020A,
		WM_XBUTTONDOWN            = 0x020B,
		WM_XBUTTONUP              = 0x020C,
		WM_XBUTTONDBLCLK          = 0x020D,
		WM_PARENTNOTIFY           = 0x0210,
		WM_ENTERMENULOOP          = 0x0211,
		WM_EXITMENULOOP           = 0x0212,
		WM_NEXTMENU               = 0x0213,
		WM_SIZING                 = 0x0214,
		WM_CAPTURECHANGED         = 0x0215,
		WM_MOVING                 = 0x0216,
		WM_DEVICECHANGE           = 0x0219,
		WM_MDICREATE              = 0x0220,
		WM_MDIDESTROY             = 0x0221,
		WM_MDIACTIVATE            = 0x0222,
		WM_MDIRESTORE             = 0x0223,
		WM_MDINEXT                = 0x0224,
		WM_MDIMAXIMIZE            = 0x0225,
		WM_MDITILE                = 0x0226,
		WM_MDICASCADE             = 0x0227,
		WM_MDIICONARRANGE         = 0x0228,
		WM_MDIGETACTIVE           = 0x0229,
		WM_MDISETMENU             = 0x0230,
		WM_ENTERSIZEMOVE          = 0x0231,
		WM_EXITSIZEMOVE           = 0x0232,
		WM_DROPFILES              = 0x0233,
		WM_MDIREFRESHMENU         = 0x0234,
		WM_IME_SETCONTEXT         = 0x0281,
		WM_IME_NOTIFY             = 0x0282,
		WM_IME_CONTROL            = 0x0283,
		WM_IME_COMPOSITIONFULL    = 0x0284,
		WM_IME_SELECT             = 0x0285,
		WM_IME_CHAR               = 0x0286,
		WM_IME_REQUEST            = 0x0288,
		WM_IME_KEYDOWN            = 0x0290,
		WM_IME_KEYUP              = 0x0291,
		WM_MOUSEHOVER             = 0x02A1,
		WM_MOUSELEAVE             = 0x02A3,
		WM_CUT                    = 0x0300,
		WM_COPY                   = 0x0301,
		WM_PASTE                  = 0x0302,
		WM_CLEAR                  = 0x0303,
		WM_UNDO                   = 0x0304,
		WM_RENDERFORMAT           = 0x0305,
		WM_RENDERALLFORMATS       = 0x0306,
		WM_DESTROYCLIPBOARD       = 0x0307,
		WM_DRAWCLIPBOARD          = 0x0308,
		WM_PAINTCLIPBOARD         = 0x0309,
		WM_VSCROLLCLIPBOARD       = 0x030A,
		WM_SIZECLIPBOARD          = 0x030B,
		WM_ASKCBFORMATNAME        = 0x030C,
		WM_CHANGECBCHAIN          = 0x030D,
		WM_HSCROLLCLIPBOARD       = 0x030E,
		WM_QUERYNEWPALETTE        = 0x030F,
		WM_PALETTEISCHANGING      = 0x0310,
		WM_PALETTECHANGED         = 0x0311,
		WM_HOTKEY                 = 0x0312,
		WM_PRINT                  = 0x0317,
		WM_PRINTCLIENT            = 0x0318,
		WM_HANDHELDFIRST          = 0x0358,
		WM_HANDHELDLAST           = 0x035F,
		WM_AFXFIRST               = 0x0360,
		WM_AFXLAST                = 0x037F,
		WM_PENWINFIRST            = 0x0380,
		WM_PENWINLAST             = 0x038F,
		WM_APP                    = 0x8000,
		WM_USER                   = 0x0400,

		// For Windows XP Balloon messages from the System Notification Area
		NIN_BALLOONSHOW			  = 0x0402,
		NIN_BALLOONHIDE			  = 0x0403,
		NIN_BALLOONTIMEOUT		  = 0x0404,
		NIN_BALLOONUSERCLICK	  = 0x0405
	}

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        IntPtr _ClipboardViewerNext;
        List<string> Modules;
        List<string> Items;
        List<string[]> Scans = new List<string[]>();
        //bool extended = false;

        private void RegisterClipboardViewer()
        {
            _ClipboardViewerNext = SetClipboardViewer(this.Handle);
        }
        private void UnregisterClipboardViewer()
        {
            ChangeClipboardChain(this.Handle, _ClipboardViewerNext);
        }

        private bool isModule(string name)
        {
            return false;
        }
        private bool isItem(string name)
        {
            Match match = Regex.Match(name, @"(\d+\s)?(.*)(\t)?.*", RegexOptions.Singleline);
            if( match.Success )
            {
                foreach(Group nonumber in match.Groups)
                if (Items.Contains(nonumber.Value))
                {
                    return true;
                }
            }

            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch ((Msgs)m.Msg)
            {
                case Msgs.WM_DRAWCLIPBOARD:

                    IDataObject clipData = Clipboard.GetDataObject();

                    if(clipData.GetDataPresent(DataFormats.Text))
                    {
                        string cliptext = (string)clipData.GetData(DataFormats.Text);
                        bool isModules = true;
                        bool isItems = true;
                        foreach (var myString in cliptext.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (isItem(myString))
                            {
                                if (!isModule(myString))
                                {
                                    isModules = false;
                                }
                            }
                            else
                            {
                                isModules = false;
                                isItems = false;
                            }
                        }

                        if (isModules)
                        {

                        }
                        else if (isItems | checkBox1.Checked)
                        {

                            using (var client = new WebClient())
                            {
                                cliptext = cliptext.Replace("\t", "  ");
                                var values = new NameValueCollection();
                                values["market"] = "30000142";
                                values["raw_paste"] = cliptext;

                                var response = client.UploadValues("http://evepraisal.com/estimate", values);
                                
                                var responseString = Encoding.Default.GetString(response);
                                /*
                                string tempFile = Path.GetTempFileName();
                                tempFile = Path.ChangeExtension(tempFile, ".html");
                                System.IO.File.WriteAllText(tempFile, responseString);
                                System.Diagnostics.Process.Start(tempFile); 
                                */

                                Match matchbuy = Regex.Match(responseString, @"<span class=""nowrap"">\n      (.*)<small>estimated <strong>buy</strong> value  in Jita</small>");
                                Match matchsell = Regex.Match(responseString, @"<span class=""nowrap"">\n      (.*)<small>estimated <strong>sell</strong> value  in Jita</small>");
                                Match matchm3 = Regex.Match(responseString, @"<span class=""nowrap"">(.*)m<sup>3</sup></span>");
                                Match matchlink = Regex.Match(responseString,@"http://evepraisal\.com/e/.......");
                                
                                
                                
                                if(matchsell.Success)
                                {
                                    bool invalid = false;
                                    if (responseString.Contains("No Market Volume") | responseString.Contains("Unknown"))
                                    {
                                        invalid = true;
                                    }
                                    string buy = matchbuy.Groups[1].Value;
                                    string sell = matchsell.Groups[1].Value;
                                    string m3 = matchm3.Groups[1].Value;
                                    string link = matchlink.Captures[0].Value;
                                    Scans.Add( new string[4]{buy,sell,m3,link} );
                                    Form2 popup = new Form2();
                                    popup.timer1.Interval = (int) (1000 * numericUpDown1.Value);
                                    popup.lblBuy.Text = buy;
                                    popup.lblSell.Text = sell;
                                    popup.lblm3.Text = m3 + "m3";
                                    popup.link = link;
                                    popup.invalid = invalid;
                                    label4.Text = sell;
                                    label5.Text = buy;
                                    label7.Text = m3 + "m3";
                                    linkLabel1.Text = link;
                                    popup.Show();
                                    if (invalid) { popup.Size = new Size(383, 141); }
                                    popup.Location = new Point(Screen.PrimaryScreen.Bounds.Width - popup.Size.Width - 10, Screen.PrimaryScreen.Bounds.Height - popup.Size.Height - 10);
                                    
                                }
                            }
                        }
                        
                        
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
                case Msgs.WM_CHANGECBCHAIN:
					if (m.WParam == _ClipboardViewerNext)
					{
						_ClipboardViewerNext = m.LParam;
					}
					else
					{
						SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
					}
					break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Modules = ClipboardEVE.Properties.Resources.Modules.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Items = ClipboardEVE.Properties.Resources.Items.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();


            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            ToolTip bruteforceTip = new ToolTip();
            bruteforceTip.SetToolTip(this.checkBox1, "If you select this, ECE will simply run all clipboard changes straight to Evepraisal without trying to see if it's actually EVE related");
            this.CenterToScreen();

            checkBox1.Checked = Properties.Settings.Default.Bruteforce;
            numericUpDown1.Value = Properties.Settings.Default.Popuptime;

            RegisterClipboardViewer();
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterClipboardViewer();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text); 
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Bruteforce = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Popuptime = numericUpDown1.Value;
            Properties.Settings.Default.Save();
        }
    }
}
