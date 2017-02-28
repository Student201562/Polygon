using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangle;

namespace Polygon
{
    class ClassPolygon
    {
        public Point[] pointPolygon;
        public ClassPolygon(Point[] masPoints)
        {
            this.pointPolygon = new Point[masPoints.Length];
            for (int i = 0; i < masPoints.Length; i++)
            {
                this.pointPolygon[i] = masPoints[i];
            }
        }
        public double PerimetrPolygon(double[] getLengthEdgeInPolygon)
        {
            double perimetrPolygon = 0;
            for (int i = 0; i < getLengthEdgeInPolygon.Length; i++)
            {
                perimetrPolygon += getLengthEdgeInPolygon[i];
            }
            return perimetrPolygon;
        }
        public double AreaPolygon(Point[] points, double areaPolygon)
        {
            double sum = 0;

            for (int i = 0; i < points.Length; i++)
            {
                if (i < points.Length - 1)
                {
                    sum += (points[i].x + points[i + 1].x) * (points[i].y - points[i + 1].y);
                }
                else
                {
                    sum += (points[i].x + points[0].x) * (points[i].y - points[0].y);
                }
            }
            areaPolygon = Math.Abs(0.5 * sum);
            return areaPolygon;
        }
    }
}