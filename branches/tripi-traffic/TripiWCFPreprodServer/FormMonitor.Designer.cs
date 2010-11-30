namespace TripiWCF.PreprodServer
{
    partial class FormMonitor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNodes = new System.Windows.Forms.Label();
            this.labelTrips = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxLawg = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNodes);
            this.groupBox1.Controls.Add(this.labelTrips);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statystyki bazy danych";
            // 
            // labelNodes
            // 
            this.labelNodes.AutoSize = true;
            this.labelNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.labelNodes.Location = new System.Drawing.Point(12, 62);
            this.labelNodes.Name = "labelNodes";
            this.labelNodes.Size = new System.Drawing.Size(66, 20);
            this.labelNodes.TabIndex = 3;
            this.labelNodes.Text = "NODES";
            this.labelNodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTrips
            // 
            this.labelTrips.AutoSize = true;
            this.labelTrips.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.labelTrips.Location = new System.Drawing.Point(12, 25);
            this.labelTrips.Name = "labelTrips";
            this.labelTrips.Size = new System.Drawing.Size(56, 20);
            this.labelTrips.TabIndex = 2;
            this.labelTrips.Text = "TRIPS";
            this.labelTrips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxLawg);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 466);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zdarzenia";
            // 
            // textBoxLawg
            // 
            this.textBoxLawg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLawg.Location = new System.Drawing.Point(3, 16);
            this.textBoxLawg.Multiline = true;
            this.textBoxLawg.Name = "textBoxLawg";
            this.textBoxLawg.Size = new System.Drawing.Size(286, 447);
            this.textBoxLawg.TabIndex = 0;
            // 
            // FormMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 566);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(50, 50);
            this.Name = "FormMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Podgląd serwz0ra";
            this.Load += new System.EventHandler(this.FormMonitor_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMonitor_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelNodes;
        private System.Windows.Forms.Label labelTrips;
        private System.Windows.Forms.TextBox textBoxLawg;
    }
}

