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
        public List<Polygon> polygonList = new List<Polygon>();
        public Point3D centerPoint = null;

        Bitmap myBitmap; //TODO: change this name

        

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
            this.centerPoint = new Point3D(this.Canvas.Size.Width / 2, this.Canvas.Size.Height / 2, 350);
            //init polygons
            var polygonPointsDict = new Dictionary<string, Point3D[]> {
                //Cube polygons 

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        //key press event pf the parallel projection angle text box
        //make it accept only numbers
        private void parallelProjectionAngle_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && e.KeyChar != 4)
            {
                e.Handled = true;
                
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void scaleUpBtn_Click(object sender, EventArgs e)
        {
            Draw3d.scale(this, this.polygonList, 1.2);
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }
    }
}
