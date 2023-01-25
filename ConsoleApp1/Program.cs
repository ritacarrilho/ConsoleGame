using ConsoleApp1;

/* Choisir une class
1 touche pour level up
1 touche pour reset
*/

var isRunning = true;

while (true)
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

    var hero = new Character(selectedClass, 1, 25, 25, 0,1, 5, 5);
    map.CreateMap();
    // Si ok -> on lance le jeu avec la bonne class
    while (!isReset)
    {
        Console.Clear();
        
        map.DisplayMap();
        
        Console.WriteLine(hero.name + 
                          " | Level : " + hero.level +
                          " | HP : " + hero.maxHp +
                          " | XP : " + hero.targetXp +
                          " | ATT : " + hero.attack +
                          " | DEF : " + hero.defense +
                          " / " + hero.targetXp
        );

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
        }
        
        var xp = hero.targetXp;
        hero.AddExperience(xp);
    }
}





/*
Classes StartGame()
{
    Console.WriteLine("Choose your Character : \n" +
                      " 1 : " + Classes.Héros + "\n" +
                      " 2 : " + Classes.Berserker + "\n" +
                      " 3 : " + Classes.Gardien + "\n" +
                      " 4 : " + Classes.Géant + "\n" +
                      " 5 : " + Classes.Paladin + "\n" +
                      " 6 : " + Classes.Noble + "\n" +
                      " 7 : " + Classes.Mage );
    // Console.WriteLine("Choose your Character : ");
    var consoleKey = Console.ReadKey();
    Classes character;
    
    switch (consoleKey.Key)
    {
        case ConsoleKey.D1:
            character = Classes.Héros;
            break;
        case ConsoleKey.D2:
            character = Classes.Berserker;
            break;
        case ConsoleKey.D3:
            character = Classes.Gardien;
            break;
        case ConsoleKey.D4:
            character = Classes.Géant;
            break;
        case ConsoleKey.D5:
            character = Classes.Paladin;
            break;
        case ConsoleKey.D6:
            character = Classes.Noble;
            break;
        case ConsoleKey.D7:
            character = Classes.Mage;
            break;
        default:
            character = Classes.Noble;
            break;
    }
    return character;
}

void DisplayInfo()
{
    Random random = new Random();
    Character hero = new Character(StartGame(), 1, 25, 25, 0,1, 5, 5);
    Console.Clear();
    Console.WriteLine(hero.name + 
                      " | Level : " + hero.level +
                      " | HP : " + hero.maxHp +
                      " | XP : " + hero.targetXp +
                      " | ATT : " + hero.attack +
                      " | DEF : " + hero.defense +
                      " / " + hero.targetXp
    );

    while (true)
    {
        Console.Clear();
        
        Console.WriteLine(hero.name + 
                          " | Level : " + hero.level +
                          " | HP : " + hero.maxHp +
                          " | XP : " + hero.targetXp +
                          " | ATT : " + hero.attack +
                          " | DEF : " + hero.defense +
                          " / " + hero.targetXp
        );

        var keyPressed = Console.ReadKey();

        switch (keyPressed.Key)
        {
            case ConsoleKey.R:
                Console.Clear();
                StartGame();
                break;
            case ConsoleKey.Q:
                Console.Clear();
                break;
        }
        
        var xp = hero.targetXp;
        hero.AddExperience(xp);
    }
}

DisplayInfo(); 
*/