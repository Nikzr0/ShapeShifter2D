using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Draw
{
    public partial class MainForm : Form
    {
        private DialogProcessor dialogProcessor = new DialogProcessor();

        public MainForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(OnKeyDown);

            UpdateStatusBar("The application has started.");

            InitializeColorComboBox(fillColorComboBox);
            InitializeBorderComboBox(borderColorNameComboBox);
        }

        private List<Shape> clipboardShapes = new List<Shape>();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                DeleteButtonClick(null, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedShapes();
                statusBar.Items[0].Text = "Last action: Copy";
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                PasteShapes();
                statusBar.Items[0].Text = "Last action: Paste";
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                dialogProcessor.GroupSelected();
                viewPort.Invalidate();
                statusBar.Items[0].Text = "Last action: Group";
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                dialogProcessor.UngroupSelected(viewPort);
                statusBar.Items[0].Text = "Last action: Ungroup";
                e.Handled = true;
            }
        }

        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (dialogProcessor.ShapeList.Count == 0)
            {
                MessageBox.Show("There are no shapes to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Draw Files (*.draw)|*.draw|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = "draw";
                saveFileDialog.AddExtension = true;
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.Title = "Save File";
                saveFileDialog.FileName = "drawing1.draw";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dialogProcessor.SaveToFile(saveFileDialog.FileName);
                        statusBar.Items[0].Text = "File saved successfully: " + saveFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Draw Files (*.draw)|*.draw|All Files (*.*)|*.*";
                openFileDialog.CheckFileExists = true;
                openFileDialog.Title = "Open File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dialogProcessor.LoadFromFile(openFileDialog.FileName);
                        viewPort.Invalidate();
                        statusBar.Items[0].Text = "File loaded successfully: " + openFileDialog.FileName;
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        MessageBox.Show("File not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dialogProcessor.ShapeList.Clear();
                        viewPort.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while loading the file: {ex.Message}\nPlease check if the file is valid.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dialogProcessor.ShapeList.Clear();
                        viewPort.Invalidate();
                    }
                }
            }
        }

        void ViewPortPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetClip(viewPort.ClientRectangle);

            foreach (Shape shape in dialogProcessor.ShapeList)
            {
                shape.DrawSelf(e.Graphics);
            }

            foreach (Shape shape in dialogProcessor.SelectedShapes)
            {
                shape.DrawSelection(e.Graphics);
            }
        }

        void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomRectangle();
            statusBar.Items[0].Text = "Last action: Drawing a rectangle";
            viewPort.Invalidate();
        }

        private void DrawEllipseSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomEllipse();
            statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";
            viewPort.Invalidate();
        }

        private void DrawStarSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomStar();
            statusBar.Items[0].Text = "Last action: Drawing a star";
            viewPort.Invalidate();
        }

        private void DrawTriangleSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomTriangle();
            statusBar.Items[0].Text = "Last action: Drawing a triangle";
            viewPort.Invalidate();
        }

        private void DrawLineButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomLine();
            viewPort.Invalidate();
            statusBar.Items[0].Text = "Last action: Drawing a line";
        }

        private void DrawPointButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomPoint();
            viewPort.Invalidate();
            statusBar.Items[0].Text = "Last action: Adding a point";
        }

        private void ShapeTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (shapeTypeComboBox.SelectedItem.ToString())
            {
                case "Rectangle":
                    dialogProcessor.AddRandomRectangle();
                    statusBar.Items[0].Text = "Last action: Drawing a rectangle";
                    break;
                case "Ellipse":
                    dialogProcessor.AddRandomEllipse();
                    statusBar.Items[0].Text = "Last action: Drawing an ellipse";
                    break;
                case "Star":
                    dialogProcessor.AddRandomStar();
                    statusBar.Items[0].Text = "Last action: Drawing a star";
                    break;
                case "Triangle":
                    dialogProcessor.AddRandomTriangle();
                    statusBar.Items[0].Text = "Last action: Drawing a triangle";
                    break;
                case "Line":
                    dialogProcessor.AddRandomLine();
                    statusBar.Items[0].Text = "Last action: Drawing a line";
                    break;
                case "Point":
                    dialogProcessor.AddRandomPoint();
                    statusBar.Items[0].Text = "Last action: Adding a point";
                    break;
            }

            viewPort.Invalidate();
        }

        void ViewPortMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (pickUpSpeedButton.Checked)
                {
                    Shape clickedShape = dialogProcessor.ContainsPoint(e.Location);

                    if (clickedShape != null)
                    {
                        if (dialogProcessor.SelectedShapes.Contains(clickedShape))
                        {
                            dialogProcessor.IsDragging = true;
                            dialogProcessor.LastLocation = e.Location;
                            statusBar.Items[0].Text = "Last action: Dragging selected shapes";
                        }
                        else
                        {
                            if (Control.ModifierKeys != Keys.Control)
                            {
                                dialogProcessor.ClearSelection();
                            }

                            dialogProcessor.AddToSelection(clickedShape);
                            dialogProcessor.IsDragging = true;

                            dialogProcessor.LastLocation = e.Location;
                            statusBar.Items[0].Text = "Last action: Shape selected and dragged";
                        }
                    }
                    else
                    {
                        if (Control.ModifierKeys != Keys.Control)
                        {
                            dialogProcessor.ClearSelection();
                        }

                        dialogProcessor.IsLassoSelecting = true;
                        dialogProcessor.LassoStartPoint = e.Location;
                        dialogProcessor.LassoRectangle = RectangleF.Empty;
                        statusBar.Items[0].Text = "Last action: Drag Selection started";
                    }
                }
            }
            viewPort.Invalidate();
            UpdatePropertyGrid();
        }

        void ViewPortMouseMove(object sender, MouseEventArgs e)
        {
            if (dialogProcessor.IsDragging)
            {
                if (dialogProcessor.SelectedShapes.Count > 0)
                {
                    statusBar.Items[0].Text = "Last action: Dragging";
                    dialogProcessor.TranslateTo(e.Location);
                    viewPort.Invalidate();
                }
            }
            else if (dialogProcessor.IsLassoSelecting)
            {
                float x = Math.Min(dialogProcessor.LassoStartPoint.X, e.Location.X);
                float y = Math.Min(dialogProcessor.LassoStartPoint.Y, e.Location.Y);
                float width = Math.Abs(dialogProcessor.LassoStartPoint.X - e.Location.X);
                float height = Math.Abs(dialogProcessor.LassoStartPoint.Y - e.Location.Y);
                dialogProcessor.LassoRectangle = new RectangleF(x, y, width, height);
                statusBar.Items[0].Text = $"Drag Selection: ({x:F0},{y:F0}) - {width:F0}x{height:F0}";
                viewPort.Invalidate();
            }
        }

        void ViewPortMouseUp(object sender, MouseEventArgs e)
        {
            if (dialogProcessor.IsDragging)
            {
                dialogProcessor.IsDragging = false;
                statusBar.Items[0].Text = "Last action: Dragging completed.";
            }
            else if (dialogProcessor.IsLassoSelecting)
            {
                dialogProcessor.IsLassoSelecting = false;
                dialogProcessor.SelectShapesInRectangle(dialogProcessor.LassoRectangle);
                dialogProcessor.LassoRectangle = RectangleF.Empty;
                statusBar.Items[0].Text = "Last action: Drag Selection completed.";
            }
            viewPort.Invalidate();
            UpdatePropertyGrid();
        }

        private void RotateLeftButtonClick(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count > 0)
            {
                foreach (var shape in dialogProcessor.SelectedShapes)
                {
                    shape.Rotate(-15);
                }
                viewPort.Invalidate();
            }
        }

        private void RotateRightButtonClick(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count > 0)
            {
                foreach (var shape in dialogProcessor.SelectedShapes)
                {
                    shape.Rotate(15);
                }
                viewPort.Invalidate();
            }
        }

        private void ScaleUpButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.ScaleSelection(1.1f);
            viewPort.Invalidate();
        }

        private void ScaleDownButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.ScaleSelection(0.9f);
            viewPort.Invalidate();
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.DeleteSelected();
            viewPort.Invalidate();
            statusBar.Items[0].Text = "Last action: Deletion of selected items";
            UpdatePropertyGrid();
        }

        private void GroupButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.GroupSelected();
            viewPort.Invalidate();
            UpdatePropertyGrid();
        }

        private void UngroupButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.UngroupSelected(viewPort);
            UpdatePropertyGrid();
        }

        private void CopySelectedShapes()
        {
            clipboardShapes.Clear();
            foreach (var shape in dialogProcessor.SelectedShapes)
            {
                clipboardShapes.Add((Shape)shape.Clone());
            }

            UpdatePropertyGrid();
        }

        private void PasteShapes()
        {
            if (clipboardShapes.Count > 0)
            {
                dialogProcessor.ClearSelection();

                foreach (var shape in clipboardShapes)
                {
                    Shape newShape = (Shape)shape.Clone();
                    newShape.Location = new PointF(newShape.Location.X + 15, newShape.Location.Y + 15);

                    dialogProcessor.ShapeList.Add(newShape);
                    dialogProcessor.AddToSelection(newShape);
                }
                viewPort.Invalidate();
            }

            UpdatePropertyGrid();
        }

        private void FillColorButtonClick(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count == 0)
            {
                MessageBox.Show("Please select at least one shape", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var shape in dialogProcessor.SelectedShapes)
                {
                    shape.FillColor = colorDialog.Color;
                }
                viewPort.Invalidate();
            }
        }

        private void BorderColorButtonClick(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count == 0)
            {
                MessageBox.Show("Please select at least one shape", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var shape in dialogProcessor.SelectedShapes)
                {
                    shape.BorderColor = colorDialog.Color;
                }
                viewPort.Invalidate();
            }
        }

        private void BorderWidthComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count == 0 ||
                !float.TryParse(borderWidthComboBox.SelectedItem.ToString(), out float width))
            {
                return;
            }

            foreach (var shape in dialogProcessor.SelectedShapes)
            {
                shape.BorderWidth = width;
            }
            viewPort.Invalidate();
        }

        private void OpacityComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (opacityTrackBar.SelectedItem == null || opacityTrackBar.SelectedItem.ToString() == "Opacity")
                return;

            if (dialogProcessor.SelectedShapes.Count == 0)
            {
                MessageBox.Show("Please select at least one shape to change the opacity.", "Warning",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                opacityTrackBar.SelectedIndex = 0;
                return;
            }

            string selectedText = opacityTrackBar.SelectedItem.ToString();
            if (float.TryParse(selectedText.Replace("%", ""), out float percentage))
            {
                float newOpacity = percentage / 100.0f;

                foreach (var shape in dialogProcessor.SelectedShapes)
                {
                    shape.Opacity = newOpacity;

                    if (shape is GroupShape group)
                    {
                        foreach (var subShape in group.Shapes)
                        {
                            subShape.Opacity = newOpacity;
                        }
                    }
                }

                statusBar.Items[0].Text = $"Последно действие: Променена прозрачност на {selectedText}";
                viewPort.Invalidate();
            }
        }

        private void OpacityComboBoxDropDown(object sender, EventArgs e)
        {
            if (opacityTrackBar.Items.Contains("Opacity"))
            {
                opacityTrackBar.Items.Remove("Opacity");
            }
        }

        private void OpacityComboBoxDropDownClosed(object sender, EventArgs e)
        {
            if (opacityTrackBar.SelectedItem == null)
            {
                opacityTrackBar.Items.Insert(0, "Opacity");
                opacityTrackBar.SelectedIndex = 0;
            }
        }

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            MainForm newForm = new MainForm();

            newForm.Show();
        }

        // Edit menu actions
        private void CopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            CopySelectedShapes();
            UpdateStatusBar("Selected shapes copied from menu.");
            this.Invalidate();
        }

        private void PasteToolStripMenuItemClick(object sender, EventArgs e)
        {
            PasteShapes();
            UpdateStatusBar("Shapes pasted from menu.");
            this.Invalidate();
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            DeleteButtonClick(sender, e);
            UpdateStatusBar("Selected shapes deleted from menu.");
            this.Invalidate();
        }

        public void UpdateStatusBar(string message)
        {
            if (currentStatusLabel != null)
            {
                currentStatusLabel.Text = message;
            }
        }

        private void InitializeColorComboBox(ToolStripComboBox comboBox)
        {
            comboBox.Items.Add("Color");
            comboBox.Items.Add("Black");
            comboBox.Items.Add("White");
            comboBox.Items.Add("Red");
            comboBox.Items.Add("Green");
            comboBox.Items.Add("Blue");
            comboBox.Items.Add("Yellow");
            comboBox.Items.Add("Orange");
            comboBox.Items.Add("Purple");
            comboBox.SelectedIndex = 0;
        }

        private void InitializeBorderComboBox(ToolStripComboBox comboBox)
        {
            comboBox.Items.Add("Border");
            comboBox.Items.Add("Black");
            comboBox.Items.Add("White");
            comboBox.Items.Add("Red");
            comboBox.Items.Add("Green");
            comboBox.Items.Add("Blue");
            comboBox.Items.Add("Yellow");
            comboBox.Items.Add("Orange");
            comboBox.Items.Add("Purple");
            comboBox.SelectedIndex = 0;
        }

        private void FillColorComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColorName = fillColorComboBox.SelectedItem.ToString();
            Color newColor = Color.FromName(selectedColorName);

            if (selectedColorName == "Transparent")
            {
                newColor = Color.Transparent;
            }

            foreach (var shape in dialogProcessor.SelectedShapes)
            {
                shape.FillColor = newColor;
            }
            viewPort.Invalidate();
            UpdateStatusBar($"Last action: Fill color changed to {selectedColorName}");

            UpdatePropertyGrid();
        }

        private void BorderColorNameComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColorName = borderColorNameComboBox.SelectedItem.ToString();
            Color newColor = Color.FromName(selectedColorName);

            if (selectedColorName == "Transparent")
            {
                newColor = Color.Transparent;
            }

            foreach (var shape in dialogProcessor.SelectedShapes)
            {
                shape.BorderColor = newColor;
            }
            viewPort.Invalidate();
            UpdateStatusBar($"Last action: Border color changed to {selectedColorName}");
        }

        // Property Grid handling
        private void UpdatePropertyGrid()
        {
            if (dialogProcessor.SelectedShapes.Count == 1)
            {
                propertyGrid.SelectedObject = dialogProcessor.SelectedShapes[0];
            }
            else if (dialogProcessor.SelectedShapes.Count > 1)
            {
                propertyGrid.SelectedObjects = dialogProcessor.SelectedShapes.ToArray();
            }
            else
            {
                propertyGrid.SelectedObject = null;
            }
        }

        private void PropertyGridPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            viewPort.Invalidate();
            UpdateStatusBar($"Last action: Changed property '{e.ChangedItem.Label}' of selected shape.");
        }
    }
}