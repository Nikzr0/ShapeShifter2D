using System;
using System.Drawing;

namespace Draw
{
    [Serializable]
    public class StarShape : Shape
    {
        public StarShape(RectangleF rect) : base(rect) { }
        public StarShape(StarShape star) : base(star) { }

        public override void DrawSelf(Graphics grfx)
        {
            PointF center = new PointF(
                Rectangle.X + Rectangle.Width / 2,
                Rectangle.Y + Rectangle.Height / 2);

            grfx.TranslateTransform(center.X, center.Y);
            grfx.RotateTransform(RotationAngle);
            grfx.ScaleTransform(ScaleX, ScaleY);
            grfx.TranslateTransform(-center.X, -center.Y);

            float outerRadius = Math.Min(Rectangle.Width, Rectangle.Height) / 2;
            float innerRadius = outerRadius / 2.5f;
            PointF[] starPoints = CreateStarPoints(center.X, center.Y, outerRadius, innerRadius, 5);

            using (SolidBrush brush = new SolidBrush(Color.FromArgb((int)(Opacity * 255), FillColor)))
            using (Pen pen = new Pen(Color.FromArgb((int)(Opacity * 255), BorderColor), BorderWidth))
            {
                grfx.FillPolygon(brush, starPoints);
                grfx.DrawPolygon(pen, starPoints);
            }

            grfx.ResetTransform();
        }

        private PointF[] CreateStarPoints(float cx, float cy, float outerRadius, float innerRadius, int numPoints)
        {
            PointF[] points = new PointF[numPoints * 2];
            double step = Math.PI / numPoints;
            double angle = -Math.PI / 2;

            for (int i = 0; i < numPoints * 2; i++)
            {
                float radius = (i % 2 == 0) ? outerRadius : innerRadius;
                points[i] = new PointF(
                    cx + (float)(Math.Cos(angle) * radius),
                    cy + (float)(Math.Sin(angle) * radius));
                angle += step;
            }

            return points;
        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(Location.X, Location.Y, Width, Height);
        }

        public override object Clone()
        {
            return new StarShape(this);
        }
    }
}
