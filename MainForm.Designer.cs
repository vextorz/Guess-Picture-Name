namespace GuessPictureName
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResources = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(248, 12);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(604, 595);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(604, 595);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(604, 595);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.btnDump);
            this.panel1.Controls.Add(this.btnResources);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 595);
            this.panel1.TabIndex = 1;
            // 
            // btnResources
            // 
            this.btnResources.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnResources.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResources.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResources.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnResources.Location = new System.Drawing.Point(34, 172);
            this.btnResources.Name = "btnResources";
            this.btnResources.Size = new System.Drawing.Size(165, 49);
            this.btnResources.TabIndex = 0;
            this.btnResources.Text = "Open Resources";
            this.btnResources.UseVisualStyleBackColor = false;
            this.btnResources.Click += new System.EventHandler(this.btnResources_Click);
            // 
            // btnDump
            // 
            this.btnDump.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDump.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDump.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDump.Location = new System.Drawing.Point(34, 241);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(165, 49);
            this.btnDump.TabIndex = 1;
            this.btnDump.Text = "Open Removed";
            this.btnDump.UseVisualStyleBackColor = false;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReload.Location = new System.Drawing.Point(48, 331);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(136, 38);
            this.btnReload.TabIndex = 2;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(864, 616);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Main Menu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.Button btnResources;
        private System.Windows.Forms.Button btnReload;
    }
}

