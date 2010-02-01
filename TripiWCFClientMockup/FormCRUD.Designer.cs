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
            this.buttonUpdateTripDesc = new System.Windows.Forms.Button();
            this.comboBoxEndpoint = new System.Windows.Forms.ComboBox();
            this.buttonCreateAsProphesized = new System.Windows.Forms.Button();
            this.buttonCreateRandomNode = new System.Windows.Forms.Button();
            this.buttonGetNodes = new System.Windows.Forms.Button();
            this.buttonGetTrips = new System.Windows.Forms.Button();
            this.buttonCreateTrip = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxTrips = new System.Windows.Forms.ListBox();
            this.propertyGridTrip = new System.Windows.Forms.PropertyGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxPositions = new System.Windows.Forms.ListBox();
            this.propertyGridPosition = new System.Windows.Forms.PropertyGrid();
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
            this.groupBox1.Controls.Add(this.buttonUpdateTripDesc);
            this.groupBox1.Controls.Add(this.comboBoxEndpoint);
            this.groupBox1.Controls.Add(this.buttonCreateRandomNode);
            this.groupBox1.Controls.Add(this.buttonCreateAsProphesized);
            this.groupBox1.Controls.Add(this.buttonGetNodes);
            this.groupBox1.Controls.Add(this.buttonGetTrips);
            this.groupBox1.Controls.Add(this.buttonCreateTrip);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opcje";
            // 
            // buttonUpdateTripDesc
            // 
            this.buttonUpdateTripDesc.BackColor = System.Drawing.Color.Chartreuse;
            this.buttonUpdateTripDesc.Enabled = false;
            this.buttonUpdateTripDesc.Location = new System.Drawing.Point(528, 14);
            this.buttonUpdateTripDesc.Name = "buttonUpdateTripDesc";
            this.buttonUpdateTripDesc.Size = new System.Drawing.Size(152, 34);
            this.buttonUpdateTripDesc.TabIndex = 7;
            this.buttonUpdateTripDesc.Text = "Zmień opis wycieczki";
            this.buttonUpdateTripDesc.UseVisualStyleBackColor = false;
            this.buttonUpdateTripDesc.Click += new System.EventHandler(this.buttonUpdateTripDesc_Click);
            // 
            // comboBoxEndpoint
            // 
            this.comboBoxEndpoint.FormattingEnabled = true;
            this.comboBoxEndpoint.Location = new System.Drawing.Point(12, 22);
            this.comboBoxEndpoint.Name = "comboBoxEndpoint";
            this.comboBoxEndpoint.Size = new System.Drawing.Size(151, 21);
            this.comboBoxEndpoint.TabIndex = 0;
            // 
            // buttonCreateAsProphesized
            // 
            this.buttonCreateAsProphesized.BackColor = System.Drawing.Color.HotPink;
            this.buttonCreateAsProphesized.Enabled = false;
            this.buttonCreateAsProphesized.Location = new System.Drawing.Point(528, 59);
            this.buttonCreateAsProphesized.Name = "buttonCreateAsProphesized";
            this.buttonCreateAsProphesized.Size = new System.Drawing.Size(152, 34);
            this.buttonCreateAsProphesized.TabIndex = 6;
            this.buttonCreateAsProphesized.Text = "Dodaj punkt według zedytowanego";
            this.buttonCreateAsProphesized.UseVisualStyleBackColor = false;
            this.buttonCreateAsProphesized.Click += new System.EventHandler(this.buttonCreateAsProphesized_Click);
            // 
            // buttonCreateRandomNode
            // 
            this.buttonCreateRandomNode.BackColor = System.Drawing.Color.HotPink;
            this.buttonCreateRandomNode.Enabled = false;
            this.buttonCreateRandomNode.Location = new System.Drawing.Point(370, 59);
            this.buttonCreateRandomNode.Name = "buttonCreateRandomNode";
            this.buttonCreateRandomNode.Size = new System.Drawing.Size(152, 34);
            this.buttonCreateRandomNode.TabIndex = 4;
            this.buttonCreateRandomNode.Text = "Dodaj losowy punkt do ID";
            this.buttonCreateRandomNode.UseVisualStyleBackColor = false;
            this.buttonCreateRandomNode.Click += new System.EventHandler(this.buttonCreateRandomNode_Click);
            // 
            // buttonGetNodes
            // 
            this.buttonGetNodes.BackColor = System.Drawing.Color.HotPink;
            this.buttonGetNodes.Enabled = false;
            this.buttonGetNodes.Location = new System.Drawing.Point(212, 59);
            this.buttonGetNodes.Name = "buttonGetNodes";
            this.buttonGetNodes.Size = new System.Drawing.Size(152, 34);
            this.buttonGetNodes.TabIndex = 5;
            this.buttonGetNodes.Text = "Odczytaj punkty dla ID";
            this.buttonGetNodes.UseVisualStyleBackColor = false;
            this.buttonGetNodes.Click += new System.EventHandler(this.buttonGetNodes_Click);
            // 
            // buttonGetTrips
            // 
            this.buttonGetTrips.BackColor = System.Drawing.Color.Chartreuse;
            this.buttonGetTrips.Enabled = false;
            this.buttonGetTrips.Location = new System.Drawing.Point(212, 14);
            this.buttonGetTrips.Name = "buttonGetTrips";
            this.buttonGetTrips.Size = new System.Drawing.Size(152, 34);
            this.buttonGetTrips.TabIndex = 3;
            this.buttonGetTrips.Text = "Odczytaj wycieczki usera";
            this.buttonGetTrips.UseVisualStyleBackColor = false;
            this.buttonGetTrips.Click += new System.EventHandler(this.buttonGetTrips_Click);
            // 
            // buttonCreateTrip
            // 
            this.buttonCreateTrip.BackColor = System.Drawing.Color.Chartreuse;
            this.buttonCreateTrip.Enabled = false;
            this.buttonCreateTrip.Location = new System.Drawing.Point(370, 14);
            this.buttonCreateTrip.Name = "buttonCreateTrip";
            this.buttonCreateTrip.Size = new System.Drawing.Size(152, 34);
            this.buttonCreateTrip.TabIndex = 2;
            this.buttonCreateTrip.Text = "Utwórz wycieczkę";
            this.buttonCreateTrip.UseVisualStyleBackColor = false;
            this.buttonCreateTrip.Click += new System.EventHandler(this.buttonCreateTrip_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 59);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(152, 34);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Połącz";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(692, 466);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxTrips);
            this.groupBox2.Controls.Add(this.propertyGridTrip);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 466);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wycieczki";
            // 
            // listBoxTrips
            // 
            this.listBoxTrips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTrips.FormattingEnabled = true;
            this.listBoxTrips.Location = new System.Drawing.Point(3, 211);
            this.listBoxTrips.Name = "listBoxTrips";
            this.listBoxTrips.Size = new System.Drawing.Size(224, 251);
            this.listBoxTrips.TabIndex = 1;
            this.listBoxTrips.SelectedIndexChanged += new System.EventHandler(this.listBoxTrips_SelectedIndexChanged);
            // 
            // propertyGridTrip
            // 
            this.propertyGridTrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridTrip.Location = new System.Drawing.Point(3, 16);
            this.propertyGridTrip.Name = "propertyGridTrip";
            this.propertyGridTrip.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridTrip.Size = new System.Drawing.Size(224, 195);
            this.propertyGridTrip.TabIndex = 0;
            this.propertyGridTrip.ToolbarVisible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxPositions);
            this.groupBox3.Controls.Add(this.propertyGridPosition);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 466);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pozycje";
            // 
            // listBoxPositions
            // 
            this.listBoxPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPositions.FormattingEnabled = true;
            this.listBoxPositions.Location = new System.Drawing.Point(3, 211);
            this.listBoxPositions.Name = "listBoxPositions";
            this.listBoxPositions.Size = new System.Drawing.Size(452, 251);
            this.listBoxPositions.TabIndex = 1;
            this.listBoxPositions.SelectedIndexChanged += new System.EventHandler(this.listBoxPositions_SelectedIndexChanged);
            // 
            // propertyGridPosition
            // 
            this.propertyGridPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridPosition.Location = new System.Drawing.Point(3, 16);
            this.propertyGridPosition.Name = "propertyGridPosition";
            this.propertyGridPosition.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridPosition.Size = new System.Drawing.Size(452, 195);
            this.propertyGridPosition.TabIndex = 0;
            this.propertyGridPosition.ToolbarVisible = false;
            // 
            // FormCRUD
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 566);
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
        private System.Windows.Forms.ComboBox comboBoxEndpoint;
        private System.Windows.Forms.Button buttonUpdateTripDesc;
    }
}

