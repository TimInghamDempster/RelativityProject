using System;
using System.Collections.Generic;
using System.Text;

namespace RelativityProject
{
    public class World
    {
        private readonly List<Point> _frame1 = new List<Point>();
        private readonly List<Point> _frame2 = new List<Point>();

        public IEnumerable<Point> Frame1 => _frame1;

        public IEnumerable<Point> Frame2 => _frame2;

        public double FirstClockPhase => _springs[0].Length;
        public double SecondClockPhase => _springs[1].Length;

        private readonly List<Spring> _springs = new List<Spring>();
        private readonly List<ITickable> _tickables = new List<ITickable>();

        public World()
        {
            var p1 = new Point(new Vec4() { X = 10, Y = 0.0001 }, new Vec4() { T = 1 });
            var p2 = new Point(new Vec4() { X = 10, Y = 0.0002 }, new Vec4() { T = 1 });
            _frame1.Add(p1);
            _frame1.Add(p2);

            var s1 = new Spring(p1, p2);
            _springs.Add(s1);


            var p3 = new Point(new Vec4() { X = 10, Y = 0.0005 }, new Vec4() { T = 1 });
            var p4 = new Point(new Vec4() { X = 10, Y = 0.0006 }, new Vec4() { T = 1 });
            _frame2.Add(p3);
            _frame2.Add(p4);

            var s2 = new Spring(p3, p4);
            _springs.Add(s1);

            _tickables.Add(p1);
            _tickables.Add(p2);
            _tickables.Add(p3);
            _tickables.Add(p4);
            _tickables.Add(s1);
            _tickables.Add(s2);
        }

        internal void Tick()
        {
            const double frame2Force = 0.001;
            foreach(var tickable in _tickables)
            {
                tickable.Tick();
            }
            foreach(var point in _frame2)
            {
                point.Velocity.X += frame2Force;
            }
        }
    }
}
