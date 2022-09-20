using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3,
        Sumshue = 4
    }

    internal class Player : Creature
    {
        protected PlayerType _PlayerType = PlayerType.None;

        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            _PlayerType = type;
        }

        public PlayerType GetPlayerType() { return _PlayerType; }
    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            int randLUK = _Random.Next(0, 11);
            SetInfo(100, 10, randLUK);
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            int randLUK = _Random.Next(0, 11);
            SetInfo(75, 12, randLUK);
        }
    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            int randLUK = _Random.Next(0, 11);
            SetInfo(50, 15, randLUK);
        }
    }

    class Sumshue : Player
    {
        public Sumshue() : base(PlayerType.Sumshue)
        {
            SetInfo(10, 1, 10);
        }
    }
}
