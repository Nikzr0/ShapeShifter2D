using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class EllipseShape : Shape
    {
        private PointF _originalLocation;
        private SizeF _originalSize;

        public EllipseShape(RectangleF rect) : base(rect)
        {
            _originalLocation = Location;
            _originalSize = new SizeF(Width, Height);
        }

        public EllipseShape(EllipseShape ellipse) : base(ellipse)
        {
            _originalLocation = ellipse._originalLocation;
            _originalSize = ellipse._originalSize;
        }

        public override bool Contains(PointF point)
        {
            float centerX = Location.X + Width / 2;
            float centerY = Location.Y + Height / 2;
            float xRadius = Width / 2;
            float yRadius = Height / 2;

            float normalizedX = (point.X - centerX) / xRadius;
            float normalizedY = (point.Y - centerY) / yRadius;

            return (normalizedX * normalizedX + normalizedY * normalizedY) <= 1.0f;
        }

        public override void Scale(float scaleFactor)
        {
            PointF center = new PointF(
                Location.X + Width / 2,
                Location.Y + Height / 2
            );

            Width *= scaleFactor;
            Height *= scaleFactor;

            Location = new PointF(
                center.X - Width / 2,
                center.Y - Height / 2
            );
        }

        public override void TranslateTo(PointF newLocation)
        {
            _originalLocation = new PointF(
                newLocation.X - (Width - _originalSize.Width) / 2,
                newLocation.Y - (Height - _originalSize.Height) / 2
            );
            base.TranslateTo(newLocation);
        }

        public override void DrawSelf(Graphics grfx)
        {
            GraphicsContainer container = grfx.BeginContainer();

            grfx.TranslateTransform(Location.X + Width / 2, Location.Y + Height / 2);
            grfx.RotateTransform(RotationAngle);
            grfx.ScaleTransform(ScaleX, ScaleY);
            grfx.TranslateTransform(-(Location.X + Width / 2), -(Location.Y + Height / 2));

            using (SolidBrush brush = new SolidBrush(Color.FromArgb((int)(Opacity * 255), originalFillColor)))
            using (Pen pen = new Pen(Color.FromArgb((int)(Opacity * 255), originalBorderColor), BorderWidth))
            {
                grfx.FillEllipse(brush, Rectangle);
                grfx.DrawEllipse(pen, Rectangle);
            }

            grfx.EndContainer(container);
        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(Location.X, Location.Y, Width, Height);
        }
        public override object Clone()
        {
            EllipseShape clonedShape = (EllipseShape)base.Clone();

            return clonedShape;
        }
    }
}