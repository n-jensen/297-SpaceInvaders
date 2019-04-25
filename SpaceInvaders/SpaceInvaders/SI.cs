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
        private Gamepad controller;
        private List<IImage> drawables;
        //private CanvasBitmap AlienImage;
        //private CanvasBitmap ShipImage;
        //private CanvasBitmap LaserImage;

        private bool gameOver = false;

        public SI(CanvasBitmap alienImage, CanvasBitmap shipImage, CanvasBitmap laserImage)
          {
            alien = new Alien(400, 500, alienImage);
            ship = new Ship(400, 500, shipImage);
            lasers = new Lasers(0, 0, laserImage);
            score = new Score();
            AlienList = new List<Alien>(10);
            drawables = new List<IImage>();


            //AlienImage = alienImage;
            //ShipImage = shipImage;
            //LaserImage = laserImage;
            FillAlienList(alienImage);
            Update(alienImage, shipImage, laserImage);   
          }

        public void Update(CanvasBitmap alienImage, CanvasBitmap shipImage, CanvasBitmap laserImage)//CanvasDrawingSession image)//
        {
            while (gameOver == false)
            {
                ship.Update();
                alien.Update();
                drawables.Add(ship);
                drawables.Add(alien);
                controller = Gamepad.Gamepads.First();
                var reading = controller.GetCurrentReading();
                if (reading.Buttons.HasFlag(GamepadButtons.A))
                {
                    lasers.ShootLaser(laserImage, ship);
                    lasers.Update(laserImage, ship);
                    lasers = new Lasers(lasers.X, lasers.Y, laserImage);
                    drawables.Add(lasers);
                }


                int lastAlienToTouch = 0;
                for (int index = 1; index <= 10; index++)
                {
                    if (AlienList[index - 1].GotHit == false)
                    {
                        lastAlienToTouch = index - 1;

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
        }

        public void FillAlienList(CanvasBitmap alienImage)
        {
            for (int index = 0; index < 10; index++)
            {
                AlienList[index].centerX = 60 + (index + 10);
                AlienList[index].Y = 40;
                AlienList[index].AlienImage = alienImage;
                AlienList[index].GotHit = false;
            }
        }


        public void Collide()
        {
            for (int index = 0; index < 10; index++)
            {
                if (lasers.Y == AlienList[index].Y && lasers.X == AlienList[index].centerX) //FIXME && xRight <= alien.XRight && xLeft >= alien.XLeft)
                {
                    lasers.LaserImage = null;
                    AlienList[index].AlienImage = null;
                    AlienList[index].GotHit = true;
                    score.FinalScore += 10;
                }
            }
        }


        public void DrawGame(CanvasDrawingSession canvas)
        {
            foreach (var drawable in drawables)
            {
                drawable.Image(canvas);
            }
        }
    }




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
