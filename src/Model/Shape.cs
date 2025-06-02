using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Draw
{
    [Serializable]
    public abstract class Shape : ICloneable
    {
        private static int shapeCounter = 0;

        private RectangleF rectangle;
        [Browsable(false)]
        public virtual RectangleF Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        [Category("Size and Position")]
        [DisplayName("Width")]
        [Description("The width of the shape.")]
        public virtual float Width
        {
            get { return Rectangle.Width; }
            set { Rectangle = new RectangleF(Rectangle.X, Rectangle.Y, value, Rectangle.Height); }
        }

        [Category("Size and Position")]
        [DisplayName("Height")]
        [Description("The height of the shape.")]
        public virtual float Height
        {
            get { return Rectangle.Height; }
            set { Rectangle = new RectangleF(Rectangle.X, Rectangle.Y, Rectangle.Width, value); }
        }

        [Category("Size and Position")]
        [DisplayName("Location")]
        [Description("The top-left corner position of the shape.")]
        public virtual PointF Location
        {
            get { return Rectangle.Location; }
            set { Rectangle = new RectangleF(value.X, value.Y, Rectangle.Width, Rectangle.Height); }
        }

        protected Color originalFillColor;
        protected Color originalBorderColor;

        private Color fillColor;
        [Category("Appearance")]
        [DisplayName("Fill Color")]
        [Description("The color used to fill the shape.")]
        public virtual Color FillColor
        {
            get { return fillColor; }
            set
            {
                originalFillColor = value;
                UpdateColorsWithOpacity();
            }
        }

        private Color borderColor;
        [Category("Appearance")]
        [DisplayName("Border Color")]
        [Description("The color of the shape's border.")]
        public virtual Color BorderColor
        {
            get { return borderColor; }
            set
            {
                originalBorderColor = value;
                UpdateColorsWithOpacity();
            }
        }

        [Category("Appearance")]
        [DisplayName("Border Width")]
        [Description("The thickness of the shape's border.")]
        public virtual float BorderWidth { get; set; } = 1;

        private float opacity;
        [Category("Appearance")]
        [DisplayName("Opacity")]
        [Description("The opacity of the shape (value between 0.0 and 1.0, where 1.0 is fully opaque).")]
        public virtual float Opacity
        {
            get { return opacity; }
            set
            {
                opacity = Math.Max(0f, Math.Min(1f, value));
                UpdateColorsWithOpacity();
            }
        }

        [Browsable(false)]
        public bool IsSelected { get; set; } = false;

        [Category("Transformations")]
        [DisplayName("Rotation Angle")]
        [Description("The rotation angle of the shape in degrees.")]
        public virtual float RotationAngle { get; set; } = 0f;

        [Category("Transformations")]
        [DisplayName("Scale X")]
        [Description("The scaling factor along the X-axis.")]
        public virtual float ScaleX { get; set; } = 1f;

        [Category("Transformations")]
        [DisplayName("Scale Y")]
        [Description("The scaling factor along the Y-axis.")]
        public virtual float ScaleY { get; set; } = 1f;

        private string name;
        [Category("Identification")]
        [DisplayName("Name")]
        [Description("A unique name for identifying the object.")]
        public virtual string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Trim().Length == 0)
                {
                    name = $"Shape {shapeCounter}";
                }
                else
                {
                    name = value;
                }
            }
        }

        public Shape()
        {
            rectangle = new RectangleF(0, 0, 1, 1);
            FillColor = Color.White;
            BorderColor = Color.Black;
            BorderWidth = 1;
            Opacity = 1.0f;
            IsSelected = false;
            RotationAngle = 0f;
            ScaleX = 1f;
            ScaleY = 1f;
            shapeCounter++;
            this.Name = $"Shape {shapeCounter}";
        }

        public Shape(RectangleF rect)
        {
            rectangle = rect;
            FillColor = Color.White;
            BorderColor = Color.Black;
            Opacity = 1.0f;
            shapeCounter++;
            this.Name = $"Shape {shapeCounter}";
        }

        public Shape(Shape source)
        {
            this.rectangle = source.rectangle;
            this.originalFillColor = source.originalFillColor;
            this.originalBorderColor = source.originalBorderColor;
            this.fillColor = source.fillColor;
            this.borderColor = source.borderColor;
            this.BorderWidth = source.BorderWidth;
            this.opacity = source.opacity;
            this.IsSelected = false;
            this.RotationAngle = source.RotationAngle;
            this.ScaleX = source.ScaleX;
            this.ScaleY = source.ScaleY;
            this.Name = source.Name;
        }

        protected void UpdateColorsWithOpacity()
        {
            this.fillColor = Color.FromArgb((int)(Opacity * 255), originalFillColor);
            this.borderColor = Color.FromArgb((int)(Opacity * 255), originalBorderColor);
        }

        public virtual bool Contains(PointF point)
        {
            return Rectangle.Contains(point);
        }

        public virtual void DrawSelf(Graphics grfx)
        {
            if (IsSelected)
            {
                DrawSelection(grfx);
            }
        }

        public virtual void DrawSelection(Graphics grfx)
        {
            using (Pen pen = new Pen(Color.Blue, 2) { DashStyle = DashStyle.Dash })
            {
                grfx.DrawRectangle(pen, Rectangle.X - 2, Rectangle.Y - 2, Rectangle.Width + 4, Rectangle.Height + 4);
            }
        }

        public abstract RectangleF GetBounds();

        public virtual void TranslateTo(PointF newLocation)
        {
            Location = newLocation;
        }

        public virtual void Scale(float scaleFactor)
        {
            PointF center = new PointF(Location.X + Width / 2, Location.Y + Height / 2);
            Width *= scaleFactor;
            Height *= scaleFactor;
            Location = new PointF(center.X - Width / 2, center.Y - Height / 2);
        }

        public virtual void TranslateBy(float dx, float dy)
        {
            Location = new PointF(Location.X + dx, Location.Y + dy);
        }

        public virtual PointF GetCenter()
        {
            return new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
        }

        public virtual void Resize(float scaleX, float scaleY)
        {
            Width *= scaleX;
            Height *= scaleY;
        }

        public virtual void Rotate(float angle)
        {
            RotationAngle = (RotationAngle + angle) % 360;
        }

        public virtual object Clone()
        {
            Shape clone = (Shape)this.MemberwiseClone();
            clone.originalFillColor = this.originalFillColor;
            clone.originalBorderColor = this.originalBorderColor;
            return clone;
        }
    }
}