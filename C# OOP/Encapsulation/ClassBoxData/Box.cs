using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {

        private double length;
        private double height;
        private double width;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            private set 
            {
                if (value<=0)
                {
                  new ArgumentException($"{Length} cannot be zero or negative.");
                   
                }
                length = value; 
            }
        }

        public double Width
        {
            get { return width; }
             private set 
            {
                if (value <= 0)
                {
                    new ArgumentException($"{Width} cannot be zero or negative.");
                  
                }
                width = value; 
            }
        }

        public double Height
        {
            get { return height; }
            private set 
            {
                if (value <= 0)
                {
                    new ArgumentException($"{Height} cannot be zero or negative.");
                  
                }
                height = value; 
            }
        }

        public double SurfaceArea()
        {
            double s = 0;

            s = 2 * ((length * height) + (length * width) + (height * width));

            return s;
        }

        public double LateralSurfaceArea()
        {
            double lsa = 0;

            lsa = 2*length*height + 2*width*height;

            return lsa;
        }
        public double Volume()
        {
            double volume = 0;

            volume = length*width*height;

            return volume;
        }




    }
}
