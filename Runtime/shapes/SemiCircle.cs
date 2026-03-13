using System;
using System.Collections.Generic;
using Shaper.Random;
using Shaper.Math;

namespace Shaper.Shapes
{
    public class SemiCircle : Shape2D, IShape2D
    {
        private float radius;
        private float arcAngle; // Arc angle in degrees

        public float Area
        {
            get
            {
                // Calculate area based on the arc angle
                float fullCircleArea = Mathf.PI * Mathf.Pow(radius, 2);
                return (arcAngle / 360f) * fullCircleArea;
            }
        }

        public float Perimeter
        {
            get
            {
                // Calculate perimeter based on the arc angle
                float fullCirclePerimeter = 2 * Mathf.PI * radius;
                return (arcAngle / 360f) * fullCirclePerimeter + 2 * radius; // Add the straight segment
            }
        }

        public SemiCircle(float radius, float arcAngle) : base()
        {
            this.radius = radius;
            this.arcAngle = arcAngle;
        }

        public List<(float, float)> GetRelativePoints(int pointsPerDegree = 360)
        {
            List<(float, float)> points = new List<(float, float)>();

            // Center point
            points.Add((0, 0));

            // First corner point
            float startX = radius * Mathf.Cos(Mathf.DegToRad(0));
            float startY = radius * Mathf.Sin(Mathf.DegToRad(0));
            points.Add((startX, startY));

            // Arc points
            for (int i = 1; i <= arcAngle * pointsPerDegree; i++)
            {
                float angle = (1.0f / pointsPerDegree) * i;
                float x = radius * Mathf.Cos(Mathf.DegToRad(angle));
                float y = radius * Mathf.Sin(Mathf.DegToRad(angle));
                points.Add((x, y));
            }

            // Last corner point
            float endX = radius * Mathf.Cos(Mathf.DegToRad(arcAngle));
            float endY = radius * Mathf.Sin(Mathf.DegToRad(arcAngle));
            points.Add((endX, endY));

            return points;
        }

        public override (float, float) GetRandomPoint()
        {
            float theta = Mathf.DegToRad(Randomf.Range(0f, arcAngle));
            float len = Mathf.Sqrt(Randomf.Range(0f, 1f));
            float x = len * Mathf.Cos(theta) * radius;
            float y = len * Mathf.Sin(theta) * radius;
            return (x, y);
        }
    }
}
