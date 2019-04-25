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



namespace SpaceInvaders
{

     public interface IImage
     {
          //do I create a new image? Or get implement the image creation task from .xaml.cs (ship, alien, laser)
          void Image(CanvasDrawingSession image);
        //What is the difference between DrawImage and CanvasDrawingSession?
     }

        
     public class SI //Space Invaders
    {
        private Alien alien;
        private Ship ship;
        private Lasers lasers;
        private Score score;
        private List<Alien> AlienList;
        private CanvasBitmap AlienImage;
        private CanvasBitmap ShipImage;
        private CanvasBitmap LaserImage;

        private bool gameOver = false;

        public SI(CanvasBitmap alienImage, CanvasBitmap shipImage, CanvasBitmap laserImage)
          {
            alien = new Alien();
            ship = new Ship();
            lasers = new Lasers();
            score = new Score();
            AlienList = new List<Alien>(10);

            AlienImage = alienImage;
            ShipImage = shipImage;
            LaserImage = laserImage;
            FillAlienList();
            Update(AlienImage, ShipImage, laserImage);   
          }

        public void Update(CanvasBitmap alienImage, CanvasBitmap shipImage, CanvasBitmap laserImage)//CanvasDrawingSession image)//
        {

            /*controller = KeyValuePair.Gamepads.First();
            var reading = controller.GetCurrentReading();
            ship.X += (int)(reading.LeftThumbstickX * 5);*/

            ship.Update();
            alien.Update();
            if (spacebuttonIsPressed)
            {
                lasers.ShootLaser(LaserImage, ship);
                lasers.Update(LaserImage, ship);
                lasers.Image(image);
            }
            //FIXME After updates, need to draw the images where they are meant to be

            CanvasDrawingSession.DrawImage(laserImage, lasers.X, lasers.Y);

            //ship.Image(image);
            //alien.Image(image);


            int lastAlienToTouch = 0;
            for(int index = 1; index <= 10; index++)
            {
                if(AlienList[index-1].GotHit == false)
                {
                    lastAlienToTouch = index-1;
                    
                }
            }
            if (AlienList[lastAlienToTouch].centerX == 400 || lastAlienToTouch == 0)
            {
                score.LivesLeft--;
                if (score.LivesLeft == 0)
                {
                    gameOver = true;
                }
            }
        }

        public void FillAlienList()
        {
            for (int index = 0; index < 10; index++)
            {
                AlienList[index].centerX = 60 + (index + 10);
                AlienList[index].Y = 40;
                AlienList[index].XLeft = AlienList[index].centerX - 24;    //get alien's left and rightmost side locations??
                AlienList[index].XRight = AlienList[index].centerX + 24;
                AlienList[index].AlienImage = AlienImage;
                AlienList[index].GotHit = false;
                gameOver = false;

            }
        }


        public void Collide()
        {
            for (int index = 0; index < 10; index++)
            {
                if (lasers.Y == AlienList[index].Y && lasers.X == AlienList[index].centerX) //FIXME && xRight <= alien.XRight && xLeft >= alien.XLeft)
                {
                    LaserImage = null;
                    AlienList[index].AlienImage = null;
                    AlienList[index].GotHit = true;
                    score.FinalScore++;
                }
            }
        }
    }




    public class Lasers : IImage
    {
        public int X;
        public int Y;
        private CanvasBitmap LaserImage;
        

        public Lasers()
        {
        }

        public void ShootLaser(CanvasBitmap laserImage, Ship ship)
        {
            LaserImage = laserImage;
            X = ship.X;
            Y = 435;
            //these ^^ declare where the image will be placed when it is uploaded/declared
        }

        public void Update(CanvasBitmap laserImage, Ship ship)
        {
            Y += 2;
        }


        public void Image(CanvasDrawingSession image)
        {
            image.DrawImage(LaserImage, X, Y);
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
}
