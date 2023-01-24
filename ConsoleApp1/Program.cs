using ConsoleApp1;

Random random = new Random();
Character hero = new Character("Toto", 1, 25, 25, 0,1, 5, 5);

while (true)
{
    var text = hero.Name() + " | Level : " + hero.Level() + "| XP : " + hero.CurrentXp() + " / " + hero.TargetXp();
    Console.WriteLine(text);
    Console.Read();
    var xp = random.Next(1, 20);
    Console.WriteLine("Vous gagnez" + xp + " d'xperience !");
    hero.AddExperience((xp));
}