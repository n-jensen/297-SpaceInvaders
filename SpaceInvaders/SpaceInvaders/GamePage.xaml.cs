using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpaceInvaders
{
     /// <summary>
     /// An empty page that can be used on its own or navigated to within a Frame.
     /// </summary>
     public sealed partial class GamePage : Page
     {
        public CanvasBitmap AlienImage;
        public CanvasBitmap ShipImage;
        public CanvasBitmap LaserImage;
        SI Si;

        public GamePage()
        {
               this.InitializeComponent();
        }

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {
            
            //args.DrawingSession.DrawImage(ShipImage, 400, 500);    
            //args.DrawingSession.DrawImage(AlienImage, 400, 500);
            //args.DrawingSession.DrawRectangle(LaserImage, 200, 300);

            Si.DrawGame(args.DrawingSession);

        }

        //2nd
        private async Task CreateResourcesAsync(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender)
        {
            ShipImage = await CanvasBitmap.LoadAsync(sender, "Assets/laserCharnesky.PNG");
            AlienImage = await CanvasBitmap.LoadAsync(sender, "Assets/chalkboardGirlAlien.PNG");
            LaserImage = await CanvasBitmap.LoadAsync(sender, "Assets/Redf.png");

            Si = new SI(AlienImage, ShipImage, LaserImage);
        }

       private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
        {
            Si.Update(AlienImage, ShipImage, LaserImage);
        }

        //first
        private void Canvas_CreateResources_1(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());

        }

        private void Canvas_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {

            if (e.VirtualKey == Windows.System.VirtualKey.Right)
            {
                Si.MoveShipRight(true);
            }

        }
        private void Canvas_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {
            if (e.VirtualKey == Windows.System.VirtualKey.Left)
            {
                Si.MoveShipLeft(true);
            }
        }

    }
}
