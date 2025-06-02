using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class RectangleShape : Shape
    {
        public RectangleShape(RectangleF rect) : base(rect)
        {
        }

        public RectangleShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        public override bool Contains(PointF point)
        {
            return base.Contains(point);
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

        public override void DrawSelf(Graphics grfx)
        {
            GraphicsState state = grfx.Save();

            PointF center = GetCenter();

            grfx.TranslateTransform(center.X, center.Y);
            grfx.RotateTransform(RotationAngle);
            grfx.ScaleTransform(ScaleX, ScaleY);
            grfx.TranslateTransform(-center.X, -center.Y);

            using (SolidBrush brush = new SolidBrush(FillColor))
            {
                grfx.FillRectangle(brush, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                grfx.DrawRectangle(pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }

            // Logic for naming the shape
            //string displayName = this.Name;
            //using (Font font = new Font("Arial", 10))
            //using (SolidBrush textBrush = new SolidBrush(Color.Black))
            //{
            //    SizeF textSize = grfx.MeasureString(displayName, font);
            //    PointF textLocation = new PointF(
            //        Rectangle.X + (Rectangle.Width / 2) - (textSize.Width / 2),
            //        Rectangle.Y + (Rectangle.Height / 2) - (textSize.Height / 2)
            //    );
            //    grfx.DrawString(displayName, font, textBrush, textLocation);
            //}

            grfx.Restore(state);

            base.DrawSelf(grfx);
        }

        public override object Clone()
        {
            RectangleShape clonedShape = (RectangleShape)base.Clone();

            return clonedShape;
        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(Location.X, Location.Y, Width, Height);
        }
    }
}