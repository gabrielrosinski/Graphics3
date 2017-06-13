using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Graphics3
{
    public class Polygon
    {
        //List<Point3D> polygonPoints = null;
        public Point3D[] polygonPoints = null;
        public Point normalPoint;

        public Polygon() { }
        public Polygon(Point3D[] points)
        {
            this.polygonPoints = points;

            //todo: calculate normal point
        }
    }
}
