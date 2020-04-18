namespace RelativityProject
{
    public class Point : ITickable
    {
        public Point(Vec4 pos, Vec4 vel)
        {
            Position = pos;
            Velocity = vel;
        }

        public Vec4 Position { get; private set; } = new Vec4();
        public Vec4 Velocity { get; set; } = new Vec4();

        public void Tick()
        {
            Position += Velocity;
        }
    }
}
