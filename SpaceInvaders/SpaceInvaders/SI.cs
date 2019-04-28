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

     public interface IImage
     {
          void Image(CanvasDrawingSession image);
        //What is the difference between DrawImage and CanvasDrawingSession?
     }

        
     public class SI //Space Invaders
    {
        private Alien alien;
        public Ship ship;
        private Lasers lasers;
        private Score score;
        private List<Alien> AlienList;
        private Gamepad controller;
        private List<IImage> drawables;
        //private CanvasBitmap AlienImage;
        //private CanvasBitmap ShipImage;
        //private CanvasBitmap LaserImage;

        private bool gameOver = false;
        
        public bool MoveShipLeft(bool moveLeft)
        {
            ship.MoveLeft = moveLeft;
            return ship.MoveLeft;
        }

        public bool MoveShipRight(bool moveRight)
        {
            ship.MoveRight = moveRight;
            return ship.MoveRight;
        }

        public SI(CanvasBitmap alienImage, CanvasBitmap shipImage, CanvasBitmap laserImage)
          {
            alien = new Alien(400, 500, alienImage);
            ship = new Ship(400, 500, shipImage);
            lasers = new Lasers(0, 0, laserImage);
            score = new Score();
            AlienList = new List<Alien>(10);
            drawables = new List<IImage>();
            FillAlienList(alienImage, AlienList);

           /* Window.Current.CoreWindow.KeyDown += Canvas_KeyDown;
            Window.Current.CoreWindow.KeyUp += Canvas_KeyUp;
            */
            //Update(alienImage, shipImage, laserImage);   
          }

        public void Update(CanvasBitmap alienImage, CanvasBitmap shipImage, CanvasBitmap laserImage)//CanvasDrawingSession image)//
        {
            if (gameOver == false)
            {

                if (MoveShipLeft(ship.MoveLeft) == true || MoveShipRight(ship.MoveRight) == true)
                {
                    ship.Update();
                }

                alien.Update();

                drawables.Add(ship);
                for(int i = 0; i < 10; i++)
                {
                    drawables.Add(AlienList[i]);
                }
                if (Gamepad.Gamepads.Count > 0)
                {
                    controller = Gamepad.Gamepads.First();
                    var reading = controller.GetCurrentReading();
                    if (reading.Buttons.HasFlag(GamepadButtons.A))
                    {
                        lasers.ShootLaser(laserImage, ship);
                        lasers.Update(laserImage);
                        lasers = new Lasers(lasers.X, lasers.Y, laserImage);
                        drawables.Add(lasers);
                    }
                }
                Collide(lasers, AlienList);

                gameOver = HitAll(AlienList); //if gameOver turns true, should quit

                if (gameOver == false)
                {
                    int lastAlienToTouch = 0;
                    for (int index = 1; index <= 10; index++)
                    {
                        if (AlienList[index - 1].GotHit == false && AlienList[index - 1].Y == 400)
                        {
                            lastAlienToTouch = index - 1;

                            if (score.LivesLeft == 0)
                            {
                                gameOver = true;
                            }

                        }
                    }
                }
            }
        }

        public bool HitAll(List<Alien> AlienList)
        {
            int NumberOfDeadAliens = 0;
            for(int index = 0; index < 10; index++)
            {
                if (AlienList[index].GotHit == true)
                {
                    NumberOfDeadAliens++;
                }
            }
            if (NumberOfDeadAliens == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FillAlienList(CanvasBitmap alienImage, List<Alien> AlientList)
        {
            AlienList = Enumerable.Repeat(new Alien(400,400, alienImage), 10).ToList();
            for (int index = 0; index < 10; index++)
            {
                AlienList[index] = new Alien((400 +(60*index)), 200, alienImage);
                AlienList[index].GotHit = false;
            }
        }


        public void Collide(Lasers Laser, List<Alien> AlientList)
        {
            for (int index = 0; index < 10; index++)
            {
                if (lasers.Y == AlienList[index].Y && lasers.X == AlienList[index].X) 
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


        public void SetShipTravelingLeftward(bool travelingLeftward)
        {
            ship.MoveLeft = travelingLeftward;
        }

        public void SetShipTravelingRightward(bool travelingRightward)
        {
            ship.MoveRight = travelingRightward;
        }


    }











}
