using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Capture the current desktop and create a gradient by dragging the mouse of the captured desktop.
/// 
/// Credits:
/// 
///   - https://www.codeproject.com/Articles/485883/Create-your-own-Snipping-Tool
///   - https://stackoverflow.com/questions/7822514/multi-color-linear-gradient-in-winforms
///   - https://rosettacode.org/wiki/Bitmap/Bresenham%27s_line_algorithm#C.23
/// 
/// </summary>
namespace GradientPicker
{
    public partial class GradientPickerForm : Form
    {
        /// <summary>
        /// Indicator whether we are in paint mode or not
        /// </summary>
        private bool mouseDown;

        /// <summary>
        /// Paint positions
        /// </summary>
        private List<Point> paintPoints =  new List<Point>();

        /// <summary>
        /// Sampled colors along the sample points
        /// </summary>
        private List<Color> sampledColors = new List<Color>();

        /// <summary>
        /// Sample points, created using the paint points
        /// </summary>
        private List<Point> samplePoints = new List<Point>();

        /// <summary>
        /// Bitmap for drawing the paint line segments
        /// </summary>
        private Bitmap paintBitmap;

        /// <summary>
        /// Gradient width selection item for the resolution combobox
        /// </summary>
        private class GradientWidth
        {
            public const int SAMPLED_COLORS_ID = -1;

            /// <summary>
            /// Gradient width combocox display name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gradient width combocox value
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// Name of the "Name" member for the combobox datasource
            /// </summary>
            public string GetDisplayMemberName()
            {
                return nameof( Name);
            }

            /// <summary>
            /// Name of the Value member for the combobox datasource
            /// </summary>
            /// <returns></returns>
            public string GetValueMemberName()
            {
                return nameof(Value);
            }
        }

        /// <summary>
        /// Set window state, init form and custom components, start new session.
        /// </summary>
        public GradientPickerForm()
        {
            // start maximized
            // WindowState = FormWindowState.Maximized;

            // init form components
            InitializeComponent();

            // init custom components
            SetupComponents();

            // start new session at startup
            NewSession();
        }

        /// <summary>
        /// Setup gradient width combobox.
        /// </summary>
        private void SetupComponents()
        {
            #region Gradient Width

            var selectedValue = 2048;

            // gradient width datasource
            var dataSource = new List<GradientWidth>();

            // predefined widths
            dataSource.Add(new GradientWidth() { Name = "128", Value = 128 });
            dataSource.Add(new GradientWidth() { Name = "256", Value = 256 });
            dataSource.Add(new GradientWidth() { Name = "512", Value = 512 });
            dataSource.Add(new GradientWidth() { Name = "1024", Value = 1024 });
            dataSource.Add(new GradientWidth() { Name = "2048", Value = 2048 });
            dataSource.Add(new GradientWidth() { Name = "Sampled Colors", Value = GradientWidth.SAMPLED_COLORS_ID });

            // set datasource
            this.GradientWidthComboBox.DataSource = dataSource;

            // set combobox automatisms
            this.GradientWidthComboBox.DisplayMember = dataSource[0].GetDisplayMemberName();
            this.GradientWidthComboBox.ValueMember = dataSource[0].GetValueMemberName();

            // preselect value
            this.GradientWidthComboBox.SelectedValue = selectedValue;

            #endregion Gradient Width
        }

        /// <summary>
        /// Capture the screen without the current form
        /// </summary>
        private void CaptureScreen()
        {

            try
            {
                // hide this form
                this.Opacity = 0; // make sure this form isn't visible
                this.Hide();

                /// 
                /// Capture Screen
                /// 

                #region Capture Screen

                // create target bitmap
                Bitmap screenBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                // create graphics
                Graphics screenGraphics = Graphics.FromImage(screenBitmap as Image);

                // capture screen
                screenGraphics.CopyFromScreen(0, 0, 0, 0, screenBitmap.Size);

                // create temporary memory stream for the screen image
                using (MemoryStream stream = new MemoryStream())
                {
                    // save graphic variable into memory
                    screenBitmap.Save(stream, ImageFormat.Bmp);

                    // set picturebox size
                    SourcePictureBox.Size = new System.Drawing.Size(this.Width, this.Height);

                    // set image of picturebox
                    SourcePictureBox.Image = Image.FromStream(stream);
                }

                #endregion Capture Screen

            }
            finally
            {
                // show this form again
                this.Opacity = 1;
                this.Show();

            }

        }

