using System.Text;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace My_task_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            setTheGrid();
        }
        public class MyProcess
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public MyProcess(string name, int id)
            {
                Name = name;
                Id = id;
            }
        }

        private void Button_Click_Notepad(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "notepad.exe";
            process.Start();
            setTheGrid();
        }
        private void setTheGrid()
        {
            List<MyProcess> processes = new List<MyProcess>();
            foreach (var item in Process.GetProcesses())
            {
                processes.Add(new MyProcess(item.ProcessName, item.Id));
            };
            taskGrid.ItemsSource = processes;
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            setTheGrid();
        }
    }
}