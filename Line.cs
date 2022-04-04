using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maximum_flow
{
    class Line
    {
        private string myname;
        private Point mystart;
        private Point myend;
        private decimal mygradient;
        private decimal myaxisintercept;

        public Line(string name, Point start, Point end)
        {
            this.myname = name;
            this.mystart = start;
            this.myend = end;
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
    }
}
