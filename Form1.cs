using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maximum_flow
{
    public partial class Form1 : Form
    {
        Bitmap bitmap = new Bitmap(2000, 2000);
        List<Button> node_list_button = new List<Button>();
        List<Node> node_list = new List<Node>();
        List<Edge> edge_list = new List<Edge>();
        List<bool> button_clicked = new List<bool>();
        List<bool> line_clicked = new List<bool>();
        int button_number = 0;
        int node_name = 0;
        int edge_name = 0;

        bool mouseDown = false;
        int mouseDownX = 0;
        int mouseDownY = 0;
        Point old_btn_pos = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
        }


        void refresh_listview(bool node, int index)
        {
            listView1.Clear();
            listView1.Columns.Add("Edge Name:", listView1.Width / 5);
            listView1.Columns.Add("Flowrate:", listView1.Width / 5);
            listView1.Columns.Add("Flow In:", listView1.Width / 5);
            listView1.Columns.Add("Flow Out:", listView1.Width / 5);
            listView1.Columns.Add("Current Flow:", listView1.Width / 5);

            if (node)
            {
                foreach (Edge flow_in in node_list[index].Flow_In_List())
                {
                    string[] row = { flow_in.Name, Convert.ToString(flow_in.Flowrate), flow_in.Flow_In_Node.Name, flow_in.Flow_Out_Node.Name, Convert.ToString(flow_in.Current_Flowrate) };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                foreach (Edge flow_out in node_list[index].Flow_Out_List())
                {
                    string[] row = { flow_out.Name, Convert.ToString(flow_out.Flowrate), flow_out.Flow_In_Node.Name, flow_out.Flow_Out_Node.Name, Convert.ToString(flow_out.Current_Flowrate) };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                this.ActiveControl = null;
            }
            else if (line_clicked.Count(s => s == true) == 1)
            {
                string[] row = { edge_list[index].Name, Convert.ToString(edge_list[index].Flowrate), edge_list[index].Flow_In_Node.Name, edge_list[index].Flow_Out_Node.Name, Convert.ToString(edge_list[index].Current_Flowrate) };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
        }

        void refresh_edges()
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(SystemColors.ButtonFace);
            float max_flowrate = 0;

            foreach (Edge flowrate in edge_list)
            {
                if (flowrate.Flowrate > max_flowrate)
                {
                    max_flowrate = flowrate.Flowrate;
                }
            }

            foreach (Edge flowrate in edge_list)
            {
                int index1 = node_list.IndexOf(flowrate.Flow_Out_Node);
                int index2 = node_list.IndexOf(flowrate.Flow_In_Node);
                Point start = Line_Start_Point(index1);
                Point end = Line_End_Point(index1, index2);
                Pen p = new Pen(Color.Gray, 5);
                if (flowrate.Color_True)
                {
                    float x = flowrate.Current_Flowrate / flowrate.Flowrate;
                    p = new Pen(Color.FromArgb(255, Convert.ToInt32(255 * x), Convert.ToInt32(255 * (1 - x)), 0));
                }
                else
                {
                    p = new Pen(Color.Gray, 5);
                }
                Pen highlight = new Pen(Color.Black, trackBar1.Value);

                if (trackBar1.Value == 0)
                {
                    p.Width = 5;
                }
                else
                {
                    p.Width = trackBar1.Value * (1 / max_flowrate * flowrate.Flowrate);
                }
                if (line_clicked[edge_list.IndexOf(flowrate)])
                {
                    p.Color = Color.Black;
                }

                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                highlight.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                g.DrawLine(p, start, end);
            }
            this.Invalidate();
        }

        private Point Line_Start_Point(int index)
        {
            return new Point(node_list_button[index].Location.X + 15, node_list_button[index].Location.Y + 15);
        }

        private Point Line_End_Point(int index1, int index2)
        {
            Point end = new Point(0, 0);

            if (node_list_button[index1].Location.X < node_list_button[index2].Location.X)
            {
                end.X = node_list_button[index2].Location.X;
            }
            else if (node_list_button[index1].Location.X == node_list_button[index2].Location.X)
            {
                end.X = node_list_button[index2].Location.X + 15;
            }
            else if (node_list_button[index1].Location.X > node_list_button[index2].Location.X)
            {
                end.X = node_list_button[index2].Location.X + 30;
            }
            if (node_list_button[index1].Location.Y < node_list_button[index2].Location.Y)
            {
                end.Y = node_list_button[index2].Location.Y;
            }
            else if (node_list_button[index1].Location.Y == node_list_button[index2].Location.Y)
            {
                end.Y = node_list_button[index2].Location.Y + 15;
            }
            else if (node_list_button[index1].Location.Y > node_list_button[index2].Location.Y)
            {
                end.Y = node_list_button[index2].Location.Y + 30;
            }

            return end;
        }

        private void btn_Enter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 4;
        }

        private void btn_Leave(object sender, EventArgs e)
        {
            if (!button_clicked.Contains(true))
            {
                Button btn = sender as Button;
                btn.FlatAppearance.BorderSize = 1;
            }
            else
            {
                for (int i = 0; i < node_list_button.Count; i++)
                {
                    if (!button_clicked[i])
                    {
                        node_list_button[i].FlatAppearance.BorderSize = 1;
                    }
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index2 = node_list_button.IndexOf(btn);

            if (radio_edge.Checked)
            {
                int count = button_clicked.Count(s => s == true);
                if (count == 1)
                {
                    int index1 = button_clicked.IndexOf(true);
                    if (node_list[index2].Is_Start() || node_list[index1].Is_End())
                    {
                        button_clicked[index1] = false;
                        button_clicked[index2] = false;
                        node_list_button[index1].FlatAppearance.BorderSize = 1;
                        node_list_button[index2].FlatAppearance.BorderSize = 1;
                        this.ActiveControl = null;
                        return;
                    }
                    if (index1 == index2)
                    {
                        for (int i = 0; i < button_clicked.Count; i++)
                        {
                            button_clicked[i] = false;
                            node_list_button[i].FlatAppearance.BorderSize = 1;
                        }
                        this.ActiveControl = null;
                        listView1.Clear();
                        return;
                    }
                    edge_list.Add(new Edge("edge_" + Convert.ToString(edge_name), 10, node_list[index1], node_list[index2], Line_Start_Point(index1), Line_End_Point(index1, index2)));
                    line_clicked.Add(false);
                    edge_name++;
                    refresh_edges();
                    for (int i = 0; i < button_clicked.Count; i++)
                    {
                        button_clicked[i] = false;
                        node_list_button[i].FlatAppearance.BorderSize = 1;
                    }
                    this.ActiveControl = null;
                    listView1.Clear();
                    return;
                }
            }
            for (int i = 0; i < button_clicked.Count(); i++)
            {
                if (i != index2)
                {
                    button_clicked[i] = false;
                    node_list_button[i].FlatAppearance.BorderSize = 1;
                }
            }

            for (int i = 0; i < line_clicked.Count(); i++)
            {
                line_clicked[i] = false;
            }

            button_clicked[index2] = !button_clicked[index2];
            if (button_clicked[index2])
            {
                btn.FlatAppearance.BorderSize = 4;
            }
            else
            {
                btn.FlatAppearance.BorderSize = 1;
            }

            refresh_listview(true, index2);
            refresh_edges();
            if (button_clicked.Contains(true))
            {
                edit_button.Visible = false;
            }
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            mouseDown = true;
            mouseDownX = e.X;
            mouseDownY = e.Y;
            old_btn_pos = btn.Location;
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Point location = new Point(e.X + btn.Left - ((e.X + btn.Left) % 30), e.Y + btn.Top - ((e.Y + btn.Top) % 30));
            btn.Location = location;
            if (old_btn_pos != location)
            {
                button_clicked[node_list_button.IndexOf(btn)] = false;
                node_list_button[node_list_button.IndexOf(btn)].FlatAppearance.BorderSize = 1;
                this.ActiveControl = null;
                listView1.Clear();

                foreach (Edge edge in edge_list)
                {
                    int index1 = node_list.IndexOf(edge.Flow_Out_Node);
                    int index2 = node_list.IndexOf(edge.Flow_In_Node);

                    edge.Function(Line_Start_Point(index1), Line_End_Point(index1, index2));
                }
            }
            mouseDown = false;
            refresh_edges();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!radio_edge.Checked && !radio_navigate.Checked)
            {
                Button btn = new Button();
                btn.Name = "button_" + Convert.ToString(button_number);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                Point location = new Point(e.X - (e.X % 30), e.Y - (e.Y % 30));
                btn.Location = location;
                btn.Height = 30;
                btn.Width = 30;
                btn.MouseEnter += new EventHandler(btn_Enter);
                btn.MouseLeave += new EventHandler(btn_Leave);
                btn.Click += new EventHandler(btn_Click);
                btn.MouseDown += new MouseEventHandler(btn_MouseDown);
                btn.MouseUp += new MouseEventHandler(btn_MouseUp);
                btn.MouseMove += new MouseEventHandler(Form1_MouseMove);
                button_clicked.Add(false);

                if (radio_start_node.Checked)
                {
                    btn.Text = "S";
                    btn.BackColor = Color.Cyan;
                    node_list.Add(new Node("start_" + Convert.ToString(button_number), true, false));
                }
                else if (radio_end_node.Checked)
                {
                    btn.Text = "T";
                    btn.BackColor = Color.DeepPink;
                    node_list.Add(new Node("end_" + Convert.ToString(button_number), false, true));
                }
                else if (radio_node.Checked)
                {
                    btn.Text = Convert.ToString(node_name);
                    node_name++;
                    node_list.Add(new Node("node_" + Convert.ToString(button_number), false, false));
                }
                
                Controls.Add(btn);
                button_number++;
                node_list_button.Add(btn);
            }

            bool check = false;


            for (int i = 0; i < edge_list.Count; i++)
            {
                line_clicked[i] = false;
            }

            for (int i = 0; i < edge_list.Count; i++)
            {
                if (edge_list[i].Is_Mouse_Over(e.X, e.Y))
                {
                    line_clicked[i] = !line_clicked[i];
                    check = true;
                    refresh_listview(false, i);
                    listView1.Items[0].Selected = true;
                }
            }

            if (!check)
            {
                for (int i = 0; i < line_clicked.Count; i++)
                {
                    line_clicked[i] = false;
                }
            }

            refresh_edges();

            for (int i = 0; i < button_clicked.Count; i++)
            {
                button_clicked[i] = false;
                node_list_button[i].FlatAppearance.BorderSize = 1;
            }

            if (!line_clicked.Contains(true))
            {
                listView1.Clear();

                edit_button.Visible = false;
                save_button.Visible = false;
                lbl_edge_name.Visible = false;
                lbl_flowrate.Visible = false;
                lbl_flow_in.Visible = false;
                lbl_flow_out.Visible = false;
                txb_edge_name.Visible = false;
                txb_flowrate.Visible = false;
                txb_flow_in.Visible = false;
                txb_flow_out.Visible = false;
            }

            if (line_clicked.Count(s => s == true) == 1)
            {
                edit_button.Visible = true;

            }
            if (button_clicked.Contains(true))
            {
                edit_button.Visible = false;
            }
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];

            lbl_edge_name.Visible = true;
            lbl_flowrate.Visible = true;
            lbl_flow_in.Visible = true;
            lbl_flow_out.Visible = true;
            txb_edge_name.Visible = true;
            txb_flowrate.Visible = true;
            txb_flow_in.Visible = true;
            txb_flow_out.Visible = true;
            save_button.Visible = true;

            txb_edge_name.Text = item.Text;
            txb_flowrate.Text = item.SubItems[1].Text;
            txb_flow_in.Text = item.SubItems[2].Text;
            txb_flow_out.Text = item.SubItems[3].Text;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txb_flowrate.Text) > 100000000)
                {
                    save_button.Visible = false;
                    lbl_edge_name.Visible = false;
                    lbl_flowrate.Visible = false;
                    lbl_flow_in.Visible = false;
                    lbl_flow_out.Visible = false;
                    txb_edge_name.Visible = false;
                    txb_flowrate.Visible = false;
                    txb_flow_in.Visible = false;
                    txb_flow_out.Visible = false;
                    return;
                }
            }
            catch
            {
                return;
            }
            ListViewItem item = listView1.SelectedItems[0];
            int i = 0;

            save_button.Visible = false;
            lbl_edge_name.Visible = false;
            lbl_flowrate.Visible = false;
            lbl_flow_in.Visible = false;
            lbl_flow_out.Visible = false;
            txb_edge_name.Visible = false;
            txb_flowrate.Visible = false;
            txb_flow_in.Visible = false;
            txb_flow_out.Visible = false;

            while (item.Text != edge_list[i].Name)
            {
                i++;
            }
            edge_list[i].Name = txb_edge_name.Text;
            edge_list[i].Flowrate = Convert.ToInt32(txb_flowrate.Text);
            edge_list[i].Flow_In_Node.Name = txb_flow_in.Text;
            edge_list[i].Flow_Out_Node.Name = txb_flow_out.Text;    
            refresh_listview(false, i);
            refresh_edges();
            edit_button.Visible = false;
            txb_edge_name.Text = "";
            txb_flowrate.Text = "";
            txb_flow_in.Text = "";
            txb_flow_out.Text = "";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bitmap, 0, 0);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < node_list_button.Count; i++)
            {
                button_clicked[i] = false;
                node_list_button[i].FlatAppearance.BorderSize = 1;
            }

            for (int a = 0; a < line_clicked.Count; a++)
            {
                line_clicked[a] = false;
            }

            for (int i = 0; i < edge_list.Count; i++)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    if (listView1.SelectedItems[0].Text == edge_list[i].Name)
                    {
                        line_clicked[i] = true;
                    }
                }
            }
            refresh_edges();
            edit_button.Visible = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            refresh_edges();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Button btn = sender as Button;
                btn.Left += (e.X - mouseDownX);
                btn.Top += (e.Y - mouseDownY);
                btn.Update();
            }
        }

        private void sim_button_Click(object sender, EventArgs e)
        {
            bool is_solved = false;

            // not important code. Just some initialisation
            foreach (Edge edge in edge_list)
            {
                edge.Current_Flowrate = 0;
            }
            foreach (Edge edge in edge_list)
            {
                // edge.Color_True = true is just for later to color the right edges
                edge.Color_True = true;
            }

            // set all start nodes to height of total number of nodes
            // load all edges which go out of a start_node fully
            foreach (Node node in node_list)
            {
                if (node.Is_Start())
                {
                    node.Height = node_list.Count();
                    foreach (Edge edge in node.Flow_Out_List())
                    {
                        edge.Current_Flowrate = edge.Flowrate;
                    }
                }
                else
                {
                    node.Height = 0;
                }
            }


            while (!is_solved)
            {
                is_solved = true;

                // try every node
                foreach (Node node in node_list)
                {
                    int height_old = node.Height;
                    float sum_flow_in_old = node.Sum_Flow_In();
                    float sum_flow_out_old = node.Sum_Flow_Out();

                    // if there is more flow_in than flow_out it will push forwards
                    if (node.Sum_Flow_In() > node.Sum_Flow_Out() && !node.Is_Start() && !node.Is_End())
                    {
                        is_solved = false;

                        // try as long until there is either a change in flow_in or in flow_out
                        while (sum_flow_in_old == node.Sum_Flow_In() && sum_flow_out_old == node.Sum_Flow_Out())
                        {
                            // try every edge that flows out first
                            foreach (Edge edge in node.Flow_Out_List())
                            {
                                // Check if edge still has capacity and that the flow_in_node has a lower height
                                if (edge.Flowrate - edge.Current_Flowrate > 0 && node.Height > edge.Flow_In_Node.Height)
                                {
                                    // Check if the capacity is big enough to flow let all the excess flow further
                                    // else let as much flow through as possible
                                    if (edge.Flowrate - edge.Current_Flowrate >= node.Sum_Flow_In() - node.Sum_Flow_Out())
                                    {
                                        edge.Current_Flowrate += node.Sum_Flow_In() - node.Sum_Flow_Out();
                                    }
                                    else
                                    {
                                        edge.Current_Flowrate += edge.Flowrate - edge.Current_Flowrate;
                                    }
                                }
                            }

                            // try every edge that flows_in second
                            foreach (Edge edge in node.Flow_In_List())
                            {
                                // Check if the flow_in_node has a lower height
                                if (node.Height > edge.Flow_Out_Node.Height)
                                {
                                    // let as much flow back as possible but not more than there is overflow
                                    if (edge.Flowrate >= node.Sum_Flow_In() - node.Sum_Flow_Out() && edge.Current_Flowrate != 0)
                                    {
                                        edge.Current_Flowrate -= node.Sum_Flow_In() - node.Sum_Flow_Out();
                                    }
                                    else if (edge.Current_Flowrate != 0)
                                    {
                                        edge.Current_Flowrate -= edge.Flowrate;
                                    }
                                }
                            }

                            // if there is no change in the flow, increase height and try again
                            if (sum_flow_in_old == node.Sum_Flow_In() && sum_flow_out_old == node.Sum_Flow_Out())
                            {
                                node.Height++;
                            }
                        }
                    }
                }
            }
            refresh_edges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_number = 0;
            node_name = 0;
            edge_name = 0;
            foreach (Button but in node_list_button)
            {
                but.Visible = false;
            }
            node_list.Clear();
            node_list_button.Clear();
            edge_list.Clear();
            button_clicked.Clear();
            line_clicked.Clear();
            refresh_listview(false, 0);
            refresh_edges();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                while (button_clicked.Contains(true))
                {
                    for (int i = 0; i < node_list_button.Count; i++)
                    {
                        if (button_clicked[i])
                        {
                            List<Edge> help1 = node_list[i].Flow_In_List();
                            List<Edge> help2 = node_list[i].Flow_Out_List();
                            Edge[] bla = help1.ToArray();
                            Edge[] bla2 = (Edge[])bla.Clone();
                            List<Edge> flowinlist = bla2.ToList();
                            Edge[] bla3 = help2.ToArray();
                            Edge[] bla4 = (Edge[])bla3.Clone();
                            List<Edge> flowoutlist = bla4.ToList();



                            foreach (Edge flowin in flowinlist)
                            {
                                int index = edge_list.IndexOf(flowin);
                                edge_list[index].Flow_In_Node.Remove_Flow_In(flowin);
                                edge_list[index].Flow_Out_Node.Remove_Flow_Out(flowin);

                                edge_list.RemoveAt(index);
                                line_clicked.RemoveAt(index);
                            }
                            foreach (Edge flowout in flowoutlist)
                            {
                                int index = edge_list.IndexOf(flowout);
                                edge_list[index].Flow_In_Node.Remove_Flow_In(flowout);
                                edge_list[index].Flow_Out_Node.Remove_Flow_Out(flowout);
                                edge_list.RemoveAt(index);
                                line_clicked.RemoveAt(index);
                            }


                            this.Controls.Remove(node_list_button[i]);
                            node_list_button.RemoveAt(i);
                            node_list.RemoveAt(i);
                            button_clicked.RemoveAt(i);
                        }
                    }
                }

                while (line_clicked.Contains(true))
                {
                    for (int i = 0; i < edge_list.Count; i++)
                    {
                        if (line_clicked[i])
                        {
                            edge_list[i].Flow_In_Node.Remove_Flow_In(edge_list[i]);
                            edge_list[i].Flow_Out_Node.Remove_Flow_Out(edge_list[i]);
                            edge_list.RemoveAt(i);
                            line_clicked.RemoveAt(i);
                        }
                    }
                }
                refresh_edges();
                refresh_listview(false, 0);
                edit_button.Visible = false;
                listView1.Clear();
                this.ActiveControl = null;
            }
        }

        private void txb_flowrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save_button.PerformClick();
            }
        }

        private void txb_flow_in_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save_button.PerformClick();
            }
        }

        private void txb_flow_out_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save_button.PerformClick();
            }
        }

        private void txb_edge_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save_button.PerformClick();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            listView1.Top = this.Height - 221;
            save_button.Top = this.Height - 76;
            edit_button.Top = this.Height - 76;
            clear_button.Top = this.Height - 76;
            txb_edge_name.Top = this.Height - 221;
            txb_flowrate.Top = this.Height - 195;
            txb_flow_in.Top = this.Height - 169;
            txb_flow_out.Top = this.Height - 143;
            lbl_edge_name.Top = this.Height - 218;
            lbl_flowrate.Top = this.Height - 192;
            lbl_flow_in.Top = this.Height - 166;
            lbl_flow_out.Top = this.Height - 140;

            save_button.Left = this.Width - 455;
            edit_button.Left = this.Width - 374;
            clear_button.Left = this.Width - 295;
            txb_edge_name.Left = this.Width - 128;
            txb_flowrate.Left = this.Width - 128;
            txb_flow_in.Left = this.Width - 128;
            txb_flow_out.Left = this.Width - 128;
            lbl_edge_name.Left = this.Width - 214;
            lbl_flowrate.Left = this.Width - 214;
            lbl_flow_in.Left = this.Width - 214;
            lbl_flow_out.Left = this.Width - 214;

            listView1.Width = this.Width - 232;
            refresh_listview(false, 0);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            save_button.PerformClick();
            edit_button.PerformClick();
        }
    }
}