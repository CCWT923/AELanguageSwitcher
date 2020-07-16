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
using System.Xml;
using System.Xml.Linq;

namespace AELanguageSwitcher
{
    public partial class Form1 : Form
    {
        //TODO: 新版AE 2020 的配置文件使用XML保存，在 Support Files\AMT 目录下的application.xml文件的<Data key="installedLanguages">zh_CN</Data>节点中
        private const string AE_INSTALLPATH_Reg = @"SOFTWARE\Adobe\After Effects";
        private const string AE_ExecutionName = "AfterFX.exe";
        private const string AE_Lang_EN = "en_US";
        private const string AE_Lang_CN = "zh_CN";
        private const string AppConfigPath = "AppConfig.ini";
        private const string AE_ProfileName1 = "painter.ini";
        private const string AE_ProfileName2 = "AMT\\application.xml";
        private string AE_InstallPath = "";
        private ProfileType CurrentProfileType = ProfileType.ini;
        private string AE_ConfigFileName = "";

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
                if(File.Exists( sb.ToString()))
                {
                    Lbl_AEInstallPath.Text = sb.ToString();
                }
                else
                {
                    Lbl_AEInstallPath.Text = GetAEInstallPath();
                }
            }
            else
            {
                Lbl_AEInstallPath.Text = GetAEInstallPath();
            }
            AE_InstallPath = Lbl_AEInstallPath.Text;


