using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    public class Octagon : Shape2D, IShape2D
    {
        public float Circumradius { get; private set; }

        public Octagon(float circumradius)
        {
            Circumradius = circumradius;
        }

        public float Area => (8f / 2f) * Circumradius * Circumradius * Sin(2f * PI / 8f);
        public float Perimeter => 8f * 2f * Circumradius * Sin(PI / 8f);

        public (float, float)[] GetVertices()
        {
            var vertices = new (float, float)[8];
            for (int i = 0; i < 8; i++)
            {
                // 22.5 degree offset gives flat top/bottom
                float angle_rad = DegToRad(22.5f + 45f * i);
                vertices[i] = (Circumradius * Cos(angle_rad), Circumradius * Sin(angle_rad));
            }
            return vertices;
        }

        public override (float, float) GetRandomPoint()
        {
            var vertices = GetVertices();
            int tri = (int)(Randomf.Range(0f, 1f) * 8f);
            if (tri >= 8) tri = 7;
            var (bx, by) = vertices[tri];
            var (cx, cy) = vertices[(tri + 1) % 8];
            float r1 = Randomf.Range(0f, 1f);
            float r2 = Randomf.Range(0f, 1f);
            if (r1 + r2 > 1f) { r1 = 1f - r1; r2 = 1f - r2; }
            return (r1 * bx + r2 * cx, r1 * by + r2 * cy);
        }
    }
}
