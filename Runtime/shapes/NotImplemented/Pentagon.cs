using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    public class Pentagon : Shape2D, IShape2D
    {
        public float Circumradius { get; private set; }

        public Pentagon(float circumradius)
        {
            Circumradius = circumradius;
        }

        public float Area => (5f / 2f) * Circumradius * Circumradius * Sin(2f * PI / 5f);
        public float Perimeter => 5f * 2f * Circumradius * Sin(PI / 5f);

        public (float, float)[] GetVertices()
        {
            var vertices = new (float, float)[5];
            for (int i = 0; i < 5; i++)
            {
                float angle_rad = DegToRad(90f + 72f * i);
                vertices[i] = (Circumradius * Cos(angle_rad), Circumradius * Sin(angle_rad));
            }
            return vertices;
        }

        public override (float, float) GetRandomPoint()
        {
            var vertices = GetVertices();
            int tri = (int)(Randomf.Range(0f, 1f) * 5f);
            if (tri >= 5) tri = 4;
            var (bx, by) = vertices[tri];
            var (cx, cy) = vertices[(tri + 1) % 5];
            float r1 = Randomf.Range(0f, 1f);
            float r2 = Randomf.Range(0f, 1f);
            if (r1 + r2 > 1f) { r1 = 1f - r1; r2 = 1f - r2; }
            return (r1 * bx + r2 * cx, r1 * by + r2 * cy);
        }
    }
}
