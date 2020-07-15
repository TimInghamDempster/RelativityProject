using System.Windows;

namespace RelativityProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new SimulationVM(new World());
            WindowState = WindowState.Maximized;
            InitializeComponent();
        }
    }
}
