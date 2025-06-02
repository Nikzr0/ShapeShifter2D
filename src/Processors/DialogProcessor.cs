using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Draw
{
    [Serializable]
    public class DialogProcessor : DisplayProcessor
    {
        private Shape selection;
        private bool isDragging;
        private PointF lastLocation;
        private List<Shape> selectedShapes = new List<Shape>();
        private bool isLassoSelecting = false;
        private PointF lassoStartPoint;
        private RectangleF lassoRectangle;

        public Shape Selection { get => selection; set => selection = value; }
        public bool IsDragging { get => isDragging; set => isDragging = value; }
        public List<Shape> SelectedShapes { get => selectedShapes; set => selectedShapes = value; }
        public PointF LastLocation { get => lastLocation; set => lastLocation = value; }
        public bool IsLassoSelecting { get => isLassoSelecting; set => isLassoSelecting = value; }
        public PointF LassoStartPoint { get => lassoStartPoint; set => lassoStartPoint = value; }
        public RectangleF LassoRectangle { get => lassoRectangle; set => lassoRectangle = value; }

        public void AddRandomRectangle()
        {
            Random rnd = new Random();
            ShapeList.Add(new RectangleShape(new RectangleF(rnd.Next(100, 1000), rnd.Next(100, 600), 100, 200)));
        }

        public void AddRandomEllipse()
        {
            Random rnd = new Random();
            ShapeList.Add(new EllipseShape(new RectangleF(rnd.Next(100, 1000), rnd.Next(100, 600), 100, 200)));
        }

        public void AddRandomStar()
        {
            Random rnd = new Random();
            ShapeList.Add(new StarShape(new RectangleF(rnd.Next(100, 1000), rnd.Next(100, 600), 100, 100)));
        }

        public void AddRandomTriangle()
        {
            Random rnd = new Random();
            ShapeList.Add(new TriangleShape(new RectangleF(rnd.Next(100, 1000), rnd.Next(100, 600), 100, 200)));
        }

        public void AddRandomLine()
        {
            Random rnd = new Random();
            PointF start = new PointF(rnd.Next(100, 1000), rnd.Next(100, 600));
            PointF end = new PointF(start.X + rnd.Next(50, 200), start.Y + rnd.Next(50, 200));
            ShapeList.Add(new LineShape(start, end));
        }

        public void AddRandomPoint()
        {
            Random rnd = new Random();
            ShapeList.Add(new PointShape(new PointF(rnd.Next(100, 1000), rnd.Next(100, 600))));
        }

        public void AddPoint(PointF location)
        {
            ShapeList.Add(new PointShape(location));
        }

        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(point))
                {
                    return ShapeList[i];
                }
            }
            return null;
        }

        public void AddToSelection(Shape shape)
        {
            if (shape != null && !selectedShapes.Contains(shape))
            {
                selectedShapes.Add(shape);
                shape.IsSelected = true;
            }
        }

        public void RemoveFromSelection(Shape shape)
        {
            if (SelectedShapes.Contains(shape))
            {
                SelectedShapes.Remove(shape);
                shape.IsSelected = false;
            }
        }

        public void ClearSelection()
        {
            foreach (var shape in selectedShapes)
            {
                shape.IsSelected = false;
            }

            selectedShapes.Clear();
            Selection = null;
        }

        public void SelectShapesInRectangle(RectangleF selectionRect)
        {
            ClearSelection();

            foreach (var shape in ShapeList)
            {
                if (shape.Rectangle.IntersectsWith(selectionRect))
                {
                    AddToSelection(shape);
                }
            }
        }

        public void TranslateTo(PointF p)
        {
            if (SelectedShapes.Count > 0)
            {
                float dx = p.X - lastLocation.X;
                float dy = p.Y - lastLocation.Y;

                foreach (var shape in SelectedShapes)
                {
                    if (shape is LineShape line)
                    {
                        line.TranslateTo(new PointF(line.Location.X + dx, line.Location.Y + dy));
                    }
                    else if (shape is GroupShape group)
                    {
                        group.TranslateTo(new PointF(group.GetCenter().X + dx, group.GetCenter().Y + dy));
                    }
                    else
                    {
                        shape.Location = new PointF(shape.Location.X + dx, shape.Location.Y + dy);
                    }
                }
                lastLocation = p;
            }
        }

        public void RotateSelection(float angle)
        {
            foreach (var shape in SelectedShapes)
            {
                shape.Rotate(angle);
            }
        }

        public void ScaleSelection(float factor)
        {
            foreach (var shape in SelectedShapes)
            {
                shape.Scale(factor);
            }
        }

        public void SetSelectionOpacity(float opacity)
        {
            foreach (var shape in SelectedShapes)
            {
                shape.Opacity = opacity;
            }
        }

        public void GroupSelected()
        {
            if (SelectedShapes.Count < 2) return;

            GroupShape group = new GroupShape { IsSelected = true };

            if (SelectedShapes.Count > 0)
            {
                group.FillColor = SelectedShapes[0].FillColor;
                group.BorderColor = SelectedShapes[0].BorderColor;
                group.BorderWidth = SelectedShapes[0].BorderWidth;
            }

            float minX = float.MaxValue, minY = float.MaxValue;
            float maxX = float.MinValue, maxY = float.MinValue;

            foreach (var shape in SelectedShapes)
            {
                minX = Math.Min(minX, shape.Location.X);
                minY = Math.Min(minY, shape.Location.Y);
                maxX = Math.Max(maxX, shape.Location.X + shape.Width);
                maxY = Math.Max(maxY, shape.Location.Y + shape.Height);

                ShapeList.Remove(shape);
                group.Shapes.Add(shape);
            }

            group.Location = new PointF(minX, minY);
            group.Width = maxX - minX;
            group.Height = maxY - minY;

            ShapeList.Add(group);

            ClearSelection();
            Selection = group;
            AddToSelection(group);
        }

        public void UngroupSelected(Control viewPort)
        {
            List<GroupShape> groupsToUngroup = new List<GroupShape>();
            foreach (Shape s in SelectedShapes)
            {
                if (s is GroupShape gs)
                {
                    groupsToUngroup.Add(gs);
                }
            }

            if (groupsToUngroup.Count == 0)
            {
                return;
            }

            ClearSelection();

            foreach (GroupShape group in groupsToUngroup)
            {
                ShapeList.Remove(group);

                foreach (Shape subShape in group.Shapes)
                {
                    ShapeList.Add(subShape);
                    subShape.IsSelected = true;
                    SelectedShapes.Add(subShape);
                }
            }

            viewPort.Invalidate();
        }

        public void SaveToFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || fileName.Trim().Length == 0)
                throw new ArgumentNullException(nameof(fileName), "Името на файла не може да бъде празно или null.");

            if (SelectedShapes == null || SelectedShapes.Count == 0)
                throw new InvalidOperationException("Няма избрани фигури за запазване.");

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    formatter.Serialize(stream, SelectedShapes);
                }
                catch (SerializationException e)
                {
                    throw new InvalidOperationException($"Грешка при сериализация: {e.Message}", e);
                }
            }
        }

        public void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("Файлът не е намерен.", fileName);

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    List<Shape> loadedShapes = (List<Shape>)formatter.Deserialize(stream);

                    foreach (Shape shape in loadedShapes)
                    {
                        ShapeList.Add(shape);
                    }

                    ClearSelection();

                    foreach (Shape shape in ShapeList)
                    {
                        if (shape.IsSelected)
                        {
                            AddToSelection(shape);
                        }
                    }
                }
                catch (SerializationException e)
                {
                    throw new InvalidOperationException($"Грешка при десериализация: {e.Message}", e);
                }
            }
        }

        public void DeleteSelected()
        {
            if (SelectedShapes.Count == 0) return;

            var shapesToDelete = new List<Shape>(SelectedShapes);

            foreach (var shape in shapesToDelete)
            {
                if (shape is GroupShape group)
                {
                    foreach (var subShape in group.Shapes)
                    {
                        ShapeList.Remove(subShape);
                    }
                }

                ShapeList.Remove(shape);
            }

            ClearSelection();
        }
    }
}
