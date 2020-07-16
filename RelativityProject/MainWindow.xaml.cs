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
            var ticksPerDraw = 200.0;
            DataContext = new SimulationVM(new World(1.0 / ticksPerDraw), (int)ticksPerDraw);
            WindowState = WindowState.Maximized;
            InitializeComponent();
        }
    }
}
