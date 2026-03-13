using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    // Right triangle with the right angle at the origin before centering.
    // Centered at centroid.
    public class TriangleRight : Shape2D, IShape2D
    {
        public float Base { get; private set; }
        public float Height { get; private set; }

        public TriangleRight(float @base, float height)
        {
            Base = @base;
            Height = height;
        }

        public float Area => Base * Height / 2f;
        public float Perimeter => Base + Height + Sqrt(Base * Base + Height * Height);

        // Vertices centered at centroid: right angle was at (0,0), so centroid = (Base/3, Height/3)
        private (float, float) VA => (-Base / 3f, -Height / 3f);
        private (float, float) VB => (2f * Base / 3f, -Height / 3f);
        private (float, float) VC => (-Base / 3f, 2f * Height / 3f);

        public override (float, float) GetRandomPoint()
        {
            var (ax, ay) = VA;
            var (bx, by) = VB;
            var (cx, cy) = VC;
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
