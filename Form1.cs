/**
 * author: W.T.
 * AE language switch tool
 * date: 2020.6.1
 */
using Microsoft.Win32; //注册表操作
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AELanguageSwitcher
{
    public partial class Form1 : Form
    {
        //TODO: 新版AE 2020 的配置文件使用XML保存，在 Support Files\AMT 目录下的application.xml文件的<Data key="installedLanguages">zh_CN</Data>节点中
        private const string AE_INSTALLPATH = @"SOFTWARE\Adobe\After Effects";
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
            
            //从已保存的配置文件中读取数据
            if(File.Exists(AppConfigPath))
            {
                StringBuilder sb = new StringBuilder();
                ProfileHelper.GetPrivateProfileString("Main", "Path", "", sb, 512, AppConfigPath);
                TextBox_AEInstallPath.Text = sb.ToString();
            }
            else
            {
                TextBox_AEInstallPath.Text = GetAEInstallPath();
            }
            string profile = TextBox_AEInstallPath.Text + "\\" + AE_ConfigFileName;
            ReadConfig(profile);
        }
        /// <summary>
        /// 从注册表中读取AE安装路径
        /// </summary>
        /// <returns></returns>
        private string GetAEInstallPath()
        {
            RegistryKey localKey = null;
            try
            {
                //判断系统架构，然后选择打开32位还是64位注册表
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                var AEPath = localKey.OpenSubKey(AE_INSTALLPATH, false);
                var finder1 = AEPath.OpenSubKey(AEPath.GetSubKeyNames()[0],false);

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

}
