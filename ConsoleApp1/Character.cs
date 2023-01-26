namespace ConsoleApp1;

public class Character
{
    // private Classes characterClass;
    private Statistics statistics;
    public int level;
    public int currentHp;
    public int maxHp;
    public int currentXp;
    public int targetXp;
    public int attack;
    public int defense;
    public ConsoleColor color;
    protected int positionX;
    protected int positionY;

    public Character(Classes playerClassses, int maxHp, int attack, int defense)
    {
        statistics = new Statistics(playerClassses);
        this.attack = attack;
        this.defense = defense;
        
        level = 1;
        currentHp = maxHp;
        this.maxHp = maxHp;
        currentXp = 0;
        targetXp = 1;
        positionX = 0;
        positionY = 0;
    }
    
    public Character(MonsterClasses monsterClass)
    {
        statistics = new Statistics(monsterClass);
        this.attack = attack;
        this.defense = defense;
        
        switch (monsterClass)
        {
            case MonsterClasses.Bat:
                maxHp = 5;
                currentXp = 2;
                targetXp = 1;
                break;
            case MonsterClasses.Goblin:
                maxHp = 8;
                currentXp = 2;
                targetXp = 2;
                break;
            case MonsterClasses.Gollum:
                maxHp = 10;
                currentXp = 1;
                targetXp = 3;
                break;
            case MonsterClasses.Orc:
                maxHp = 6;
                currentXp = 2;
                targetXp = 4;
                break;
            case MonsterClasses.Troll:
                maxHp = 3;
                currentXp = 1;
                targetXp = 3;
                break;
        }
        
        level = 1;
        currentHp = maxHp;
        this.maxHp = maxHp;
        currentXp = 0;
        targetXp = 1;
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

    
    private void DefineTargetXp()
    {
        targetXp = (int)Math.Round(4 * (Math.Pow(level, 3) / 5));
    }
    
    
    public void LevelUp()
    {
        level += 1;
        statistics.LevelUpStatistic(StatisticType.Hp, ref maxHp);
        RestoreHp();
        statistics.LevelUpStatistic(StatisticType.Attack, ref attack);
        statistics.LevelUpStatistic(StatisticType.Defense, ref defense);
        
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
    
    
    public void Move(Map map, int xDirection, int yDirection)
    {
        var futureTile = map.map[positionX + xDirection, positionY + yDirection];
        switch (futureTile.type)
        {
            case TileType.Ground:
                map.map[positionX + xDirection, positionY + yDirection] = new Tile(positionX - 1, positionY, TileType.Heros);
                map.map[positionX, positionY] = new Tile(positionX, positionY, TileType.Ground);
                positionX += xDirection;
                positionY += yDirection;
                break;
        }
    }
}