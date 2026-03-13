using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    public class Hexagon : Shape2D, IShape2D
    {
        public float Circumradius { get; private set; }

        public Hexagon(float circumradius)
        {
            Circumradius = circumradius;
        }

        public float Area => 3f * Sqrt(3f) / 2f * Circumradius * Circumradius;

        // Side length of a regular hexagon equals its circumradius
        public float Perimeter => 6f * Circumradius;

        public float Width => 2f * Circumradius;

        public float Height => Sqrt(3f) * Circumradius;

        public (float, float)[] GetVertices()
        {
            var vertices = new (float, float)[6];
            for (int i = 0; i < 6; i++)
            {
                float angle_rad = DegToRad(60f * i - 30f);
                vertices[i] = (Circumradius * Cos(angle_rad), Circumradius * Sin(angle_rad));
            }
            return vertices;
        }

        public override (float, float) GetRandomPoint()
        {
            var vertices = GetVertices();
            int tri = (int)(Randomf.Range(0f, 1f) * 6f);
            if (tri >= 6) tri = 5;
            var (bx, by) = vertices[tri];
            var (cx, cy) = vertices[(tri + 1) % 6];
            float r1 = Randomf.Range(0f, 1f);
            float r2 = Randomf.Range(0f, 1f);
            if (r1 + r2 > 1f) { r1 = 1f - r1; r2 = 1f - r2; }
            return (r1 * bx + r2 * cx, r1 * by + r2 * cy);
        }
    }
}
