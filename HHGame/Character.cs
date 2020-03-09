using System;
using System.Collections.Generic;
using System.Text;

namespace HHGame
{
    class Character
    {
        private string name;
        private int health;
        private int x;
        private int y;
        private int level;

        public Character(string Name = "Witcher", int X = 5, int Y = 2)
        {
            this.name = Name;
            this.health = 100;
            this.x = X;
            this.y = Y;
            this.level = 1;
            Console.WriteLine($"Object {this.name} was created at {this.Coordinates}.");
        }
        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.Y = value;
            }
        }
        public void LevelCheck(Character ch)
        {
            Console.WriteLine($"This hero {this.name} has {this.level} level.");
        }
        //Проверка на дохлость
        public bool IsAlive
        {
            get
            {
                return this.health > 0 ? true : false;
            }
        }
        //Движение
        public void Move(string direction)
        {
            switch (direction)
            {
                case "d":
                    this.x++;
                    break;
                case "a":
                    this.x--;
                    break;
                case "w":
                    this.y++;
                    break;
                case "s":
                    this.y--;
                    break;
            }
        }

        public void Atack(Character a, Character b)
        {
            Random rand = new Random();
            while (a.IsAlive && b.IsAlive)
            {
                int aa = rand.Next(1, 36);
                int bb = rand.Next(1, 21);
                b.health = b.health - aa;
                Console.WriteLine($"HP[{b.health}] Damage to Ork: {aa}");
                if (!b.IsAlive) break;
                a.health = a.health - bb;
                Console.WriteLine($"HP[{a.health}] Damage to You: {bb}");
            }
            int i = 0;
            if (a.IsAlive)
            {
                Console.WriteLine("Вы победили вонючего орка! ДА!!!");
                level += 1;
                i = rand.Next(1, 71);
                a.health += i;
                Console.WriteLine($"Вы получили новый уровень {level}, ваше HP увеличено на {i} и теперь у вас {a.health} здоровья");
            }
            else
            {
                Console.WriteLine("О нет, вы програли. Но это не конец!");
                while (i < 10)
                {
                    Console.Write("ПОБРОБУЙ СНОВА ");
                    i++;
                }
            }


        }
        // Координаты перса
        public string Coordinates
        {
            get
            {
                int a = this.x;
                int b = this.y;
                string s = string.Empty;
                return s = $"[{a}, {b}]";
            }

        }
        // Мы даём как аргумент одного из перснонажей в нашем классе и сравниваем координаты. Как я понял, это для драчки. 
        // Если координаты мпс или врага совпадают, то мы с кем-то встретились и можем проводить какие-нибудь действия.
        // Используется это так: bool collide = hero.Collide(npc); <npc - это наш новый перс>
        public bool Collide(Character ch)
        {
            if (ch.X == x && ch.Y == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Start()
        {
            Console.WriteLine();
            Console.Write(new string('-', 40));
            Console.Write("Game started!");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
            Console.Write(new string('-', 5));
            Console.WriteLine("Ваша задача убить всех орков");
            Console.Write(new string('-', 5));
            Console.WriteLine("За убийство орка вам будет начисляться новый уровень!");
            Console.Write(new string('-', 5));
            Console.WriteLine("А всместе с ним повышаться HP");
            Console.WriteLine();
            Console.Write(new string('-', 5));
            Console.Write("Удачи юный Рыцарь!");
            Console.WriteLine(new string('-', 5));
            Console.WriteLine();
        }
    }
}
