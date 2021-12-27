using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JumpKick.HttpLib.Samples.wpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Http.Post("http://47.108.142.12/aipipeline-api/project/file/upload")
                    .Headers(new { Authorization = $"eyJhbGciOiJIUzUxMiJ9.eyJsb2dpbl91c2VyX2tleSI6IjA5YTM5ZWI5LTg3YjktNDAxMi1hYzY5LWNkZmFlNjk0ZGMyNSJ9.M-A1amaTCJA1LQgxIG9lpE711ncZ9lobIr0TwGxNJzj9Zoa915ELr9IQjaE5zd3APYEoGVmROhWh1QShyhXb7A" })
                    .Upload(
                        files:
                        new[] {
                            new NamedFileStream("file", "长乌临线-20211214-191456", "application/octet-stream", File.OpenRead(@"C:\Users\tianwei\Desktop\长乌临线-20211214-191456.zip"))
                        },
                        parameters:
                        new { projectType = 1, newProjectName = "长乌临线-20211214-191456" })
                    .OnMake(request=> request.ServicePoint.Expect100Continue = false)
                    .OnSuccess(res => {
                        Trace.WriteLine(res);
                    })
                    .OnFail(res => {
                        Trace.WriteLine(res.Message); 
                    })
                    .Go();
        }
    }
}
