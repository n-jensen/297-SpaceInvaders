using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceInvaders
{
     public interface IImage
     {
          //do I create a new image? Or get implement the image creation task from .xaml.cs (ship, alien, laser)
          bool Image(TaskCreationOptions image);
     }
     public interface ICollidable
     {
          bool Collide(int x, int y, int height, int width);
     }
    public class SI //Space Invaders
    {
          private List<Alien> alien;
          private Ship ship;
          private Lasers lasers;
          private Score score;

          public SI()
          {
               alien = new List<Alien>();
               ship = new Ship();
               
          }

     }
     public class Alien : ICollidable
     {
          //alien IImage: image, area, hit yes/no
          //need multiple aliens all at one t
          public int X { get; set; }
          public int Y { get; set; }

          public Alien()
          {

          }

     }

     public class Ship : ICollidable
     {

          public Ship()
          {
               //create a picture of a ship here
               //only one ship is used throughout the game
               
          }

     }



     public class Score
     {

     }





     public bool Update()
     {
          //Add 100 aliens/ multiple rows (4)

          //if ship collides with alien
               //alien dies, score++
          //if alien hits ship
               //ship dies, trigger noise / end game
          //if all aliens go off screen
               //end game, score finished
     }
}
