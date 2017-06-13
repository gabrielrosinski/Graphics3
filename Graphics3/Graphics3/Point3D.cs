using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics3
{
    public class Point3D 
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        public Point3D() { }

        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

    }
}
