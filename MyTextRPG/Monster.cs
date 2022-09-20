using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3
    }

    internal class Monster:Creature
    {
        protected MonsterType _MonsterType = MonsterType.None;

        protected Monster(MonsterType type) : base(CreatureType.Monster)
        {
            _MonsterType = type;
        }

        public MonsterType GetMonsterType() { return _MonsterType; }
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            int randLUK = _Random.Next(0, 11);
            SetInfo(20, 5, randLUK);
        }
    }

    class Orc : Monster
    {
        public Orc() : base(MonsterType.Slime)
        {
            int randLUK = _Random.Next(0, 11);
            SetInfo(50, 8, randLUK);
        }
    }

    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Slime)
        {
            int randLUK = _Random.Next(0, 11);
            SetInfo(30, 12, randLUK);
        }
    }
}
