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
            int angle = Convert.ToInt32(form.parallelProjectionAngle_text.Text);

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
            //move objects to 0
            moveObjectsToZero(form, polygonList);


            //scale 

            //move objects to center
        }

        //public static void rotate(Form1 form, List<Polygon> polygonList, double scaleFactor, double angle)
        //{
        //    //get the angle in radians
        //    double angleInRad = angle / 180.0 * Math.PI;
        //    //pre calculate the cos and sin
        //    double cos = Math.Cos(angleInRad);
        //    double sin = Math.Sin(angleInRad);
        //    centerPoint.x = (((centerPoint.x - choosenX) * cos) - ((centerPoint.y - choosenY) * sin) + choosenX);
        //    centerPoint.y = (((centerPoint.y - choosenY) * cos) + ((centerPoint.x - choosenX) * sin) + choosenY);
        //    if (tranform.Lines != null)
        //        for (int i = 0; i < tranform.Lines.Length; ++i)
        //        {
        //            tranform.Lines[i].first.x = (((tranform.Lines[i].first.x - choosenX) * cos) - ((tranform.Lines[i].first.y - choosenY) * sin) + choosenX);
        //            tranform.Lines[i].first.y = (((tranform.Lines[i].first.y - choosenY) * cos) + ((tranform.Lines[i].first.x - choosenX) * sin) + choosenY);
        //            tranform.Lines[i].second.x = (((tranform.Lines[i].second.x - choosenX) * cos) - ((tranform.Lines[i].second.y - choosenY) * sin) + choosenX);
        //            tranform.Lines[i].second.y = (((tranform.Lines[i].second.y - choosenY) * cos) + ((tranform.Lines[i].second.x - choosenX) * sin) + choosenY);
        //        }
        //    if (tranform.Circles != null)
        //        for (int i = 0; i < tranform.Circles.Length; ++i)
        //        {
        //            tranform.Circles[i].center.x = (((tranform.Circles[i].center.x - choosenX) * cos) - ((tranform.Circles[i].center.y - choosenY) * sin) + choosenX);
        //            tranform.Circles[i].center.y = (((tranform.Circles[i].center.y - choosenY) * cos) + ((tranform.Circles[i].center.x - choosenX) * sin) + choosenY);
        //        }
        //    if (tranform.Curves != null)
        //        for (int i = 0; i < tranform.Curves.Length; ++i)
        //        {
        //            tranform.Curves[i].first.x = (((tranform.Curves[i].first.x - choosenX) * cos) - ((tranform.Curves[i].first.y - choosenY) * sin) + choosenX);
        //            tranform.Curves[i].first.y = (((tranform.Curves[i].first.y - choosenY) * cos) + ((tranform.Curves[i].first.x - choosenX) * sin) + choosenY);
        //            tranform.Curves[i].second.x = (((tranform.Curves[i].second.x - choosenX) * cos) - ((tranform.Curves[i].second.y - choosenY) * sin) + choosenX);
        //            tranform.Curves[i].second.y = (((tranform.Curves[i].second.y - choosenY) * cos) + ((tranform.Curves[i].second.x - choosenX) * sin) + choosenY);
        //            tranform.Curves[i].thired.x = (((tranform.Curves[i].thired.x - choosenX) * cos) - ((tranform.Curves[i].thired.y - choosenY) * sin) + choosenX);
        //            tranform.Curves[i].thired.y = (((tranform.Curves[i].thired.y - choosenY) * cos) + ((tranform.Curves[i].thired.x - choosenX) * sin) + choosenY);
        //            tranform.Curves[i].fourth.x = (((tranform.Curves[i].fourth.x - choosenX) * cos) - ((tranform.Curves[i].fourth.y - choosenY) * sin) + choosenX);
        //            tranform.Curves[i].fourth.y = (((tranform.Curves[i].fourth.y - choosenY) * cos) + ((tranform.Curves[i].fourth.x - choosenX) * sin) + choosenY);
        //        }
        //    if (tranform.Poligon != null)
        //        for (int i = 0; i < tranform.Poligon.Length; ++i)
        //        {
        //            tranform.Poligon[i].center.x = (((tranform.Poligon[i].center.x - choosenX) * cos) - ((tranform.Poligon[i].center.y - choosenY) * sin) + choosenX);
        //            tranform.Poligon[i].center.y = (((tranform.Poligon[i].center.y - choosenY) * cos) + ((tranform.Poligon[i].center.x - choosenX) * sin) + choosenY);
        //            tranform.Poligon[i].radius.x = (((tranform.Poligon[i].radius.x - choosenX) * cos) - ((tranform.Poligon[i].radius.y - choosenY) * sin) + choosenX);
        //            tranform.Poligon[i].radius.y = (((tranform.Poligon[i].radius.y - choosenY) * cos) + ((tranform.Poligon[i].radius.x - choosenX) * sin) + choosenY);
        //        }
        //    draw();
        //}

        //Utilties
        private static void moveObjectsToZero(Form1 form, List<Polygon> polygonList)
        {
            Point3D centerPoint = new Point3D(form.centerPoint.x, form.centerPoint.y, form.centerPoint.z);
            //create 2d representation of the polygons
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
            form.holderCenter = new Point3D(centerPoint.x, centerPoint.y, centerPoint.z);
            //if(form.lastClicked == 1)
            //{
            //    form.clearScreen();
            //    drawPrespective(form, form.polygonList);
            //}
            //else if(form.lastClicked == 2)
            //{
            //    form.clearScreen();
            //    drawParallel(form, form.polygonList);
            //}
            //else if (form.lastClicked == 3)
            //{
            //    form.clearScreen();
            //    drawOblique(form, form.polygonList);
            //}

           // moveBackObject(centerPoint, form, polygonList);
        }

        private static void moveBackObject(Point3D originalCenter, Form1 form, List<Polygon> polygonList)
        {
            Point3D calculate = new Point3D(originalCenter.x, originalCenter.y, originalCenter.z);
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
            form.centerPoint.x = originalCenter.x;
            form.centerPoint.y = originalCenter.y;
            form.holderCenter = null;
            //if (form.lastClicked == 1)
            //{
            //    form.clearScreen();
            //    drawPrespective(form, form.polygonList);
            //}
            //else if (form.lastClicked == 2)
            //{
            //    form.clearScreen();
            //    drawParallel(form, form.polygonList);
            //}
            //else if (form.lastClicked == 3)
            //{
            //    form.clearScreen();
            //    drawOblique(form, form.polygonList);
            //}
        }

        //private static void moveObjectsToZero(Form1 form, List<Polygon> polygonList)
        //{
        //    Point3D centerPoint = form.centerPoint;

        //    //create 2d representation of the polygons
        //    foreach (Polygon polygon in polygonList)
        //    {
        //        for (int i = 0; i < polygon.polygonPoints.Length; ++i)
        //        {
        //            Point3D point3D = polygon.polygonPoints[i];
        //            point3D.x += -centerPoint.x;
        //            point3D.y += -centerPoint.y;
        //           // point3D.z += -centerPoint.z;

        //            polygon.polygonPoints[i] = point3D;
        //        }
        //    }
        //}


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
