namespace ConsoleApp1;

public class Character
{
    private string name;
    private int level;
    private int currentHp;
    private int maxHp;
    private int currentXp;
    private int targetXp;
    private int attack;
    private int defense;


    public Character(string name, int level, int currentHp, int maxHp, int currentXp, int tagetXp, int attack, int defense)
    {
        this.name = name;
        this.level = level;
        this.currentHp = currentHp;
        this.maxHp = maxHp;
        this.currentXp = currentXp;
        this.targetXp = tagetXp;
        this.attack = attack;
        this.defense = defense;
    }

    public string Name()
    {
        return name;
    }
    
    public int Level()
    {
        return level;
    }
    
    public int CurrentXp()
    {
        return currentXp;
    }
    
    public int TargetXp()
    {
        return targetXp;
    }
    
    public void RestoreHp()
    {
        currentHp = maxHp;
    }

    public void IncreaseHealth(int value)
    {
        /* if (currentHp + value < maxHp) { currentHp += value; } else { currentHp = maxHp; } */
        currentHp = Math.Min(currentHp + value, maxHp);
    }

    public void DecreaseHp(int value)
    {
        currentHp = Math.Max(currentHp - value, 0);
    }

    public void DefineTargetXp()
    {
        targetXp = (int)Math.Round(4 * (Math.Pow(level, 3) / 5));
    }
    
    public void LevelUp()
    {
        level += 1;
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
    
    
}