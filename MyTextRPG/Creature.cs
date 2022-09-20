using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public enum CreatureType
    {
        None = 0,
        Player = 1,
        Monster = 2
    }

    internal class Creature
    {
        protected CreatureType _type;
        protected int _hp = 0;
        protected int _attack = 0;
        protected int _LUK = 0;
        protected Random _Random = new Random();

        protected Creature(CreatureType type)
        {
            _type = type;
        }

        public void SetInfo(int hp, int attack, int LUK)
        {
            _hp = hp;
            _attack = attack;
            _LUK = LUK;
        }


        public int GetHp() { return _hp; }
        public int GetAttack() { return _attack; }
        public int GetLUK() { return _LUK; }

        public void OnDamaged(int damage)
        {
            _hp -= damage;
            if (_hp < 0)
                _hp = 0;
        }

        public bool IsDead() { return _hp <= 0; }

    }
}
