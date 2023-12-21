using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();
    }
}

class Game
{
    private Player player;
    private List<Enemy> enemies;
    private HealthPack healthPack;
    private Buff buff;
    private Boss boss;

    public Game()
    {
        player = new Player();
        enemies = GenerateEnemies();
        healthPack = new HealthPack();
        buff = new Buff();
        boss = null;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("Добро пожаловать в Консольный RPG!");
        Console.WriteLine("Нажмите Enter, чтобы начать, или Q, чтобы выйти.");

        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.Enter)
        {
            while (true)
            {
                Console.Clear();
                DisplayGameInfo();
                DisplayGame();
                ConsoleKeyInfo moveKey = Console.ReadKey();
                if (moveKey.Key == ConsoleKey.Q)
                {
                    SaveProgress();
                    Console.WriteLine("Игра сохранена. Нажмите любую клавишу для выхода.");
                    Console.ReadKey();
                    break;
                }
                else if (moveKey.Key == ConsoleKey.B)
                {
                    player.ActivateBuff();
                }
                else
                {
                    player.Move(moveKey);
                    CheckCollision();
                    if (enemies.Count == 0 && boss == null)
                    {
                        GenerateBoss();
                    }
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
    }

    private void DisplayGameInfo()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Игрок: Здоровье - {player.Health}, Опыт - {player.XP}, Бафф {(player.IsBuffActive ? "активен" : "неактивен")}");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Аптечка: X - {healthPack.X}, Y - {healthPack.Y}");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Бафф: X - {buff.X}, Y - {buff.Y}, {(buff.IsActive ? "активен" : "неактивен")}");

        Console.ResetColor();
    }

    private void DisplayGame()
    {
        foreach (Enemy enemy in new List<Enemy>(enemies))
        {
            Console.SetCursorPosition(enemy.X, enemy.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("В");
        }

        Console.SetCursorPosition(healthPack.X, healthPack.Y);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("А");

        Console.SetCursorPosition(buff.X, buff.Y);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Б");

        if (boss != null)
        {
            Console.SetCursorPosition(boss.X, boss.Y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Босс");
        }

        Console.SetCursorPosition(player.X, player.Y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("И");
        Console.ResetColor();
    }

    private void CheckCollision()
    {
        
        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy enemy = enemies[i];
            if (player.X == enemy.X && player.Y == enemy.Y)
            {
                Combat(player, enemy);
            }
        }

        
        if (player.X == healthPack.X && player.Y == healthPack.Y)
        {
            player.Heal(healthPack.Amount);
            healthPack.Respawn();
        }

       
        if (player.X == buff.X && player.Y == buff.Y)
        {
            player.ActivateBuff();
            buff.Respawn();
        }

        
        if (boss != null && player.X == boss.X && player.Y == boss.Y)
        {
            CombatBoss(player, boss);
            if (boss.Health <= 0)
            {
                Console.Clear();
                DisplayGameInfo();
                DisplayGame();
                Console.WriteLine("Поздравляем! Вы победили Босса! Игра пройдена.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        
        if (player.X < 0) player.X = 0;
        if (player.X > 29) player.X = 29;
        if (player.Y < 0) player.Y = 0;
        if (player.Y > 15) player.Y = 15;
    }

    private void Combat(Player player, Enemy enemy)
    {
        while (player.Health > 0 && enemy.Health > 0)
        {
            Console.Clear();
            DisplayGameInfo();
            DisplayGame();
            Console.WriteLine($"Игрок: Здоровье - {player.Health}, Опыт - {player.XP}");
            Console.WriteLine($"Противник: Здоровье - {enemy.Health}");
            Console.WriteLine("Нажмите любую клавишу для продолжения битвы...");

            Console.ReadKey();

            player.TakeDamage(enemy.Attack());
            enemy.TakeDamage(player.Attack());
        }

        if (player.Health <= 0)
        {
            Console.WriteLine("Вы были повержены! Игра окончена.");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine($"Вы победили противника! Получено {enemy.XP} Опыта.");
            player.GainXP(enemy.XP);
            enemies.Remove(enemy);
        }
    }

    private void CombatBoss(Player player, Boss boss)
    {
        while (player.Health > 0 && boss.Health > 0)
        {
            Console.Clear();
            DisplayGameInfo();
            DisplayGame();
            Console.WriteLine($"Игрок: Здоровье - {player.Health}, Опыт - {player.XP}");
            Console.WriteLine($"Босс: Здоровье - {boss.Health}");
            Console.WriteLine("Нажмите любую клавишу для продолжения битвы...");

            Console.ReadKey();

            player.TakeDamage(boss.Attack());
            boss.TakeDamage(player.Attack());
        }

        if (player.Health <= 0)
        {
            Console.WriteLine("Вы были повержены! Игра окончена.");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine($"Вы победили Босса! Получено {boss.XP} Опыта.");
            player.GainXP(boss.XP);
        }
    }

    private List<Enemy> GenerateEnemies()
    {
        List<Enemy> generatedEnemies = new List<Enemy>();
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            int x = random.Next(0, 30);
            int y = random.Next(0, 15);
            generatedEnemies.Add(new Enemy(x, y));
        }

        return generatedEnemies;
    }

    private void GenerateBoss()
    {
        boss = new Boss();
        Console.WriteLine("Появился Босс! Будьте осторожны.");
        Console.ReadKey();
    }

    private void SaveProgress()
    {
        using (StreamWriter writer = new StreamWriter("save.txt"))
        {
            writer.WriteLine($"{player.X},{player.Y},{player.Health},{player.XP},{(player.IsBuffActive ? 1 : 0)}");
            foreach (Enemy enemy in enemies)
            {
                writer.WriteLine($"{enemy.X},{enemy.Y},{enemy.Health}");
            }
            writer.WriteLine($"{healthPack.X},{healthPack.Y}");
            writer.WriteLine($"{buff.X},{buff.Y},{(buff.IsActive ? 1 : 0)}");
        }
    }
}

class Player
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    public int Health { get; set; } = 50;
    public int XP { get; set; } = 0;
    public bool IsBuffActive { get; private set; } = false;

    public void Move(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (Y > 0) Y--;
                break;
            case ConsoleKey.DownArrow:
                if (Y < 15) Y++;
                break;
            case ConsoleKey.LeftArrow:
                if (X > 0) X--;
                break;
            case ConsoleKey.RightArrow:
                if (X < 29) X++;
                break;
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void ActivateBuff()
    {
        IsBuffActive = true;
    }

    public int Attack()
    {
        return IsBuffActive ? 20 : 10;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void GainXP(int xp)
    {
        XP += xp;
    }
}

class Enemy
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Health { get; set; } = 20;
    public int XP { get; } = 10;

    public Enemy(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int Attack()
    {
        return 15;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}

class HealthPack
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Amount { get; } = 30;

    public HealthPack()
    {
        Respawn();
    }

    public void Respawn()
    {
        Random random = new Random();
        X = random.Next(0, 30);
        Y = random.Next(0, 15);
    }
}

class Buff
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public bool IsActive { get; private set; }

    public Buff()
    {
        Respawn();
    }

    public void Respawn()
    {
        Random random = new Random();
        X = random.Next(0, 30);
        Y = random.Next(0, 15);
        IsActive = false;
    }
}

class Boss
{
    public int X { get; } = 25;
    public int Y { get; } = 10;
    public int XP { get; } = 50;
    public int Health { get; set; } = 50;

    public int Attack()
    {
        return 30;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
