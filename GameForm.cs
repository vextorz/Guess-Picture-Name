using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using NAudio.Wave;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GuessPictureName
{
    public partial class GameForm : Form
    {
        private string themePath;
        private string removedPath;
        private Queue<string> imageQueue;
        private Timer timer;
        private int timeLeft;
        private ImageForm imageForm;
        private string themeName;
        private WaveOutEvent waveOut;
        private AudioFileReader audioFile;
        public GameForm(string themePath)
        {
            InitializeComponent();
            this.themePath = themePath;
            this.removedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Removed");

            if (!Directory.Exists(removedPath))
            {
                Directory.CreateDirectory(removedPath);
            }
            themeName = Path.GetFileName(themePath);
            
            LoadImages();
            InitializeTimer();
            InitializeImageForm();
            this.Location = new Point(100, 25);
        }

        // Load image from folder
        private void LoadImages()
        {
            var jpgFiles = Directory.GetFiles(themePath, "*.jpg");
            var pngFiles = Directory.GetFiles(themePath, "*.png");
            var imageFiles = jpgFiles.Concat(pngFiles);
            imageQueue = new Queue<string>(imageFiles);
        }

        // Setup the timer
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        // Setup the ImageForm
        private void InitializeImageForm()
        {
            imageForm = new ImageForm();
            imageForm.Show();
            UpdateNextImageNameLabel();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                UpdateTimerLabel();
            }
            else
            {
                imageForm.Label1.Show();
                timer.Stop();
                imageForm.timer.Stop();
                imageForm.PictureBox.Hide();
            }
        }

        private void UpdateTimerLabel()
        {
            timerLabel.Text = timeLeft.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (imageQueue.Any())
            {
                if (timer.Enabled)
                {
                    timer.Stop();
                }

                timeLeft = 90;
                imageForm.timeLeft = 90;
                UpdateTimerLabel();
                imageForm.UpdateTimerLabel();

                DisplayNextImage();

                timer.Start();
                imageForm.timer.Start();

                UpdateNextImageNameLabel();

                if (imageForm.PictureBox.Visible == false && timer.Enabled == true)
                {
                    imageForm.PictureBox.Show();
                }

            }
            else
            {
                MessageBox.Show("No more images.");
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                imageForm.timer.Stop();
                imageForm.PictureBox.Hide();
                btnPause.Text = "Play";
            }
            else
            {
                timer.Start();
                imageForm.timer.Start();
                imageForm.PictureBox.Show();
                btnPause.Text = "Pause";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
            if (imageForm != null && !imageForm.IsDisposed)
            {
                imageForm.Close(); // Close the ImageForm if it exists and is open
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (imageForm.PictureBox.Image != null)
            {
                // Create theme-specific folder if it doesn't exist
                string themeFolderPath = Path.Combine(removedPath, themeName);
                if (!Directory.Exists(themeFolderPath))
                {
                    Directory.CreateDirectory(themeFolderPath);
                }

                var currentImage = imageForm.PictureBox.Tag.ToString();
                DisposeCurrentImage();

                var fileName = Path.GetFileName(currentImage);
                var destination = Path.Combine(themeFolderPath, fileName);

                try
                { 
                    File.Move(currentImage, destination);
                }
                catch (IOException) 
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
            PlayWinningSound();

            DisplayNextImage();
            UpdateNextImageNameLabel();
        }

        private void PlayWinningSound()
        {
            string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "winning_sound.mp3"); // Adjust the file name as needed
            if (File.Exists(soundPath))
            {
                waveOut = new WaveOutEvent();
                audioFile = new AudioFileReader(soundPath);
                waveOut.Init(audioFile);
                waveOut.Play();
            }
            else
            {
                MessageBox.Show("Winning sound file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSkip_Click(object sender, EventArgs e)
        {
            if (imageForm.PictureBox.Image != null)
            {
                if (imageQueue.Any())
                {
                    var currentImage = imageForm.PictureBox.Tag.ToString();
                    DisposeCurrentImage();

                    imageQueue.Enqueue(currentImage);
                    DisplayNextImage();
                    UpdateNextImageNameLabel();
                }
            }
        }
        private void DisplayNextImage()
        {
            if (imageQueue.Any())
            {
                var nextImage = imageQueue.Dequeue();
                imageForm.PictureBox.Image = Image.FromFile(nextImage);
                imageForm.PictureBox.Tag = nextImage;
                nextImageNameLabel.Text = "";
            }
            else
            {
                imageForm.PictureBox.Image = null;
                imageForm.PictureBox.Tag = null;
                nextImageNameLabel.Text = "No more images.";
            }
        }

        private void DisposeCurrentImage()
        {
            if (imageForm.PictureBox.Image != null)
            {
                imageForm.PictureBox.Image.Dispose();
                imageForm.PictureBox.Image = null;
            }
        }

        private void UpdateNextImageNameLabel()
        {
            if (imageForm.PictureBox.Image != null && imageForm.PictureBox.Tag != null)
            {
                var currentImage = imageForm.PictureBox.Tag.ToString();
                var fileName = Path.GetFileNameWithoutExtension(currentImage);
                nextImageNameLabel.Text = fileName;
            }
            else
            {
                nextImageNameLabel.Text = "No image loaded.";
            }
        }

        private void timerLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
