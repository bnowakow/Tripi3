namespace TrafficDebugVisualizer
{
    partial class PointGetter
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
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.buttonGetPoints = new System.Windows.Forms.Button();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.listBoxPoints = new System.Windows.Forms.ListBox();
            this.groupBoxPoints = new System.Windows.Forms.GroupBox();
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.groupBoxSettings.SuspendLayout();
            this.groupBoxPoints.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.checkBoxShow);
            this.groupBoxSettings.Controls.Add(this.buttonGetPoints);
            this.groupBoxSettings.Controls.Add(this.textBoxCommand);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSettings.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(699, 71);
            this.groupBoxSettings.TabIndex = 0;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "groupBox1";
            // 
            // buttonGetPoints
            // 
            this.buttonGetPoints.Location = new System.Drawing.Point(306, 20);
            this.buttonGetPoints.Name = "buttonGetPoints";
            this.buttonGetPoints.Size = new System.Drawing.Size(75, 23);
            this.buttonGetPoints.TabIndex = 1;
            this.buttonGetPoints.Text = "Get points";
            this.buttonGetPoints.UseVisualStyleBackColor = true;
            this.buttonGetPoints.Click += new System.EventHandler(this.buttonGetPoints_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(7, 20);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(293, 20);
            this.textBoxCommand.TabIndex = 0;
            // 
            // listBoxPoints
            // 
            this.listBoxPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPoints.FormattingEnabled = true;
            this.listBoxPoints.Location = new System.Drawing.Point(3, 16);
            this.listBoxPoints.Name = "listBoxPoints";
            this.listBoxPoints.Size = new System.Drawing.Size(693, 511);
            this.listBoxPoints.TabIndex = 2;
            // 
            // groupBoxPoints
            // 
            this.groupBoxPoints.Controls.Add(this.listBoxPoints);
            this.groupBoxPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPoints.Location = new System.Drawing.Point(0, 71);
            this.groupBoxPoints.Name = "groupBoxPoints";
            this.groupBoxPoints.Size = new System.Drawing.Size(699, 536);
            this.groupBoxPoints.TabIndex = 1;
            this.groupBoxPoints.TabStop = false;
            this.groupBoxPoints.Text = "groupBox1";
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.Location = new System.Drawing.Point(7, 47);
            this.checkBoxShow.Name = "checkBoxShow";
            this.checkBoxShow.Size = new System.Drawing.Size(145, 17);
            this.checkBoxShow.TabIndex = 2;
            this.checkBoxShow.Text = "Show this group of points";
            this.checkBoxShow.UseVisualStyleBackColor = true;
            // 
            // PointGetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxPoints);
            this.Controls.Add(this.groupBoxSettings);
            this.Name = "PointGetter";
            this.Size = new System.Drawing.Size(699, 607);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.groupBoxPoints.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Button buttonGetPoints;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.ListBox listBoxPoints;
        private System.Windows.Forms.GroupBox groupBoxPoints;
        private System.Windows.Forms.CheckBox checkBoxShow;
    }
}