            if(File.Exists(AE_InstallPath + AE_ProfileName1))
            {
                CurrentProfileType = ProfileType.ini;
                AE_ConfigFileName = AE_InstallPath + AE_ProfileName1;
                ReadConfig(AE_ConfigFileName, ProfileType.ini);
            }
            else if(File.Exists(AE_InstallPath + AE_ProfileName2))
            {
                CurrentProfileType = ProfileType.xml;
                AE_ConfigFileName = AE_InstallPath + AE_ProfileName2;
                ReadConfig(AE_ConfigFileName, ProfileType.xml);
            }
            else
            {
                Lbl_AEInstallPath.Text = "请单击选择AE安装路径";
            }

        }

        private void CheckFileExists(string file)
        {
            if(File.Exists(file))
            {
                Btn_SetLanguage.Enabled = true;
            }
            else
            {
                Btn_SetLanguage.Enabled = false;
            }
        }
        /// <summary>
        /// 从注册表中读取AE安装路径
        /// </summary>
        /// <returns></returns>
        private string GetAEInstallPath()
        {
            RegistryKey localKey;
            try
            {
                //判断系统架构，然后选择打开32位还是64位注册表
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                var AEPath = localKey.OpenSubKey(AE_INSTALLPATH_Reg, false);
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
                Lbl_AEInstallPath.Text = dialog.SelectedPath;
            }


            AE_InstallPath = Lbl_AEInstallPath.Text;


            if (File.Exists(AE_InstallPath + AE_ProfileName1))
            {
                CurrentProfileType = ProfileType.ini;
                AE_ConfigFileName = AE_InstallPath + AE_ProfileName1;
                ReadConfig(AE_ConfigFileName, ProfileType.ini);
            }
            else if (File.Exists(AE_InstallPath + AE_ProfileName2))
            {
                CurrentProfileType = ProfileType.xml;
                AE_ConfigFileName = AE_InstallPath + AE_ProfileName2;
                ReadConfig(AE_ConfigFileName, ProfileType.xml);
            }
            else
            {
                Lbl_AEInstallPath.Text = "请单击选择AE安装路径";
            }
        }

        private void ReadConfig(string profileName, ProfileType profileType)
        {
            if (File.Exists(profileName))
            {
                if(profileType ==  ProfileType.ini)
                {
                    File.SetAttributes(profileName, FileAttributes.Normal);
                    int size = 512;
                    StringBuilder sb = new StringBuilder(size);
                    ProfileHelper.WritePrivateProfileString("Config", "ForceLanguage", "1", profileName);
                    ProfileHelper.GetPrivateProfileString("Config", "Language", "", sb, size, profileName);
                    if (sb.ToString() == "")
                    {
                        Lbl_CurrentLanguage.Text = "未知";
                        Lbl_CurrentLanguage.Tag = string.Empty;
                    }
                    else if (sb.ToString().Trim() == AE_Lang_CN)
                    {
                        Lbl_CurrentLanguage.Text = "简体中文";
                        Lbl_CurrentLanguage.Tag = AE_Lang_CN;
                    }
                    else if (sb.ToString().Trim() == AE_Lang_EN)
                    {
                        Lbl_CurrentLanguage.Text = "英语";
                        Lbl_CurrentLanguage.Tag = AE_Lang_EN;
                    }
                }
                else if(profileType ==  ProfileType.xml)
                {
                    //读取xml文件
                    using (XmlReader reader = XmlReader.Create(profileName))
                    {
                        while(reader.Read())
                        {
                            if(reader.NodeType == XmlNodeType.Element)
                            {
                                if(reader.Name == "Data")
                                {
                                    if(reader.GetAttribute("key") == "installedLanguages")
                                    {
                                        if(reader.Read())
                                        {
                                            string v = reader.Value;
                                            if (v.ToUpper() == AE_Lang_CN.ToUpper())
                                            {
                                                Lbl_CurrentLanguage.Text = "简体中文";
                                                Lbl_CurrentLanguage.Tag = AE_Lang_CN;
                                            }
                                            else if (v.ToUpper() == AE_Lang_EN.ToUpper())
                                            {
                                                Lbl_CurrentLanguage.Text = "英语";
                                                Lbl_CurrentLanguage.Tag = AE_Lang_EN;
                                            }
                                            else
                                            {
                                                Lbl_CurrentLanguage.Text = "未知";
                                                Lbl_CurrentLanguage.Tag = string.Empty;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void WriteConfig(string profileName, ProfileType profileType)
        {
            if(File.Exists(profileName))
            {
                if(profileType == ProfileType.ini)
                {
                    //写ini配置文件
                    if (Lbl_CurrentLanguage.Tag.ToString() == AE_Lang_EN)
                    {
                        var a = ProfileHelper.WritePrivateProfileString("Config", "Language", "zh_CN", profileName);
                    }
                    else if (Lbl_CurrentLanguage.Tag.ToString() == AE_Lang_CN)
                    {
                        var a = ProfileHelper.WritePrivateProfileString("Config", "Language", "en_US", profileName);
                    }
                    else
                    {
                        MessageBox.Show("未知错误！");
                    }
                }
                else if(profileType == ProfileType.xml)
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(profileName);
                    var target = document.SelectSingleNode("/Configuration/Payload/Data[@key='installedLanguages']");
                    if (Lbl_CurrentLanguage.Tag.ToString() == AE_Lang_EN)
                    {
                        target.InnerText = AE_Lang_CN;
                    }
                    else if (Lbl_CurrentLanguage.Tag.ToString() == AE_Lang_CN)
                    {
                        target.InnerText = AE_Lang_EN;
                    }
                    document.Save(profileName);
                }
            }
        }


        private void Btn_SetLanguage_Click(object sender, EventArgs e)
        {
            
            if(CurrentProfileType == ProfileType.ini)
            {
                WriteConfig(AE_ConfigFileName, ProfileType.ini);
            }
            else if(CurrentProfileType == ProfileType.xml)
            {
                WriteConfig(AE_ConfigFileName, ProfileType.xml);
            }

            ReadConfig(AE_ConfigFileName, CurrentProfileType);

            if (ModifierKeys == Keys.Control)
            {
                string p = Lbl_AEInstallPath.Text + "\\" + AE_ExecutionName;
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

        private void Lbl_AEInstallPath_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存路径配置
        /// </summary>
        private void SavePathConfig()
        {
            if (!File.Exists(AppConfigPath))
            {
                File.Create(AppConfigPath);
            }
            //保存路径
            ProfileHelper.WritePrivateProfileString("Main", "Path",Lbl_AEInstallPath.Text, AppConfigPath);
        }
    }
    /// <summary>
    /// 配置文件类型：xml或者ini
    /// </summary>
    enum ProfileType
    {
        ini,
        xml
    }
}
