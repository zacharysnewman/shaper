using System;
using Shaper.Random;
using static Shaper.Math.Mathf;

namespace Shaper.Shapes
{
    public class RingElliptical : Shape2D, IShape2D
    {
        public Ellipse InnerEllipse { get; private set; }
        public Ellipse OuterEllipse { get; private set; }

        public float Area => OuterEllipse.Area - InnerEllipse.Area;
        public float Perimeter => OuterEllipse.Perimeter + InnerEllipse.Perimeter;

        public RingElliptical(float innerRadiusWidth, float innerRadiusHeight, float outerRadiusWidth, float outerRadiusHeight)
        {
            this.InnerEllipse = new Ellipse(innerRadiusWidth, innerRadiusHeight);
            this.OuterEllipse = new Ellipse(outerRadiusWidth, outerRadiusHeight);
        }

        // Source: https://stackoverflow.com/questions/9048095/create-random-number-within-an-annulus
        public override (float, float) GetRandomPoint()
        {
            float ow = OuterEllipse.RadiusWidth;
            float oh = OuterEllipse.RadiusHeight;
            float iw = InnerEllipse.RadiusWidth;
            float ih = InnerEllipse.RadiusHeight;

            while (true)
            {
                float x = Randomf.Range(-ow, ow);
                float y = Randomf.Range(-oh, oh);
                bool insideOuter = (x * x) / (ow * ow) + (y * y) / (oh * oh) <= 1f;
                bool insideInner = (x * x) / (iw * iw) + (y * y) / (ih * ih) <= 1f;
                if (insideOuter && !insideInner)
                    return (x, y);
            }
        }
    }
}
