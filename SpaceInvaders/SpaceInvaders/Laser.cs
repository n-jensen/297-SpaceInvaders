using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Windows.UI;
using System.Windows.Input;
using Windows.Gaming.Input;
using Windows.UI.Xaml;

namespace SpaceInvaders
{
    public class Lasers : IImage
    {
        public int X;
        public int Y;
        public CanvasBitmap LaserImage;


        public Lasers(int x, int y, CanvasBitmap image)
        {
            X = x;
            Y = y;
            LaserImage = image;
        }

        public void ShootLaser(CanvasBitmap laserImage, Ship ship)
        {
            LaserImage = laserImage;
            X = ship.X;
            Y = 435;
            //these ^^ declare where the image will be placed when it is uploaded/declared
        }

        public void Update(CanvasBitmap laserImage)
        {
            Y += 1;
        }

        public void Image(CanvasDrawingSession image)
        {
            image.DrawImage(LaserImage, X, Y);
        }

    }
}
