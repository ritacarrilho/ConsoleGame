using System.Diagnostics;

namespace ConsoleApp1;

/*
 * Créer une class Tile
 * Créer un tableau à deux dimensions de Tile
 * Afficher le tableau
 * Créer automatiquement les bordures (murs)
 */

public enum TileType {
    Ground,
    Wall,
    Heros,
}

public class Tile
{
    public int posX;
    public int posY;
    public TileType type;
    public char sprite;
    public ConsoleColor color;
    public bool isPassable;
    
    public Tile(int posX, int posY, TileType type)
    {
        this.posX = posX;
        this.posY = posY;

        this.type = type;
        
        switch (type)
        {
            case TileType.Ground:
                sprite = '.';
                color = ConsoleColor.Yellow;
                isPassable = true;
                break;
            case TileType.Wall:
                sprite = '#';
                color = ConsoleColor.DarkBlue;
                isPassable = false;
                break;
            case TileType.Heros:
                sprite = '@';
                color = ConsoleColor.Cyan;
                isPassable = false;
                break;
        }
    }
}

