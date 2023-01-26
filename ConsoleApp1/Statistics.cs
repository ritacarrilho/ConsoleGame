using System.Diagnostics;
using System.Numerics;

namespace ConsoleApp1;

/*
----------------------------------------------------------------------------
    DICE SYSTEM & VALUES FOR LIFE & STATISTICS
----------------------------------------------------------------------------
 Fast_Stat = 4D2 --- Medium_Stat = 2D2 --- Slow_Stat = 1D2
 Fast_Health = 9D6 --- Medium_Health = 5D6 --- Slow_Health = 3D4

 Fast_Stat     :     Max 8 Min 4         Fast_Health     :     Max 54 Min 9
 Medium_Stat   :     Max 4 Min 2         Medium_Health   :     Max 30 Min 5
 Slow_Stat     :     Max 2 Min 1         Slow_Health     :     Max 12 Min 3
---------------------------------------------------------------------------- */
    
public enum Classes
{
    Héros,
    Mage,
    Paladin,
    Noble,
    Gardien,
    Berserker,
    Géant,
}

public enum Growth
{
    Fast,
    Medium,
    Slow,
}

public enum StatisticType
{
    Attack,
    Defense,
    Hp,
}

public enum MonsterClasses
{
    Bat,
    Goblin,
    Troll,
    Orc,
    Gollum,
}

public class Statistics
{
    private Classes playerClass;
    private MonsterClasses monsterClass;
    private Random random = new Random();

    private Growth attackGrowth;
    private int attackRollsNumber;
    private int attackFacesNumber;
    
    private Growth defenseGrowth;
    private int defenseRollsNumber;
    private int defenseFacesNumber;
    
    private Growth hpGrowth;
    private int hpRollsNumber;
    private int hpFacesNumber;
    

    public Statistics(Classes playerClass)
    {
        this.playerClass = playerClass;

        switch (playerClass)
        {
            case Classes.Berserker:
                attackGrowth = Growth.Fast;
                defenseGrowth = Growth.Slow;
                hpGrowth = Growth.Medium;
                break;
            case Classes.Gardien:
                attackGrowth = Growth.Slow;
                defenseGrowth = Growth.Fast;
                hpGrowth = Growth.Medium;
                break;
            case Classes.Géant:
                attackGrowth = Growth.Medium;
                defenseGrowth = Growth.Slow;
                hpGrowth = Growth.Fast;
                break;
            case Classes.Noble:
                attackGrowth = Growth.Medium;
                defenseGrowth = Growth.Fast;
                hpGrowth = Growth.Slow;
                break;
            case Classes.Héros:
                attackGrowth = Growth.Medium;
                defenseGrowth = Growth.Medium;
                hpGrowth = Growth.Medium;
                break;
            case Classes.Mage:
                attackGrowth = Growth.Fast;
                defenseGrowth = Growth.Medium;
                hpGrowth = Growth.Slow;
                break;
            case Classes.Paladin:
                attackGrowth = Growth.Slow;
                defenseGrowth = Growth.Medium;
                hpGrowth = Growth.Fast;
                break;
        }
        
        DefineStatisticsGrowthValues(attackGrowth, ref attackRollsNumber, ref attackFacesNumber);
        DefineStatisticsGrowthValues(defenseGrowth, ref defenseRollsNumber, ref defenseFacesNumber);
        DefineStatisticsGrowthHealth(hpGrowth, ref hpRollsNumber, ref hpFacesNumber);
    }
    
    public Statistics(MonsterClasses monsterClass)
    {
        this.monsterClass = monsterClass;

        switch (monsterClass)
        {
            case MonsterClasses.Troll:
                attackGrowth = Growth.Fast;
                defenseGrowth = Growth.Slow;
                hpGrowth = Growth.Medium;
                break;
            case MonsterClasses.Gollum:
                attackGrowth = Growth.Slow;
                defenseGrowth = Growth.Fast;
                hpGrowth = Growth.Medium;
                break;
            case MonsterClasses.Orc:
                attackGrowth = Growth.Medium;
                defenseGrowth = Growth.Slow;
                hpGrowth = Growth.Fast;
                break;
            case MonsterClasses.Bat:
                attackGrowth = Growth.Slow;
                defenseGrowth = Growth.Medium;
                hpGrowth = Growth.Fast;
                break;
        }
        
        DefineStatisticsGrowthValues(attackGrowth, ref attackRollsNumber, ref attackFacesNumber);
        DefineStatisticsGrowthValues(defenseGrowth, ref defenseRollsNumber, ref defenseFacesNumber);
        DefineStatisticsGrowthHealth(hpGrowth, ref hpRollsNumber, ref hpFacesNumber);
    }


    // method for defense and attack > same values of growth for fast, medium or slow so the function is reusable
    public void DefineStatisticsGrowthValues(Growth growth, ref int rollsNumber, ref int facesNumber)
    {
        switch (growth)
        {
            case Growth.Fast:
                rollsNumber = 4;
                break;
            case Growth.Medium:
                rollsNumber = 2;
                break;
            case Growth.Slow:
                rollsNumber = 1;
                break;
        }
    }
    
    public void DefineStatisticsGrowthHealth(Growth growth, ref int rollsNumber, ref int facesNumber)
    {
        switch (growth)
        {
            case Growth.Fast:
                rollsNumber = 9;
                facesNumber = 6;
                break;
            case Growth.Medium:
                rollsNumber = 5;
                facesNumber = 6;
                break;
            case Growth.Slow:
                rollsNumber = 3;
                facesNumber = 1;
                break;
        }
    }
    
    private int RollDice(int rollsNumber, int facesNumber)
    {
        var count = 0;
        for (var i = 0; i < rollsNumber; i++)
        {
            count += random.Next(1, facesNumber + 1);
        }

        return count;
    }

    public void LevelUpStatistic(StatisticType type, ref int targetStatistic)
    {
        switch (type) {
            case StatisticType.Hp:
                targetStatistic += RollDice(hpRollsNumber, hpFacesNumber);
                break;
            case StatisticType.Attack:
                targetStatistic += RollDice(attackRollsNumber, attackFacesNumber);
                break;
            case StatisticType.Defense:
                targetStatistic += RollDice(defenseRollsNumber, defenseFacesNumber);
                break;
        }
    }
}