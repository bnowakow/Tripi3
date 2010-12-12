namespace Tripi
{
    partial class TrafficForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrafficForm));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.gpsTimer = new System.Windows.Forms.Timer();
            this.picBoxSignal = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudFrequency = new System.Windows.Forms.NumericUpDown();
            this.bttnStop = new System.Windows.Forms.Button();
            this.bttnStart = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // picBoxSignal
            // 
            this.picBoxSignal.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSignal.Image")));
            this.picBoxSignal.Location = new System.Drawing.Point(210, 72);
            this.picBoxSignal.Name = "picBoxSignal";
            this.picBoxSignal.Size = new System.Drawing.Size(10, 10);
            this.picBoxSignal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSignal.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(31, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 22);
            this.label1.Text = "Send Frequency:";
            // 
            // nudFrequency
            // 
            this.nudFrequency.Location = new System.Drawing.Point(152, 108);
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
            this.nudFrequency.TabIndex = 28;
            this.nudFrequency.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // bttnStop
            // 
            this.bttnStop.Enabled = false;
            this.bttnStop.Location = new System.Drawing.Point(138, 179);
            this.bttnStop.Name = "bttnStop";
            this.bttnStop.Size = new System.Drawing.Size(82, 43);
            this.bttnStop.TabIndex = 27;
            this.bttnStop.Text = "Stop";
            // 
            // bttnStart
            // 
            this.bttnStart.Location = new System.Drawing.Point(31, 179);
            this.bttnStart.Name = "bttnStart";
            this.bttnStart.Size = new System.Drawing.Size(82, 43);
            this.bttnStart.TabIndex = 26;
            this.bttnStart.Text = "Start";
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTitle.Location = new System.Drawing.Point(31, 72);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 20);
            this.labelTitle.Text = "GPS Logger";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TrafficForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.picBoxSignal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudFrequency);
            this.Controls.Add(this.bttnStop);
            this.Controls.Add(this.bttnStart);
            this.Controls.Add(this.labelTitle);
            this.Name = "TrafficForm";
            this.Text = "Tripi Traffic";
            this.Load += new System.EventHandler(this.FormLoad);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OnClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer gpsTimer;
        private System.Windows.Forms.PictureBox picBoxSignal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudFrequency;
        private System.Windows.Forms.Button bttnStop;
        private System.Windows.Forms.Button bttnStart;
        private System.Windows.Forms.Label labelTitle;

    }
}

