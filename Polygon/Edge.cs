﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Edge
    {
        public readonly Point pointA;
        public readonly Point pointB;

        public Edge(Point a, Point b)
        {
            this.pointA = a;
            this.pointB = b;
        }
        public double GetLenghteEdge()
        {
            return Math.Sqrt(Math.Pow((pointB.X - pointA.X), 2) + Math.Pow((pointB.Y - pointA.Y), 2));
        }
    }
}