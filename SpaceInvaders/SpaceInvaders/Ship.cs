using System;
using Microsoft.Graphics.Canvas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input;

namespace SpaceInvaders
{

    public class Ship : IImage, ICollidable
    {
        public CanvasBitmap shipImage;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public bool MoveLeft { get; set; }
        public bool MoveRight { get; set; }

        public Ship(int x, int y, CanvasBitmap image)
        {
            X = x;
            Y = y;
            MoveLeft = false;
            MoveRight = false;
            this.shipImage = image;
        }

        public void Update()
        {
            if (MoveRight && X > 443 && X < 921)
            {
                X += 1;
            }
            else if (MoveLeft && X > 443 && X < 921)
            {
                X -= 1;
            }
        }

        public bool CollidesLeftEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        public bool CollidesRightEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
        public void Image(CanvasDrawingSession canvas)
        {
            canvas.DrawImage(shipImage, X, Y);
        }

        
    }

    public interface ICollidable
    {
        bool CollidesLeftEdge(int x, int y);
        bool CollidesRightEdge(int x, int y);
    }

    
}