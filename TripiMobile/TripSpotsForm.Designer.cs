namespace Tripi
{
    partial class TripSpotsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TripSpotsForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.lBoxTrips = new System.Windows.Forms.ListBox();
            this.labelTrip = new System.Windows.Forms.Label();
            this.labelSpot = new System.Windows.Forms.Label();
            this.lBoxSpots = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTitle.Location = new System.Drawing.Point(24, 37);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 20);
            this.labelTitle.Text = "Trip Spots";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lBoxTrips
            // 
            this.lBoxTrips.Location = new System.Drawing.Point(24, 80);
            this.lBoxTrips.Name = "lBoxTrips";
            this.lBoxTrips.Size = new System.Drawing.Size(189, 58);
            this.lBoxTrips.TabIndex = 23;
            this.lBoxTrips.SelectedIndexChanged += new System.EventHandler(this.OnTripChanged);
            // 
            // labelTrip
            // 
            this.labelTrip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTrip.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelTrip.Location = new System.Drawing.Point(24, 57);
            this.labelTrip.Name = "labelTrip";
            this.labelTrip.Size = new System.Drawing.Size(98, 20);
            this.labelTrip.Text = "Trip";
            // 
            // labelSpot
            // 
            this.labelSpot.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelSpot.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSpot.Location = new System.Drawing.Point(24, 155);
            this.labelSpot.Name = "labelSpot";
            this.labelSpot.Size = new System.Drawing.Size(98, 20);
            this.labelSpot.Text = "Spots";
            // 
            // lBoxSpots
            // 
            this.lBoxSpots.Location = new System.Drawing.Point(24, 174);
            this.lBoxSpots.Name = "lBoxSpots";
            this.lBoxSpots.Size = new System.Drawing.Size(189, 86);
            this.lBoxSpots.TabIndex = 27;
            // 
            // TripSpotsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.lBoxSpots);
            this.Controls.Add(this.labelSpot);
            this.Controls.Add(this.labelTrip);
            this.Controls.Add(this.lBoxTrips);
            this.Controls.Add(this.labelTitle);
            this.Name = "TripSpotsForm";
            this.Text = "Tripi";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListBox lBoxTrips;
        private System.Windows.Forms.Label labelTrip;
        private System.Windows.Forms.Label labelSpot;
        private System.Windows.Forms.ListBox lBoxSpots;
    }
}