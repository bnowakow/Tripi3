namespace Tripi
{
    partial class ContinueTripForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContinueTripForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.bttnOk = new System.Windows.Forms.Button();
            this.lBoxTrips = new System.Windows.Forms.ListBox();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTitle.Location = new System.Drawing.Point(24, 45);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 20);
            this.labelTitle.Text = "Continue Trip";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bttnOk
            // 
            this.bttnOk.Location = new System.Drawing.Point(72, 224);
            this.bttnOk.Name = "bttnOk";
            this.bttnOk.Size = new System.Drawing.Size(85, 24);
            this.bttnOk.TabIndex = 21;
            this.bttnOk.Text = "OK";
            this.bttnOk.Click += new System.EventHandler(this.OKClick);
            // 
            // lBoxTrips
            // 
            this.lBoxTrips.Location = new System.Drawing.Point(24, 98);
            this.lBoxTrips.Name = "lBoxTrips";
            this.lBoxTrips.Size = new System.Drawing.Size(189, 114);
            this.lBoxTrips.TabIndex = 23;
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelName.Location = new System.Drawing.Point(24, 76);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(98, 20);
            this.labelName.Text = "Choose Trip:";
            // 
            // ContinueTripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.lBoxTrips);
            this.Controls.Add(this.bttnOk);
            this.Controls.Add(this.labelTitle);
            this.Name = "ContinueTripForm";
            this.Text = "Tripi";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button bttnOk;
        private System.Windows.Forms.ListBox lBoxTrips;
        private System.Windows.Forms.Label labelName;
    }
}