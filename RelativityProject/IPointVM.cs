using System.ComponentModel;
using System.Windows.Media;

namespace RelativityProject
{
    public interface IPointVM : INotifyPropertyChanged
    {
        double X { get; }
        double Y { get; }
        Brush Brush { get; }
        void RefreshState();
    }
}
