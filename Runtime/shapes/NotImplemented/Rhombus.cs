using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    // Rhombus defined by its two diagonals (horizontal and vertical), centered at origin.
    public class Rhombus : Shape2D, IShape2D
    {
        public float DiagonalWidth { get; private set; }
        public float DiagonalHeight { get; private set; }

        public Rhombus(float diagonalWidth, float diagonalHeight)
        {
            DiagonalWidth = diagonalWidth;
            DiagonalHeight = diagonalHeight;
        }

        public float Area => DiagonalWidth * DiagonalHeight / 2f;
        public float Perimeter => 4f * Sqrt(
            (DiagonalWidth / 2f) * (DiagonalWidth / 2f) +
            (DiagonalHeight / 2f) * (DiagonalHeight / 2f)
        );

        // Vertices along the diagonals, already centered
        private (float, float) V0 => (DiagonalWidth / 2f, 0f);
        private (float, float) V1 => (0f, DiagonalHeight / 2f);
        private (float, float) V2 => (-DiagonalWidth / 2f, 0f);
        private (float, float) V3 => (0f, -DiagonalHeight / 2f);

        public override (float, float) GetRandomPoint()
        {
            // Split into 4 equal triangles from center; pick one randomly
            int tri = (int)(Randomf.Range(0f, 1f) * 4f);
            if (tri >= 4) tri = 3;
            (float, float)[] verts = { V0, V1, V2, V3 };
            var (bx, by) = verts[tri];
            var (cx, cy) = verts[(tri + 1) % 4];
            float r1 = Randomf.Range(0f, 1f);
            float r2 = Randomf.Range(0f, 1f);
            if (r1 + r2 > 1f) { r1 = 1f - r1; r2 = 1f - r2; }
            // Triangle is (0,0), B, C
            return (r1 * bx + r2 * cx, r1 * by + r2 * cy);
        }
    }
}
