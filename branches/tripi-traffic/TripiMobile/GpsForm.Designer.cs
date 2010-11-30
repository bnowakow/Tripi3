namespace Tripi
{
    partial class GpsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GpsForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelLongitude = new System.Windows.Forms.Label();
            this.labelLatitude = new System.Windows.Forms.Label();
            this.tboxLongitude = new System.Windows.Forms.TextBox();
            this.tboxLatitude = new System.Windows.Forms.TextBox();
            this.labelSatellite = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.tboxSpeed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTitle.Location = new System.Drawing.Point(33, 49);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 20);
            this.labelTitle.Text = "GPS information";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelLongitude
            // 
            this.labelLongitude.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelLongitude.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelLongitude.Location = new System.Drawing.Point(10, 118);
            this.labelLongitude.Name = "labelLongitude";
            this.labelLongitude.Size = new System.Drawing.Size(83, 20);
            this.labelLongitude.Text = "Longitude:";
            this.labelLongitude.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelLatitude
            // 
            this.labelLatitude.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelLatitude.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelLatitude.Location = new System.Drawing.Point(10, 90);
            this.labelLatitude.Name = "labelLatitude";
            this.labelLatitude.Size = new System.Drawing.Size(83, 20);
            this.labelLatitude.Text = "Latitude:";
            this.labelLatitude.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tboxLongitude
            // 
            this.tboxLongitude.Location = new System.Drawing.Point(99, 117);
            this.tboxLongitude.Name = "tboxLongitude";
            this.tboxLongitude.Size = new System.Drawing.Size(123, 21);
            this.tboxLongitude.TabIndex = 9;
            // 
            // tboxLatitude
            // 
            this.tboxLatitude.Location = new System.Drawing.Point(99, 90);
            this.tboxLatitude.Name = "tboxLatitude";
            this.tboxLatitude.Size = new System.Drawing.Size(123, 21);
            this.tboxLatitude.TabIndex = 7;
            // 
            // labelSatellite
            // 
            this.labelSatellite.Location = new System.Drawing.Point(26, 196);
            this.labelSatellite.Name = "labelSatellite";
            this.labelSatellite.Size = new System.Drawing.Size(189, 45);
            this.labelSatellite.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSpeed
            // 
            this.labelSpeed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelSpeed.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSpeed.Location = new System.Drawing.Point(10, 147);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(83, 20);
            this.labelSpeed.Text = "Speed:";
            this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tboxSpeed
            // 
            this.tboxSpeed.Location = new System.Drawing.Point(99, 146);
            this.tboxSpeed.Name = "tboxSpeed";
            this.tboxSpeed.Size = new System.Drawing.Size(123, 21);
            this.tboxSpeed.TabIndex = 11;
            // 
            // GpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.tboxSpeed);
            this.Controls.Add(this.labelSatellite);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelLongitude);
            this.Controls.Add(this.labelLatitude);
            this.Controls.Add(this.tboxLongitude);
            this.Controls.Add(this.tboxLatitude);
            this.Name = "GpsForm";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelLongitude;
        private System.Windows.Forms.Label labelLatitude;
        private System.Windows.Forms.TextBox tboxLongitude;
        private System.Windows.Forms.TextBox tboxLatitude;
        private System.Windows.Forms.Label labelSatellite;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.TextBox tboxSpeed;
    }
}