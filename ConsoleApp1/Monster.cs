namespace ConsoleApp1;

public class Monster : Character
{
    private MonsterClasses monsterClass;
    
    public Monster(MonsterClasses monsterClass) : 
        base(monsterClass)
    {
        this.monsterClass = monsterClass;
    }
    
    public void placeMonsterRandomly(Map map)
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

                switch (monsterClass)
                {
                    case MonsterClasses.Bat:
                        map.map[x, y] = new Tile(x, y, TileType.Bat);
                        break;
                    case MonsterClasses.Goblin:
                        map.map[x, y] = new Tile(x, y, TileType.Goblin);
                        break;
                    case MonsterClasses.Gollum:
                        map.map[x, y] = new Tile(x, y, TileType.Gollum);
                        break;
                    case MonsterClasses.Orc:
                        map.map[x, y] = new Tile(x, y, TileType.Orc);
                        break;
                    case MonsterClasses.Troll:
                        map.map[x, y] = new Tile(x, y, TileType.Troll);
                        break;
                }
                isPlaced = true;
            }
        }
    }
}