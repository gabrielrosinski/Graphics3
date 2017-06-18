using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics3
{
    public class Point3D 
    {
        public Double x { get; set; }
        public Double y { get; set; }
        public Double z { get; set; }

        public Point3D() { }

        public Point3D(Double x, Double y, Double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

    }
}
