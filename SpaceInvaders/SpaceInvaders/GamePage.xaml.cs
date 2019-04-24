using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
          public CanvasBitmap alien;
          public CanvasBitmap ship;
          public CanvasBitmap laser;

          public GamePage()
          {
               this.InitializeComponent();
          }

          private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
          {

          }

          private void Canvas_CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
          {
               args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
          }

          private async Task CreateResourcesAsync(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender)
          {
               ship = await CanvasBitmap.LoadAsync(sender, "Assets/Images/laserCharnesky.PNG");
               alien = await CanvasBitmap.LoadAsync(sender, "Assets/Images/chalkboardGirlAlien.PNG");
               laser = await CanvasBitmap.LoadAsync(sender, "Assets/Images/RedF.PNG");

          }

          private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
          {

          }






     }
}