        /// <summary>
        /// Create the gradient using the sampled colors.
        /// If no sampled colors are available, the gradient image is empty.
        /// </summary>
        private void CreateGradient()
        {
            // get the selected gradient width
            int gradientWidth = GetSelectedGradientWidth();
            int gradientHeight = GradientPictureBox.Height;

            // gradient rectangle using the selected with and picturebox height
            Rectangle gradientRectangle = new Rectangle( 0, 0, gradientWidth, gradientHeight);

            // create bitmap & graphics
            Bitmap bitmap = new Bitmap(gradientWidth, gradientHeight);
            Graphics graphics = Graphics.FromImage(bitmap as Image);

            // setup the gradient
            LinearGradientBrush brush = new LinearGradientBrush(gradientRectangle, Color.Black, Color.Black, 0, false);
            ColorBlend colorBlend = new ColorBlend();
            
            // set number of gradient colors
            int gradientColorCount = sampledColors.Count;

            if (gradientColorCount > 0)
            {
                // initialize arrays
                float[] gradientPositions = new float[gradientColorCount];
                Color[] gradientColors = new Color[gradientColorCount];

                // set the gradient position [0..1] and color
                for (var i = 0; i < gradientColorCount; i++)
                {
                    // get the position, it must start with exactly 0 and end with exactly 1
                    float position;

                    if (i == 0)
                        position = 0;
                    else if (i == gradientColorCount - 1)
                        position = 1;
                    else
                        position = ((float)i) / (gradientColorCount - 1);

                    // set position and color
                    gradientPositions[i] = position;
                    gradientColors[i] = sampledColors[i];
                }

                colorBlend.Positions = gradientPositions;
                colorBlend.Colors = gradientColors;

                brush.InterpolationColors = colorBlend;
                brush.RotateTransform(0);

                // paint the gradient
                graphics.FillRectangle(brush, gradientRectangle);
            }

            // set the gradient bitmap as new image
            GradientPictureBox.Image = bitmap;

            // resize the picturebox to the actual gradient size
            GradientPictureBox.Size = new System.Drawing.Size(gradientWidth, GradientPictureBox.Size.Height);

            // update the layout panel and implicitly adjust auto-scrolls
            GradientLayoutPanel.Invalidate();
        }

        /// <summary>
        /// Add the sample points between 2 points using the Bresenham algorithm.
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        void AddSamplePoints( int x0, int y0, int x1, int y1)
        {
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;
            for (; ; )
            {
                #region Add sample points
                // add the point along the line to the sample points, but only if it doesn't overlap with the previous one
                Point newPoint = new Point(x0, y0);

                Boolean isOverlapping = samplePoints.Count > 0 && samplePoints[samplePoints.Count - 1].Equals(newPoint);
                if (!isOverlapping)
                {
                    samplePoints.Add( newPoint);
                }
                #endregion Add sample points

                if (x0 == x1 && y0 == y1) break;
                e2 = err;
                if (e2 > -dx) { err -= dy; x0 += sx; }
                if (e2 < dy) { err += dx; y0 += sy; }
            }
        }

        /// <summary>
        /// Start painting using mouse down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evt"></param>
        private void SourcePictureBox_MouseDown_1(object sender, MouseEventArgs evt)
        {
            // clear the sample data
            paintPoints.Clear();
            sampledColors.Clear();
            samplePoints.Clear();

            // remove previously painted lines
            SourcePictureBox.Invalidate();

            // indicator that we are painting
            mouseDown = true;

            // add clicked point
            paintPoints.Add(new Point(evt.X, evt.Y));
        }

        /// <summary>
        /// Paint using mouse drag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evt"></param>
        private void SourcePictureBox_MouseMove_1(object sender, MouseEventArgs evt)
        {
            // check if we are in paint mode
            if (!mouseDown)
                return;
            
            // add painted point
            paintPoints.Add(new Point(evt.X, evt.Y));

            // repaint painted line
            SourcePictureBox.Invalidate();
        }

        /// <summary>
        /// Paint mode finished, sample points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evt"></param>
        private void SourcePictureBox_MouseUp(object sender, MouseEventArgs evt)
        {
            // abort if not in paint mode
            if (!mouseDown)
                return;

            // stop paint mode
            mouseDown = false;

            // draw the painted path
            using (Graphics graphics = Graphics.FromImage(paintBitmap))
            {
                DrawPath( graphics);
                graphics.Flush();
            }

            // perform sampling
            SampleColors();

            // paint the gradient
            CreateGradient();
        }

        /// <summary>
        /// Paint the path while we are in paint mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sourcePictureBox_Paint(object sender, PaintEventArgs e)
        {
            // abort if not in paint mode
            if (!mouseDown)
                return;

            // draw painted path
            DrawPath(e.Graphics);
        }

