using System;
using System.Collections.Generic;

namespace Task2._8_Game
{
    using System;
    class Field
    {
        protected Int32 _height;
        protected Int32 _width;
        protected Int32[,] _field;
        public Field()
        {
            _height = 100;
            _width = 100;
            _field = new Int32[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    _field[i, j] = 0;
            }
        }
        public Int32 Height
        {
            set { _height = value; }
            get { return _height; }
        }
        public Int32 Width
        {
            set { _width = value; }
            get { return _width; }
        }
        public Int32[,] field
        {
            get { return _field; }
        }

    }
    abstract class Bonus
    {
        protected Int32 _x;
        protected Int32 _y;
        protected Int32 _addhealth;
        public Int32 Addhealth
        {
            get { return _addhealth; }
        }
        public Int32 x
        {
            get { return _x; }
            set { x = value; }
        }
        public Int32 y
        {
            get { return _y; }
            set { y = value; }
        }
    }
    class Apple : Bonus
    {
        public Apple(int x, int y)
        {
            _x = x;
            _y = y;
            _addhealth = 50;
        }
    }
    class Cherry : Bonus
    {
        public Cherry(int x, int y)
        {
            _x = x;
            _y = y;
            _addhealth = 25;
        }
    }
    abstract class GameCharacter
    {
        protected Int32 _x;
        protected Int32 _y;
        protected Int32 _health;
        protected Int32 _damage;

