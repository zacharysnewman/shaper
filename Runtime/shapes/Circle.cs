﻿using System;
using ShapeCalculations.Random;
using static ShapeCalculations.Math.Mathf;

namespace ShapeCalculations.Shapes
{
    public class Circle : IRandomPointable
    {
        public float Radius { get; private set; }
        public float Diameter { get => 2f * this.Radius; }
        public float Area { get => PI * Pow(this.Radius, 2); }
        public float Perimeter { get => 2f * PI * this.Radius; }

        public Circle(float radius)
        {
            this.Radius = radius;
        }

        public (float, float) GetRandomPoint()
        {
            // Get Angle in radians
            float theta = 2 * PI * Randomf.Range(0f, 1f);

            // Get length from center
            float len = Sqrt(Randomf.Range(0f, 1f));

            // Add point to results.
            float xPos = len * Cos(theta) * this.Radius;
            float yPos = len * Sin(theta) * this.Radius;
            return (xPos, yPos);
        }
    } 
}
