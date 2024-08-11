using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CobaltClient
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            SetRoundedRegion();

            LoadMainForm();
        }

        private void SetRoundedRegion()
        {
            int radius = 58; // The radius for the corners
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

        private async void LoadMainForm()
        {
            await Task.Delay(2000); // Wait for 2 seconds asynchronously

            IW8 iw8 = new IW8();
            iw8.Show();

            this.Hide();
        }
    }
}
