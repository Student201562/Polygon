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
        public readonly Point[] pointPolygon;
        public ClassPolygon(Point[] masPoints)
        {
            this.pointPolygon = new Point[masPoints.Length];
            for (int i = 0; i < masPoints.Length; i++)
            {
                this.pointPolygon[i] = masPoints[i];
            }
        }

        public bool VerificationPoints()
        {
            for (int i = 0; i < pointPolygon.Length; i++)
            {
                if (i < pointPolygon.Length - 1)
                {
                    //совпадают ли точки
                    if (pointPolygon[i].X == pointPolygon[i + 1].X &&
                    pointPolygon[i].Y == pointPolygon[i + 1].Y)
                    {
                        return true;
                    }
                }
                else
                {
                    //совпадают ли точки
                    if (pointPolygon[i].X == pointPolygon[0].X &&
                   pointPolygon[i].Y == pointPolygon[0].Y)
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < pointPolygon.Length; i++)
            {
                //лежат ли на одной прямой?
                // (x2-x0)(y1-y0)-(y2-y0)(x1-x0) = 0 
                if (i < pointPolygon.Length - 2)
                {
                    if ((pointPolygon[i + 2].X - pointPolygon[i].X) * (pointPolygon[i + 1].Y - pointPolygon[i].Y) -
                (pointPolygon[i + 2].Y - pointPolygon[i].Y) * (pointPolygon[i + 1].X - pointPolygon[i].X) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
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
                    sum += (points[i].X + points[i + 1].X) * (points[i].Y - points[i + 1].Y);
                }
                else
                {
                    sum += (points[i].X + points[0].X) * (points[i].Y - points[0].Y);
                }
            }
            areaPolygon = Math.Abs(0.5 * sum);
            return areaPolygon;
        }
    }
}