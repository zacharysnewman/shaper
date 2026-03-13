using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    // Parallelogram with a horizontal base, given height, and horizontal shear of the top edge.
    // Centered at centroid.
    public class Parallelogram : Shape2D, IShape2D
    {
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float Shear { get; private set; }

        public Parallelogram(float width, float height, float shear)
        {
            Width = width;
            Height = height;
            Shear = shear;
        }

        public float Area => Width * Height;
        public float Perimeter => 2f * Width + 2f * Sqrt(Height * Height + Shear * Shear);

        public override (float, float) GetRandomPoint()
        {
            float t1 = Randomf.Range(0f, 1f);
            float t2 = Randomf.Range(0f, 1f);
            // point_raw = t1*(Width,0) + t2*(Shear,Height), then center
            float x = t1 * Width + t2 * Shear - (Width + Shear) / 2f;
            float y = t2 * Height - Height / 2f;
            return (x, y);
        }
    }
}
