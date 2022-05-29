using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void checkconn_Click(object sender, EventArgs e)
        {
            if (ADBHelper.Fastboot("devices") != "")
            {
                conninfo.Text = "Fastboot";
            }
            else
            {
                conninfo.Text = "未连接";
            }
            int adbcheck = ADBHelper.ADB("devices").IndexOf("recovery");
            if (adbcheck != -1)
            {
                conninfo.Text = "Recovery";
            }
            if (conninfo.Text == "Fastboot")
            {
                int unlocked = ADBHelper.FError("getvar unlocked").IndexOf("yes");
                if (unlocked != -1)
                {
                    BLinfo.Text = "已解锁";
                }
                int locked = ADBHelper.FError("getvar unlocked").IndexOf("no");
                if (locked != -1)
                {
                    BLinfo.Text = "未解锁";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (ADBHelper.Fastboot("devices") != "")
            {
                conninfo.Text = "Fastboot";
            }
            else
            {
                conninfo.Text = "未连接";
            }
            int adbcheck = ADBHelper.ADB("devices").IndexOf("recovery");
            if (adbcheck != -1)
            {
                conninfo.Text = "Recovery";
            }
            if (conninfo.Text == "Fastboot")
            {
                int unlocked = ADBHelper.FError("getvar unlocked").IndexOf("yes");
                if (unlocked != -1)
                {
                    BLinfo.Text = "已解锁";
                }
                int locked = ADBHelper.FError("getvar unlocked").IndexOf("no");
                if (locked != -1)
                {
                    BLinfo.Text = "未解锁";
                }
            }
        }

        string device = "";
        private void download_Click(object sender, EventArgs e)
        {
            if (mix2s.Checked)
                device = mix2s.Text;
            if (mi8.Checked)
                device = mi8.Text;
            if (mi8ud.Checked)
                device = mi8ud.Text;
            if (mix3.Checked)
                device = mix3.Text;
            if (mi6.Checked)
                device = mi6.Text;
            if (mix2.Checked)
                device = mix2.Text;
            if (op6.Checked)
                device = op6.Text;
            if (op6t.Checked)
                device = op6t.Text;
            if (op5.Checked)
                device = op5.Text;
            if (op5t.Checked)
                device = op5t.Text;
        }

        private void choseuefi_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "UEFI Files(*.img) | *.img";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                uefifilename.Text = fileDialog.FileName;
            }
        }

        private void flashuefiboot_Click(object sender, EventArgs e)
        {
            if (ADBHelper.Fastboot("devices") != "")
            {
                conninfo.Text = "Fastboot";
            }
            else
            {
                conninfo.Text = "未连接";
            }
            if (conninfo.Text == "Fastboot")
            {
                if (uefifilename.Text != "")
                {
                    string file = uefifilename.Text;
                    string shell = string.Format("flash boot {0}", file);
                    int sf = ADBHelper.FError(shell).IndexOf("FAILED");
                    if (sf == -1)
                    {
                        MessageBox.Show("刷入成功！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("刷入失败！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请选择UEFI文件！", "提示");
                }
            }
            else
            {
                MessageBox.Show("设备未连接", "提示");
            }
        }

        private void flashuefiboota_Click(object sender, EventArgs e)
        {
            if (ADBHelper.Fastboot("devices") != "")
            {
                conninfo.Text = "Fastboot";
            }
            else
            {
                conninfo.Text = "未连接";
            }
            if (conninfo.Text == "Fastboot")
            {
                if (uefifilename.Text != "")
                {
                    string file = uefifilename.Text;
                    string shell = string.Format("flash boot_a {0}", file);
                    int sf = ADBHelper.FError(shell).IndexOf("FAILED");
                    if (sf == -1)
                    {
                        MessageBox.Show("刷入成功！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("刷入失败！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请选择UEFI文件！", "提示");
                }
            }
            else
            {
                MessageBox.Show("设备未连接", "提示");
            }
        }

        private void flashuefibootb_Click(object sender, EventArgs e)
        {
            if (ADBHelper.Fastboot("devices") != "")
            {
                conninfo.Text = "Fastboot";
            }
            else
            {
                conninfo.Text = "未连接";
            }
            if (conninfo.Text == "Fastboot")
            {
                if (uefifilename.Text != "")
                {
                    string file = uefifilename.Text;
                    string shell = string.Format("flash boot_b {0}", file);
                    int sf = ADBHelper.FError(shell).IndexOf("FAILED");
                    if (sf == -1)
                    {
                        MessageBox.Show("刷入成功！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("刷入失败！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请选择UEFI文件！", "提示");
                }
            }
            else
            {
                MessageBox.Show("设备未连接", "提示");
            }
        }

        private void flashuefirec_Click(object sender, EventArgs e)
        {
            if (ADBHelper.Fastboot("devices") != "")
            {
                conninfo.Text = "Fastboot";
            }
            else
            {
                conninfo.Text = "未连接";
            }
            if (conninfo.Text == "Fastboot")
            {
                if (uefifilename.Text != "")
                {
                    string file = uefifilename.Text;
                    string shell = string.Format("flash recovery {0}", file);
                    int sf = ADBHelper.FError(shell).IndexOf("FAILED");
                    if (sf == -1)
                    {
                        MessageBox.Show("刷入成功！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("刷入失败！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请选择UEFI文件！", "提示");
                }
            }
            else
            {
                MessageBox.Show("设备未连接", "提示");
            }
        }

        private void bootuefi_Click(object sender, EventArgs e)
        {
            if (ADBHelper.Fastboot("devices") != "")
            {
                conninfo.Text = "Fastboot";
            }
            else
            {
                conninfo.Text = "未连接";
            }
            if (conninfo.Text == "Fastboot")
            {
                if (uefifilename.Text != "")
                {
                    string file = uefifilename.Text;
                    string shell = string.Format("boot {0}", file);
                    int sf = ADBHelper.FError(shell).IndexOf("FAILED");
                    if (sf == -1)
                    {
                        MessageBox.Show("启动成功！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("启动失败！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请选择UEFI文件！", "提示");
                }
            }
            else
            {
                MessageBox.Show("设备未连接", "提示");
            }
        }

        private void mindows_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mindows.cn");
        }
    }
}
