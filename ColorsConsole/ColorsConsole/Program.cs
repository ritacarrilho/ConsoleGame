// See https://aka.ms/new-console-template for more information

/* String[] array = new String[3];
List<String> list = new List<String>();

list.Add("A");
list.Add("B");
list.Add("C");

String loopFor = "Loop For";
Console.WriteLine(loopFor);

for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}

String loopWhile = "Loop While";
Console.WriteLine(loopWhile);

int j = 0;
while (j < list.Count) 
{
    Console.WriteLine(list[j]);
    j++;
}

list.Insert(1, "D");

String loopForeach = "Loop ForEach";
Console.WriteLine(loopForeach);

foreach (var element in list)
{
Console.WriteLine(element);
}

String listForeach = "List ForEach";
Console.WriteLine(listForeach);
list.ForEach(Console.WriteLine);

if (list.Count > 2)
{
    Console.WriteLine("Inside if");
}

*/


/* EXO */
// create alphabet
// var alphabet = "ABCDEFGHIJKLMNOPQRSTUVXZ".ToCharArray();

List<char> alphabet = new List<char>();

Random rng = new Random();

// colors array
List<ConsoleColor> colorArray = new List<ConsoleColor>();

// add colors to color array
void AddColors()
{
    for (int i = 0; i < 25; i++)
    {
        var randColor = (ConsoleColor)rng.Next(1, 16);
        colorArray.Add(randColor);
        Console.ForegroundColor = randColor;
    }
}


// display line of alphabet
void  DisplayLetters()
{
    for (int j = 0; j < 500; j++)
    {
        for (var i = 0; i < 26; i++)
        {
            AddColors();
            alphabet.Add((char)('A' + i));
            Console.Write((alphabet[i]));
        }
        Console.Write("\r");
        Thread.Sleep(100);

    }
    /* foreach (var element in alphabet)
    {
        Console.Write(element);
        AddColors();
    } */
}

DisplayLetters();


/* Correction
String alphabetLetters = "ABCDEFGHIJKLMNOPQRSTUVXZ";

List<ConsoleColor> colors = new List<ConsoleColor>
{
    ConsoleColor.Green,
    ConsoleColor.Red,
    ConsoleColor.Yellow,
    ConsoleColor.Green,
    ConsoleColor.Magenta,
    ConsoleColor.White,
    ConsoleColor.Cyan,
};

Random random = new Random();

void AttributeRandomColor()
{
    var randomIndex = random.Next(0, colors.Count);
    var randomColor = colors[randomIndex];
    Console.ForegroundColor = randomColor;
}
    
void DisplayAlphabet() {
    foreach (var letter in alphabetLetters)
    {
        AttributeRandomColor();
        Console.Write((letter));
    }
}

DisplayAlphabet();

*/