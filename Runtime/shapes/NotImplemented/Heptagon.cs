using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    public class Heptagon : Shape2D, IShape2D
    {
        public float Circumradius { get; private set; }

        public Heptagon(float circumradius)
        {
            Circumradius = circumradius;
        }

        public float Area => (7f / 2f) * Circumradius * Circumradius * Sin(2f * PI / 7f);
        public float Perimeter => 7f * 2f * Circumradius * Sin(PI / 7f);

        public (float, float)[] GetVertices()
        {
            var vertices = new (float, float)[7];
            for (int i = 0; i < 7; i++)
            {
                float angle_rad = DegToRad(90f + (360f / 7f) * i);
                vertices[i] = (Circumradius * Cos(angle_rad), Circumradius * Sin(angle_rad));
            }
            return vertices;
        }

        public override (float, float) GetRandomPoint()
        {
            var vertices = GetVertices();
            int tri = (int)(Randomf.Range(0f, 1f) * 7f);
            if (tri >= 7) tri = 6;
            var (bx, by) = vertices[tri];
            var (cx, cy) = vertices[(tri + 1) % 7];
            float r1 = Randomf.Range(0f, 1f);
            float r2 = Randomf.Range(0f, 1f);
            if (r1 + r2 > 1f) { r1 = 1f - r1; r2 = 1f - r2; }
            return (r1 * bx + r2 * cx, r1 * by + r2 * cy);
        }
    }
}
