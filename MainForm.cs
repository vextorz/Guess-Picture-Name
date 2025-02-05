using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessPictureName
{
    public partial class MainForm : Form
    {
        private string resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
        private string removedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Removed");
        public MainForm()
        {
            InitializeComponent();
            LoadThemes();
        }
        private void LoadThemes()
        {
            flowLayoutPanel1.Controls.Clear();

            if (!Directory.Exists(resourcesPath))
            {
                Directory.CreateDirectory(resourcesPath);
            }

            var themeDirectories = Directory.GetDirectories(resourcesPath);

            foreach (var themeDir in themeDirectories)
            {
                var themeName = Path.GetFileName(themeDir);
                var jpgFiles = Directory.GetFiles(themeDir, "*.jpg");
                var pngFiles = Directory.GetFiles(themeDir, "*.png");
                var imageFilesCount = jpgFiles.Length + pngFiles.Length;

                var button = new Button
                {
                    Text = $"{themeName} ({imageFilesCount})",
                    Tag = themeDir,
                    AutoSize = false,
                    Size = new Size(110, 110),
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 18, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    FlatStyle = FlatStyle.Popup,
            };
                button.Click += ThemeButton_Click;
                flowLayoutPanel1.Controls.Add(button);
            }
        }
        private void ThemeButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var themePath = button.Tag.ToString();
            var gameForm = new GameForm(themePath);
            gameForm.FormClosed += GameForm_FormClosed; // Subscribe to the FormClosed event
            gameForm.Show();

            // Customize button appearance

        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Reload themes
            LoadThemes();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnResources_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(resourcesPath))
            {
                Process.Start(resourcesPath);
            }
            else
            {
                MessageBox.Show("Resources folder does not exist.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(removedPath))
            {
                Process.Start(removedPath);
            }
            else
            {
                MessageBox.Show("Removed folder does not exist.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadThemes();
        }
    }
}
