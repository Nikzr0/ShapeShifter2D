using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class TriangleShape : Shape
    {
        public TriangleShape(RectangleF rect) : base(rect) { }

        public TriangleShape(TriangleShape triangle) : base(triangle) { }

        public override bool Contains(PointF point)
        {
            using (Matrix matrix = new Matrix())
            {
                PointF center = new PointF(
                    Rectangle.X + Rectangle.Width / 2,
                    Rectangle.Y + Rectangle.Height / 2);

                matrix.Translate(center.X, center.Y);
                matrix.Rotate(RotationAngle);
                matrix.Scale(ScaleX, ScaleY);
                matrix.Translate(-center.X, -center.Y);

                PointF[] pts = { point };
                matrix.TransformPoints(pts);
                point = pts[0];
            }

            PointF[] trianglePoints = GetTrianglePoints();
            return IsPointInTriangle(point, trianglePoints[0], trianglePoints[1], trianglePoints[2]);
        }

        public override void DrawSelf(Graphics grfx)
        {
            PointF center = new PointF(
                Rectangle.X + Rectangle.Width / 2,
                Rectangle.Y + Rectangle.Height / 2);

            GraphicsState state = grfx.Save();

            grfx.TranslateTransform(center.X, center.Y);
            grfx.RotateTransform(RotationAngle);
            grfx.TranslateTransform(-center.X, -center.Y);


            PointF[] points = GetTrianglePoints();

            using (SolidBrush brush = new SolidBrush(Color.FromArgb((int)(Opacity * 255), FillColor)))
            {
                grfx.FillPolygon(brush, points);
            }

            using (Pen pen = new Pen(Color.FromArgb((int)(Opacity * 255), BorderColor), BorderWidth))
            {
                grfx.DrawPolygon(pen, points);
            }

            grfx.Restore(state);

            if (IsSelected)
                DrawSelection(grfx);
        }
        private PointF[] GetTrianglePoints()
        {
            return new PointF[] {
                new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y),
                new PointF(Rectangle.X, Rectangle.Y + Rectangle.Height),
                new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height)
            };
        }

        private bool IsPointInTriangle(PointF p, PointF a, PointF b, PointF c)
        {
            float d1 = Sign(p, a, b);
            float d2 = Sign(p, b, c);
            float d3 = Sign(p, c, a);

            bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(hasNeg && hasPos);
        }

        private float Sign(PointF p1, PointF p2, PointF p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        public override void DrawSelection(Graphics grfx)
        {
            PointF[] points = GetTrianglePoints();
            using (Pen pen = new Pen(Color.Blue, 2) { DashStyle = DashStyle.Dash })
            {
                float minX = Math.Min(Math.Min(points[0].X, points[1].X), points[2].X);
                float minY = Math.Min(Math.Min(points[0].Y, points[1].Y), points[2].Y);
                float maxX = Math.Max(Math.Max(points[0].X, points[1].X), points[2].X);
                float maxY = Math.Max(Math.Max(points[0].Y, points[1].Y), points[2].Y);

                grfx.DrawRectangle(pen, minX - 2, minY - 2, maxX - minX + 4, maxY - minY + 4);
            }
        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(Location.X, Location.Y, Width, Height);
        }

        public override object Clone()
        {
            return new TriangleShape(this);
        }
    }
}