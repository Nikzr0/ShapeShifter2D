using System;
using System.Windows.Forms;

namespace Draw
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawEllipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawStarSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawTriangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawLineSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawPointButton = new System.Windows.Forms.ToolStripButton();
            this.shapeTypeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.rotateLeftButton = new System.Windows.Forms.ToolStripButton();
            this.rotateRightButton = new System.Windows.Forms.ToolStripButton();
            this.scaleUpButton = new System.Windows.Forms.ToolStripButton();
            this.scaleDownButton = new System.Windows.Forms.ToolStripButton();
            this.groupButton = new System.Windows.Forms.ToolStripButton();
            this.ungroupButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.fillColorButton = new System.Windows.Forms.ToolStripButton();
            this.borderColorButton = new System.Windows.Forms.ToolStripButton();
            this.borderWidthComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.fillColorComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.borderColorNameComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.opacityTrackBar = new System.Windows.Forms.ToolStripComboBox();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1361, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.pasteToolStripMenuItem.Text = "Past";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItemClick);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 499);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(1361, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speedMenu
            // 
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawRectangleSpeedButton,
            this.drawEllipseSpeedButton,
            this.drawStarSpeedButton,
            this.drawTriangleSpeedButton,
            this.drawLineSpeedButton,
            this.drawPointButton,
            this.shapeTypeComboBox,
            this.pickUpSpeedButton,
            this.rotateLeftButton,
            this.rotateRightButton,
            this.scaleUpButton,
            this.scaleDownButton,
            this.groupButton,
            this.ungroupButton,
            this.deleteButton,
            this.fillColorButton,
            this.borderColorButton,
            this.borderWidthComboBox,
            this.fillColorComboBox,
            this.borderColorNameComboBox,
            this.opacityTrackBar});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(1361, 25);
            this.speedMenu.TabIndex = 3;
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawRectangleSpeedButton.Text = "DrawRectangleButton";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // drawEllipseSpeedButton
            // 
            this.drawEllipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawEllipseSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawEllipseSpeedButton.Image")));
            this.drawEllipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawEllipseSpeedButton.Name = "drawEllipseSpeedButton";
            this.drawEllipseSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawEllipseSpeedButton.Text = "DrawEllipseButton";
            this.drawEllipseSpeedButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.drawEllipseSpeedButton.ToolTipText = "DrawEllipseButton";
            this.drawEllipseSpeedButton.Click += new System.EventHandler(this.DrawEllipseSpeedButtonClick);
            // 
            // drawStarSpeedButton
            // 
            this.drawStarSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawStarSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawStarSpeedButton.Image")));
            this.drawStarSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawStarSpeedButton.Name = "drawStarSpeedButton";
            this.drawStarSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawStarSpeedButton.Text = "DrawStarButton";
            this.drawStarSpeedButton.ToolTipText = "DrawStarButton";
            this.drawStarSpeedButton.Click += new System.EventHandler(this.DrawStarSpeedButtonClick);
            // 
            // drawTriangleSpeedButton
            // 
            this.drawTriangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawTriangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawTriangleSpeedButton.Image")));
            this.drawTriangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawTriangleSpeedButton.Name = "drawTriangleSpeedButton";
            this.drawTriangleSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawTriangleSpeedButton.Text = "drawTriangleSpeedButton";
            this.drawTriangleSpeedButton.Click += new System.EventHandler(this.DrawTriangleSpeedButtonClick);
            // 
            // drawLineSpeedButton
            // 
            this.drawLineSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawLineSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawLineSpeedButton.Image")));
            this.drawLineSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawLineSpeedButton.Name = "drawLineSpeedButton";
            this.drawLineSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawLineSpeedButton.Text = "Draw Line";
            this.drawLineSpeedButton.Click += new System.EventHandler(this.DrawLineButtonClick);
            // 
            // drawPointButton
            // 
            this.drawPointButton.Image = ((System.Drawing.Image)(resources.GetObject("drawPointButton.Image")));
            this.drawPointButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawPointButton.Name = "drawPointButton";
            this.drawPointButton.Size = new System.Drawing.Size(23, 22);
            this.drawPointButton.Click += new System.EventHandler(this.DrawPointButtonClick);
            // 
            // shapeTypeComboBox
            // 
            this.shapeTypeComboBox.Items.AddRange(new object[] {
            "Rectangle",
            "Ellipse",
            "Star",
            "Triangle",
            "Line",
            "Point"});
            this.shapeTypeComboBox.Name = "shapeTypeComboBox";
            this.shapeTypeComboBox.Size = new System.Drawing.Size(120, 25);
            this.shapeTypeComboBox.Text = "Select Shape";
            this.shapeTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ShapeTypeComboBoxSelectedIndexChanged);
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.pickUpSpeedButton.Text = "drawTriangleSpeedButton";
            // 
            // rotateLeftButton
            // 
            this.rotateLeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateLeftButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateLeftButton.Image")));
            this.rotateLeftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateLeftButton.Name = "rotateLeftButton";
            this.rotateLeftButton.Size = new System.Drawing.Size(23, 22);
            this.rotateLeftButton.Text = "Rotate Left";
            this.rotateLeftButton.Click += new System.EventHandler(this.RotateLeftButtonClick);
            // 
            // rotateRightButton
            // 
            this.rotateRightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateRightButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateRightButton.Image")));
            this.rotateRightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateRightButton.Name = "rotateRightButton";
            this.rotateRightButton.Size = new System.Drawing.Size(23, 22);
            this.rotateRightButton.Text = "Rotate Right";
            this.rotateRightButton.Click += new System.EventHandler(this.RotateRightButtonClick);
            // 
            // scaleUpButton
            // 
            this.scaleUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.scaleUpButton.Image = ((System.Drawing.Image)(resources.GetObject("scaleUpButton.Image")));
            this.scaleUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scaleUpButton.Name = "scaleUpButton";
            this.scaleUpButton.Size = new System.Drawing.Size(23, 22);
            this.scaleUpButton.Text = "Scale Up";
            this.scaleUpButton.Click += new System.EventHandler(this.ScaleUpButtonClick);
            // 
            // scaleDownButton
            // 
            this.scaleDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.scaleDownButton.Image = ((System.Drawing.Image)(resources.GetObject("scaleDownButton.Image")));
            this.scaleDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scaleDownButton.Name = "scaleDownButton";
            this.scaleDownButton.Size = new System.Drawing.Size(23, 22);
            this.scaleDownButton.Text = "Scale Down";
            this.scaleDownButton.Click += new System.EventHandler(this.ScaleDownButtonClick);
            // 
            // groupButton
            // 
            this.groupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.groupButton.Image = ((System.Drawing.Image)(resources.GetObject("groupButton.Image")));
            this.groupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.groupButton.Name = "groupButton";
            this.groupButton.Size = new System.Drawing.Size(23, 22);
            this.groupButton.Text = "Group";
            this.groupButton.Click += new System.EventHandler(this.GroupButtonClick);
            // 
            // ungroupButton
            // 
            this.ungroupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ungroupButton.Image = ((System.Drawing.Image)(resources.GetObject("ungroupButton.Image")));
            this.ungroupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ungroupButton.Name = "ungroupButton";
            this.ungroupButton.Size = new System.Drawing.Size(23, 22);
            this.ungroupButton.Text = "Ungroup";
            this.ungroupButton.Click += new System.EventHandler(this.UngroupButtonClick);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(23, 22);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // fillColorButton
            // 
            this.fillColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillColorButton.Name = "fillColorButton";
            this.fillColorButton.Size = new System.Drawing.Size(58, 22);
            this.fillColorButton.Text = "Fill Color";
            this.fillColorButton.Click += new System.EventHandler(this.FillColorButtonClick);
            // 
            // borderColorButton
            // 
            this.borderColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.borderColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.borderColorButton.Name = "borderColorButton";
            this.borderColorButton.Size = new System.Drawing.Size(78, 22);
            this.borderColorButton.Text = "Border Color";
            this.borderColorButton.Click += new System.EventHandler(this.BorderColorButtonClick);
            // 
            // borderWidthComboBox
            // 
            this.borderWidthComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "8"});
            this.borderWidthComboBox.Name = "borderWidthComboBox";
            this.borderWidthComboBox.Size = new System.Drawing.Size(99, 25);
            this.borderWidthComboBox.SelectedIndexChanged += new System.EventHandler(this.BorderWidthComboBoxSelectedIndexChanged);
            // 
            // fillColorComboBox
            // 
            this.fillColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillColorComboBox.Name = "fillColorComboBox";
            this.fillColorComboBox.Size = new System.Drawing.Size(160, 25);
            this.fillColorComboBox.SelectedIndexChanged += new System.EventHandler(this.FillColorComboBoxSelectedIndexChanged);
            // 
            // borderColorNameComboBox
            // 
            this.borderColorNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.borderColorNameComboBox.Name = "borderColorNameComboBox";
            this.borderColorNameComboBox.Size = new System.Drawing.Size(160, 25);
            this.borderColorNameComboBox.SelectedIndexChanged += new System.EventHandler(this.BorderColorNameComboBoxSelectedIndexChanged);
            // 
            // opacityTrackBar
            // 
            this.opacityTrackBar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.opacityTrackBar.Items.AddRange(new object[] {
            "Opacity",
            "100%",
            "90%",
            "80%",
            "70%",
            "60%",
            "50%",
            "40%",
            "30%",
            "20%",
            "10%",
            "0%"});
            this.opacityTrackBar.Name = "opacityTrackBar";
            this.opacityTrackBar.Size = new System.Drawing.Size(160, 25);
            this.opacityTrackBar.DropDown += new System.EventHandler(this.OpacityComboBoxDropDown);
            this.opacityTrackBar.DropDownClosed += new System.EventHandler(this.OpacityComboBoxDropDownClosed);
            this.opacityTrackBar.SelectedIndexChanged += new System.EventHandler(this.OpacityComboBoxSelectedIndexChanged);
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 0);
            this.viewPort.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(1628, 521);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
            // 
            // propertyGrid
            // 
            this.propertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ControlLight;
            this.propertyGrid.Location = new System.Drawing.Point(1361, 0);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(267, 521);
            this.propertyGrid.TabIndex = 6;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGridPropertyValueChanged);
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1628, 521);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.viewPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
        private Draw.DoubleBufferedPanel viewPort;
        private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
        private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip speedMenu;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton drawEllipseSpeedButton;
        private System.Windows.Forms.ToolStripButton drawStarSpeedButton;
        private System.Windows.Forms.ToolStripButton drawTriangleSpeedButton;
        private System.Windows.Forms.ToolStripButton rotateLeftButton;
        private System.Windows.Forms.ToolStripButton rotateRightButton;
        private System.Windows.Forms.ToolStripButton scaleUpButton;
        private System.Windows.Forms.ToolStripButton scaleDownButton;
        private System.Windows.Forms.ToolStripButton groupButton;
        private System.Windows.Forms.ToolStripButton ungroupButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton fillColorButton;
        private System.Windows.Forms.ToolStripButton borderColorButton;
        private System.Windows.Forms.ToolStripComboBox borderWidthComboBox;
        private System.Windows.Forms.ToolStripComboBox shapeTypeComboBox;
        private System.Windows.Forms.ToolStripButton drawLineSpeedButton;
        private System.Windows.Forms.ToolStripButton drawPointButton;
        private System.Windows.Forms.ToolStripComboBox opacityTrackBar;
        // Edit menu items
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        // Color selection combo boxes
        private System.Windows.Forms.ToolStripComboBox fillColorComboBox;
        private System.Windows.Forms.ToolStripComboBox borderColorNameComboBox;
        // property grid
        private System.Windows.Forms.PropertyGrid propertyGrid;
    }
}
