using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maximum_flow
{
    /// <summary>
    /// Class Edge: represents an Edge
    /// </summary>
    class Edge
    {
        private float myflowrate;
        private float mycurrent_flowrate;
        private string myname;
        private Node myflow_out_node;
        private Node myflow_in_node;
        private Point mystart;
        private Point myend;
        private decimal mygradient;
        private decimal myaxisintercept;
        private bool mycolortrue;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="flowrate">Flowrate of this Edge</param>
        /// <param name="flow_out_node">Node of which Edge flows out</param>
        /// <param name="flow_in_node">Node of which Edge flows in</param>
        public Edge(string name, float flowrate, Node flow_out_node, Node flow_in_node, Point start, Point end)
        {
            this.myname = name;
            this.myflowrate = flowrate;
            this.myflow_out_node = flow_out_node;
            this.myflow_in_node = flow_in_node;
            this.myflow_out_node.Add_Flow_Out(this);
            this.myflow_in_node.Add_Flow_In(this);
            this.mystart = start;
            this.myend = end;
            this.mycurrent_flowrate = 0;
            this.mycolortrue = false;

            if (myend.X == mystart.X)
            {
                this.mygradient = 10 ^ 10;
            }
            else
            {
                this.mygradient = Convert.ToDecimal(mystart.Y - myend.Y) / Convert.ToDecimal(myend.X - mystart.X);
            }
            this.myaxisintercept = -mystart.Y - mygradient * mystart.X;
        }

        public Node Flow_Out_Node
        {
            get
            {
                return myflow_out_node;
            }
            set
            {
                myflow_out_node = value;
            }
        }

        public Node Flow_In_Node
        {
            get
            {
                return myflow_in_node;
            }
            set
            {
                myflow_in_node = value;
            }
        }

        public float Flowrate
        {
            get
            {
                return myflowrate;
            }
            set
            {
                myflowrate = value;
            }
        }

        public string Name
        {
            get
            {
                return myname;
            }
            set
            {
                myname = value;
            }
        }

        public bool Is_Mouse_Over(int mouseX, int mouseY)
        {
            if (-mygradient * mouseX - myaxisintercept < mouseY + 5 && -mygradient * mouseX - myaxisintercept > mouseY - 5)
            {
                if (myend.X >= mystart.X)
                {
                    if (mouseX >= mystart.X - 5 && mouseX < myend.X + 5)
                    {
                        return true;
                    }
                }
                else
                {
                    if (mouseX <= mystart.X + 5 && mouseX > myend.X - 5)
                    {
                        return true;
                    }
                }
            }
            else if (myend.X == mystart.X)
            {
                if (mouseX >= mystart.X - 5 && mouseX < myend.X + 5)
                {
                    if (myend.Y >= mystart.Y)
                    {
                        if (mouseY <= myend.Y + 5 && mouseY > mystart.Y - 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (mouseY >= myend.Y - 5 && mouseY < mystart.Y + 5)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Point Start_Point()
        {
            return mystart;
        }

        public Point End_Point()
        {
            return myend;
        }

        public float Current_Flowrate
        {
            get
            {
                return mycurrent_flowrate;
            }
            set
            {
                mycurrent_flowrate = value;
            }
        }

        public bool Color_True
        {
            get
            {
                return mycolortrue;
            }
            set
            {
                mycolortrue = value;
            }
        }

        public void Function(Point new_start_point, Point new_end_point)
        {
            mystart = new_start_point;
            myend = new_end_point;
            
            if (myend.X == mystart.X)
            {
                mygradient = 10 ^ 10;
            }
            else
            {
                mygradient = Convert.ToDecimal(mystart.Y - myend.Y) / Convert.ToDecimal(myend.X - mystart.X);
            }
            myaxisintercept = -mystart.Y - mygradient * mystart.X;
        }
    }
}
