using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topdown.StateManager
{
    public abstract partial class GameState : DrawableGameComponent
    {
        #region Field Region
        protected GameState inst;
        protected readonly IStateManager manager;
        protected ContentManager content;
        protected readonly List<GameComponent> childComponents;
        #endregion

        #region Constructor Region
        public GameState(Game game) : base(game)
        {
            inst = this;

            content = Game.Content;
            childComponents = new List<GameComponent>();
        }


        #endregion

        #region Method Region        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent component in childComponents)
                if (component.Enabled)
                    component.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            foreach (GameComponent component in childComponents)
                if (component is DrawableGameComponent && ((DrawableGameComponent) component).Visible)
                    ((DrawableGameComponent)component).Draw(gameTime);
        }



    }
}