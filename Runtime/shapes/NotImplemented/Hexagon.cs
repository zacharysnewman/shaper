﻿using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    public class Hexagon : Shape2D, IShape2D
    {
        public Hexagon()
        {
            throw new NotImplementedException();
        }

        public float Area => throw new NotImplementedException();
        public float Perimeter => throw new NotImplementedException();

        public override (float, float) GetRandomPoint() => throw new NotImplementedException();
    }
}
