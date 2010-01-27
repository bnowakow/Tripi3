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
            this.bttnMap = new System.Windows.Forms.Button();
            this.bttnWeather = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.gpsTimer = new System.Windows.Forms.Timer();
            this.bttnGps = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttnMap
            // 
            this.bttnMap.Location = new System.Drawing.Point(59, 128);
            this.bttnMap.Name = "bttnMap";
            this.bttnMap.Size = new System.Drawing.Size(130, 20);
            this.bttnMap.TabIndex = 1;
            this.bttnMap.Text = "View Map";
            // 
            // bttnWeather
            // 
            this.bttnWeather.Location = new System.Drawing.Point(58, 76);
            this.bttnWeather.Name = "bttnWeather";
            this.bttnWeather.Size = new System.Drawing.Size(131, 20);
            this.bttnWeather.TabIndex = 2;
            this.bttnWeather.Text = "Check Weather";
            this.bttnWeather.Click += new System.EventHandler(this.WeatherButtonClick);
            // 
            // bttnGps
            // 
            this.bttnGps.Location = new System.Drawing.Point(58, 102);
            this.bttnGps.Name = "bttnGps";
            this.bttnGps.Size = new System.Drawing.Size(131, 20);
            this.bttnGps.TabIndex = 11;
            this.bttnGps.Text = "Get GPS Positions ";
            this.bttnGps.Click += new System.EventHandler(this.GpsButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.bttnGps);
            this.Controls.Add(this.bttnWeather);
            this.Controls.Add(this.bttnMap);
            this.Name = "MainForm";
            this.Text = "Tripi";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnMap;
        private System.Windows.Forms.Button bttnWeather;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer gpsTimer;
        private System.Windows.Forms.Button bttnGps;

    }
}

