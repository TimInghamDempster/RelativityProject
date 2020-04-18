using System;

namespace RelativityProject
{
    public class Vec4
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double T { get; set; }
        public static Vec4 operator +(Vec4 a, Vec4 b)
            => new Vec4() { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z, T = a.T + b.T };
        public static Vec4 operator -(Vec4 a, Vec4 b)
            => new Vec4() { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z, T = a.T - b.T };
        public static Vec4 operator *(Vec4 a, double b)
            => new Vec4() { X = a.X * b, Y = a.Y * b, Z = a.Z * b, T = a.T * b };

        internal double SpatialLength =>
            Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
    }
}
