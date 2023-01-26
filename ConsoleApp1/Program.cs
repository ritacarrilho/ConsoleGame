using ConsoleApp1;

var isRunning = true;

while (isRunning)
{
    bool isReset = false;
    bool isBadClassChoise;
    Classes selectedClass = Classes.Héros;
    Random random = new Random();
    var map = new Map();

    do
    {
        Console.Clear();
        isBadClassChoise = false;

        // Afficher les choix
        Console.WriteLine("Please choose a class :");

        foreach (var charClass in Enum.GetValues(typeof(Classes)))
        {
            Console.WriteLine(((int)charClass + 1) + " : " + charClass);
        }

        // Mettre en place un choix via des touches
        var keyPressed = Console.ReadKey();

        switch (keyPressed.Key)
        {
            case ConsoleKey.D1:
                selectedClass = Classes.Héros;
                break;
            case ConsoleKey.D2:
                selectedClass = Classes.Mage;
                break;
            case ConsoleKey.D3:
                selectedClass = Classes.Paladin;
                break;
            case ConsoleKey.D4:
                selectedClass = Classes.Noble;
                break;
            case ConsoleKey.D5:
                selectedClass = Classes.Gardien;
                break;
            case ConsoleKey.D6:
                selectedClass = Classes.Berserker;
                break;
            case ConsoleKey.D7:
                selectedClass = Classes.Géant;
                break;
            // Securite si mauvaise touche est entre
            default:
                isBadClassChoise = true;
                break;
        }
    } while (isBadClassChoise);

    var player = new Player(selectedClass, 20, 5, 5);

    map.CreateMap();
    map.placeWalls(10, 30);
    
    List<Monster> MonsterList = new List<Monster>();
    var randomMonsterNumber = random.Next(1, 5);

    for (var i = 0; i < randomMonsterNumber; i++)
    {
        var monster = new Monster((MonsterClasses)random.Next(0, 5));
        monster.placeMonsterRandomly(map);
        MonsterList.Add(monster);
    }
    
    player.placePlayerRandomly(map);
    
    while (!isReset)
    {
        Console.Clear();

        map.DisplayMap();
        player.displayPlayerHUD();

        player.PlayerActions(ref isReset, ref isRunning, map);
    }
}