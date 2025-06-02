using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class DisplayProcessor
    {
        #region Constructor

        public DisplayProcessor()
        {
        }

        #endregion

        #region Properties

        private List<Shape> shapeList = new List<Shape>();
        public List<Shape> ShapeList
        {
            get { return shapeList; }
            set { shapeList = value; }
        }

        #endregion

        #region Drawing

        public void ReDraw(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Draw(e.Graphics);
        }

        public virtual void Draw(Graphics grfx)
        {
            foreach (Shape item in ShapeList)
            {
                DrawShape(grfx, item);
            }
        }

        public virtual void DrawShape(Graphics grfx, Shape item)
        {
            item.DrawSelf(grfx);
        }

        #endregion
    }
}