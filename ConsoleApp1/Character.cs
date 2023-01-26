namespace ConsoleApp1;

public class Character
{
    private Classes characterClass;
    private Statistics characterStatistics;
    public string name;
    public int level;
    public int currentHp;
    public int maxHp;
    public int currentXp;
    public int targetXp;
    public int attack;
    public int defense;
    public ConsoleColor color;
    public int positionX;
    public int positionY;

    public Character(Classes characterClass, int level, int currentHp, int maxHp, int currentXp, int tagetXp, int attack, int defense)
    {
        this.characterClass = characterClass;
        name = characterClass.ToString();
        characterStatistics = new Statistics(this.characterClass);
        this.level = level;
        this.currentHp = currentHp;
        this.maxHp = maxHp;
        this.currentXp = currentXp;
        this.targetXp = tagetXp;
        this.attack = attack;
        this.defense = defense;
        positionX = 0;
        positionY = 0;
    }
    
    public void IncreaseHealth(int value)
    {
        /* if (currentHp + value < maxHp) { currentHp += value; } else { currentHp = maxHp; } */
        currentHp = Math.Min(currentHp + value, maxHp);
    }

    public void RestoreHp()
    {
        currentHp = maxHp;
    }

    public void DefineTargetXp()
    {
        targetXp = (int)Math.Round(4 * (Math.Pow(level, 3) / 5));
    }
    
    public void LevelUp()
    {
        level += 1;
        characterStatistics.LevelUpStatistic(StatisticType.Hp, ref maxHp);
        RestoreHp();
        characterStatistics.LevelUpStatistic(StatisticType.Attack, ref attack);
        characterStatistics.LevelUpStatistic(StatisticType.Defense, ref defense);
        
        DefineTargetXp();
    }

    public void AddExperience(int value)
    {
        currentXp += value;

        while (currentXp >= targetXp)
        {
            currentXp -= targetXp;
            LevelUp();
        }
    }
    
    
    public void placeRandomlyCharacter(Map map)
    {
        var random = new Random();
        var isPlaced = false;
        
        while (!isPlaced)
        {
            var x = random.Next(0, map.mapWidth);
            var y = random.Next(0, map.mapHeight);
            
            if (map.map[x, y].type == TileType.Ground)
            {
                positionX = x;
                positionY = y;

                map.map[x, y] = new Tile(x, y, TileType.Heros);
                isPlaced = true;
            }
        }
    }

    
    public void displayCharacterHUD()
    {
        var hudLength = (" " + name + 
                        " ║ Level : " + level +
                        " ║ HP : " + currentHp + " / " + maxHp   +
                        " ║ XP : " + currentXp + " / " + targetXp +
                        " ║ ATT : " + attack +
                        " ║ DEF : " + defense  + " "
            ).Length;
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("╔");

        for (var i = 0; i < hudLength; i++)
        {
            Console.Write("═");
        }
        Console.Write("╗");

        Console.WriteLine();
        
        Console.Write("║ ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(name);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" ║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Level : " + level);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" ║ ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("HP : " + currentHp + " / " + maxHp);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" ║ ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("XP : " + currentXp + " / " + targetXp);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" ║ ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("ATT : " + attack);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" ║ ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("DEF : " + defense );
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" ║");
        
        Console.WriteLine();
        Console.Write("╚");
        
        for (var i = 0; i < hudLength; i++)
        {
            Console.Write("═");
        }
        
        Console.Write("╝");
    }
}