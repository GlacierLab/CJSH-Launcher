using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for Init.xaml
    /// </summary>
    public partial class Init : Window
    {
        public Init()
        {
            InitializeComponent();
            PathT.Text = System.IO.Directory.GetCurrentDirectory();
            if (Directory.GetFiles(PathT.Text, "*", SearchOption.AllDirectories).Length > 1)
            {
                Status.Content += "不是空目录，安装可能覆盖现存文件";
                Status.Foreground = Brushes.Red;
            }else { 
                Status.Content += "空目录";
            }
            Status.Content += "，剩余空间"+ GetDiskFreeSpace(PathT.Text) / (1024 * 1024 * 1024)+"GB";
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请把安装程序移动到目标文件夹运行","安装");
        }
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
    out ulong lpFreeBytesAvailable,
    out ulong lpTotalNumberOfBytes,
    out ulong lpTotalNumberOfFreeBytes);

        public static ulong GetDiskFreeSpace(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            ulong dummy = 0;

            if (!GetDiskFreeSpaceEx(path, out ulong freeSpace, out dummy, out dummy))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return freeSpace;
        }

        private void Install_Click(object sender, RoutedEventArgs e)
        {

        }
        private void About_MouseDown(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("https://qinlili.bid")
            {
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }
    }
}
