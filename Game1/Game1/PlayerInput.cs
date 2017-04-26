using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class PlayerInput
    {
        public Keys Duck;
        public Keys Jump;
        public Keys Kick;
        public Keys Punch;
        public Keys WalkLeft;
        public Keys WalkRight;
        public PlayerIndex index;
        

        public PlayerInput(Keys walkright, Keys walkleft, Keys duck, Keys jump, Keys punch, Keys kick, PlayerIndex index)
        {
            this.WalkRight = walkright;
            this.WalkLeft = walkleft;
            this.Duck = duck;
            this.Jump = jump;
            this.Punch = punch;
            this.Kick = kick;
            this.index = index;
        }
    }
}