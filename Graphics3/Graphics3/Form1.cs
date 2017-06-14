using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Drawing2D;

namespace Graphics3
{
    public partial class Form1 : Form
    {

        
        public Graphics graphics;
        public Pen pen;
        Bitmap myBitmap; //TODO: change this name

        public List<Polygon> polygonList = new List<Polygon>();

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void init()
        {
            if (graphics != null) {
                graphics.Dispose();
            }

            graphics = Canvas.CreateGraphics();
            
            
            pen = new Pen(Color.Black, 2);

            //init polygons
            var polygonPointsDict = new Dictionary<string, Point3D[]> {
                //Cube polygons 
                ///////////////TODO: there is an issue with diagonal lines
                ///////////////////  either the drawing procces is off or the order of the points is bad.
                { "polygon1", new[] {
                    new Point3D(350,150,150),
                    new Point3D(350,250,150),
                    new Point3D(450,250,150),
                    new Point3D(450,150,150),
                    }
                }
                ,{ "polygon2", new[] {
                    new Point3D(350,150,250),
                    new Point3D(450,150,250),
                    new Point3D(450,250,250),
                    new Point3D(350,250,250)
                    }
                }
                ,{ "polygon3", new[] {
                    new Point3D(350,150,150),
                    new Point3D(350,150,250),
                    new Point3D(350,250,250),
                    new Point3D(350,250,150)
                    }
                }
                ,{ "polygon4", new[] {
                    new Point3D(450,250,250),
                    new Point3D(450,150,250),
                    new Point3D(450,150,150),
                    new Point3D(450,250,150),   
                    }
                }
                ,{ "polygon5", new[] {
                    new Point3D(350,150,250),
                    new Point3D(350,150,150),
                    new Point3D(450,150,150),
                    new Point3D(450,150,250),
                    }
                }
                ,{ "polygon6", new[] {
                    new Point3D(350,250,250),
                    new Point3D(450,250,250),
                    new Point3D(450,250,150),
                    new Point3D(350,250,150),
                    }
                }

                //TODO: add Pyramid polygons
            };
            


            //Create polygons from points3D arraya
            foreach (string key in polygonPointsDict.Keys)
            {
                dynamic pointsArray = polygonPointsDict[key];

                polygonList.Add(new Polygon(pointsArray));
            }
        }

        /*TODO: 
            1. add button to clear / reset screen
            2. add button to scale up
            3. add button to scale down
            4. add move objects
        */
        private void drawButton_Click(object sender, EventArgs e)
        {
            clearScreen();
            Draw3d.drawPrespective(this, this.polygonList);
        }

        private void drawParallelClicked(object sender, EventArgs e)
        {
            clearScreen();
            Draw3d.drawParallel(this, this.polygonList);
        }

        private void drawObliqueClicked(object sender, EventArgs e)
        {
            clearScreen();
            Draw3d.drawOblique(this, this.polygonList);
        }

        public void clearScreen()
        {
            init();
            graphics.Clear(Color.Gray);
        }
    }
}
