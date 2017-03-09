using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Polygon;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Баловался
            for (int i = 0; i <= 100; i++)
            {
                Console.Write("\r {0} %", i);
                System.Threading.Thread.Sleep(10);
            }           
            MethodForTriangle();
            //==================
            MetodForPolygon();

            Console.ReadKey();
        }
        // Методы для триугольника
        static void MethodForTriangle()
        {
            Random gen = new Random();
            Point[] points = new Point[3];
            Edge[] edges = new Edge[3];


            double sumPerimeterRightTriangles = 0;
            double sumAreaIsoscelesTriangles = 0;
            double countRightTriangle = 0;
            double countIsoscelesTriangle = 0;

            Console.Write("\nВведите количесто треугольников = ");

            Triangle[] triangles = new Triangle[Convert.ToInt32(Console.ReadLine())];

            for (int indexTriangle = 0; indexTriangle < triangles.Length; indexTriangle++)
            {
                Console.WriteLine("\nТреугольник = {0}", indexTriangle);
                RandomCoordinates(gen, points, triangles, indexTriangle, edges); // Генерация точек
                PrintPoints(triangles[indexTriangle].points); // Выводит точки
                double[] getLengthEdge = EdgesLengthInTriangle(edges, points); // Расчет длин ребер треугольника

                //TODO: добавить для обычных треугольников реализовать метод (периметра и площади)
                if (triangles[indexTriangle].RightTriangle(getLengthEdge) == true)
                {
                    countRightTriangle++;
                    sumPerimeterRightTriangles += triangles[indexTriangle].Perimeter(getLengthEdge);
                    Console.WriteLine("Периметр прямоугольного треугольника = {0}", sumPerimeterRightTriangles);
                }
                if (triangles[indexTriangle].IsoscelesTriangle(getLengthEdge) == true)
                {
                    countIsoscelesTriangle++;
                    double perimetr = triangles[indexTriangle].Perimeter(getLengthEdge);
                    sumAreaIsoscelesTriangles += triangles[indexTriangle].Area(getLengthEdge, perimetr);
                    Console.WriteLine("Площадь равнобедренного треугольника = {0}", sumAreaIsoscelesTriangles);
                }
                Console.WriteLine("---------------==== ---------------");
            }

            Console.WriteLine("Количество прямоугольных треугольников = {0}. Средний периметр = {1}", countRightTriangle, sumPerimeterRightTriangles / countRightTriangle);
            Console.WriteLine("Количество равнобедренных треугольников = {0}. Средняя площадь = {1}", countIsoscelesTriangle, sumAreaIsoscelesTriangles / countIsoscelesTriangle);
        }
        static void PrintPoints(Point[] points)
        {
            Console.WriteLine("Точки");
            for (int i = 0; i < points.Length; i++)
            {
                Console.Write(points[i].x + " " + points[i].y);
                Console.WriteLine();
            }
        }
        static void RandomCoordinates(Random gen, Point[] points, Triangle[] triangles, int indexTriangle, Edge[] edges)
        {
            for (int j = 0; j < points.Length; j++)
            {
                points[j] = new Point(gen.Next(0, 10), gen.Next(0, 10));
            }
            triangles[indexTriangle] = new Triangle(points, edges);

            triangles[indexTriangle].CheckPointsInMassive(points);
            triangles[indexTriangle] = new Triangle(points, edges);
        }
        static double[] EdgesLengthInTriangle(Edge[] edges, Point[] points)
        {
            //TODO: вернуться к этому моменту
            double[] getLengthEdge = new double[edges.Length]; // здесь длина ребер 

            Console.WriteLine("Длина ребер");
            for (int i = 0; i < edges.Length; i++)
            {
                if (i == (edges.Length - 1))
                    edges[i] = new Edge(points[i], points[0]);
                else
                    edges[i] = new Edge(points[i], points[i + 1]);

                getLengthEdge[i] = edges[i].GetLenghteEdge();
                Console.WriteLine("Ребро {0} = {1}", i, getLengthEdge[i]);
            }
            return getLengthEdge;
        }
        
        // Методы для многоугольника
        static void MetodForPolygon()
        {
            Random gen = new Random();
            Console.Write("\n\n\nВведите кол-во вершин = ");
            int countVertexPolygon = Convert.ToInt32(Console.ReadLine());

            Point[] pointPolygon = new Point[countVertexPolygon];
            Edge[] edgesPolygon = new Edge[countVertexPolygon];
            ClassPolygon polygon = new ClassPolygon(pointPolygon);

            double perimetrPolygon = 0;
            double areaPolygon = 0;

            RandomCoordinatesForPolygon(gen, pointPolygon, polygon);

            double[] getLengthEdgeInPolygon = EdgesLengthInPolygon(edgesPolygon, pointPolygon);

            PrintPoints(pointPolygon);
            perimetrPolygon += polygon.PerimetrPolygon(getLengthEdgeInPolygon);
            areaPolygon += polygon.AreaPolygon(pointPolygon, areaPolygon);

            Console.WriteLine("Периметр = {0} Площадь = {1}", Math.Round(perimetrPolygon, 2), Math.Round(areaPolygon, 4));
        }
        static void RandomCoordinatesForPolygon(Random gen,Point[] pointPolygon, ClassPolygon polygon)
        {
            for (int i = 0; i < pointPolygon.Length; i++)
            {
                pointPolygon[i] = new Point(gen.Next(0,10), gen.Next(0,10));
                polygon = new ClassPolygon(pointPolygon);
            }
        }
        static double[] EdgesLengthInPolygon(Edge[] edges, Point[] pointPolygon)
        {
            double[] getLengthEdge = new double[pointPolygon.Length]; // здесь длина ребер 

            Console.WriteLine("Длина ребер");
            for (int i = 0; i < getLengthEdge.Length; i++)
            {
                if (i == (edges.Length - 1))
                    edges[i] = new Edge(pointPolygon[i], pointPolygon[0]);
                else
                    edges[i] = new Edge(pointPolygon[i], pointPolygon[i + 1]);

                getLengthEdge[i] = edges[i].GetLenghteEdge();
                Console.WriteLine("Ребро {0} = {1}", i, getLengthEdge[i]);
            }
            return getLengthEdge;
        }
    }
}