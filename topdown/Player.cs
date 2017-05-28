using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topdown
{
    class Player : DrawableGameComponent
    {
        private Vector2 position;
        private int hp = 0;
        
        public Player(Game game) : base (game)
        {

        }


    }
}
