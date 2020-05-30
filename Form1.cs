using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32; //注册表操作
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace AELanguageSwitcher
{
    public partial class Form1 : Form
    {
        private const string AE_INSTALLPATH = @"HKEY_LOCAL_MACHINE\SOFTWARE\Adobe\After Effects";
        private const string AE_ConfigFileName = "painter.ini";
        private const string AE_ExecutionName = "AfterFX.exe";
        private const string AE_Lang_EN = "en_US";
        private const string AE_Lang_CN = "zh_CN";
        private const string AppConfigPath = "AppConfig.ini";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TextBox_AEInstallPath.Text = GetAEInstallPath();
            if(File.Exists(AppConfigPath))
            {
                StringBuilder sb = new StringBuilder();
                ProfileHelper.GetPrivateProfileString("Main", "Path", "", sb, 512, AppConfigPath);
                TextBox_AEInstallPath.Text = sb.ToString();
            }
        }

        private string GetAEInstallPath()
        {
            RegistryKey AEPathFinder;
            try
            {
                //使用只读模式打开
                AEPathFinder = Registry.LocalMachine.OpenSubKey(AE_INSTALLPATH,false);
                var finder1 = AEPathFinder.OpenSubKey(AEPathFinder.GetSubKeyNames()[0]);

                return finder1.GetValue("InstallPath", string.Empty).ToString();
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

        private void Btn_BrowseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                TextBox_AEInstallPath.Text = dialog.SelectedPath;
                if(!File.Exists(AppConfigPath))
                {
                    File.Create(AppConfigPath);
                }
                //保存路径
                ProfileHelper.WritePrivateProfileString("Main", "Path", dialog.SelectedPath, AppConfigPath);

                string profile = TextBox_AEInstallPath.Text + "\\" + AE_ConfigFileName;
                ReadConfig(profile);
            }
        }

        private void ReadConfig(string profile)
        {
            if (File.Exists(profile))
            {
                File.SetAttributes(profile, FileAttributes.Normal);
                int size = 512;
                StringBuilder sb = new StringBuilder(size);
                ProfileHelper.WritePrivateProfileString("Config", "ForceLanguage", "1", profile);
                ProfileHelper.GetPrivateProfileString("Config", "Language", "", sb, size, profile);
                if (sb.ToString() == "")
                {
                    ComboBox_LanguageList.SelectedIndex = 0;
                }
                else if (sb.ToString().Trim().ToUpper() == "ZH_CN")
                {
                    ComboBox_LanguageList.SelectedIndex = 1;
                }
                else if (sb.ToString().Trim().ToUpper() == "EN_US")
                {
                    ComboBox_LanguageList.SelectedIndex = 2;
                }
            }
        }


        private void Btn_SetLanguage_Click(object sender, EventArgs e)
        {
            string profile = TextBox_AEInstallPath.Text + "\\" + AE_ConfigFileName;
            if(File.Exists(profile))
            {
                if(ComboBox_LanguageList.SelectedIndex == 1)
                {
                    ProfileHelper.WritePrivateProfileString("Config", "Language", "zh_CN", profile);
                }
                else if(ComboBox_LanguageList.SelectedIndex == 2)
                {
                    ProfileHelper.WritePrivateProfileString("Config", "Language", "en_US", profile);
                }
            }

            if (CheckBox_LaunchApp.Checked == true)
            {
                string p = TextBox_AEInstallPath.Text + "\\" + AE_ExecutionName;
                if(File.Exists(p))
                {
                    try
                    {
                        Process.Start(p);
                    }
                    catch (Exception)
                    {

                    }
                    
                }
            }
        }

        private void TextBox_AEInstallPath_TextChanged(object sender, EventArgs e)
        {
            string p = TextBox_AEInstallPath.Text + "\\" + AE_ConfigFileName;
            if(File.Exists(p))
            {
                ReadConfig(p);
            }
        }
    }

    /// <summary>
    /// INI文件操作类
    /// </summary>
    public class ProfileHelper
    {
        /// <summary>
        /// 读 INI 文件
        /// </summary>
        /// <param name="lpAppName">节点名称</param>
        /// <param name="lpKeyName">项名称</param>
        /// <param name="lpDefault">没有找到指定项时的返回值</param>
        /// <param name="lpReturnString">指定一个字符缓冲区，长度最少为nSize</param>
        /// <param name="nSize">指定复制到字符缓冲区的最大字符数量</param>
        /// <param name="lpFileName">ini文件路径</param>
        /// <returns>复制到字符缓冲区的字节数，不包括中止字符</returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnString, int nSize, string lpFileName);

        /// <summary>
        /// 写 INI 文件
        /// </summary>
        /// <param name="lpSectionName">要写入的节点名称</param>
        /// <param name="lpKeyName">要写入的项目名称</param>
        /// <param name="lpString">要写入的字符串</param>
        /// <param name="lpFileName">ini文件的路径</param>
        /// <returns>零表示失败，非零表示成功</returns>
        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(string lpSectionName, string lpKeyName, string lpString, string lpFileName);
    }

}
