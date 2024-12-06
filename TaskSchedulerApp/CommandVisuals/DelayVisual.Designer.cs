namespace TaskSchedulerApp.CommandVisuals
{
    partial class DelayVisual
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2NumericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Silver;
            guna2HtmlLabel1.Location = new Point(3, 5);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(96, 19);
            guna2HtmlLabel1.TabIndex = 2;
            guna2HtmlLabel1.Text = "Delay Seconds:";
            // 
            // guna2NumericUpDown1
            // 
            guna2NumericUpDown1.BackColor = Color.Transparent;
            guna2NumericUpDown1.BorderRadius = 5;
            guna2NumericUpDown1.BorderThickness = 0;
            guna2NumericUpDown1.CustomizableEdges = customizableEdges1;
            guna2NumericUpDown1.Font = new Font("Segoe UI", 9F);
            guna2NumericUpDown1.Location = new Point(5, 27);
            guna2NumericUpDown1.Name = "guna2NumericUpDown1";
            guna2NumericUpDown1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2NumericUpDown1.Size = new Size(87, 23);
            guna2NumericUpDown1.TabIndex = 3;
            // 
            // StartWindowsProcessVisual2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            Controls.Add(guna2NumericUpDown1);
            Controls.Add(guna2HtmlLabel1);
            Name = "StartWindowsProcessVisual2";
            Size = new Size(300, 58);
            Click += VisualForm_Click;
            ((System.ComponentModel.ISupportInitialize)guna2NumericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown1;
    }
}
