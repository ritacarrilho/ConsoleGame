namespace ConsoleApp1;

public class Map
{
    private Random random = new Random();
    public int mapWidth;
    public int mapHeight;
    public Tile[,] map;
    public ConsoleColor color;

    public Map()
    {
        mapWidth = random.Next(10, 50);
        mapHeight = random.Next(5, 10);
        map = new Tile[mapWidth, mapHeight];
    }

    public void CreateMap()
    {
        for (var x = 0; x < mapWidth; x++) {
            for (var y = 0; y < mapHeight; y++) {
                if (x == 0 || y == 0 || x == mapWidth -1 || y == mapHeight -1) {
                    map[x, y] = new Tile(x, y, TileType.Wall);
                } else {
                    map[x, y] = new Tile(x, y, TileType.Ground);
                }
            }
        }
    }

    
    public void placeWalls(int minPercent, int maxPercent)
    {
        var availableNumber = (mapWidth - 2) * (mapHeight - 2);
        float randomPercent = random.Next(minPercent, maxPercent + 1);
        var wallsNumber = availableNumber * randomPercent / 100 ;

        for (var i = wallsNumber; i > 0; i--)
        {
            var isPlaced = false;

            while (!isPlaced)
            {
                var x = random.Next(0, mapWidth);
                var y = random.Next(0, mapHeight);
            
                if (map[x, y].type == TileType.Ground)
                {
                    map[x, y] = new Tile(x, y, TileType.Wall);
                    isPlaced = true;
                }
            }
        }
    }
    
    public void DisplayMap()
    {
        for (var y = 0; y < mapHeight; y++) {
            for (var x = 0; x < mapWidth; x++)
            {
                Console.ForegroundColor = map[x, y].color;
                Console.Write(map[x, y].sprite);
            }
            Console.WriteLine();
        }
    }
}