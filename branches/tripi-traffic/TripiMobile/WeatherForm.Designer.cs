namespace Tripi
{
    partial class WeatherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeatherForm));
            this.weatherTitle = new System.Windows.Forms.Label();
            this.weatherDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // weatherTitle
            // 
            this.weatherTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.weatherTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.weatherTitle.Location = new System.Drawing.Point(96, 45);
            this.weatherTitle.Name = "weatherTitle";
            this.weatherTitle.Size = new System.Drawing.Size(67, 20);
            this.weatherTitle.Text = "Weather";
            // 
            // weatherDescription
            // 
            this.weatherDescription.Location = new System.Drawing.Point(26, 87);
            this.weatherDescription.Name = "weatherDescription";
            this.weatherDescription.Size = new System.Drawing.Size(188, 140);
            this.weatherDescription.Text = "text";
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.weatherDescription);
            this.Controls.Add(this.weatherTitle);
            this.Name = "WeatherForm";
            this.Text = "Tripi";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label weatherTitle;
        private System.Windows.Forms.Label weatherDescription;
    }
}