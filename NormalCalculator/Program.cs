using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalCalculator
{
  internal class Program
  {
    long currentNumber = 0;
    long buffer = 0;

    static void Main(string[] args)
    {
      DrawCalculatorLayout(0, "");
      while (true)
      {
        Console.SetCursorPosition(0, 0);
        string keyPressed = GetKey();

        DrawCalculatorLayout(1234567890, keyPressed);
      }
      Console.ReadKey();
    }

    static string[,] keys = new string[4, 5]
        {
          {" 7 ", " 8 ", " 9 ", " + ", " - " },
          {" 4 ", " 5 ", " 6 ", " * ", " / " },
          {" 1 ", " 2 ", " 3 ", " = ", "   " },
          {"   ", " 0 ", "   ", "   ", " C " },
        };

    static void DrawCalculatorLayout(int currentNumber, string selectedKey)
    {
      //-------------------------------
      //|                        1234 |
      //-------------------------------
      //|  7  |  8  |  9  |  +  |  -  |
      //-------------------------------
      //|  4  |  5  |  6  |  *  |  /  |
      //-------------------------------
      //|  1  |  2  |  3  |  =  |     |
      //-------------------------------
      //|     |  0  | -/+ |     |  C  |
      //-------------------------------
      //               ^
      //               |
      //            Press .
      string horizontalWall = new string('-', 31);
      if (selectedKey == ".")
      {
        selectedKey = "-/+";
      }
      if (selectedKey == "c")
      {
        selectedKey = "C";
      }
      if (selectedKey.Length == 1)
      {
        selectedKey = " " + selectedKey + " ";
      }


      Console.SetCursorPosition(0, 0);
      for (int i = 1; i <= 6; i++)
      {
        Console.WriteLine(horizontalWall);
        Console.WriteLine();
      }
      for (int i = 0; i < 4; i++)
      {
        Console.SetCursorPosition(0, 3 + i * 2);
        for (int j = 0; j < 5; j++)
        {
          Console.Write("|");
          if (selectedKey == keys[i, j])
          {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
          }
          Console.Write(" " + keys[i, j] + " ");
          Console.ResetColor();
        }
        Console.Write("|");
      }
      Console.SetCursorPosition(0, 1);
      Console.Write("|");
      string spaces = new string(' ', 28 - currentNumber.ToString().Length);
      Console.Write(spaces + currentNumber.ToString() + " |");
      Console.SetCursorPosition(15, 11);
      Console.Write("^");
      Console.SetCursorPosition(15, 12);
      Console.Write("|");
      Console.SetCursorPosition(12, 13);
      Console.WriteLine("Press .");
    }    
    
    static string GetKey()
    {
      return Console.ReadKey().KeyChar.ToString();
    }
  }                              
}
