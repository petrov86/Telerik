/* Implement the "Falling Rocks" game in the text console. 
 * A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
 * A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
 * Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. 
 * The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
 * Implement collision detection and scoring system
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

public class Rock
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Symbol { get; set; }

    public Rock(int x, int y, string symbol)
    {
        this.X = x;
        this.Y = y;
        this.Symbol = symbol;
    }
}

class FallingRocks
{

    static int dwarfPositionX = Console.WindowWidth / 2 - 4;
    static int dwarfPositionY = Console.WindowHeight - 1;
    static int rockPositionX;
    static int rockPositionY = 1;
    static char[] rocks = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
    static string rockSymbol;
    static int result = 3;
    static List<Rock> rockList = new List<Rock>();
    static Random randomGenerator = new Random();

    static void RemoveScrollBars()
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    static void DrawDwarf()
    {
        PrintAtPosition(dwarfPositionX, dwarfPositionY, "000000");
    }

    static void MoveDwarfRight()
    {
        if (dwarfPositionX < Console.WindowWidth - 8)
        {
            dwarfPositionX++;
        }
    }

    static void MoveDwarfLeft()
    {
        if (dwarfPositionX > 0)
        {
            dwarfPositionX--;
        }

    }

    static void PrintAtPosition(int x, int y, string symbol)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(symbol);
    }

    static int GenerateRandomPosition()
    {
        int maxWidth = Console.WindowWidth - 1;
        int randomPositionX = randomGenerator.Next(0, maxWidth);
        return randomPositionX;
    }

    static string GenerateRandomSymbol()
    {
        char randomRock = rocks[randomGenerator.Next(0, 12)];
        string symbol = Convert.ToString(randomRock);
        return symbol;
    }

    private static void PrintRocks()
    {
        foreach (Rock rock in rockList)
        {
            PrintAtPosition(rock.X, rock.Y, rock.Symbol);
        }
    }

    private static void GenerateRocks()
    {
        for (int i = 0; i < 2; i++)
        {
            rockList.Add(new Rock(GenerateRandomPosition(), rockPositionY, GenerateRandomSymbol()));
        }
    }


    static void MoveRocks()
    {
        foreach (var rock in rockList)
        {
            rock.Y++;
        }
    }

    static void PrintResult()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 0);
        Console.WriteLine("Left: {0}", result);
    }

    static void Main()
    {
        RemoveScrollBars();
        while (true)
        {

            Console.Clear();
            DrawDwarf();
            GenerateRocks();
            MoveRocks();
            RemoveRocks();
            PrintRocks();
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    MoveDwarfLeft();
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    MoveDwarfRight();
                }
            }

            if (rockPositionY + 1 == dwarfPositionY)
            {
                if (rockPositionX == dwarfPositionX ||
                    rockPositionX == dwarfPositionX + 1 ||
                    rockPositionX == dwarfPositionX + 2 ||
                    rockPositionX == dwarfPositionX + 3 ||
                    rockPositionX == dwarfPositionX + 4 ||
                    rockPositionX == dwarfPositionX + 5)
                {
                    result--;
                }

            }
            PrintResult();
            Thread.Sleep(100);

        }
    }

    private static void RemoveRocks()
    {
        int listCount = rockList.Count;
        int maxHeight = Console.WindowHeight - 1;
        for (int i = 0; i < listCount ; i++)
        {
            if (rockList[i] != null)
            {
                if (rockList[i].Y == 10)
                {
                    Console.WriteLine("rock");
                    rockList.Remove(rockList[i]);
                    //rockList[i] = null;
                   
                }
            }
        }
    }
}

