using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace RelativityProject
{
    public class SimulationVM
    {
        private readonly List<IPointVM> _points = new List<IPointVM>();
        private readonly World _world;

        public IEnumerable<IPointVM> Points => _points;

        public SeriesCollection Frame1SeriesCollection { get; } = new SeriesCollection();
        private readonly Series _frame1Series;
        public SeriesCollection Frame2SeriesCollection { get; } = new SeriesCollection();
        private readonly Series _frame2Series;
        public SeriesCollection Frame2VelocityCollection { get; } = new SeriesCollection();
        private readonly Series _frame2VelocitySeries;

        private int _frameCount = 0;

        public SimulationVM(World world)
        {
            _world = world;

            foreach(var point in world.Frame1)
            {
                _points.Add(new PointVM(true, point));
            }

            foreach (var point in world.Frame2)
            {
                _points.Add(new PointVM(false, point));
            }

            CompositionTarget.Rendering += Tick;

            _frame1Series = new LineSeries() { Values = new ChartValues<ObservableValue>() };
            Frame1SeriesCollection.Add(_frame1Series);
            _frame2Series = new LineSeries() { Values = new ChartValues<ObservableValue>() };
            Frame2SeriesCollection.Add(_frame2Series);
            _frame2VelocitySeries = new LineSeries() { Values = new ChartValues<ObservableValue>() };
            Frame2VelocityCollection.Add(_frame2VelocitySeries);
        }

        private void Tick(object sender, EventArgs e)
        {
            _frameCount++;
            _world.Tick();

            const int sampleInterval = 1;
            const int velocitySampleInterval = 50;

            foreach(var point in _points)
            {
                point.RefreshState();
            }


            if (_frameCount % velocitySampleInterval == 0)
            {
                _frame2VelocitySeries.Values.Add(new ObservableValue(_world.Frame2.First().Velocity.X));
            }

            if (_frameCount % sampleInterval == 0)
            {
                _frame1Series.Values.Add(new ObservableValue(_world.FirstClockPhase));
                _frame2Series.Values.Add(new ObservableValue(_world.SecondClockPhase));

                if (_frame1Series.Values.Count > 300)
                {
                    _frame1Series.Values.RemoveAt(0);
                    _frame2Series.Values.RemoveAt(0);
                }
            }
        }
    }
}