        public virtual void Move(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Int32 x
        {
            get { return _x; }
            set { _x = value; }
        }
        public Int32 y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Int32 Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public Int32 Damage
        {
            get { return _damage;}
        }

    }
    class Player : GameCharacter
    {
        public Player(int w, int h)
        {
            _x = w;
            _y = h;
            _health = 100;
            _damage = 30;
        }
        public override void Move(int w, int h)
        {
            Random rndx = new Random();
            Random rndy = new Random();
            int tmpx=rndx.Next(x - 1, x + 1);
            int tmpy=rndy.Next(y - 1, y + 1);
            if (tmpx < w)
            {
                if (tmpx > 0)
                    x = tmpx;
                else x=tmpx+1;
            }
            else x=tmpx-1;
            if (tmpy < h)
            {
                if (tmpy > 0)
                    y = tmpy;
                else y=tmpy+1;
            }
            else y=tmpy-1;
        }
    }
    class Wolf : GameCharacter
    {
        public Wolf(int x, int y)
        {
            _x = x;
            _y = y;
            _health = 100;
            _damage = 5;
        }
        public override void Move(int w, int h)
        {
            Random rndx = new Random();
            Random rndy = new Random();
            int tmpx = rndx.Next(x - 1, x + 1);
            int tmpy = rndy.Next(y - 1, y + 1);
            if (tmpx < w)
            {
                if (tmpx > 0)
                    x = tmpx;
                else x = tmpx + 1;
            }
            else x = tmpx - 1;
            if (tmpy < h)
            {
                if (tmpy > 0)
                    y = tmpy;
                else y = tmpy + 1;
            }
            else y = tmpy - 1;
        }
    }
    class Bear : GameCharacter
    {
        public Bear(int x, int y)
        {
            _x = x;
            _y = y;
            _health = 100;
            _damage = 10;
        }
        public override void Move(int w, int h)
        {
            Random rndx = new Random();
            Random rndy = new Random();
            int tmpx = rndx.Next(x - 1, x + 1);
            int tmpy = rndy.Next(y - 1, y + 1);
            if (tmpx < w)
            {
                if (tmpx > 0)
                    x = tmpx;
                else x = tmpx + 1;
            }
            else x = tmpx - 1;
            if (tmpy < h)
            {
                if (tmpy > 0)
                    y = tmpy;
                else y = tmpy + 1;
            }
            else y = tmpy - 1;
        }
    }
    abstract class Let
    {
        protected Int32 _x;
        protected Int32 _y;
    }
    class Tree : Let
    {
        public Tree(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
    class Stone : Let
    {
        public Stone(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
    public class Program
    {
        private static Wolf CreateWolf(Field f)
        {
            Random rnd = new Random();
            Wolf wolf;
            int x;
            int y;
            while (true)
            {
                x = rnd.Next(0, f.Width);
                y = rnd.Next(0, f.Height);
                if (f.field[x, y] == 0)
                {
                   wolf=new Wolf(x, y);
                   f.field[x, y] = 5;
                  break;
                }
            }
            Console.WriteLine("Координаты волка ({0},{1})",x,y);
            return wolf;
        }

        private static Bear CreateBear(Field f)
        {
            Random rnd = new Random();
            Bear bear;
            int x;
            int y;
            while (true)
            {
               x = rnd.Next(0, f.Width);
               y = rnd.Next(0, f.Height);
               if (f.field[x, y] == 0)
               {
                    bear=new Bear(x, y);
                    f.field[x, y] = 6;
                    break;
               }
            }
            Console.WriteLine("Координаты медведя ({0},{1})", x, y);
            return bear;
        }

        private static Tree CreateTree(Field f)
        {
            Random rnd = new Random();
            Tree tree;
            int x;
            int y;
            while (true)
            {
                x = rnd.Next(0, f.Width);
                y = rnd.Next(0, f.Height);
                if (f.field[x, y] == 0)
                {
                    tree=new Tree(x, y);
                    f.field[x, y] = 1;
                    break;
                }

            }
            Console.WriteLine("Координаты дерева ({0},{1})", x, y);
            return tree;
        }
        private static Stone CreateStone(Field f)
        {
            Random rnd = new Random();
            Stone stone;
            int x;
            int y;
            while (true)
            {
                x = rnd.Next(0, f.Width);
                y = rnd.Next(0, f.Height);
                if (f.field[x, y] == 0)
                {
                    stone=new Stone(x, y);
                    f.field[x, y] = 2;
                    break;
                }
            }
            Console.WriteLine("Координаты камня ({0},{1})", x, y);
            return stone;
        }

        private static Apple CreateApple(Field f)
        {
            Random rnd = new Random();
            Apple apple;
            int x;
            int y;
            while (true)
            {
                x = rnd.Next(0, f.Width);
                y = rnd.Next(0, f.Height);
                if (f.field[x, y] == 0)
                {
                    apple=new Apple(x, y);
                    f.field[x, y] = 3;
                    break;
                }
            }
            Console.WriteLine("Координаты яблока ({0},{1})", x, y);
            return apple;
        }

        private static Cherry CreateCherry(Field f)
        {
            Random rnd = new Random();
            Cherry cherry;
            int x;
            int y;
            while (true)
            {
                x = rnd.Next(0, f.Width);
                y = rnd.Next(0, f.Height);
                if (f.field[x, y] == 0)
                {
                    cherry=new Cherry(x, y);
                    f.field[x, y] = 4;
                    break;
                }
            }
            Console.WriteLine("Координаты вишни ({0},{1})", x, y);
            return cherry;
        }

        private static Int32 Check(Field f, int x, int y)
        {
           return f.field[x, y];
        }

        public static void Main()
        {

            //Приблизительная реализация игры. Полностью не закончена, т.к. условия задачи этого не требуют
            Field field = new Field();
            Player player = new Player(field.Width, field.Height);
            Wolf wolf = CreateWolf(field);
            Bear bear=CreateBear(field);
            Tree tree=CreateTree(field);
            Stone stone = CreateStone(field);
            Apple apple = CreateApple(field);
            Cherry cherry = CreateCherry(field);
            while (true)
            {
                player.Move(field.Width, field.Height);
                Console.WriteLine("Игрок сделал шаг его координаты ({0},{1})", player.x, player.y);
                if (Check(field, player.x, player.y) == 1)
                    Console.WriteLine("Игрок уперся в дерево");
                else if (Check(field, player.x, player.y) == 2)
                    Console.WriteLine("Игрок уперся в камень");
                else if (Check(field, player.x, player.y) == 3)
                {
                    Console.WriteLine("Игрок нашел яблоко");
                    player.Health = player.Health + apple.Addhealth;
                    Console.WriteLine("Здоровье игрока = {0}", player.Health);
                    field.field[apple.x, apple.y] = 0;
                }
                else if (Check(field, player.x, player.y) == 4)
                {
                    Console.WriteLine("Игрок нашел вишню");
                    player.Health = player.Health + cherry.Addhealth;
                    Console.WriteLine("Здоровье игрока = {0}", player.Health);
                    field.field[cherry.x, cherry.y] = 0;
                }
                else if (Check(field, player.x, player.y) == 5)
                {
                    Console.WriteLine("Игрок встретился с волком");
                    player.Health = player.Health - wolf.Damage;
                    wolf.Health = wolf.Health - player.Damage;
                    Console.WriteLine("Здоровье игрока = {0}", player.Health);
                    Console.WriteLine("Здоровье волка = {0}", wolf.Health);
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("Игрок погиб! Игра окончена!");
                        break;
                    }
                    if (wolf.Health <= 0)
                        field.field[wolf.x, wolf.y] = 0;
                }
                else if (Check(field, player.x, player.y) == 5)
                {
                    Console.WriteLine("Игрок встретился с медведем");
                    player.Health = player.Health - bear.Damage;
                    bear.Health = bear.Health - player.Damage;
                    Console.WriteLine("Здоровье игрока = {0}", player.Health);
                    Console.WriteLine("Здоровье медведя = {0}", bear.Health);
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("Игрок погиб! Игра окончена!");
                        break;
                    }
                    if (bear.Health <= 0)
                        field.field[bear.x, bear.y] = 0;
                }
                bear.Move(field.Width, field.Height);
                Console.WriteLine("Медведь сделал шаг его координаты ({0},{1})", bear.x, player.y);
                if (Check(field, bear.x, bear.y) == 1)
                    Console.WriteLine("Медведь уперся в дерево");
                else if (Check(field, bear.x, bear.y) == 2)
                    Console.WriteLine("Медведь уперся в камень");
                
            }
        }
    }

}



