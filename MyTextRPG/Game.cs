using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public enum GameMode
    {
        None = 0,
        Lobby = 1,
        Town = 2,
        Field = 3
    }

    internal class Game
    {
        private GameMode _GameMode = GameMode.Lobby;
        private Player _player = null;
        private Monster _monster = null;
        private Random _rand = new Random();

        public void Process()
        {
            switch (_GameMode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        public void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    _player = new Knight();
                    _GameMode = GameMode.Town;
                    break;
                case "2":
                    _player = new Archer();
                    _GameMode = GameMode.Town;
                    break;
                case "3":
                    _player = new Mage();
                    _GameMode = GameMode.Town;
                    break;
                case "807":
                    Console.WriteLine("히든 클래스를 발견했습니다!");
                    _player = new Sumshue();
                    _GameMode = GameMode.Town;
                    break;
            }
        }

        public void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다!");
            Console.WriteLine("[1] 필드로 접속하기");
            Console.WriteLine("[2] 로비로 돌아가기");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    _GameMode = GameMode.Field;
                    break;
                case "2":
                    _GameMode = GameMode.Lobby;
                    break;
            }
        }

        public void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다!");
            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 일정확률로 마을로 도망치기");

            CreateRandomMonster();

            Console.WriteLine($"몬스터의 치명타 확률 {10 + _monster.GetLUK() * 2}%");
            Console.WriteLine($"플레이어가 마을로 도망칠 확률 {33 + _player.GetLUK() * 3}%");
            
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    ProcessTryEscape();
                    break;
            }
        }

        public void CreateRandomMonster()
        {
            int randValue = _rand.Next(0, 3);
            switch (randValue)
            {
                case 0:
                    _monster = new Slime();
                    Console.WriteLine("슬라임이 생성되었습니다!");
                    break;
                case 1:
                    _monster = new Orc();
                    Console.WriteLine("오크가 생성되었습니다!");
                    break;
                case 2:
                    _monster = new Skeleton();
                    Console.WriteLine("스켈레톤이 생성되었습니다!");
                    break;
            }
        }

        public void ProcessFight()
        {
            while (true)
            {
                int damage = _player.GetAttack();
                _monster.OnDamaged(damage);
                if (_monster.IsDead())
                {
                    Console.WriteLine("승리했습니다!");
                    Console.WriteLine($"남은 체력 {_player.GetHp()}");
                    break;
                }

                CriticalAttack();
                if (_player.IsDead())
                {
                    Console.WriteLine("패배했습니다!");
                    _GameMode = GameMode.Lobby;
                    break;
                }
            }
        }

        public void ProcessTryEscape()
        {
            int randValue = _rand.Next(0, 101);
            if (randValue <= 33 + (_player.GetLUK()) * 3) // 확률 33% + (플레이어의 LUK * 3)% -> 최대 66%
            {
                Console.WriteLine("도망치는데 성공했습니다!");
                _GameMode = GameMode.Town;
            }
            else
            {
                Console.WriteLine("도망치는데 실패했습니다!");
                ProcessFight();
            }
        }

        public void CriticalAttack()
        {
            int randValue = _rand.Next(0, 101);
            int damage = _monster.GetAttack();

            if(randValue<=10 + _monster.GetLUK() * 2) // 확률 10% + (몬스터의 LUK * 2)% -> 최대 30%
            {
                Console.WriteLine("몬스터의 치명타 공격!");
                damage *= 2;
            }

            _player.OnDamaged(damage);
        }
    }
}
