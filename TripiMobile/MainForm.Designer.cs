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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.exitButton = new System.Windows.Forms.MenuItem();
            this.mapButton = new System.Windows.Forms.Button();
            this.weatherButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.exitButton);
            // 
            // exitButton
            // 
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.ExitApplication);
            // 
            // mapButton
            // 
            this.mapButton.Location = new System.Drawing.Point(65, 101);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(111, 20);
            this.mapButton.TabIndex = 1;
            this.mapButton.Text = "View Map";
            this.mapButton.Click += new System.EventHandler(this.MapButtonClick);
            // 
            // weatherButton
            // 
            this.weatherButton.Location = new System.Drawing.Point(64, 75);
            this.weatherButton.Name = "weatherButton";
            this.weatherButton.Size = new System.Drawing.Size(112, 20);
            this.weatherButton.TabIndex = 2;
            this.weatherButton.Text = "Check Weather";
            this.weatherButton.Click += new System.EventHandler(this.WeatherButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.weatherButton);
            this.Controls.Add(this.mapButton);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Tripi";
            this.Load += new System.EventHandler(this.onFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem exitButton;
        private System.Windows.Forms.Button mapButton;
        private System.Windows.Forms.Button weatherButton;

    }
}

