namespace RelativityProject
{
    public class Spring : ITickable
    {
        private readonly Point _pointA;
        private readonly Point _pointB;

        public Spring(Point pointA, Point pointB)
        {
            _pointA = pointA;
            _pointB = pointB;
        }

        public double Length { get; private set; }

        public void Tick()
        {
            const double k = 0.001;
            Vec4 delta = _pointA.Position - _pointB.Position;

            // We should only be applying this between points at the
            // the same time co-ordinate, but there could be drift due
            // to numerical precision, so null it explicitly
            delta.T = 0;

            Length = delta.SpatialLength;

            _pointA.Acceleration -= delta * k;
            _pointB.Acceleration += delta * k;
        }
    }
}
