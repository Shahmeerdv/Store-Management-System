namespace PROJECT_SYSTEM
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ProgressBar1 = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new Bunifu.UI.WinForms.BunifuImageButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(263, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "STORE MANAGEMENT SYSTEM";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.AllowAnimations = false;
            this.ProgressBar1.Animation = 0;
            this.ProgressBar1.AnimationSpeed = 220;
            this.ProgressBar1.AnimationStep = 10;
            this.ProgressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.ProgressBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProgressBar1.BackgroundImage")));
            this.ProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.ProgressBar1.BorderRadius = 9;
            this.ProgressBar1.BorderThickness = 1;
            this.ProgressBar1.Location = new System.Drawing.Point(279, 402);
            this.ProgressBar1.Maximum = 100;
            this.ProgressBar1.MaximumValue = 100;
            this.ProgressBar1.Minimum = 0;
            this.ProgressBar1.MinimumValue = 0;
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ProgressBar1.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.ProgressBar1.ProgressColorLeft = System.Drawing.Color.DodgerBlue;
            this.ProgressBar1.ProgressColorRight = System.Drawing.Color.DodgerBlue;
            this.ProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ProgressBar1.Size = new System.Drawing.Size(285, 13);
            this.ProgressBar1.TabIndex = 3;
            this.ProgressBar1.Value = 50;
            this.ProgressBar1.ValueByTransition = 50;
            this.ProgressBar1.ProgressChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuProgressBar.ProgressChangedEventArgs>(this.ProgressBar1_ProgressChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PROJECT_SYSTEM.Properties.Resources.shopping_bag;
            this.pictureBox1.Location = new System.Drawing.Point(305, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 238);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.ActiveImage = null;
            this.btnClose.AllowAnimations = true;
            this.btnClose.AllowBuffering = false;
            this.btnClose.AllowToggling = false;
            this.btnClose.AllowZooming = false;
            this.btnClose.AllowZoomingOnFocus = false;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnClose.ErrorImage")));
            this.btnClose.FadeWhenInactive = false;
            this.btnClose.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.ImageLocation = null;
            this.btnClose.ImageMargin = 20;
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.ImageZoomSize = new System.Drawing.Size(50, 50);
            this.btnClose.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnClose.InitialImage")));
            this.btnClose.Location = new System.Drawing.Point(804, -5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Rotation = 0;
            this.btnClose.ShowActiveImage = true;
            this.btnClose.ShowCursorChanges = true;
            this.btnClose.ShowImageBorders = true;
            this.btnClose.ShowSizeMarkers = false;
            this.btnClose.Size = new System.Drawing.Size(50, 50);
            this.btnClose.TabIndex = 0;
            this.btnClose.ToolTipText = "";
            this.btnClose.WaitOnLoad = false;
            this.btnClose.Zoom = 20;
            this.btnClose.ZoomSpeed = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(294, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Project by Ali and Shahmeer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(848, 570);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuImageButton btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuProgressBar ProgressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}

