using System;
using System.Windows.Forms;
using Mindows.Basic;
using Mindows.Basic.Calling;
using Mindows.Basic.Device;

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
            void EntryPoint(IDevice device)
            { 
                if (device.State == DeviceState.Poweron)
                {
                    conninfo.Text = "已连接";
                }
                if (device.State == DeviceState.Recovery)
                {
                    conninfo.Text = "Recovery";
                }
                if (device.State == DeviceState.Sideload)
                {
                    conninfo.Text = "Sideload";

                }
                if (device.State == DeviceState.Offline)
                {
                    conninfo.Text = "设备离线";
                }
                if (device.State == DeviceState.Unauthorized)
                {
                    conninfo.Text = "设备未授权";
                }
                if (device.State == DeviceState.Unknown)
                {
                    conninfo.Text = "未知状态";
                }
                if (device.State == DeviceState.Fastboot)
                {
                    conninfo.Text = "Fastboot";
                    CommandExecutor executer = new CommandExecutor();
                    var result = executer.Fastboot(device, $"getvar unlocked");
                    if (result.ExitCode == 0)
                    {
                        if (result.Output.Contains("yes"))
                        {
                            BLinfo.Text = "已解锁";
                        }
                        else
                        {
                            BLinfo.Text = "未解锁";
                        }
                    }
                    else
                    {
                        BLinfo.Text = "读取失败";
                    }
                } 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            void EntryPoint(IDevice device)
            {
                if (device.State == DeviceState.Poweron)
                {
                    conninfo.Text = "已连接";
                }
                if (device.State == DeviceState.Recovery)
                {
                    conninfo.Text = "Recovery";
                }
                if (device.State == DeviceState.Sideload)
                {
                    conninfo.Text = "Sideload";

                }
                if (device.State == DeviceState.Offline)
                {
                    conninfo.Text = "设备离线";
                }
                if (device.State == DeviceState.Unauthorized)
                {
                    conninfo.Text = "设备未授权";
                }
                if (device.State == DeviceState.Unknown)
                {
                    conninfo.Text = "未知状态";
                }
                if (device.State == DeviceState.Fastboot)
                {
                    conninfo.Text = "Fastboot";
                    CommandExecutor executer = new CommandExecutor();
                    var result = executer.Fastboot(device, $"getvar unlocked");
                    if (result.ExitCode == 0)
                    {
                        if (result.Output.Contains("yes"))
                        {
                            BLinfo.Text = "已解锁";
                        }
                        else
                        {
                            BLinfo.Text = "未解锁";
                        }
                    }
                    else
                    {
                        BLinfo.Text = "读取失败";
                    }
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
            void EntryPoint(IDevice device)
            {


                if (device.State == DeviceState.Fastboot)
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
                        CommandExecutor executer = new CommandExecutor();
                        string shell = string.Format("flash boot {0}", file);
                        var result = executer.Fastboot(shell);
                        if (result.ExitCode == 0)
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
                    MessageBox.Show("无Fastboot设备链接", "提示");
                }
            }
        }

        private void flashuefiboota_Click(object sender, EventArgs e)
        {
            void EntryPoint(IDevice device)
            {
                if (device.State == DeviceState.Fastboot)
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
                        CommandExecutor executer = new CommandExecutor();
                        string shell = string.Format("flash boot_a {0}", file);
                        var result = executer.Fastboot(shell);
                        if (result.ExitCode == 0)
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
                    MessageBox.Show("无Fastboot设备链接", "提示");
                }
            }
        }

        private void flashuefibootb_Click(object sender, EventArgs e)
        {
            void EntryPoint(IDevice device)
            {
                if (device.State == DeviceState.Fastboot)
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
                        CommandExecutor executer = new CommandExecutor();
                        string shell = string.Format("flash boot_b {0}", file);
                        var result = executer.Fastboot(shell);
                        if (result.ExitCode == 0)
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
                    MessageBox.Show("无Fastboot设备链接", "提示");
                }
            }
        }

        private void flashuefirec_Click(object sender, EventArgs e)
        {
            void EntryPoint(IDevice device)
            {
                if (device.State == DeviceState.Fastboot)
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
                        CommandExecutor executer = new CommandExecutor();
                        var result = executer.Fastboot(shell);
                        if (result.ExitCode == 0)
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
        }

        private void bootuefi_Click(object sender, EventArgs e)
        {
            void EntryPoint(IDevice device)
            {
                if (device.State == DeviceState.Fastboot)
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
                        CommandExecutor executer = new CommandExecutor();
                        var result = executer.Fastboot(shell);
                        if (result.ExitCode == 0)
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
        }

        private void mindows_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mindows.cn");
        }
    }
}
