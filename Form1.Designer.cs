
namespace Maximum_flow
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_navigate = new System.Windows.Forms.RadioButton();
            this.radio_edge = new System.Windows.Forms.RadioButton();
            this.radio_end_node = new System.Windows.Forms.RadioButton();
            this.radio_node = new System.Windows.Forms.RadioButton();
            this.radio_start_node = new System.Windows.Forms.RadioButton();
            this.edit_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.txb_flowrate = new System.Windows.Forms.TextBox();
            this.txb_flow_in = new System.Windows.Forms.TextBox();
            this.txb_flow_out = new System.Windows.Forms.TextBox();
            this.txb_edge_name = new System.Windows.Forms.TextBox();
            this.lbl_edge_name = new System.Windows.Forms.Label();
            this.lbl_flowrate = new System.Windows.Forms.Label();
            this.lbl_flow_in = new System.Windows.Forms.Label();
            this.lbl_flow_out = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.sim_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_navigate);
            this.groupBox1.Controls.Add(this.radio_edge);
            this.groupBox1.Controls.Add(this.radio_end_node);
            this.groupBox1.Controls.Add(this.radio_node);
            this.groupBox1.Controls.Add(this.radio_start_node);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add:";
            // 
            // radio_navigate
            // 
            this.radio_navigate.AutoSize = true;
            this.radio_navigate.Checked = true;
            this.radio_navigate.Location = new System.Drawing.Point(6, 19);
            this.radio_navigate.Name = "radio_navigate";
            this.radio_navigate.Size = new System.Drawing.Size(68, 17);
            this.radio_navigate.TabIndex = 4;
            this.radio_navigate.TabStop = true;
            this.radio_navigate.Text = "Navigate";
            this.radio_navigate.UseVisualStyleBackColor = true;
            // 
            // radio_edge
            // 
            this.radio_edge.AutoSize = true;
            this.radio_edge.Location = new System.Drawing.Point(6, 111);
            this.radio_edge.Name = "radio_edge";
            this.radio_edge.Size = new System.Drawing.Size(50, 17);
            this.radio_edge.TabIndex = 3;
            this.radio_edge.Text = "Edge";
            this.radio_edge.UseVisualStyleBackColor = true;
            // 
            // radio_end_node
            // 
            this.radio_end_node.AutoSize = true;
            this.radio_end_node.Location = new System.Drawing.Point(6, 88);
            this.radio_end_node.Name = "radio_end_node";
            this.radio_end_node.Size = new System.Drawing.Size(73, 17);
            this.radio_end_node.TabIndex = 2;
            this.radio_end_node.Text = "End Node";
            this.radio_end_node.UseVisualStyleBackColor = true;
            // 
            // radio_node
            // 
            this.radio_node.AutoSize = true;
            this.radio_node.Location = new System.Drawing.Point(6, 65);
            this.radio_node.Name = "radio_node";
            this.radio_node.Size = new System.Drawing.Size(51, 17);
            this.radio_node.TabIndex = 1;
            this.radio_node.Text = "Node";
            this.radio_node.UseVisualStyleBackColor = true;
            // 
            // radio_start_node
            // 
            this.radio_start_node.AutoSize = true;
            this.radio_start_node.Location = new System.Drawing.Point(6, 42);
            this.radio_start_node.Name = "radio_start_node";
            this.radio_start_node.Size = new System.Drawing.Size(76, 17);
            this.radio_start_node.TabIndex = 0;
            this.radio_start_node.Text = "Start Node";
            this.radio_start_node.UseVisualStyleBackColor = true;
            // 
            // edit_button
            // 
            this.edit_button.Location = new System.Drawing.Point(926, 824);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(75, 23);
            this.edit_button.TabIndex = 2;
            this.edit_button.Text = "Edit";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Visible = false;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(845, 824);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 3;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Visible = false;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 679);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1068, 140);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // txb_flowrate
            // 
            this.txb_flowrate.Location = new System.Drawing.Point(1172, 705);
            this.txb_flowrate.Name = "txb_flowrate";
            this.txb_flowrate.Size = new System.Drawing.Size(100, 20);
            this.txb_flowrate.TabIndex = 7;
            this.txb_flowrate.Visible = false;
            this.txb_flowrate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_flowrate_KeyDown);
            // 
            // txb_flow_in
            // 
            this.txb_flow_in.Location = new System.Drawing.Point(1172, 731);
            this.txb_flow_in.Name = "txb_flow_in";
            this.txb_flow_in.Size = new System.Drawing.Size(100, 20);
            this.txb_flow_in.TabIndex = 8;
            this.txb_flow_in.Visible = false;
            this.txb_flow_in.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_flow_in_KeyDown);
            // 
            // txb_flow_out
            // 
            this.txb_flow_out.Location = new System.Drawing.Point(1172, 757);
            this.txb_flow_out.Name = "txb_flow_out";
            this.txb_flow_out.Size = new System.Drawing.Size(100, 20);
            this.txb_flow_out.TabIndex = 9;
            this.txb_flow_out.Visible = false;
            this.txb_flow_out.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_flow_out_KeyDown);
            // 
            // txb_edge_name
            // 
            this.txb_edge_name.Location = new System.Drawing.Point(1172, 679);
            this.txb_edge_name.Name = "txb_edge_name";
            this.txb_edge_name.Size = new System.Drawing.Size(100, 20);
            this.txb_edge_name.TabIndex = 10;
            this.txb_edge_name.Visible = false;
            this.txb_edge_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_edge_name_KeyDown);
            // 
            // lbl_edge_name
            // 
            this.lbl_edge_name.AutoSize = true;
            this.lbl_edge_name.Location = new System.Drawing.Point(1086, 682);
            this.lbl_edge_name.Name = "lbl_edge_name";
            this.lbl_edge_name.Size = new System.Drawing.Size(64, 13);
            this.lbl_edge_name.TabIndex = 11;
            this.lbl_edge_name.Text = "Edge name:";
            this.lbl_edge_name.Visible = false;
            // 
            // lbl_flowrate
            // 
            this.lbl_flowrate.AutoSize = true;
            this.lbl_flowrate.Location = new System.Drawing.Point(1086, 708);
            this.lbl_flowrate.Name = "lbl_flowrate";
            this.lbl_flowrate.Size = new System.Drawing.Size(50, 13);
            this.lbl_flowrate.TabIndex = 12;
            this.lbl_flowrate.Text = "Flowrate:";
            this.lbl_flowrate.Visible = false;
            // 
            // lbl_flow_in
            // 
            this.lbl_flow_in.AutoSize = true;
            this.lbl_flow_in.Location = new System.Drawing.Point(1086, 734);
            this.lbl_flow_in.Name = "lbl_flow_in";
            this.lbl_flow_in.Size = new System.Drawing.Size(43, 13);
            this.lbl_flow_in.TabIndex = 13;
            this.lbl_flow_in.Text = "Flow in:";
            this.lbl_flow_in.Visible = false;
            // 
            // lbl_flow_out
            // 
            this.lbl_flow_out.AutoSize = true;
            this.lbl_flow_out.Location = new System.Drawing.Point(1086, 760);
            this.lbl_flow_out.Name = "lbl_flow_out";
            this.lbl_flow_out.Size = new System.Drawing.Size(50, 13);
            this.lbl_flow_out.TabIndex = 14;
            this.lbl_flow_out.Text = "Flow out:";
            this.lbl_flow_out.Visible = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(117, 32);
            this.trackBar1.Maximum = 15;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(190, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Line thickness:";
            // 
            // sim_button
            // 
            this.sim_button.Location = new System.Drawing.Point(117, 58);
            this.sim_button.Margin = new System.Windows.Forms.Padding(2);
            this.sim_button.Name = "sim_button";
            this.sim_button.Size = new System.Drawing.Size(190, 27);
            this.sim_button.TabIndex = 17;
            this.sim_button.Text = "Simulate";
            this.sim_button.UseVisualStyleBackColor = true;
            this.sim_button.Click += new System.EventHandler(this.sim_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(1005, 824);
            this.clear_button.Margin = new System.Windows.Forms.Padding(2);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(75, 23);
            this.clear_button.TabIndex = 18;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Max Flow Rate = 100\'000\'000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 861);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.sim_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lbl_flow_out);
            this.Controls.Add(this.lbl_flow_in);
            this.Controls.Add(this.lbl_flowrate);
            this.Controls.Add(this.lbl_edge_name);
            this.Controls.Add(this.txb_edge_name);
            this.Controls.Add(this.txb_flow_out);
            this.Controls.Add(this.txb_flow_in);
            this.Controls.Add(this.txb_flowrate);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_edge;
        private System.Windows.Forms.RadioButton radio_end_node;
        private System.Windows.Forms.RadioButton radio_node;
        private System.Windows.Forms.RadioButton radio_start_node;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.RadioButton radio_navigate;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txb_flowrate;
        private System.Windows.Forms.TextBox txb_flow_in;
        private System.Windows.Forms.TextBox txb_flow_out;
        private System.Windows.Forms.TextBox txb_edge_name;
        private System.Windows.Forms.Label lbl_edge_name;
        private System.Windows.Forms.Label lbl_flowrate;
        private System.Windows.Forms.Label lbl_flow_in;
        private System.Windows.Forms.Label lbl_flow_out;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sim_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Label label2;
    }
}

