namespace Trex_Endless_Running_Project
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
            this.lblScore = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.obstacles3 = new System.Windows.Forms.PictureBox();
            this.obstacles2 = new System.Windows.Forms.PictureBox();
            this.obstacles1 = new System.Windows.Forms.PictureBox();
            this.Trex = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trex)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(0, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(43, 16);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score";
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 15;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // obstacles3
            // 
            this.obstacles3.BackColor = System.Drawing.Color.Transparent;
            this.obstacles3.Image = global::Trex_Endless_Running_Project.Properties.Resources.Bird;
            this.obstacles3.Location = new System.Drawing.Point(660, 344);
            this.obstacles3.Name = "obstacles3";
            this.obstacles3.Size = new System.Drawing.Size(80, 60);
            this.obstacles3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacles3.TabIndex = 4;
            this.obstacles3.TabStop = false;
            this.obstacles3.Tag = "obstacles";
            // 
            // obstacles2
            // 
            this.obstacles2.BackColor = System.Drawing.Color.Transparent;
            this.obstacles2.Image = global::Trex_Endless_Running_Project.Properties.Resources.Tree;
            this.obstacles2.Location = new System.Drawing.Point(547, 328);
            this.obstacles2.Name = "obstacles2";
            this.obstacles2.Size = new System.Drawing.Size(92, 80);
            this.obstacles2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacles2.TabIndex = 3;
            this.obstacles2.TabStop = false;
            this.obstacles2.Tag = "obstacles";
            // 
            // obstacles1
            // 
            this.obstacles1.BackColor = System.Drawing.Color.Transparent;
            this.obstacles1.Image = global::Trex_Endless_Running_Project.Properties.Resources.Stone;
            this.obstacles1.Location = new System.Drawing.Point(382, 357);
            this.obstacles1.Name = "obstacles1";
            this.obstacles1.Size = new System.Drawing.Size(49, 64);
            this.obstacles1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacles1.TabIndex = 2;
            this.obstacles1.TabStop = false;
            this.obstacles1.Tag = "obstacles";
            // 
            // Trex
            // 
            this.Trex.BackColor = System.Drawing.Color.Transparent;
            this.Trex.Image = global::Trex_Endless_Running_Project.Properties.Resources.Running;
            this.Trex.Location = new System.Drawing.Point(217, 312);
            this.Trex.Name = "Trex";
            this.Trex.Size = new System.Drawing.Size(88, 92);
            this.Trex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Trex.TabIndex = 1;
            this.Trex.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.obstacles3);
            this.Controls.Add(this.obstacles2);
            this.Controls.Add(this.obstacles1);
            this.Controls.Add(this.Trex);
            this.Controls.Add(this.lblScore);
            this.Name = "Form1";
            this.Text = "T Rex Endless Runner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPaintEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.obstacles3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacles1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox Trex;
        private System.Windows.Forms.PictureBox obstacles1;
        private System.Windows.Forms.PictureBox obstacles2;
        private System.Windows.Forms.PictureBox obstacles3;
    }
}

