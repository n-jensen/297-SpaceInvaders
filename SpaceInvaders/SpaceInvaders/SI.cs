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

    /* public interface IImage
     {
          //do I create a new image? Or get implement the image creation task from .xaml.cs (ship, alien, laser)
          void Image(CanvasDrawingSession image);

     }
     public interface ICollidable
     {
          bool Collide(int xRight, int xLeft, int y, int height, int width);
     }




    //import 100 images that move across the screen left and right
        //when a "laser" shoots the alien, it disappears, score++
        //When a 

     public class SI //Space Invaders
    {
          private List<Alien> AlienList;
        Alien alien;
          private Ship ship;
          private Lasers lasers;
          private Score score;
        private CanvasBitmap AlienImage;
        private CanvasBitmap ShipImage;

        private bool gaemOver = false;

        public SI(CanvasBitmap alienImage, CanvasBitmap shipImage)
          {
            Alien alien = new Alien();
            AlienList = new List<Alien>(10);
            AlienImage = alienImage;
            ShipImage = shipImage;
            Ship ship = new Ship();
            FillAlienList();
               
          }

        public void FillAlienList()
        {
            for (int index = 0; index < 10; index++)
            {
                AlienList[index].centerX = 60 + (index+10);
                AlienList[index].Y = 40;
                //AlienList[index].XLeft = (centerX - )     //get alien's left and rightmost side locations??
                AlienList[index].alienImage = AlienImage;
                AlienList[index].GotHit = false;
            }
        }

        public bool Collide(int xRight, int xLeft, int y, int height, int width)
        {
            return y == alien.Y && xRight <= alien.XRight && xLeft >= alien.XLeft;
        }






    }





    public class Lasers
    {

        public Lasers(int x, int y,  int height, int width)
        {

        }
    }

     public class Score
     {
        public int FinalScore { get; set; }
        public int LivesLeft { get; set; }
        public Score()
        {
            FinalScore = 0;
            LivesLeft = 3;
        }
     }

    */

}
