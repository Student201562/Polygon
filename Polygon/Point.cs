using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Point
    {
        private double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y { get; set; }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
