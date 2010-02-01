namespace Tripi
{
    partial class PointForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.bttnOk = new System.Windows.Forms.Button();
            this.tBoxDescription = new System.Windows.Forms.TextBox();
            this.inputPanel = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTitle.Location = new System.Drawing.Point(26, 52);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 20);
            this.labelTitle.Text = "Interesting Spot";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelDescription.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelDescription.Location = new System.Drawing.Point(16, 85);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(92, 20);
            this.labelDescription.Text = "Description:";
            // 
            // bttnOk
            // 
            this.bttnOk.Location = new System.Drawing.Point(73, 221);
            this.bttnOk.Name = "bttnOk";
            this.bttnOk.Size = new System.Drawing.Size(82, 24);
            this.bttnOk.TabIndex = 16;
            this.bttnOk.Text = "Save";
            this.bttnOk.Click += new System.EventHandler(this.SaveClick);
            // 
            // tBoxDescription
            // 
            this.tBoxDescription.Location = new System.Drawing.Point(16, 108);
            this.tBoxDescription.Multiline = true;
            this.tBoxDescription.Name = "tBoxDescription";
            this.tBoxDescription.Size = new System.Drawing.Size(209, 97);
            this.tBoxDescription.TabIndex = 30;
            // 
            // PointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tBoxDescription);
            this.Controls.Add(this.bttnOk);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelDescription);
            this.Name = "PointForm";
            this.Text = "Tripi";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button bttnOk;
        private System.Windows.Forms.TextBox tBoxDescription;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel;
    }
}