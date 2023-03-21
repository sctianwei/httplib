using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
            /*
            Http.Post("http://47.108.142.122/aipipeline-api/project/file/upload")
                    .Headers(new { Authorization = $"eyJhbGciOiJIUzUxMiJ9.eyJsb2dpbl91c2VyX2tleSI6ImI3NjNlMTY0LTdkYjMtNDMyZS05NTBhLTQxODcwNmRiMzBjMiJ9.XOEFuRu9Ny9LHxLZBc2iOG-IKLvjJ4pGpLP97fJMs2ZU6rVBZXuy8rIPI_6kJp61tqNo9aY_g6jWdqnfrQhIBQ" })
                    .Upload(
                        files:
                        new[] {
                            new NamedFileStream("file", "长乌临线-20211214-191456.zip", "application/octet-stream", File.OpenRead(@"C:\Users\tianwei\Desktop\长乌临线-20211214-191456.zip"))
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
            */
            Http.Get($"http://47.108.201.252:31197/mock/klsz/core/auth/token?appkey=123456&appsecret=123456")
                    .Headers(new Dictionary<string, string> { { "x-request-project", "Default" } })
                    .OnMake((Action<HttpWebRequest>)(req =>
                    {
                        req.Accept = "application/json; charset=utf-8";
                        req.ContentType = "application/json; charset=utf-8";
                    }))
                    .OnSuccess((Action<string>)(res => Console.WriteLine(res)))
                    .OnFail(res => Console.WriteLine($"失败{res}"))
                    .Go();
        }
    }
}
