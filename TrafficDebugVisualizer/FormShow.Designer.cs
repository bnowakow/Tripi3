namespace TrafficDebugVisualizer
{
    partial class FormShow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxPiniatas = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pointGetterRaw = new TrafficDebugVisualizer.PointGetter();
            this.pointGetterEstimated = new TrafficDebugVisualizer.PointGetter();
            this.pointGetterWCF = new TrafficDebugVisualizer.PointGetter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxPiniatas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(997, 671);
            this.splitContainer1.SplitterDistance = 542;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxPiniatas
            // 
            this.groupBoxPiniatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPiniatas.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPiniatas.Name = "groupBoxPiniatas";
            this.groupBoxPiniatas.Size = new System.Drawing.Size(542, 671);
            this.groupBoxPiniatas.TabIndex = 0;
            this.groupBoxPiniatas.TabStop = false;
            this.groupBoxPiniatas.Text = "Piniatas";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pointGetterWCF);
            this.splitContainer3.Size = new System.Drawing.Size(451, 671);
            this.splitContainer3.SplitterDistance = 448;
            this.splitContainer3.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pointGetterRaw);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pointGetterEstimated);
            this.splitContainer2.Size = new System.Drawing.Size(451, 448);
            this.splitContainer2.SplitterDistance = 274;
            this.splitContainer2.TabIndex = 0;
            // 
            // pointGetterRaw
            // 
            this.pointGetterRaw.Command = "";
            this.pointGetterRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointGetterRaw.GroupBoxTitle = "groupBox1";
            this.pointGetterRaw.Location = new System.Drawing.Point(0, 0);
            this.pointGetterRaw.Name = "pointGetterRaw";
            this.pointGetterRaw.Size = new System.Drawing.Size(451, 274);
            this.pointGetterRaw.TabIndex = 0;
            // 
            // pointGetterEstimated
            // 
            this.pointGetterEstimated.Command = "";
            this.pointGetterEstimated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointGetterEstimated.GroupBoxTitle = "groupBox1";
            this.pointGetterEstimated.Location = new System.Drawing.Point(0, 0);
            this.pointGetterEstimated.Name = "pointGetterEstimated";
            this.pointGetterEstimated.Size = new System.Drawing.Size(451, 170);
            this.pointGetterEstimated.TabIndex = 0;
            // 
            // pointGetterWCF
            // 
            this.pointGetterWCF.Command = "http://127.0.0.1:1337/Eiskonfekt.svc 54.36 18.50 13:37";
            this.pointGetterWCF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointGetterWCF.GroupBoxTitle = "groupBoxWCF";
            this.pointGetterWCF.Location = new System.Drawing.Point(0, 0);
            this.pointGetterWCF.Name = "pointGetterWCF";
            this.pointGetterWCF.Size = new System.Drawing.Size(451, 219);
            this.pointGetterWCF.TabIndex = 0;
            // 
            // FormShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 671);
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(730, 50);
            this.Name = "FormShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Debug preview";
            this.Load += new System.EventHandler(this.FormShow_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxPiniatas;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private PointGetter pointGetterRaw;
        private PointGetter pointGetterEstimated;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private PointGetter pointGetterWCF;
    }
}

