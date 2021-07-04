using System;

namespace PointLib{
    public class Point{

        public double x, y;

        public Point(double x, double y){
            this.x = x;
            this.y = y;
        }
        public double getModule(){
            return Math.Sqrt(x*x + y*y);
        }

        public string toString(){
            return "Point (x = " + x + ", y = " + y + ")";
        }
    }
}