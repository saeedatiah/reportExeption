using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
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
using System.IO;
using System.Diagnostics;

namespace testHandleException
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static string Log(string text,
                        [CallerFilePath] string file = "",
                        [CallerMemberName] string member = "",
                        [CallerLineNumber] int line = 0)
        {
            string path = Directory.GetCurrentDirectory();
            if (!File.Exists(@"D:\file.txt"))
                System.IO.File.WriteAllText(""+ path + "\\file.txt", "file for exexptions \n Exeption:"+ text +" ; File Name : "+ file + " ; Method Name : "+ member + "  ;  Line : "+ line + "");


            else System.IO.File.AppendAllText("" + path + "\\file.txt", "Exeption:" + text + " ; File Name : " + file + " ; Method Name : " + member + "  ;  Line : " + line + "" + Environment.NewLine);



            return path;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = int.Parse(txt.Text);

            }
            catch (Exception ex)
            {
                //msg.Text= this.GetType().Name+"\n"+ (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber() + "\n" + (new System.Diagnostics.StackFrame(0, true)).GetMethod(); ;
                msg.Text= Log(ex.Message); 

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();

            if (Directory.Exists(path))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = path,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
        }


           
    
    }
}
