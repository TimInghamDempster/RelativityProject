using System.ComponentModel;
using System.Windows.Media;

namespace RelativityProject
{
    public class PointVM : IPointVM
    {
        private const double _yZoomFactor = 1000000;
        private const double _xZoomFactor = 10;
        private const double _width = 1900;
        private Point _point;

        public event PropertyChangedEventHandler PropertyChanged;

        public double X
        {
            get
            {
                return (_point.Position.X * _xZoomFactor) % (_width * 2.0 / 3.0);
            }
        }

        public double Y => _point.Position.Y * _yZoomFactor;
        public Brush Brush { get; }

        public PointVM(bool isBlue, Point point)
        {
            _point = point;
            Brush = isBlue ? Brushes.Blue : Brushes.Red;
        }

        public void RefreshState()
        {
            OnPropertyChanged(nameof(X));
            OnPropertyChanged(nameof(Y));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
