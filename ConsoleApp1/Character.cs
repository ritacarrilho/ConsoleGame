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
    
    
}