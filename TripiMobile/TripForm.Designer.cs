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
            this.tboxName = new System.Windows.Forms.TextBox();
            this.bttnStop = new System.Windows.Forms.Button();
            this.bttnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTitle.Location = new System.Drawing.Point(26, 52);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 20);
            this.labelTitle.Text = "New Trip";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelName.Location = new System.Drawing.Point(3, 86);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.Text = "Name:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tboxName
            // 
            this.tboxName.Location = new System.Drawing.Point(64, 85);
            this.tboxName.Name = "tboxName";
            this.tboxName.Size = new System.Drawing.Size(151, 21);
            this.tboxName.TabIndex = 7;
            this.tboxName.Text = "Wycieczka krajoznawcza";
            // 
            // bttnStop
            // 
            this.bttnStop.Location = new System.Drawing.Point(64, 166);
            this.bttnStop.Name = "bttnStop";
            this.bttnStop.Size = new System.Drawing.Size(112, 20);
            this.bttnStop.TabIndex = 17;
            this.bttnStop.Text = "Stop";
            this.bttnStop.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // bttnStart
            // 
            this.bttnStart.Location = new System.Drawing.Point(37, 140);
            this.bttnStart.Name = "bttnStart";
            this.bttnStart.Size = new System.Drawing.Size(112, 20);
            this.bttnStart.TabIndex = 16;
            this.bttnStart.Text = "Start";
            this.bttnStart.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // TripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.bttnStop);
            this.Controls.Add(this.bttnStart);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.tboxName);
            this.Name = "TripForm";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tboxName;
        private System.Windows.Forms.Button bttnStop;
        private System.Windows.Forms.Button bttnStart;
    }
}