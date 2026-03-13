using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    // General triangle defined by three side lengths.
    // Convention: side a is opposite vertex A, b opposite B, c opposite C.
    // Centered at centroid.
    public class Triangle : Shape2D, IShape2D
    {
        private float a, b, c;
        private (float, float) A, B, C;

        public Triangle(float a, float b, float c)
        {
            this.a = a; this.b = b; this.c = c;

            // Place side c (A-B) along x-axis, compute C via law of cosines
            float cx_raw = (b * b + c * c - a * a) / (2f * c);
            float cy_raw = Sqrt(b * b - cx_raw * cx_raw);

            // Center at centroid
            float centX = (c + cx_raw) / 3f;
            float centY = cy_raw / 3f;

            A = (-centX, -centY);
            B = (c - centX, -centY);
            C = (cx_raw - centX, cy_raw - centY);
        }

        public float Area
        {
            get
            {
                float s = (a + b + c) / 2f;
                return Sqrt(s * (s - a) * (s - b) * (s - c));
            }
        }

        public float Perimeter => a + b + c;

        public override (float, float) GetRandomPoint()
        {
            var (ax, ay) = A;
            var (bx, by) = B;
            var (cx, cy) = C;
            float r1 = Randomf.Range(0f, 1f);
            float r2 = Randomf.Range(0f, 1f);
            if (r1 + r2 > 1f) { r1 = 1f - r1; r2 = 1f - r2; }
            return (
                (1f - r1 - r2) * ax + r1 * bx + r2 * cx,
                (1f - r1 - r2) * ay + r1 * by + r2 * cy
            );
        }
    }
}
