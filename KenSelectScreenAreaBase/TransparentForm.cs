﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KenSmithConsulting.KenSelectScreenAreaBase
{
    public partial class TransparentForm : Form
    {
        public Rectangle SelectedArea { get; set; }
        public bool SelectionCancelled { get; set; }
        // v1.1.0 2020-05-29 Fix bug: The window must be the original size if the Escape key is used to exit from resizing and moving the red frame.
        private int origWidth;
        private int origHeight;
        private Point origLocation;

        const float DEFAULT_OPACITY = .75f; //.60f;
        const int CLOSE_AMOUNT_PIXELS = 10;
        const int RED_BORDER_WIDTH_PIXELS = 12;

        readonly Pen RedBorderPen = new Pen(Color.Red, RED_BORDER_WIDTH_PIXELS);
        readonly Font TextFont = new Font(FontFamily.GenericSansSerif, 8);

        bool pictureTakingMode = false;
        bool isDrag = false;
        bool isResizeNW = false;
        bool isResizeSE = false;
        bool isResizeNE = false;
        bool isResizeSW = false;
        bool isResizeW = false;
        bool isResizeN = false;
        bool isResizeE = false;
        bool isResizeS = false;

        Point startPoint;
        public TransparentForm()
        {
            InitializeComponent();
        }
        private void TransparentForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            SimulateInitialLoad();
        }
        private void SimulateInitialLoad()
        {
            SelectionCancelled = true;
            // v1.1.0 2020-05-29 Fix bug: The window must be the original size if the Escape key is used to exit from resizing and moving the red frame.
            origWidth = Width;
            origHeight = Height;
            origLocation = Location;
            // 5/28/2020 Circumvent bug in .NET! If you set this to Sizable, then it is ok until you
            // move the window to a 2nd display where the x-xoord starts in negative numbers.  The
            // sizing cursor on the bottom edge will always be Cursors.SizeNWSE instead of SizeNS.
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            pictureTakingMode = false;
            TitleLine.Visible = true;
            labelInformation.Visible = true;
            labelInformation2.Visible = true;
            labelVersion.Visible = true;
            ButtonBegin.Visible = true;
            checkBoxDisplayCoordinates.Visible = true;
            this.Opacity = 1.0f;
            Refresh();
        }
        private void TransparentForm_Paint(object sender, PaintEventArgs e)
        {
            if (pictureTakingMode == true)
            {
                Graphics graphics = e.Graphics;
                graphics.DrawRectangle(RedBorderPen, 0 + RedBorderPen.Width / 2, 0 + RedBorderPen.Width / 2,
                                    ClientSize.Width - RedBorderPen.Width, ClientSize.Height - RedBorderPen.Width);
                if (checkBoxDisplayCoordinates.Checked)
                {
                    string info = $"({Location.X + RED_BORDER_WIDTH_PIXELS},{Location.Y + RED_BORDER_WIDTH_PIXELS})"
                        + $" Width: {Size.Width - (2 * RED_BORDER_WIDTH_PIXELS)}"
                        + $" Height: {Size.Height - (2 * RED_BORDER_WIDTH_PIXELS)}";
                    graphics.DrawString(info, TextFont, Brushes.Black, RED_BORDER_WIDTH_PIXELS + 2, RED_BORDER_WIDTH_PIXELS + 2);
                }
            }
        }
        private void ButtonBegin_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pictureTakingMode = true;
            TitleLine.Visible = false;
            labelInformation.Visible = false;
            labelInformation2.Visible = false;
            labelVersion.Visible = false;
            ButtonBegin.Visible = false;
            checkBoxDisplayCoordinates.Visible = false;
            this.Opacity = DEFAULT_OPACITY;
            Refresh();
        }
        private void TransparentForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Set the isDrag variable as appropriate
                isDrag = (CursorIsCloseToAnyEdge() == false);
                // Set the isResizeXX variable as appropriate
                isResizeNW = (CursorIsCloseToTopEdge() && CursorIsCloseToLeftEdge());
                isResizeSE = (CursorIsCloseToBottomEdge() && CursorIsCloseToRightEdge());
                isResizeNE = (CursorIsCloseToTopEdge() && CursorIsCloseToRightEdge());
                isResizeSW = (CursorIsCloseToBottomEdge() && CursorIsCloseToLeftEdge());
                isResizeW = CursorIsCloseToLeftEdgeOnly();
                isResizeN = CursorIsCloseToTopEdgeOnly();
                isResizeE = CursorIsCloseToRightEdgeOnly();
                isResizeS = CursorIsCloseToBottomEdgeOnly();

                // get the starting point by using the PointToScreen method to convert form  
                // coordinates to screen coordinates. 
                Control control = (Control)sender;
                startPoint = control.PointToScreen(new Point(e.X, e.Y));
            }
        }
        private void TransparentForm_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            // If the MouseUp event occurs, the user is not dragging or resizing.
            isDrag = false;
            isResizeNW = false;
            isResizeSE = false;
            isResizeNE = false;
            isResizeSW = false;
            isResizeW = false;
            isResizeN = false;
            isResizeE = false;
            isResizeS = false;
        }
        private void TransparentForm_MouseMove(object sender, MouseEventArgs e)
        {
            Point endPoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
            // If the mouse is being dragged, move the window
            if (isDrag)
            {
                // Calculate the endpoint 
                int deltaX = endPoint.X - startPoint.X;
                int deltaY = endPoint.Y - startPoint.Y;
                Location = new Point(Location.X + deltaX, Location.Y + deltaY);
                // Tricky! Do not allow window to escape bounds of LogicalScreenBounds
                // Really Tricky! We want the red border to escape bounds of LogicalScreenBounds.
                Rectangle areaInsideRedFrame = new Rectangle(
                    Location.X + RED_BORDER_WIDTH_PIXELS,
                    Location.Y + RED_BORDER_WIDTH_PIXELS,
                    Size.Width - (2 * RED_BORDER_WIDTH_PIXELS),
                    Size.Height - (2 * RED_BORDER_WIDTH_PIXELS));
                // v1.1.0 2020-05-29 Refactored code to use SystemInformation.VirtualScreen instead of method GetLogicalScreenBounds().
                // The virtual screen is the combination of all screens considered to be one contiguous screen.
                // Note that the upper left corner of the virtual screen may not be (0,0)!
                Rectangle virtualScreen = SystemInformation.VirtualScreen;
                if (areaInsideRedFrame.X < SystemInformation.VirtualScreen.X)
                {
                    Location = new Point(virtualScreen.X - RED_BORDER_WIDTH_PIXELS, Location.Y);
                }
                if (areaInsideRedFrame.X + areaInsideRedFrame.Width > virtualScreen.X + virtualScreen.Width)
                {
                    Location = new Point(virtualScreen.X + virtualScreen.Width + RED_BORDER_WIDTH_PIXELS - Size.Width, Location.Y);
                }
                if (areaInsideRedFrame.Y < virtualScreen.Y)
                {
                    Location = new Point(Location.X, virtualScreen.Y - RED_BORDER_WIDTH_PIXELS);
                }
                if (areaInsideRedFrame.Y + areaInsideRedFrame.Height > virtualScreen.Y + virtualScreen.Height)
                {
                    Location = new Point(Location.X, virtualScreen.Y + virtualScreen.Height + RED_BORDER_WIDTH_PIXELS - Size.Height);
                }
                startPoint = new Point(endPoint.X, endPoint.Y);
                // only necessary if drawing text because moving a window does not generally call Paint
                if (checkBoxDisplayCoordinates.Checked)
                {
                    Invalidate();
                }
            }
            // v1.1.0 2020-05-29 Refactored code for window resizing actions
            // Tricky! Method ResizeRedFrame will examine flags isResizeNW, isResizeSE etc, (Those flags will be valid in that method!)
            ResizeRedFrame(endPoint);
            if (e.Button == MouseButtons.None) 
            {
                SetCursorImage();
            }
        }
        private void SetCursorImage()
        {
            Cursor = Cursors.Arrow;
            bool cursorIsCloseToAnyEdge = false;
            if ((CursorIsCloseToRightEdge() == true) || (CursorIsCloseToLeftEdge() == true))
            {
                Cursor = Cursors.SizeWE;
                cursorIsCloseToAnyEdge = true;
            }
            if ((CursorIsCloseToTopEdge() == true) || (CursorIsCloseToBottomEdge() == true))
            {
                Cursor = Cursors.SizeNS;
                cursorIsCloseToAnyEdge = true;
            }
            if (
                ((CursorIsCloseToTopEdge() == true) && (CursorIsCloseToLeftEdge() == true))
                ||
                ((CursorIsCloseToBottomEdge() == true) && (CursorIsCloseToRightEdge() == true))
                )
            {
                Cursor = Cursors.SizeNWSE;
                cursorIsCloseToAnyEdge = true;
            }
            if (
                ((CursorIsCloseToTopEdge() == true) && (CursorIsCloseToRightEdge() == true))
                ||
                ((CursorIsCloseToBottomEdge() == true) && (CursorIsCloseToLeftEdge() == true))
                )
            {
                Cursor = Cursors.SizeNESW;
                cursorIsCloseToAnyEdge = true;
            }
            
            if ((cursorIsCloseToAnyEdge == false) && (pictureTakingMode == true) && (CursorIsInsideTransparentFormBounds()))
            {
                Cursor = Cursors.SizeAll;
            }
        }
        // v1.1.0 2020-05-29 Refactored code for window resizing actions
        // Tricky! Method ResizeRedFrame will examine flags isResizeNW, isResizeSE etc, (Those flags will be valid in that method!)
        private void ResizeRedFrame(Point endPoint)
        {
            int deltaX = endPoint.X - startPoint.X;
            int deltaY = endPoint.Y - startPoint.Y;
            // v1.1.0 2020-05-29 Fix bug: Do not allow resizing to width or height less than 10.
            int origWidth = Width;
            int origHeight = Height;
            Point origLocation = Location;
            if (isResizeNW)
            {
                Width = Width - deltaX;
                Height = Height - deltaY;
                Location = new Point(Location.X + deltaX, Location.Y + deltaY);
            }
            if (isResizeN)
            {
                Height = Height - deltaY;
                Location = new Point(Location.X, Location.Y + deltaY);
            }
            if (isResizeNE)
            {
                Width = Width + deltaX;
                Height = Height - deltaY;
                Location = new Point(Location.X, Location.Y + deltaY);
            }
            if (isResizeE)
            {
                Width = Width + deltaX;
            }
            if (isResizeSE)
            {
                Width = Width + deltaX;
                Height = Height + deltaY;
            }
            if (isResizeS)
            {
                Height = Height + deltaY;
            }
            if (isResizeSW)
            {
                Width = Width - deltaX;
                Height = Height + deltaY;
                Location = new Point(Location.X + deltaX, Location.Y);
            }
            if (isResizeW)
            {
                Width = Width - deltaX;
                Location = new Point(Location.X + deltaX, Location.Y);
            }
            // v1.1.0 2020-05-29 Fix bug: Do not allow resizing to width or height less than 10.
            if ((Width < 10 + (2 * RED_BORDER_WIDTH_PIXELS)) || (Height < 10 + (2 * RED_BORDER_WIDTH_PIXELS)))
            {
                Width = origWidth;
                Height = origHeight;
                Location = origLocation;
            }
            startPoint = new Point(endPoint.X, endPoint.Y);
            Refresh();
        }
        
        private bool CursorIsInsideTransparentFormBounds()
        {
            Rectangle rect = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
            bool isInside = rect.Contains(Cursor.Position);
            return isInside;
        }
        #region methods: cursorIsCloseToxxxxxxxx
        private bool CursorIsCloseToRightEdge()
        {
            bool isClose = false;
            Point pt = Cursor.Position;
            int edgePosition = Location.X + ClientSize.Width;

            if (Math.Abs(pt.X - edgePosition) <= CLOSE_AMOUNT_PIXELS)
            {
                isClose = true;
            }
            return isClose;
        }
        private bool CursorIsCloseToLeftEdge()
        {
            bool isClose = false;
            Point pt = Cursor.Position;
            int edgePosition = Location.X;

            if (Math.Abs(pt.X - edgePosition) <= CLOSE_AMOUNT_PIXELS)
            {
                isClose = true;
            }
            return isClose;
        }
        private bool CursorIsCloseToBottomEdge()
        {
            bool isClose = false;
            Point pt = Cursor.Position;
            int edgePosition = Location.Y + ClientSize.Height;

            if (Math.Abs(pt.Y - edgePosition) <= CLOSE_AMOUNT_PIXELS)
            {
                isClose = true;
            }
            return isClose;
        }
        private bool CursorIsCloseToTopEdge()
        {
            bool isClose = false;
            Point pt = Cursor.Position;
            int edgePosition = Location.Y;

            if (Math.Abs(pt.Y - edgePosition) <= CLOSE_AMOUNT_PIXELS)
            {
                isClose = true;
            }
            return isClose;
        }
        private bool CursorIsCloseToAnyEdge()
        {
            return CursorIsCloseToBottomEdge() || CursorIsCloseToLeftEdge()
                    || CursorIsCloseToRightEdge() || CursorIsCloseToTopEdge();
        }
        private bool CursorIsCloseToLeftEdgeOnly()
        {
            bool isClose = CursorIsCloseToLeftEdge() == true &&
                CursorIsCloseToBottomEdge() == false &&
                CursorIsCloseToTopEdge() == false;
            return isClose;
        }
        private bool CursorIsCloseToTopEdgeOnly()
        {
            bool isClose = (CursorIsCloseToTopEdge() == true) &&
                    (CursorIsCloseToLeftEdge() == false) &&
                    (CursorIsCloseToRightEdge() == false);
            return isClose;
        }
        private bool CursorIsCloseToRightEdgeOnly()
        {
            bool isClose = (CursorIsCloseToRightEdge() == true) &&
                    (CursorIsCloseToBottomEdge() == false) &&
                    (CursorIsCloseToTopEdge() == false);
            return isClose;
        }
        private bool CursorIsCloseToBottomEdgeOnly()
        {
            bool isClose = (CursorIsCloseToBottomEdge() == true) &&
                    (CursorIsCloseToLeftEdge() == false) &&
                    (CursorIsCloseToRightEdge() == false);
            return isClose;
        }
        #endregion
        private void TransparentForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Very tricky! You have to switch the form property "KeyPreview" to true or your events will not be fired
            if (e.KeyCode == Keys.Escape)
            {
                // v1.1.0 2020-05-29 Fix bug: The window must be the original size if the Escape key is used to exit from resizing and moving the red frame.
                Width = origWidth;
                Height = origHeight;
                Location = origLocation;
                SimulateInitialLoad();
            }
        }
        private void TransparentForm_DoubleClick(object sender, EventArgs e)
        {
            SelectionCancelled = false;
            SelectedArea = new Rectangle(this.Location.X + RED_BORDER_WIDTH_PIXELS,
                                        this.Location.Y + RED_BORDER_WIDTH_PIXELS,
                                        this.Width - (2 * RED_BORDER_WIDTH_PIXELS),
                                        this.Height - (2 * RED_BORDER_WIDTH_PIXELS));
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
