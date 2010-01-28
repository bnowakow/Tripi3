namespace TripiWCF.ClientMockup
{
    partial class FormCRUD
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonCreateTrip = new System.Windows.Forms.Button();
            this.buttonGetTrips = new System.Windows.Forms.Button();
            this.buttonGetNodes = new System.Windows.Forms.Button();
            this.buttonCreateRandomNode = new System.Windows.Forms.Button();
            this.buttonCreateAsProphesized = new System.Windows.Forms.Button();
            this.propertyGridTrip = new System.Windows.Forms.PropertyGrid();
            this.propertyGridPosition = new System.Windows.Forms.PropertyGrid();
            this.listBoxTrips = new System.Windows.Forms.ListBox();
            this.listBoxPositions = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCreateAsProphesized);
            this.groupBox1.Controls.Add(this.buttonCreateRandomNode);
            this.groupBox1.Controls.Add(this.buttonGetNodes);
            this.groupBox1.Controls.Add(this.buttonGetTrips);
            this.groupBox1.Controls.Add(this.buttonCreateTrip);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opcje";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 100);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(492, 466);
            this.splitContainer1.SplitterDistance = 164;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxTrips);
            this.groupBox2.Controls.Add(this.propertyGridTrip);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 466);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wycieczki";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxPositions);
            this.groupBox3.Controls.Add(this.propertyGridPosition);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 466);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pozycje";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 19);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(101, 34);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Połącz";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonCreateTrip
            // 
            this.buttonCreateTrip.Enabled = false;
            this.buttonCreateTrip.Location = new System.Drawing.Point(12, 59);
            this.buttonCreateTrip.Name = "buttonCreateTrip";
            this.buttonCreateTrip.Size = new System.Drawing.Size(101, 34);
            this.buttonCreateTrip.TabIndex = 1;
            this.buttonCreateTrip.Text = "Utwórz wycieczkę";
            this.buttonCreateTrip.UseVisualStyleBackColor = true;
            this.buttonCreateTrip.Click += new System.EventHandler(this.buttonCreateTrip_Click);
            // 
            // buttonGetTrips
            // 
            this.buttonGetTrips.Enabled = false;
            this.buttonGetTrips.Location = new System.Drawing.Point(119, 19);
            this.buttonGetTrips.Name = "buttonGetTrips";
            this.buttonGetTrips.Size = new System.Drawing.Size(152, 34);
            this.buttonGetTrips.TabIndex = 2;
            this.buttonGetTrips.Text = "Odczytaj wycieczki usera";
            this.buttonGetTrips.UseVisualStyleBackColor = true;
            this.buttonGetTrips.Click += new System.EventHandler(this.buttonGetTrips_Click);
            // 
            // buttonGetNodes
            // 
            this.buttonGetNodes.Enabled = false;
            this.buttonGetNodes.Location = new System.Drawing.Point(119, 59);
            this.buttonGetNodes.Name = "buttonGetNodes";
            this.buttonGetNodes.Size = new System.Drawing.Size(152, 34);
            this.buttonGetNodes.TabIndex = 3;
            this.buttonGetNodes.Text = "Odczytaj punkty dla ID";
            this.buttonGetNodes.UseVisualStyleBackColor = true;
            this.buttonGetNodes.Click += new System.EventHandler(this.buttonGetNodes_Click);
            // 
            // buttonCreateRandomNode
            // 
            this.buttonCreateRandomNode.Enabled = false;
            this.buttonCreateRandomNode.Location = new System.Drawing.Point(277, 19);
            this.buttonCreateRandomNode.Name = "buttonCreateRandomNode";
            this.buttonCreateRandomNode.Size = new System.Drawing.Size(203, 34);
            this.buttonCreateRandomNode.TabIndex = 4;
            this.buttonCreateRandomNode.Text = "Dodaj losowy punkt do ID";
            this.buttonCreateRandomNode.UseVisualStyleBackColor = true;
            this.buttonCreateRandomNode.Click += new System.EventHandler(this.buttonCreateRandomNode_Click);
            // 
            // buttonCreateAsProphesized
            // 
            this.buttonCreateAsProphesized.Enabled = false;
            this.buttonCreateAsProphesized.Location = new System.Drawing.Point(277, 60);
            this.buttonCreateAsProphesized.Name = "buttonCreateAsProphesized";
            this.buttonCreateAsProphesized.Size = new System.Drawing.Size(203, 34);
            this.buttonCreateAsProphesized.TabIndex = 5;
            this.buttonCreateAsProphesized.Text = "Dodaj punkt według zedytowanego";
            this.buttonCreateAsProphesized.UseVisualStyleBackColor = true;
            this.buttonCreateAsProphesized.Click += new System.EventHandler(this.buttonCreateAsProphesized_Click);
            // 
            // propertyGridTrip
            // 
            this.propertyGridTrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridTrip.Location = new System.Drawing.Point(3, 16);
            this.propertyGridTrip.Name = "propertyGridTrip";
            this.propertyGridTrip.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridTrip.Size = new System.Drawing.Size(158, 158);
            this.propertyGridTrip.TabIndex = 0;
            this.propertyGridTrip.ToolbarVisible = false;
            // 
            // propertyGridPosition
            // 
            this.propertyGridPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridPosition.Location = new System.Drawing.Point(3, 16);
            this.propertyGridPosition.Name = "propertyGridPosition";
            this.propertyGridPosition.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridPosition.Size = new System.Drawing.Size(318, 158);
            this.propertyGridPosition.TabIndex = 0;
            this.propertyGridPosition.ToolbarVisible = false;
            // 
            // listBoxTrips
            // 
            this.listBoxTrips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTrips.FormattingEnabled = true;
            this.listBoxTrips.Location = new System.Drawing.Point(3, 174);
            this.listBoxTrips.Name = "listBoxTrips";
            this.listBoxTrips.Size = new System.Drawing.Size(158, 277);
            this.listBoxTrips.TabIndex = 1;
            this.listBoxTrips.SelectedIndexChanged += new System.EventHandler(this.listBoxTrips_SelectedIndexChanged);
            // 
            // listBoxPositions
            // 
            this.listBoxPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPositions.FormattingEnabled = true;
            this.listBoxPositions.Location = new System.Drawing.Point(3, 174);
            this.listBoxPositions.Name = "listBoxPositions";
            this.listBoxPositions.Size = new System.Drawing.Size(318, 277);
            this.listBoxPositions.TabIndex = 1;
            this.listBoxPositions.SelectedIndexChanged += new System.EventHandler(this.listBoxPositions_SelectedIndexChanged);
            // 
            // FormCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 566);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(350, 50);
            this.Name = "FormCRUD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dostęp do TripiWCF.Service";
            this.Load += new System.EventHandler(this.FormCRUD_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonGetNodes;
        private System.Windows.Forms.Button buttonGetTrips;
        private System.Windows.Forms.Button buttonCreateTrip;
        private System.Windows.Forms.Button buttonCreateRandomNode;
        private System.Windows.Forms.Button buttonCreateAsProphesized;
        private System.Windows.Forms.PropertyGrid propertyGridTrip;
        private System.Windows.Forms.PropertyGrid propertyGridPosition;
        private System.Windows.Forms.ListBox listBoxTrips;
        private System.Windows.Forms.ListBox listBoxPositions;
    }
}

