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
    static void Main(string[] args)
    {
      DrawCalculatorLayout(1234567890, "");
      Console.ReadKey();
    }
    static string[,] keys = new string[5, 4]
        {
          {" - ", " / ", "   ", "   " },
          {" + ", " * ", " = ", "   "},
          {" 9 ", " 6 ", " 3 ", "-/+"},
          {" 8 ", " 5 ", " 2 ", " 0 "},
          {" 7 ", " 4 ", " 1 ", "   "},
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
      //|     |  0  | -/+ |           |
      //-------------------------------
      //               ^
      //               |
      //            Press.
      string horizontalWall = new string('-', 31);
      if (selectedKey.Length == 1)
      {
        selectedKey = " " + selectedKey + " ";
      }
      for (int i = 1; i <= 6; i++)
      {
        Console.WriteLine(horizontalWall);
        Console.WriteLine();
      }
      for (int i = 0; i < 4; i++)
      {
        Console.SetCursorPosition(0, 3 + i * 2);
        for (int j = 4; j >= 0; j--)
        {
          Console.Write("|");
          if (selectedKey == keys[j, i])
          {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
          }
          Console.Write(" " + keys[j, i] + " ");
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
      Console.Write("Press .");
    }                               
  }                              
}
