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
    static long currentNumber = 0;
    static long buffer = 0;
    static string currentOperation = "=";
    static bool alive = true;
    static Random random = new Random();
    static string password = "#####";
    static int enterCounter = 0;
    static long bufferLong = 0;
    static int bufferInt = 0;
    static string bufferStr = "";

    static void Main(string[] args)
    {
      Console.CursorVisible = false;
      DrawCalculatorLayout(0, "");
      while (alive)
      {
        Console.SetCursorPosition(0, 0);
        string keyPressed = GetKey();
        PerformOperations(keyPressed);
        DrawCalculatorLayout(currentNumber, keyPressed);
        if (enterCounter >=1)
        {
          ShowHackMenu();
        }
      }
      Console.ReadKey();
    }

    static string[,] keys = new string[4, 5]
        {
          {" 7 ", " 8 ", " 9 ", " + ", " - " },
          {" 4 ", " 5 ", " 6 ", " * ", " / " },
          {" 1 ", " 2 ", " 3 ", " = ", "   " },
          {"   ", " 0 ", "-/+", "   ", " C " },
        };

    static void DrawCalculatorLayout(long currentNumber, string selectedKey)
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
      //
      //Press E to exit
      string horizontalWall = new string('-', 31);
      
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
      Console.WriteLine();
      Console.WriteLine("Press E to exit");
    }    
    
    static string GetKey()
    {
      string key = Console.ReadKey().KeyChar.ToString();
      if (key == ".")
      {
        key = "-/+";
      }
      if (key == "c")
      {
        key = "C";
      }
      if (key == "e")
      {
        key = "E";
      }
      return key;
    }

    static void PerformOperations(string selectedKey)
    {
      if (selectedKey == "-/+")
      {
        currentNumber *= -1;
      }
      else if (selectedKey == "C")
      {
        currentNumber = 0;
      }
      else if (selectedKey == "*" || selectedKey == "/" || selectedKey == "+" || selectedKey == "-")
      {
        buffer = currentNumber;
        currentNumber = 0;
        currentOperation = selectedKey;
      }
      else if (selectedKey == "=")
      {
        if (currentOperation == "+")
        {
          currentNumber += buffer;
        }
        else if(currentOperation == "-")
        {
          currentNumber -= buffer;
        }
        else if (currentOperation == "*")
        {
          currentNumber *= buffer;
        }
        else if (currentOperation == "/")
        {
          currentNumber /= buffer;
        }
        if (currentOperation != "=")
        {
          enterCounter++;
          if (enterCounter % 3 == 0)
          {
            RevealPasswordNumber();
          }
        }
        currentOperation = "=";
      }
      else if (selectedKey == "E")
      {
        alive = false;
      }
      else
      {
        if (long.TryParse(selectedKey, out bufferLong))
        {
          currentNumber = currentNumber * 10 + bufferLong;
        }
      }
    }

    static void DrawGlitchTab(int glitchChance)
    {
      // #-------HackTechINC--------#  
      // |                          |
      // |  Password for Pentagon:  |
      // |          #####           |
      // |                          |
      // |                          |
      // | ■■■■■■■■■■■■□□□□□□□□ 60% |
      // #--------------------------#
      int[] spacings = new int[8] { 40, 40, 40, 40, 40, 40, 40, 40 };
      string randomSymbols = "%$#!*&?^:;/";
      string newPassword = "";
      int percentComplete = 0;
      string percentBar = "";

      for (int i = 0; i < password.Length; i++)
      {
        if (password[i] != '1' && password[i] != '2' && password[i] != '3' && password[i] != '4' && password[i] != '5' && password[i] != '6' &&
          password[i] != '7' && password[i] != '8' && password[i] != '9' && password[i] != '0')
        {
          newPassword += randomSymbols[random.Next(0, randomSymbols.Length)];
        }
        else
        {
          newPassword += password[i];
          percentComplete += 20;
          percentBar += "■■■■";
        }
      }
      percentBar += new string('#', 20 - percentBar.Length);

      if (random.Next(1, 101) < glitchChance)
      {
        spacings[random.Next(0, 8)] += random.Next(0, 10) - 5;
      }

      Console.SetCursorPosition(spacings[0], 0);
      Console.Write("#-------HackTechINC--------#");
      Console.SetCursorPosition(spacings[1], 1);
      Console.Write("|                          |");
      Console.SetCursorPosition(spacings[2], 2);
      Console.Write("|  Password for Pentagon:  |");
      Console.SetCursorPosition(spacings[3], 3);
      Console.Write("|          " + newPassword + "           |");
      Console.SetCursorPosition(spacings[4], 4);
      Console.Write("|                          |");
      Console.SetCursorPosition(spacings[5], 5);
      Console.Write("|                          |");
      Console.SetCursorPosition(spacings[6], 6);
      if (percentComplete < 100)
      {
        Console.Write("| " + percentBar + new string(' ', 3 - percentComplete.ToString().Length) + percentComplete.ToString() + "% |");
      }
      else
      {
        Console.Write("|        Completed!        |");
      }
      Console.SetCursorPosition(spacings[7], 7);
      Console.Write("#--------------------------#");
    }

    static void ShowHackMenu()
    {
        DrawGlitchTab(0);
        Console.SetCursorPosition(0, 0);
    }

    static void RevealPasswordNumber()
    {
      do
      {
        bufferInt = random.Next(0, 5);
      } while (int.TryParse(password[bufferInt] + "", out _));
      bufferStr = "";
      for (int i = 0; i < 5; i++)
      {
        if (i == bufferInt)
        {
          bufferStr += (i + 1).ToString();
        }
        else
        {
          bufferStr += password[i];
        }
      }
      password = bufferStr;
    }
  }                              
}
