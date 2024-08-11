using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CobaltClient
{
    public partial class IW8 : Form
    {

        private Timer fadeInTimer;
        private double fadeInStep = 0.05; // Step size for opacity change
        private double targetOpacity = 1.0; // Final opacity (fully opaque)
        private double initialOpacity = 0.0; // Starting opacity (fully transparent)

        public IW8()
        {
            InitializeComponent();
            SetRoundedRegion();

            this.Opacity = initialOpacity;

            // Initialize and configure the timer
            fadeInTimer = new Timer();
            fadeInTimer.Interval = 50; // Interval in milliseconds
            fadeInTimer.Tick += FadeInTimer_Tick;
            fadeInTimer.Start();
        }

        private void SetRoundedRegion()
        {
            int radius = 36; // The radius for the corners
            var path = new GraphicsPath();

            // Create a rounded rectangle
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
            path.CloseAllFigures();

            // Set the form's region to the rounded rectangle
            this.Region = new Region(path);
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            // Increase opacity
            this.Opacity += fadeInStep;

            // Stop the timer once the form is fully opaque
            if (this.Opacity >= targetOpacity)
            {
                this.Opacity = targetOpacity;
                fadeInTimer.Stop();
            }
        }
    }
}
