using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    // 5-pointed star defined by outer (tip) and inner (indent) radii, centered at origin.
    public class Star : Shape2D, IShape2D
    {
        public float OuterRadius { get; private set; }
        public float InnerRadius { get; private set; }

        public Star(float outerRadius, float innerRadius)
        {
            OuterRadius = outerRadius;
            InnerRadius = innerRadius;
        }

        // 10 equal triangles from center, each spanning 36 degrees between adjacent outer/inner vertices
        public float Area => 5f * OuterRadius * InnerRadius * Sin(2f * PI / 10f);
        public float Perimeter => 10f * Sqrt(
            OuterRadius * OuterRadius + InnerRadius * InnerRadius
            - 2f * OuterRadius * InnerRadius * Cos(2f * PI / 10f)
        );

        public (float, float)[] GetVertices()
        {
            var vertices = new (float, float)[10];
            for (int i = 0; i < 10; i++)
            {
                float radius = (i % 2 == 0) ? OuterRadius : InnerRadius;
                // Start at 90 degrees (point at top), step 36 degrees
                float angle_rad = DegToRad(90f + 36f * i);
                vertices[i] = (radius * Cos(angle_rad), radius * Sin(angle_rad));
            }
            return vertices;
        }

        public override (float, float) GetRandomPoint()
        {
            var vertices = GetVertices();
            int tri = (int)(Randomf.Range(0f, 1f) * 10f);
            if (tri >= 10) tri = 9;
            var (bx, by) = vertices[tri];
            var (cx, cy) = vertices[(tri + 1) % 10];
            float r1 = Randomf.Range(0f, 1f);
            float r2 = Randomf.Range(0f, 1f);
            if (r1 + r2 > 1f) { r1 = 1f - r1; r2 = 1f - r2; }
            // Triangle is (0,0), B, C
            return (r1 * bx + r2 * cx, r1 * by + r2 * cy);
        }
    }
}
