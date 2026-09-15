namespace Circuits
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAnd = new System.Windows.Forms.ToolStripButton();
            this.orIconButton = new System.Windows.Forms.ToolStripButton();
            this.notIconButton = new System.Windows.Forms.ToolStripButton();
            this.inputIconButton = new System.Windows.Forms.ToolStripButton();
            this.outputIconButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAnd,
            this.orIconButton,
            this.notIconButton,
            this.inputIconButton,
            this.outputIconButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1344, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAnd
            // 
            this.toolStripButtonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnd.Image = global::Circuits.Properties.Resources.AndIcon;
            this.toolStripButtonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnd.Name = "toolStripButtonAnd";
            this.toolStripButtonAnd.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonAnd.Text = "toolStripButton1";
            this.toolStripButtonAnd.Click += new System.EventHandler(this.toolStripButtonAnd_Click);
            // 
            // orIconButton
            // 
            this.orIconButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.orIconButton.Image = global::Circuits.Properties.Resources.OrIcon;
            this.orIconButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.orIconButton.Name = "orIconButton";
            this.orIconButton.Size = new System.Drawing.Size(29, 24);
            this.orIconButton.Text = "orIconButton";
            this.orIconButton.Click += new System.EventHandler(this.orIconButton_Click);
            // 
            // notIconButton
            // 
            this.notIconButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.notIconButton.Image = global::Circuits.Properties.Resources.NotIcon;
            this.notIconButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.notIconButton.Name = "notIconButton";
            this.notIconButton.Size = new System.Drawing.Size(29, 24);
            this.notIconButton.Text = "notIconButton";
            this.notIconButton.Click += new System.EventHandler(this.notIconButton_Click);
            // 
            // inputIconButton
            // 
            this.inputIconButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.inputIconButton.Image = global::Circuits.Properties.Resources.InputIcon;
            this.inputIconButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inputIconButton.Name = "inputIconButton";
            this.inputIconButton.Size = new System.Drawing.Size(29, 28);
            this.inputIconButton.Text = "inputIconButton";
            this.inputIconButton.Click += new System.EventHandler(this.inputIconButton_Click);
            // 
            // outputIconButton
            // 
            this.outputIconButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.outputIconButton.Image = global::Circuits.Properties.Resources.OutputIcon;
            this.outputIconButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.outputIconButton.Name = "outputIconButton";
            this.outputIconButton.Size = new System.Drawing.Size(29, 28);
            this.outputIconButton.Text = "outputIconButton";
            this.outputIconButton.Click += new System.EventHandler(this.outputIconButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1344, 897);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Circuits 2023";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnd;
        private System.Windows.Forms.ToolStripButton orIconButton;
        private System.Windows.Forms.ToolStripButton notIconButton;
        private System.Windows.Forms.ToolStripButton inputIconButton;
        private System.Windows.Forms.ToolStripButton outputIconButton;
    }
}