        /// <summary>
        /// Draw the path as line segments
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawPath(Graphics graphics)
        {
            // abort if nothing to paint
            if (paintPoints.Count == 0)
                return;

            // create line types
            byte[] types = new byte[paintPoints.Count];
            types[0] = (byte) PathPointType.Start;
            for (int i = 1; i < paintPoints.Count; i++)
            {
                types[i] = (byte)PathPointType.Line;
            }

            // draw the line using the points and types
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.DrawPath(pen, new System.Drawing.Drawing2D.GraphicsPath( paintPoints.ToArray(), types));
            }
        }

        /// <summary>
        /// Sample the colors using the available sample points.
        /// Special case: only 1 sample point available, this means the gradient is a solid color with same start and end point color.
        /// </summary>
        private void SampleColors()
        {
            // reset color list
            sampledColors.Clear();

            // the bitmap to sample colors from
            Bitmap sourceBitmap = SourcePictureBox.Image as Bitmap;

            // special case: single mouse click should be solid color
            if (paintPoints.Count == 1)
            {
                paintPoints.Add(paintPoints[0]);
            }

            // create sample points using the available paint points
            // gaps are prevented by moving along any 2 given points using the bresenham algorithm
            for (int i = 1; i < paintPoints.Count; i++)
            {
                Point a = paintPoints[i - 1];
                Point b = paintPoints[i];

                // check point being in image bounds
                Boolean valid = a.X >= 0 && a.Y >= 0 && a.X < sourceBitmap.Width && a.Y < sourceBitmap.Height;
                valid &= b.X >= 0 && b.Y >= 0 && b.X < sourceBitmap.Width && b.Y < sourceBitmap.Height;

                // skip if outside of bounds
                if (!valid)
                    continue;

                // add sample points using the bresenham algorithm
                AddSamplePoints(a.X, a.Y, b.X, b.Y);

            }

            // get the colors using the sample points
            for (int i = 0; i < samplePoints.Count; i++)
            {
                Point samplePoint = samplePoints[i];

                // read color from the source bitmap
                Color newColor = sourceBitmap.GetPixel(samplePoint.X, samplePoint.Y);

                sampledColors.Add(newColor);
            }

            // special case: single mouse click should be solid color
            // the gradient algorithm requires at least 2 colors
            if (sampledColors.Count == 1)
            {
                sampledColors.Add(sampledColors[0]);
            }

        }

        /// <summary>
        /// Reset the members and capture the screen
        /// </summary>
        private void NewSession()
        {
            // dispose of existing bitmaps
            if (paintBitmap != null)
            {
                paintBitmap.Dispose();
            }

            // capture the screen and put it into the source picturebox
            CaptureScreen();

            // reset variables
            this.paintPoints.Clear();
            this.samplePoints.Clear();
            this.sampledColors.Clear();

            // create bitmap to paint ont
            this.paintBitmap = new Bitmap(SourcePictureBox.Width, SourcePictureBox.Height);

        }

        /// <summary>
        /// Save the gradient as PNG.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evt"></param>
        private void SaveButton_Click(object sender, EventArgs evt)
        {
            // save dialog, select filename
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PNG (*.png)|*.png";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            // set gradient height to single line
            int saveBitmapHeight = 1;

            // create single line image from the existing gradient
            Bitmap saveBitmap = new Bitmap(GradientPictureBox.Image.Width, saveBitmapHeight);

            Graphics graphics = Graphics.FromImage(saveBitmap as Image);
            graphics.DrawImageUnscaled(GradientPictureBox.Image, 0, 0);
            graphics.Dispose();

            GradientPictureBox.DrawToBitmap(saveBitmap, new Rectangle(0, 0, GradientPictureBox.Width, saveBitmapHeight));

            // create an image from the bitmap which has a save method
            Image saveImage = saveBitmap as Image;

            // save the image
            saveImage.Save(dialog.FileName, ImageFormat.Png);

        }

        /// <summary>
        /// Get the selected width of the gradient in pixels.
        /// Special case GradientWidth.SAMPLED_COLORS_ID: instead of predefined width calculate the width using the available colors
        /// </summary>
        /// <returns></returns>
        private int GetSelectedGradientWidth()
        {
            // get selected width object
            GradientWidth gradientSize = GradientWidthComboBox.SelectedItem as GradientWidth;

            // get the width
            int value = gradientSize.Value;

            // special case: instead of the resolution use the number of sampled colors
            if( value == GradientWidth.SAMPLED_COLORS_ID)
            {
                value = sampledColors.Count;
            }

            return value;
        }

        /// <summary>
        /// Start a new session, re-initialize the members and capture the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evt"></param>
        private void NewSessionButton_Click(object sender, EventArgs evt)
        {
            NewSession();
        }

        /// <summary>
        /// Recreate the gradient if the resolution changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evt"></param>
        private void GradientWidthComboBox_SelectionChangeCommitted(object sender, EventArgs evt)
        {

            CreateGradient();

        }
    }
}
