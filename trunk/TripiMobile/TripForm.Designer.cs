namespace Tripi
{
    partial class TripForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TripForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.bttnStop = new System.Windows.Forms.Button();
            this.bttnStart = new System.Windows.Forms.Button();
            this.labelTripName = new System.Windows.Forms.Label();
            this.nudFrequency = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.bttnAddPoint = new System.Windows.Forms.Button();
            this.picBoxSignal = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTitle.Location = new System.Drawing.Point(26, 52);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 20);
            this.labelTitle.Text = "Trip Logger";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelName.Location = new System.Drawing.Point(16, 85);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(52, 20);
            this.labelName.Text = "Name:";
            // 
            // bttnStop
            // 
            this.bttnStop.Enabled = false;
            this.bttnStop.Location = new System.Drawing.Point(133, 159);
            this.bttnStop.Name = "bttnStop";
            this.bttnStop.Size = new System.Drawing.Size(82, 43);
            this.bttnStop.TabIndex = 17;
            this.bttnStop.Text = "Stop";
            this.bttnStop.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // bttnStart
            // 
            this.bttnStart.Location = new System.Drawing.Point(26, 159);
            this.bttnStart.Name = "bttnStart";
            this.bttnStart.Size = new System.Drawing.Size(82, 43);
            this.bttnStart.TabIndex = 16;
            this.bttnStart.Text = "Start";
            this.bttnStart.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // labelTripName
            // 
            this.labelTripName.Location = new System.Drawing.Point(62, 85);
            this.labelTripName.Name = "labelTripName";
            this.labelTripName.Size = new System.Drawing.Size(153, 20);
            this.labelTripName.Text = "tripName";
            // 
            // nudFrequency
            // 
            this.nudFrequency.Location = new System.Drawing.Point(137, 105);
            this.nudFrequency.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrequency.Name = "nudFrequency";
            this.nudFrequency.Size = new System.Drawing.Size(68, 22);
            this.nudFrequency.TabIndex = 20;
            this.nudFrequency.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(16, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 22);
            this.label1.Text = "Send Frequency:";
            // 
            // bttnAddPoint
            // 
            this.bttnAddPoint.Location = new System.Drawing.Point(39, 224);
            this.bttnAddPoint.Name = "bttnAddPoint";
            this.bttnAddPoint.Size = new System.Drawing.Size(152, 32);
            this.bttnAddPoint.TabIndex = 24;
            this.bttnAddPoint.Text = "Add Interesting Spot";
            this.bttnAddPoint.Visible = false;
            this.bttnAddPoint.Click += new System.EventHandler(this.AddInterestingSpotClick);
            // 
            // picBoxSignal
            // 
            this.picBoxSignal.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSignal.Image")));
            this.picBoxSignal.Location = new System.Drawing.Point(205, 52);
            this.picBoxSignal.Name = "picBoxSignal";
            this.picBoxSignal.Size = new System.Drawing.Size(10, 10);
            this.picBoxSignal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSignal.Visible = false;
            // 
            // TripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.picBoxSignal);
            this.Controls.Add(this.bttnAddPoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudFrequency);
            this.Controls.Add(this.labelTripName);
            this.Controls.Add(this.bttnStop);
            this.Controls.Add(this.bttnStart);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelName);
            this.Name = "TripForm";
            this.Text = "Tripi";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button bttnStop;
        private System.Windows.Forms.Button bttnStart;
        private System.Windows.Forms.Label labelTripName;
        private System.Windows.Forms.NumericUpDown nudFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttnAddPoint;
        private System.Windows.Forms.PictureBox picBoxSignal;
    }
}