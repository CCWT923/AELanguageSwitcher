using System.Runtime.InteropServices;
using System.Text;

namespace AELanguageSwitcher
{
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
