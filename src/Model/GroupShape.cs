using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class GroupShape : Shape
    {
        private List<Shape> shapes = new List<Shape>();

        public List<Shape> Shapes => shapes;

        public override Color FillColor
        {
            get => base.FillColor;
            set
            {
                foreach (var shape in Shapes)
                {
                    shape.FillColor = value;
                }
            }
        }

        public override Color BorderColor
        {
            get => base.BorderColor;
            set
            {
                foreach (var shape in Shapes)
                {
                    shape.BorderColor = value;
                }
            }
        }

        public override float BorderWidth
        {
            get => base.BorderWidth;
            set
            {
                base.BorderWidth = value;
                foreach (var shape in Shapes)
                {
                    shape.BorderWidth = value;
                }
            }
        }

        public override float Opacity
        {
            get => base.Opacity;
            set
            {
                base.Opacity = value;
                foreach (var shape in Shapes)
                {
                    shape.Opacity = value;
                }
            }
        }

        public GroupShape() : base()
        {
            Rectangle = RectangleF.Empty;
            FillColor = Color.Transparent;
            BorderColor = Color.Transparent;
            Opacity = 1.0f;
        }

        public GroupShape(GroupShape group) : base(group)
        {
            foreach (var shape in group.Shapes)
            {
                shapes.Add((Shape)shape.Clone());
            }
            GetBounds();
        }

        public override void DrawSelf(Graphics grfx)
        {
          
            foreach (var shape in Shapes)
            {
                shape.DrawSelf(grfx);
            }

            if (IsSelected)
            {
                DrawSelection(grfx);
            }
        }

        public override bool Contains(PointF point)
        {
            using (Matrix matrix = new Matrix())
            {
                PointF groupCenter = GetCenter();
                matrix.Translate(groupCenter.X, groupCenter.Y);
                matrix.Rotate(RotationAngle);
                matrix.Scale(ScaleX, ScaleY);
                matrix.Translate(-groupCenter.X, -groupCenter.Y);
                matrix.Invert();
                PointF[] transformedPoint = { point };
                matrix.TransformPoints(transformedPoint);
                point = transformedPoint[0];
            }

            foreach (var shape in shapes)
            {
                if (shape.Contains(point))
                    return true;
            }
            return false;
        }

        public override void Rotate(float angle)
        {
            foreach (var shape in shapes)
            {
                shape.Rotate(angle);
            }

            GetBounds();
        }

        public override void Scale(float scaleFactor)
        {
            foreach (var shape in shapes)
            {
                shape.Scale(scaleFactor);
            }

            GetBounds();
        }

        public override PointF GetCenter()
        {
            RectangleF bounds = GetBounds();
            return new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
        }

        public override RectangleF GetBounds()
        {
            if (shapes.Count == 0)
            {
                Rectangle = RectangleF.Empty;
                return RectangleF.Empty;
            }

            float minX = float.MaxValue, minY = float.MaxValue;
            float maxX = float.MinValue, maxY = float.MinValue;

            foreach (var shape in shapes)
            {
                RectangleF shapeBounds = shape.GetBounds();
                minX = Math.Min(minX, shapeBounds.Left);
                minY = Math.Min(minY, shapeBounds.Top);
                maxX = Math.Max(maxX, shapeBounds.Right);
                maxY = Math.Max(maxY, shapeBounds.Bottom);
            }

            Rectangle = new RectangleF(minX, minY, maxX - minX, maxY - minY);
            return Rectangle;
        }

        public override void DrawSelection(Graphics grfx)
        {
            if (!IsSelected) return;

            RectangleF bounds = GetBounds();
            using (Pen pen = new Pen(Color.Gray, 2f) { DashStyle = DashStyle.Dash })
            {
                grfx.DrawRectangle(pen, bounds.X - 2, bounds.Y - 2, bounds.Width + 4, bounds.Height + 4);
            }
        }

        public override void TranslateBy(float dx, float dy)
        {
            foreach (var shape in shapes)
            {
                shape.TranslateBy(dx, dy);
            }
            Rectangle = new RectangleF(Rectangle.X + dx, Rectangle.Y + dy, Rectangle.Width, Rectangle.Height);
        }

        public override void TranslateTo(PointF newPosition)
        {
            PointF currentCenter = GetCenter();
            float dx = newPosition.X - currentCenter.X;
            float dy = newPosition.Y - currentCenter.Y;
            TranslateBy(dx, dy);
        }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
            GetBounds();
        }

        public void RemoveShape(Shape shape)
        {
            shapes.Remove(shape);
            GetBounds();
        }

        public override object Clone()
        {
            GroupShape clonedShape = (GroupShape)base.Clone();
            clonedShape.shapes = new List<Shape>();

            foreach (var shape in this.shapes)
            {
                clonedShape.shapes.Add((Shape)shape.Clone());
            }

            return clonedShape;
        }
    }
}