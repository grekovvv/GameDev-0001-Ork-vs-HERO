using System;
using System.Threading;

namespace HHGame

{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Random rand = new Random();
            Character hero = new Character("Witcher", rand.Next(1, 11), rand.Next(1, 11));
            hero.LevelCheck(hero);
            Character ork = new Character("Ork", rand.Next(1, 11), rand.Next(1, 11));
            Character ork2 = new Character("Ork", rand.Next(1, 11), rand.Next(1, 11));
            Character ork3 = new Character("Ork", rand.Next(1, 11), rand.Next(1, 11));
            hero.Start();
            //Движение нашего перса, до exit. 
            while (command != "exit")
            {
                Console.WriteLine($"You are at {hero.Coordinates}. Where to go?");
                command = Console.ReadLine();
                hero.Move(command);
                if (hero.Collide(ork))
                {
                    hero.Atack(hero, ork);
                }
                if (hero.Collide(ork2))
                {
                    hero.Atack(hero, ork2);
                }
                if (hero.Collide(ork3))
                {
                    hero.Atack(hero, ork3);
                }
                if (!ork.IsAlive && !ork2.IsAlive && !ork3.IsAlive)
                {
                    Console.Write(new string('-', 10));
                    Console.Write("Вы победили Всех орков, теперь вы настоящий рыцарь!!!");
                    Console.WriteLine(new string('-', 10));
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("$$$ ПОПРОБУЙ ЕЩЁ РАЗ $$$ ПОПРОБУЙ ЕЩЁ РАЗ $$$ ПОПРОБУЙ ЕЩЁ РАЗ $$$");
                Thread.Sleep(800);
            }

        }
    }
}

