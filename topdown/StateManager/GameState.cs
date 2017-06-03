using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topdown.StateManager { 
    public interface IGameState
    {
        GameState Inst { get; }
        PlayerIndex? PlayerIndexInControl { get; set; }
    }

    public abstract partial class GameState : DrawableGameComponent, IGameState
    {
        #region Field Region
        protected GameState inst;
        protected readonly IStateManager manager;
        protected ContentManager content;
        protected readonly List<GameComponent> childComponents;

        protected PlayerIndex? indexInControl;
        public PlayerIndex? PlayerIndexInControl
        {
            get { return indexInControl; }
            set { indexInControl = value; }
        }

        public List<GameComponent> Components
        {
            get { return childComponents; }
        }
        public GameState Inst
        {
            get { return inst; }
        }
   
        #endregion

        #region Constructor Region

        public GameState(Game game) : base(game)
        {
            inst = this;

            content = Game.Content;
            childComponents = new List<GameComponent>();
        }


        #endregion

        #region Method Region
        protected override void LoadContent()
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

        protected internal virtual void StateChanged(object sender, EventArgs e)
        {
            if (manager.CurrentState == inst)
                Show();
            else
                Hide();
        }

        protected internal virtual void Show()
        {
            Enabled = true;
            Visible = true;

            foreach (GameComponent component in childComponents)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = true;
            }
        }

        public virtual void Hide()
        {
            Enabled = false;
            Visible = false;
            foreach (GameComponent component in childComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = false;
            }
        }
        #endregion

    }
}