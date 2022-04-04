using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_flow
{
    /// <summary>
    /// Class Node: represents a Node
    /// </summary>
    class Node
    {
        private string myname;
        private bool mystart_node;
        private bool myend_node;
        private int myheight;
        private List<Edge> myflow_in_list = new List<Edge>();
        private List<Edge> myflow_out_list = new List<Edge>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of Node</param>
        /// <param name="is_start_node">Is Node a start node?</param>
        /// <param name="is_end_node">Is Node an end node?</param>
        public Node(string name, bool is_start_node, bool is_end_node)
        {
            this.myname = name;
            this.myheight = 0;
            this.mystart_node = is_start_node;
            this.myend_node = is_end_node;
        }

        /// <summary>
        /// List of all Edges which flow in this Node
        /// </summary>
        /// <returns>List of flow in</returns>
        public List<Edge> Flow_In_List()
        {
            return myflow_in_list;
        }

        /// <summary>
        /// List of all Edges which flow out of this Node
        /// </summary>
        /// <returns>List of flow out</returns>
        public List<Edge> Flow_Out_List()
        {
            return myflow_out_list;
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

        public bool Is_Start()
        {
            return mystart_node;
        }

        public bool Is_End()
        {
            return myend_node;
        }

        /// <summary>
            /// Adds an Edge which flows in this node
            /// </summary>
            /// <param name="flowin">Edge that flows in</param>
        public void Add_Flow_In(Edge flowin)
        {
            myflow_in_list.Add(flowin);
        }

        /// <summary>
        /// Adds an Edge which flows out of this node
        /// </summary>
        /// <param name="flowout">Edge that flows out</param>
        public void Add_Flow_Out(Edge flowout)
        {
            myflow_out_list.Add(flowout);
        }

        /// <summary>
        /// Removes an Edge which flows in this node
        /// </summary>
        /// <param name="flowin">Edge that flows in</param>
        public void Remove_Flow_In(Edge flowin)
        {
            myflow_in_list.Remove(flowin);
        }

        /// <summary>
        /// Removes an Edge which flows out of this node
        /// </summary>
        /// <param name="flowout">Edge that flows out</param>
        public void Remove_Flow_Out(Edge flowout)
        {
            myflow_out_list.Remove(flowout);
        }

        public int Height
        {
            get
            {
                return myheight;
            }
            set
            {
                myheight = value;
            }
        }

        public float Sum_Flow_In()
        {
            float sum = 0;
            
            foreach (Edge edge in myflow_in_list)
            {
                sum += edge.Current_Flowrate;
            }

            return sum;
        }

        public float Sum_Flow_Out()
        {
            float sum = 0;

            foreach (Edge edge in myflow_out_list)
            {
                sum += edge.Current_Flowrate;
            }

            return sum;
        }
    }
}
