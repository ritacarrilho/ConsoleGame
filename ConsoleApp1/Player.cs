namespace ConsoleApp1;

public class Player: Character
{
    private Classes playerClasses;

    public Player(Classes playerClassses, int maxHp, int attack, int defense) : base(playerClassses, maxHp, attack, defense)
    {
        this.playerClasses = playerClassses;
    }

    public void placePlayerRandomly(Map map)
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
    public void PlayerActions(ref bool isReset, ref bool isRunning, Map map)
    {
        var keyPressed = Console.ReadKey();
        
        switch (keyPressed.Key)
        {
            case ConsoleKey.R:
                isReset = true;
                break;
            case ConsoleKey.Q:
                isReset = true;
                isRunning = false;
                break;
            case ConsoleKey.LeftArrow:
                Move(map, -1, 0);
                break;
            case ConsoleKey.RightArrow:
                Move(map, 1, 0);
                break;
            case ConsoleKey.UpArrow:
                Move(map, 0, -1);
                break;
            case ConsoleKey.DownArrow:
                Move(map, 0, 1);
                break;
        }
    }
    
    public void displayPlayerHUD()
    {
        var hudLength = (" " + playerClasses + 
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
        Console.Write(playerClasses);
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