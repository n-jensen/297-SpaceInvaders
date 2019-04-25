using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Windows.UI;


namespace SpaceInvaders
{
    
    public class Alien : IImage
    {
        //an image, dimensions, placement, hit yes/no
        public int X { get; set; }
        public int Y { get; set; }
        public CanvasBitmap AlienImage;
        public bool GotHit;

        public Alien(int x, int y, CanvasBitmap image)//int centerx, int y, int height, int width)
        {
            X = x;
            Y = y;
            this.AlienImage = image;
        }




        //do an update for every alien
        public void Update()
        {
            //Y between 200 - 400
            if (Y != 400)  //some aliens still exist, not yet reached the bottom 
            {
                Y -= 2;
            }
            //END GAME FIXME

        }

        public void Image(CanvasDrawingSession image)
        {
            image.DrawImage(AlienImage, X, Y);
        }
    }


}