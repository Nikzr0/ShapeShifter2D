using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class LineShape : Shape
    {
        public PointF EndPoint { get; set; }

        public LineShape(PointF startPoint, PointF endPoint)
                : base(new RectangleF(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y), Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y)))
        {
            Location = startPoint;
            EndPoint = endPoint;
            FillColor = Color.Transparent;
            BorderColor = Color.Black;
            Opacity = 1.0f;
        }

        public LineShape(LineShape source) : base(source)
        {
            this.EndPoint = source.EndPoint;
        }

        public override void DrawSelf(Graphics grfx)
        {
            GraphicsState state = grfx.Save();

            PointF center = GetCenter();
            grfx.TranslateTransform(center.X, center.Y);
            grfx.RotateTransform(RotationAngle);
            grfx.ScaleTransform(ScaleX, ScaleY);
            grfx.TranslateTransform(-center.X, -center.Y);

            using (Pen pen = new Pen(Color.FromArgb((int)(Opacity * 255), originalBorderColor), BorderWidth))
            {
                grfx.DrawLine(pen, Location, EndPoint);
            }

            grfx.Restore(state);

            if (IsSelected)
                DrawSelection(grfx);
        }

        public override void DrawSelection(Graphics grfx)
        {
            using (Pen selectionPen = new Pen(Color.Blue, 1f) { DashStyle = DashStyle.Dash })
            {
                RectangleF bounds = GetBounds();
                grfx.DrawRectangle(selectionPen, bounds.X, bounds.Y, bounds.Width, bounds.Height);

                float markerSize = 8f;
                grfx.FillRectangle(Brushes.Blue,
                    Location.X - markerSize / 2, Location.Y - markerSize / 2,
                    markerSize, markerSize);

                grfx.FillRectangle(Brushes.Blue,
                    EndPoint.X - markerSize / 2, EndPoint.Y - markerSize / 2,
                    markerSize, markerSize);
            }
        }

        public override void Resize(float scaleX, float scaleY)
        {
            float dx = EndPoint.X - Location.X;
            float dy = EndPoint.Y - Location.Y;

            EndPoint = new PointF(Location.X + dx * scaleX, Location.Y + dy * scaleY);
        }

        public override void Rotate(float angle)
        {
            RotationAngle = (RotationAngle + angle) % 360;
        }

        public override bool Contains(PointF point)
        {
            using (Matrix matrix = new Matrix())
            {
                matrix.RotateAt(-RotationAngle, GetCenter());
                PointF[] pts = { point };
                matrix.TransformPoints(pts);
                point = pts[0];
            }

            if (!GetBounds().Contains(point))
                return false;

            return IsPointNearLine(Location, EndPoint, point, BorderWidth + 3f);
        }

        public override RectangleF GetBounds()
        {
            float x = Math.Min(Location.X, EndPoint.X);
            float y = Math.Min(Location.Y, EndPoint.Y);
            float width = Math.Abs(EndPoint.X - Location.X);
            float height = Math.Abs(EndPoint.Y - Location.Y);

            float padding = BorderWidth + 5f;
            return new RectangleF(x - padding, y - padding,
                width + 2 * padding, height + 2 * padding);
        }

        public override PointF GetCenter()
        {
            return new PointF((Location.X + EndPoint.X) / 2, (Location.Y + EndPoint.Y) / 2);
        }

        public override void TranslateTo(PointF newLocation)
        {
            float dx = newLocation.X - Location.X;
            float dy = newLocation.Y - Location.Y;

            Location = newLocation;
            EndPoint = new PointF(EndPoint.X + dx, EndPoint.Y + dy);
        }

        private bool IsPointNearLine(PointF start, PointF end, PointF point, float tolerance)
        {
            float lineLength = Distance(start, end);
            if (lineLength == 0) return Distance(start, point) <= tolerance;

            float dot = (((point.X - start.X) * (end.X - start.X)) + ((point.Y - start.Y) * (end.Y - start.Y))) / (lineLength * lineLength);
            dot = Math.Max(0, Math.Min(1, dot));

            float closestX = start.X + (dot * (end.X - start.X));
            float closestY = start.Y + (dot * (end.Y - start.Y));

            return Distance(point, new PointF(closestX, closestY)) <= tolerance;
        }

        private float Distance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        public override object Clone()
        {
            LineShape clonedShape = (LineShape)base.Clone();

            return clonedShape;
        }

        public override void TranslateBy(float dx, float dy)
        {
            Location = new PointF(Location.X + dx, Location.Y + dy);
            EndPoint = new PointF(EndPoint.X + dx, EndPoint.Y + dy);
        }
    }
}