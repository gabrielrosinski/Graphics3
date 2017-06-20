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

            form.clearScreen();

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
            int angle = Convert.ToInt32(form.parallelProjectionAngle_text.Text);

            form.clearScreen();

            //create 2d representation of the polygons
            foreach (Polygon polygon in polygonList)
            {
                foreach (Point3D point3D in polygon.polygonPoints)
                {
                    
                    var point2D = parallelProjection(point3D, angle);
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

            form.clearScreen();

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





        //Transformations

        public static void scale(Form1 form, List<Polygon> polygonList, double scaleFactor)
        {
            List<Polygon> newPoligonList = new List<Polygon>();
            Polygon newPolygon;// = new Polygon();
            Point3D point;
            List<Point3D> tempPointList;// = new List<Point3D>();

            double[] distance = {
                form.centerPoint.x,
                form.centerPoint.y,
                form.centerPoint.z
            };

            double[,] scaleMatrix = { 
                { scaleFactor, 0, 0, 0 },
                { 0, scaleFactor, 0, 0 },
                { 0, 0, scaleFactor, 0 },
                {
                    (1 - scaleFactor) * distance[0],
                    (1 - scaleFactor) * distance[1],
                    (1 - scaleFactor) * distance[2],
                    1
                }
            };

            foreach (Polygon polygon in polygonList)
            {
                newPolygon = new Polygon();
                tempPointList = new List<Point3D>();

                foreach (Point3D P in polygon.polygonPoints)
                {
                    double[,] array = { 
                        {
                            P.x,
                            P.y,
                            P.z,
                            1
                        }
                    };

                    array = multiplyMatrix(array, scaleMatrix);
                    point = new Point3D();

                    point.x = (int)array[0, 0];
                    point.y = (int)array[0, 1];
                    point.z = (int)array[0, 2];
                    tempPointList.Add(point);
                }


                newPolygon.polygonPoints = tempPointList.ToArray();
                newPoligonList.Add(newPolygon);

            }

            form.polygonList = newPoligonList;
            form.clearScreen();
            form.tempPaint();
        }

        public static void rotateZAxis(Form1 form, List<Polygon> polygonList, double angle)
        {
           // getCenter(form);
            //    //get the angle in radians
                double angleInRad = angle / 180.0 * Math.PI;
            //    //pre calculate the cos and sin
            double cos = Math.Cos(angleInRad);
            double sin = Math.Sin(angleInRad);
           
            form.centerPoint.y = ((form.centerPoint.x - form.centerPoint.x) * sin + ((form.centerPoint.y - form.centerPoint.y) * cos) + form.centerPoint.y);
            form.centerPoint.x = ((form.centerPoint.x - form.centerPoint.x) * cos - ((form.centerPoint.y - form.centerPoint.y) * sin) + form.centerPoint.x);
            foreach (Polygon polygon in polygonList)
            {
                for (int i = 0; i < polygon.polygonPoints.Length; ++i)
                {
                    Point3D point3D = polygon.polygonPoints[i];
                    point3D.x = ((((point3D.x- form.centerPoint.x) * cos) - (point3D.y- form.centerPoint.y) * sin)+ form.centerPoint.x);
                    point3D.y = ((((point3D.x- form.centerPoint.x) * sin) + (point3D.y- form.centerPoint.y) * cos)+ form.centerPoint.y);

                    polygon.polygonPoints[i] = point3D;
                }

            }

        }

        public static void rotateYAxis(Form1 form, List<Polygon> polygonList, double angle)
        {
           // getCenter(form);
            //    //get the angle in radians
            double angleInRad = angle / 180.0 * Math.PI;
            //    //pre calculate the cos and sin
            double cos = Math.Cos(angleInRad);
            double sin = Math.Sin(angleInRad);

            form.centerPoint.z = form.centerPoint.z * cos - ((form.centerPoint.x * sin) + form.centerPoint.x);
            form.centerPoint.x = form.centerPoint.z * sin + ((form.centerPoint.x * cos) + form.centerPoint.x);
            foreach (Polygon polygon in polygonList)
            {
                for (int i = 0; i < polygon.polygonPoints.Length; ++i)
                {
                    Point3D point3D = polygon.polygonPoints[i];
                    point3D.z = (((point3D.z- form.centerPoint.z) * cos) - ((point3D.x- form.centerPoint.x) * sin)+ form.centerPoint.z);
                    point3D.x = (((point3D.z - form.centerPoint.z) * sin) + ((point3D.x- form.centerPoint.x) * cos)+ form.centerPoint.x);

                    polygon.polygonPoints[i] = point3D;
                }

            }

        }

        public static void rotateXAxis(Form1 form, List<Polygon> polygonList, double angle)
        {
           // getCenter(form);
            //    //get the angle in radians
            double angleInRad = angle / 180.0 * Math.PI;
            //    //pre calculate the cos and sin
            double cos = Math.Cos(angleInRad);
            double sin = Math.Sin(angleInRad);

            form.centerPoint.z = (form.centerPoint.y * cos - (form.centerPoint.z * sin) + form.centerPoint.z);
            form.centerPoint.y = (form.centerPoint.y * sin + (form.centerPoint.z * cos) + form.centerPoint.y);
            foreach (Polygon polygon in polygonList)
            {
                for (int i = 0; i < polygon.polygonPoints.Length; ++i)
                {
                    Point3D point3D = polygon.polygonPoints[i];
                    point3D.z = (((point3D.y - form.centerPoint.y) * cos) - ((point3D.z - form.centerPoint.z) * sin) + form.centerPoint.z);
                    point3D.y = (((point3D.y - form.centerPoint.y) * sin) + ((point3D.z - form.centerPoint.z) * cos) + form.centerPoint.y);

                    polygon.polygonPoints[i] = point3D;
                }


            }

        }

        //Utilties
        public static void moveObjectsToZero(Form1 form, List<Polygon> polygonList)
        {
            Point3D centerPoint = new Point3D(form.centerPoint.x, form.centerPoint.y, form.centerPoint.z);
            //create 2d representation of the polygons
            form.holderCenter = new Point3D(centerPoint.x, centerPoint.y, centerPoint.z);
            foreach (Polygon polygon in polygonList)
            {
                for (int i = 0; i < polygon.polygonPoints.Length; ++i)
                {
                    Point3D point3D = polygon.polygonPoints[i];
                                point3D.x += -centerPoint.x;
                                point3D.y += -centerPoint.y;
                                point3D.z += -centerPoint.z;

                    polygon.polygonPoints[i] = point3D;
                }
            }
            form.centerPoint.x = 0;
            form.centerPoint.y = 0;
            form.centerPoint.z = 0;
        }

        public static void moveBackObject(Point3D originalCenter, Form1 form, List<Polygon> polygonList)
        {
            Point3D calculate = new Point3D(form.holderCenter.x - form.centerPoint.x, form.holderCenter.y - form.centerPoint.y, form.holderCenter.z - form.centerPoint.z);
            //create 2d representation of the polygons
            foreach (Polygon polygon in polygonList)
            {
                for (int i = 0; i < polygon.polygonPoints.Length; ++i)
                {
                    Point3D point3D = polygon.polygonPoints[i];
                    point3D.x += calculate.x;
                    point3D.y += calculate.y;
                    point3D.z += calculate.z;

                    polygon.polygonPoints[i] = point3D;
                }
            }
            form.centerPoint.x += calculate.x;
            form.centerPoint.y += calculate.y;
            form.centerPoint.z += calculate.z;
            form.holderCenter = null;
        }

        public static void getCenter(Form1 form)
        {
            List<Point> objectsPointsList = new List<Point>();
            Point3D min = new Point3D();
            min.x = double.MaxValue;
            min.y = double.MaxValue;
            min.z = double.MaxValue;
            Point3D max = new Point3D();
            max.x = double.MinValue;
            max.y = double.MinValue;
            max.z = double.MinValue;
            //create 2d representation of the polygons
            foreach (Polygon polygon in form.polygonList)
            {
                foreach (Point3D point3D in polygon.polygonPoints)
                {
                    var point2D = perspectiveProjection(point3D);   //returns point2D

                    if (point3D.x < min.x) min.x = point3D.x;
                    if (point3D.x > max.x) max.x = point3D.x;
                    if (point3D.y < min.y) min.y = point3D.y;
                    if (point3D.y > max.y) max.y = point3D.y;
                    if (point3D.z < min.z) min.z = point3D.z;
                    if (point3D.z > max.z) max.z = point3D.z;

                }
                form.centerPoint = new Point3D(min.x+((max.x - min.x) / 2), min.y + ((max.y - min.y) / 2), min.z + ((max.z - min.z) / 2));
            }
        }

        public static void drawPolygons(Form1 form, List<Point> points)
        {
            form.graphics.DrawPolygon(form.pen, points.ToArray());
            Rectangle rectangle1 = new Rectangle((int)form.centerPoint.x, (int)form.centerPoint.y, 4, 4);
            form.graphics.DrawRectangle(Pens.Black, rectangle1);
            form.graphics.FillRectangle(Brushes.Red, rectangle1);
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
