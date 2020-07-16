using System;
using System.Windows;

namespace RelativityProject
{
    public class Point : ITickable
    {
        private readonly double _timestep;
        public Point(Vec4 pos, Vec4 vel, double timestep)
        {
            Position = pos;
            Velocity = vel;
            _timestep = timestep;
        }

        public Vec4 Position { get; private set; } = new Vec4();
        public Vec4 Velocity { get; private set; } = new Vec4();
        public Vec4 Acceleration { get; set; } = new Vec4();

        public void Tick()
        {
            IntegratePosition();
            EnforceFourVelocity();
        }

        private void EnforceFourVelocity()
        {
            Velocity.T = Math.Sqrt(1.0 - (Math.Pow(Velocity.X, 2.0) + Math.Pow(Velocity.Y, 2.0) + Math.Pow(Velocity.Z, 2.0)));
            if(double.IsNaN(Velocity.T))
            {
                throw new ArgumentException("Velocity exceeded C");
            }
        }

        private void IntegratePosition()
        {
            Velocity += Acceleration * Velocity.T * _timestep;
            Position += Velocity * _timestep;
            Acceleration = Vec4.Zero;
        }
    }
}
