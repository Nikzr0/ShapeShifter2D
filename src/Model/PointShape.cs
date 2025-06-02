using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class PointShape : Shape
    {
        public PointShape(PointF location, float size) : base(new RectangleF(location.X - size / 2, location.Y - size / 2, size, size))
        {
            this.FillColor = Color.Black;
            this.BorderColor = Color.Black;
            this.BorderWidth = 1;
        }

        public PointShape(PointF location) : this(location, 5f)
        {
        }


        public PointShape(PointShape source) : base(source)
        {
        }

        public override object Clone()
        {
            PointShape clonedShape = (PointShape)base.Clone();

            return clonedShape;
        }

        public override bool Contains(PointF point)
        {
            float centerX = Location.X + Width / 2;
            float centerY = Location.Y + Height / 2;
            float distance = (float)Math.Sqrt(Math.Pow(point.X - centerX, 2) + Math.Pow(point.Y - centerY, 2));
            float hitTolerance = 3f;
            return distance <= (Width / 2) + hitTolerance;
        }

        public override void DrawSelf(Graphics grfx)
        {
            GraphicsState state = grfx.Save();

            PointF center = new PointF(Location.X + Width / 2, Location.Y + Height / 2);
            grfx.TranslateTransform(center.X, center.Y);
            grfx.RotateTransform(RotationAngle);
            grfx.ScaleTransform(ScaleX, ScaleY);
            grfx.TranslateTransform(-center.X, -center.Y);

            using (SolidBrush brush = new SolidBrush(FillColor))
            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                grfx.FillEllipse(brush, Rectangle);
                grfx.DrawEllipse(pen, Rectangle);
            }

            grfx.Restore(state);

            if (IsSelected)
            {
                DrawSelection(grfx);
            }
        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(Location.X, Location.Y, Width, Height);
        }
    }
}