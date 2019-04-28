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
