//========================================================================================
// Solution to Project Euler Problem 67 (https://projecteuler.net/problem=9).
// By Daan Juttmann - 2017-11-06
// GNU General Public License 3.0 (https://www.gnu.org/licenses/gpl-3.0.en.html).
// Required input file: p067_triangle.txt
//========================================================================================

using System;

namespace ConsoleApp1
{
  class Triangle
  {
    int [,] Values;

    public int Size {get; private set;}

    // Methods

    // Constructor - source file given
    public Triangle (string filename)
    {
      Load (filename);
    }


    // Constructor - size given
    public Triangle (int size)
    {
      this.Size = size;
      Values = new int [size, size];
    }


    // Load from text file.
    public bool Load (string filename)
    {
      string [] triangleValues;
      try
      {
        triangleValues = System.IO.File.ReadAllLines (filename);
      }
      catch (Exception e)
      {
        Console.WriteLine (e.Message);
        return false;
      }
      Size = triangleValues.Length;
      Values = new int [Size, Size];
      for (int i = 0; i < Size; i++)
      {
        string [] triangleRow = triangleValues [i].Split (new [] {' ', '\t'});
        for (int j = 0; j <= i && j < triangleRow.Length; j++)
        {
          Values [i, j] = Convert.ToInt32 (triangleRow [j]);
        }
      }
      return true;
    }


    // Return element
    public int Get (int row, int col)
    {
      if (row >=0 && row < Size && col >= 0 && col <= row)
        return Values [row, col];
      return 0; //  values outside of triangle are zero.
    }


    // Set element
    public void Set (int row, int col, int value)
    {
      if (row >=0 && row < Size && col >= 0 && col <= row)
        Values [row, col] = value;
    }
  }


  class PathFinder
  {
    // Find path through triangle with greatest sum.
    public static void FindOptimalPath (string filename)
    {
      Triangle t = new Triangle (filename);
      Triangle sums = new Triangle (t.Size);
      int max = 0;

      // Fill sums triangle with sums of optimal paths leading to each cell.
      for (int i = 0; i < t.Size; i++)
      {
        for (int j = 0; j <= i; j++)
        {
          max = Math.Max (sums.Get (i - 1, j - 1), sums.Get (i - 1, j));
          sums.Set (i, j, t.Get (i, j) + max);
        }
      }

      // Select greatest sum from last row of sums triangle.
      int lastRow = t.Size - 1;
      max = 0;
      for (int j = 0; j <= lastRow; j++)
      {
        max = Math.Max (max, sums.Get (lastRow, j));
      }
      Console.WriteLine ("Largest sum: {0}", max);
    }
  }


  class Euler067
  {
    static void Main (string [] args)
    {
      Console.WriteLine (System.Reflection.Assembly.GetEntryAssembly ().Location);
      PathFinder.FindOptimalPath ("p067_triangle.txt");
      Console.ReadKey ();
    }
  }
}
