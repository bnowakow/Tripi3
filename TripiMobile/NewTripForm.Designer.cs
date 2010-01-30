namespace Tripi
{
    partial class NewTripForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTripForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.tBoxName = new System.Windows.Forms.TextBox();
            this.bttnOk = new System.Windows.Forms.Button();
            this.inputPanel = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTitle.Location = new System.Drawing.Point(24, 72);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 20);
            this.labelTitle.Text = "New Trip";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelName.Location = new System.Drawing.Point(11, 105);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.Text = "Name:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBoxName
            // 
            this.tBoxName.Location = new System.Drawing.Point(72, 105);
            this.tBoxName.Name = "tBoxName";
            this.tBoxName.Size = new System.Drawing.Size(153, 21);
            this.tBoxName.TabIndex = 20;
            // 
            // bttnOk
            // 
            this.bttnOk.Location = new System.Drawing.Point(72, 151);
            this.bttnOk.Name = "bttnOk";
            this.bttnOk.Size = new System.Drawing.Size(85, 24);
            this.bttnOk.TabIndex = 21;
            this.bttnOk.Text = "OK";
            this.bttnOk.Click += new System.EventHandler(this.OKClick);
            // 
            // NewTripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.bttnOk);
            this.Controls.Add(this.tBoxName);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelName);
            this.Name = "NewTripForm";
            this.Text = "Tripi";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tBoxName;
        private System.Windows.Forms.Button bttnOk;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel;
    }
}