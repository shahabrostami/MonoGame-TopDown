using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using topdown.AvatarComponents;

namespace topdown.Components.AvatarComponents
{
    public enum AvatarElement
    {
        Dark, Earth, Fire, Light, Water, Wind
    }

    class Avatar
    {
        #region Field Region
        private static Random random = new Random();
        private Texture2D texture;
        private string name;
        private AvatarElement element;
        private int level;
        private long experience;
        private int costToBuy;
        private int speed;
        private int attack;
        private int defense;
        private int health;
        private int currentHealth;
        private List<IMove> effects;
        private Dictionary<string, IMove> knownMoves;


        #endregion
        #region Property Region
        public string Name
        {
            get { return name; }
        }

        public int Level
        {
            get { return level; }
            set { level = (int)MathHelper.Clamp(value, 1, 100); }
        }

        public long Experience
        {
            get { return experience; }
        }

        public Texture2D Texture
        {
            get { return texture; }
        }

        public Dictionary<string, IMove> KnownMoves
        {
            get { return knownMoves; }
        }

        public AvatarElement Element
        {
            get { return element; }
        }

        public List<IMove> Effects
        {
            get { return effects; }
        }

        public static Random Random
        {
            get { return random; }
        }

        public int BaseAttack
        {
            get { return attack; }
        }

        public int BaseDefense
        {
            get { return defense; }
        }

        public int BaseSpeed
        {
            get { return speed; }
        }

        public int BaseHealth
        {
            get { return health; }
        }

        public int CurrentHealth
        {
            get { return currentHealth; }
        }

        public bool Alive
        {
            get { return (currentHealth > 0); }
        }
        #endregion

        #region Constructor Region
        private Avatar()
        {
            level = 1;
            knownMoves = new Dictionary<string, IMove>();
            effects = new List<IMove>();
        }
        #endregion

        public void ResoleveMove(IMove move, Avatar target)
        {
            bool found = false;
            switch (move.Target)
            {
                case Target.Self:
                    if (move.MoveType == MoveType.Buff)
                    {
                        found = false;
                        for (int i = 0; i < effects.Count; i++)
                        {
                            if (effects[i].Name == move.Name)
                            {
                                effects[i].Duration += move.Duration;
                                found = true;
                            }
                        }
                        if (!found)
                            effects.Add((IMove)move.Clone());
                    }
                    else if (move.MoveType == MoveType.Heal)
                    {
                        currentHealth += move.Health;
                        if (currentHealth > health)
                            currentHealth = health;
                    }
                    else if (move.MoveType == MoveType.Status)
                    {
                    }
                    break;

                case Target.Enemy:
                    if (move.MoveType == MoveType.Debuff)
                    {
                        found = false;
                        for (int i = 0; i < target.Effects.Count; i++)
                        {
                            if (target.Effects[i].Name == move.Name)
                            {
                                target.Effects[i].Duration += move.Duration;
                                found = true;
                            }
                        }
                        if (!found)
                            target.Effects.Add((IMove)move.Clone());
                    }
                    else if (move.MoveType == MoveType.Attack)
                    {
                        float modifier = GetMoveModifier(move.MoveElement, target.Element);
                        float tDamage = GetAttack() + move.Health * modifier -
                       target.GetDefense();
                        if (tDamage < 1f)
                            tDamage = 1f;
                        target.ApplyDamage((int)tDamage);
                    }
                    break;
            }
        }
    }
}
