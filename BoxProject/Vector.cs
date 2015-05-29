using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino;
using Rhino.Input;
using Rhino.Geometry;
using Rhino.Display;

namespace _5.Classes
{
    class BoxProject
    {
        private Box box;

        private int size;

        private List<Point3d> corner = new List<Point3d>();
        private Curve crv;

        private RhinoView view;

        public BoxProject(
            int _size,
            RhinoView _view
        )
        {
            size = _size;
            view = _view;
        }

        //public void MakePoint()
        //{
        //    Random rnd = new Random();

        //    for (int i = 0; i < number; i++)
        //    {
        //        double wid = rnd.Next(0, width);
        //        double hei = rnd.Next(0, height);
        //        pop.Add(new Point3d(wid, hei, 0));
        //    }
        //}

        public void MakeBox()
        {
            box = new Box(Plane.WorldXY, new Interval(0, size), new Interval(0, size), new Interval(0, size));

            corner.AddRange(box.GetCorners());
        }

        public void ScreenArea()
        {
            Rectangle rec = view.ClientRectangle;
        }

        //public void CreateCrv()
        //{
        //    crv = Curve.CreateInterpolatedCurve(pop, 3);
        //}

        //private Vector3d NormalVector(double t1 , double t2)
        //{
        //    double ax, ay, az, bx, by, bz;
        //    Vector3d normvec , v1, v2;
        //    v1 = crv.CurvatureAt(t1);
        //    v2 = crv.CurvatureAt(t2);

        //    ax = v1.X;
        //    ay = v1.Y;
        //    az = v1.Z;
        //    bx = v2.X;
        //    by = v2.Y;
        //    bz = v2.Z;

        //    normvec = new Vector3d(ay * bz - az * by, az * bx - ax * bz, ax * by - ay * bx);
        //    return normvec;
        //}

        //public void DecideCoplanar()
        //{
        //    double cx, cy, cz, dx, dy, dz , angle;
        //    Vector3d nv1, nv2;
        //    nv1 = NormalVector(8, 9);
        //    nv2 = NormalVector(5, 2);

        //    cx = nv1.X;
        //    cy = nv1.Y;
        //    cz = nv1.Z;
        //    dx = nv2.X;
        //    dy = nv2.Y;
        //    dz = nv2.Z;

        //    angle = Math.Acos((cx * dx + cy * dy + cz * dz) / (nv1.Length * nv2.Length));

        //    RhinoApp.WriteLine(String.Format("{0}", angle));

        //    if(angle == 0 || angle == Math.PI)
        //    {
        //        RhinoApp.WriteLine("curve is coplanar");
        //    }
        //}
        
        public void Display(RhinoDoc _doc)
        {
            Brep objs = Brep.CreateFromBox(box);
                _doc.Objects.AddBrep(objs);
            for (int i = 0; i < corner.Count; i++)
            {
                _doc.Objects.AddPoint(corner[i]);
            }
        }
    }
}
