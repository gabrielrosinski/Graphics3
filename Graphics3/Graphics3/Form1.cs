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
        public Point3D holderCenter = null;
        public int lastClicked = 0;
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
            BVisible.Checked = true;
            graphics = Canvas.CreateGraphics();
            
            
            pen = new Pen(Color.Black, 2);

            //clear the polygon list 
            polygonList = new List<Polygon>();

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

                //Pyramid polygons
                ,{ "polygon7", new[] {
                    new Point3D(550, 250, 150),
                    new Point3D(650, 250, 150),
                    new Point3D(600, 150, 200)
                    }
                }
                ,{ "polygon8", new[] {
                    new Point3D(550, 250, 250),
                    new Point3D(600, 150, 200),
                    new Point3D(650, 250, 250)
                    }
                }
                ,{ "polygon9", new[] {
                    new Point3D(550, 250, 250),
                    new Point3D(550, 250, 150),
                    new Point3D(600, 150, 200)
                    }
                }
                ,{ "polygon10", new[] {
                    new Point3D(650, 250, 250),
                    new Point3D(600, 150, 200),
                    new Point3D(650, 250, 150)
                    }
                }
            };
            
            //Create polygons from points3D arraya
            foreach (string key in polygonPointsDict.Keys)
            {
                dynamic pointsArray = polygonPointsDict[key];

                polygonList.Add(new Polygon(pointsArray));
            }
            //centerPoint = new Point3D(polygonList[0].polygonPoints[0].x, polygonList[0].polygonPoints[0].y, polygonList[0].polygonPoints[0].z);
            Draw3d.getCenter(this);
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            this.lastClicked = 1;
            init();
            Draw3d.drawPrespective(this, this.polygonList);
        }

        private void drawParallelClicked(object sender, EventArgs e)
        {
            if (parallelProjectionAngle_text.Text == String.Empty) return;
            this.lastClicked = 2;
            init();
            Draw3d.drawParallel(this, this.polygonList);
        }

        private void drawObliqueClicked(object sender, EventArgs e)
        {
            this.lastClicked = 3;
            init();
            Draw3d.drawOblique(this, this.polygonList);
        }

        public void clearScreen()
        {
            //this.lastClicked = 0;
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

        private void scaleDownBtn_Click(object sender, EventArgs e)
        {
            Draw3d.scale(this, this.polygonList, 0.8);
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        private void rotateYButton_Click(object sender, EventArgs e)
        {
            if (rotationAngle.Text == String.Empty) return;
            Point3D center = new Point3D(centerPoint.x, centerPoint.y, centerPoint.z);
            holderCenter = center;
            Draw3d.moveObjectsToZero(this, polygonList);
            Draw3d.rotateYAxis(this, polygonList, int.Parse(rotationAngle.Text));
            Draw3d.moveBackObject(center, this, polygonList);
            clearScreen();
            tempPaint();
        }

        private void rotateXButton_Click(object sender, EventArgs e)
        {
            if (rotationAngle.Text == String.Empty) return;
            Point3D center = new Point3D(centerPoint.x, centerPoint.y, centerPoint.z);
            holderCenter = center;
            Draw3d.moveObjectsToZero(this, polygonList);
            Draw3d.rotateXAxis(this, polygonList, int.Parse(rotationAngle.Text));
            Draw3d.moveBackObject(center, this, polygonList);
            clearScreen();
            tempPaint();
        }

        private void rotateZButton_Click(object sender, EventArgs e)
        {
            if (rotationAngle.Text == String.Empty) return;
            Point3D center = new Point3D(centerPoint.x, centerPoint.y, centerPoint.z);
            holderCenter = center;
           // Draw3d.moveObjectsToZero(this, polygonList);
            Draw3d.rotateZAxis(this, polygonList, int.Parse(rotationAngle.Text));
           // Draw3d.moveBackObject(center, this, polygonList);
            clearScreen();
            tempPaint();
        }

        public void tempPaint()
        {
            if (this.lastClicked == 1)
            {
                //this.clearScreen();
                Draw3d.drawPrespective(this, this.polygonList);
            }
            else if (this.lastClicked == 2)
            {
                //this.clearScreen();
                Draw3d.drawParallel(this, this.polygonList);
            }
            else if (this.lastClicked == 3)
            {
                //clearScreen();
                Draw3d.drawOblique(this, this.polygonList);
            }
        }

        private void rotationAngle_TextChanged(object sender, EventArgs e)
        {

        }

        private void BVisible_CheckedChanged(object sender, EventArgs e)
        {
            tempPaint();
        }
    }
}
