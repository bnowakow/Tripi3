namespace Tripi
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bttnNewTrip = new System.Windows.Forms.Button();
            this.bttnWeather = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.gpsTimer = new System.Windows.Forms.Timer();
            this.bttnGps = new System.Windows.Forms.Button();
            this.bttnContinueTrip = new System.Windows.Forms.Button();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelUserValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bttnNewTrip
            // 
            this.bttnNewTrip.Location = new System.Drawing.Point(55, 104);
            this.bttnNewTrip.Name = "bttnNewTrip";
            this.bttnNewTrip.Size = new System.Drawing.Size(130, 20);
            this.bttnNewTrip.TabIndex = 1;
            this.bttnNewTrip.Text = "Create New Trip";
            this.bttnNewTrip.Click += new System.EventHandler(this.NewTripButtonClick);
            // 
            // bttnWeather
            // 
            this.bttnWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bttnWeather.Location = new System.Drawing.Point(55, 182);
            this.bttnWeather.Name = "bttnWeather";
            this.bttnWeather.Size = new System.Drawing.Size(131, 20);
            this.bttnWeather.TabIndex = 2;
            this.bttnWeather.Text = "Check Weather";
            this.bttnWeather.Click += new System.EventHandler(this.WeatherButtonClick);
            // 
            // bttnGps
            // 
            this.bttnGps.Location = new System.Drawing.Point(55, 156);
            this.bttnGps.Name = "bttnGps";
            this.bttnGps.Size = new System.Drawing.Size(131, 20);
            this.bttnGps.TabIndex = 11;
            this.bttnGps.Text = "View GPS Positions ";
            this.bttnGps.Click += new System.EventHandler(this.GpsButtonClick);
            // 
            // bttnContinueTrip
            // 
            this.bttnContinueTrip.Location = new System.Drawing.Point(55, 130);
            this.bttnContinueTrip.Name = "bttnContinueTrip";
            this.bttnContinueTrip.Size = new System.Drawing.Size(130, 20);
            this.bttnContinueTrip.TabIndex = 12;
            this.bttnContinueTrip.Text = "Continue Trip";
            this.bttnContinueTrip.Click += new System.EventHandler(this.ContinueTripClick);
            // 
            // labelUser
            // 
            this.labelUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelUser.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelUser.Location = new System.Drawing.Point(39, 75);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(50, 20);
            this.labelUser.Text = "User:";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelUserValue
            // 
            this.labelUserValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelUserValue.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelUserValue.Location = new System.Drawing.Point(95, 75);
            this.labelUserValue.Name = "labelUserValue";
            this.labelUserValue.Size = new System.Drawing.Size(101, 20);
            this.labelUserValue.Text = "User";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.labelUserValue);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.bttnContinueTrip);
            this.Controls.Add(this.bttnGps);
            this.Controls.Add(this.bttnWeather);
            this.Controls.Add(this.bttnNewTrip);
            this.Name = "MainForm";
            this.Text = "Tripi";
            this.Load += new System.EventHandler(this.FormLoad);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OnClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnNewTrip;
        private System.Windows.Forms.Button bttnWeather;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer gpsTimer;
        private System.Windows.Forms.Button bttnGps;
        private System.Windows.Forms.Button bttnContinueTrip;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelUserValue;

    }
}

