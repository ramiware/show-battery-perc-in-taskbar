
namespace ShowBatteryPercentageInTaskbar
{
    partial class BatteryPercentage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatteryPercentage));
            notifyIconBatteryPercentage = new System.Windows.Forms.NotifyIcon(components);
            contextMenuBP = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            pictureBoxX = new System.Windows.Forms.PictureBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            contextMenuBP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIconBatteryPercentage
            // 
            notifyIconBatteryPercentage.ContextMenuStrip = contextMenuBP;
            notifyIconBatteryPercentage.Visible = true;
            notifyIconBatteryPercentage.MouseClick += notifyIconBatteryPercentage_MouseClick;
            // 
            // contextMenuBP
            // 
            contextMenuBP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemAbout, toolStripMenuItemExit });
            contextMenuBP.Name = "contextMenuBP";
            contextMenuBP.Size = new System.Drawing.Size(108, 48);
            // 
            // toolStripMenuItemAbout
            // 
            toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            toolStripMenuItemAbout.Size = new System.Drawing.Size(107, 22);
            toolStripMenuItemAbout.Text = "About";
            toolStripMenuItemAbout.Click += toolStripMenuItemAbout_Click;
            // 
            // toolStripMenuItemExit
            // 
            toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            toolStripMenuItemExit.Size = new System.Drawing.Size(107, 22);
            toolStripMenuItemExit.Text = "Exit";
            toolStripMenuItemExit.Click += toolStripMenuItemExit_Click;
            // 
            // pictureBoxX
            // 
            pictureBoxX.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pictureBoxX.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBoxX.BackgroundImage");
            pictureBoxX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBoxX.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxX.Location = new System.Drawing.Point(340, 8);
            pictureBoxX.Name = "pictureBoxX";
            pictureBoxX.Size = new System.Drawing.Size(16, 16);
            pictureBoxX.TabIndex = 1;
            pictureBoxX.TabStop = false;
            pictureBoxX.Click += pictureBoxX_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox1.Image = Properties.Resources.logo_ramiware_500x500;
            pictureBox1.Location = new System.Drawing.Point(132, 296);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(115, 82);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(62, 148);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(261, 20);
            label1.TabIndex = 3;
            label1.Text = "Show Battery Percentage in Taskbar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(62, 176);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(96, 15);
            label2.TabIndex = 4;
            label2.Text = "Version 1.03 2025";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(62, 204);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 15);
            label3.TabIndex = 5;
            label3.Text = "Ramiware";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(62, 233);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(135, 15);
            label4.TabIndex = 6;
            label4.Text = "support@ramiware.com";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.White;
            label5.Location = new System.Drawing.Point(62, 263);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(83, 15);
            label5.TabIndex = 7;
            label5.Text = "ramiware.com";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox2.Image = Properties.Resources.ShowBatteryPercentageInTaskbar_logo;
            pictureBox2.Location = new System.Drawing.Point(91, 50);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(191, 95);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.bg;
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 394);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(368, 206);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(8, 20, 0);
            panel2.Controls.Add(pictureBoxX);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(368, 30);
            panel2.TabIndex = 10;
            // 
            // BatteryPercentage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(8, 20, 0);
            ClientSize = new System.Drawing.Size(368, 600);
            Controls.Add(pictureBox2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BatteryPercentage";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Battery Perentage by Ramiware";
            contextMenuBP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxX).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIconBatteryPercentage;
        private System.Windows.Forms.PictureBox pictureBoxX;
        private System.Windows.Forms.ContextMenuStrip contextMenuBP;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

