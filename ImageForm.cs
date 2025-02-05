using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace GuessPictureName
{
    public partial class ImageForm : Form
    {
        public Timer timer;
        public int timeLeft;
        public ImageForm()
        {
            InitializeComponent();
            InitializeTimer();
            this.Location = new Point( 1000, 25);
        }

        public PictureBox PictureBox
        {
            get { return pictureBox1; }
        }
        public Label Label1
        {
            get { return endLbl; }
        }
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                UpdateTimerLabel();
            }
        }

        public void UpdateTimerLabel()
        {
            timerLbl.Text = timeLeft.ToString();
        }

    }
}
