using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace Graphics3
{
    public static class Draw3d
    {

        public static void drawPrespective(Form1 form, List<Polygon> polygonList)
        {
            List<Point> objectsPointsList = new List<Point>();

            //create 2d representation of the polygons
            foreach (Polygon polygon in polygonList)
            {
                foreach (Point3D point3D in polygon.polygonPoints)
                {
                    var point2D = perspectiveProjection(point3D);   //returns point2D
                    objectsPointsList.Add(point2D);
                }

                //draw objects in prespective
                drawPolygons(form, objectsPointsList);
                objectsPointsList = new List<Point>();

            }
        }

        //Prespective projection 
        static Point perspectiveProjection(Point3D point)
        {
            double scalar, z;

            scalar = -900;
            z = 1 / (1 + (point.z / scalar));
            double[,] prespectiveMatrix = { 
                { z, 0, 0, 0 },
                { 0, z, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 1 }
            };
            double[,] pointMatrix = { 
                {
                    point.x,
                    point.y,
                    point.z,
                    1
                }
            };
            double[,] result = multiplyMatrix(pointMatrix, prespectiveMatrix);
            return new Point((int)result[0, 0], (int)result[0, 1]);
        }


        public static void drawParallel(Form1 form, List<Polygon> polygonList)
        {
            List<Point> objectsPointsList = new List<Point>();

            //create 2d representation of the polygons
            foreach (Polygon polygon in polygonList)
            {
                foreach (Point3D point3D in polygon.polygonPoints)
                {
                    var point2D = parallelProjection(point3D, 90.0);
                    objectsPointsList.Add(point2D);
                }

                //draw objects in prespective
                drawPolygons(form, objectsPointsList);
                objectsPointsList = new List<Point>();
            }
        }

        //Parallel projection
        public static Point parallelProjection(Point3D point, double angle)
        {
            double cos = (Math.Cos(angle * (Math.PI / 180)));
            double sin = (Math.Sin(angle * (Math.PI / 180)));

            double[,] parallelMatrix = { 
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { cos, sin, 0, 0 },
                { 0, 0, 0, 1 }
            };

            double[,] pointMatrix = { 
                {
                    point.x,
                    point.y,
                    point.z,
                    1
                }
            };

            double[,] result = multiplyMatrix(pointMatrix, parallelMatrix);

            return new Point((int)result[0, 0], (int)result[0, 1]);
        }

        //
        public static void drawOblique(Form1 form, List<Polygon> polygonList)
        {
            List<Point> objectsPointsList = new List<Point>();

            //create 2d representation of the polygons
            foreach (Polygon polygon in polygonList)
            {
                foreach (Point3D point3D in polygon.polygonPoints)
                {
                    var point2D = obliqueProjection(point3D);
                    objectsPointsList.Add(point2D);
                }

                //draw objects in prespective
                drawPolygons(form, objectsPointsList);
                objectsPointsList = new List<Point>();
            }
        }

        //Oblique projection
        public static Point obliqueProjection(Point3D Points)
        {
            double[,] obliqueMatrix = { 
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 1 }
            };

            double[,] pointMatrix = { 
                {
                    Points.x,
                    Points.y,
                    Points.z,
                    1
                }
            };

            double[,] result = multiplyMatrix(pointMatrix, obliqueMatrix);

            return new Point((int)result[0, 0], (int)result[0, 1]);
        }


        public static void drawPolygons(Form1 form, List<Point> points)
        {
            form.graphics.DrawPolygon(form.pen, points.ToArray());
        }


        public static double[,] multiplyMatrix(double[,] pointMatrix, double[,] prespectiveMatrix)
        {
            double[,] newMatrix = new double[0,0];
            if (pointMatrix.GetLength(1) == prespectiveMatrix.GetLength(0))
            {
                newMatrix = new double[pointMatrix.GetLength(0), prespectiveMatrix.GetLength(1)];
                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        newMatrix[i, j] = 0;
                        for (int k = 0; k < pointMatrix.GetLength(1); k++) 
                            newMatrix[i, j] = newMatrix[i, j] + pointMatrix[i, k] * prespectiveMatrix[k, j];
                    }
                }
            }
            else
            {
                Console.WriteLine("\n Number of columns in First Matrix should be equal to Number of rows in Second Matrix.");
                Console.WriteLine("\n Please re-enter correct dimensions.");
                //Environment.Exit(-1);
            }

            return newMatrix;
        }
    }
}
