//========================================================================================
// Solution to Project Euler Problem 9 (https://projecteuler.net/problem=9).
// By Daan Juttmann - 2017-10-31
// GNU General Public License 3.0 (https://www.gnu.org/licenses/gpl-3.0.en.html).
//========================================================================================


using System;

namespace Euler009
{

  class Pythagoras
  {
    private static int Target = 1000; // desired sum for pythagorean triple


    // Check if the triple sums to the target value.
    public static bool ValidateTriple (int a, int b, int c)
    {
      return (a + b + c) == Target;
    }


    // Find the root of an integer, returns int (floor).
    private static int RootInt (int n)
    {
      if (n < 0) // return 0 for negative input (should never happen)
        return 0;
      double root = Math.Sqrt (Convert.ToDouble (n));
      return (int) root;
    }


    // Find all triples that sum to 1000, and display their product.
    public static void SearchTriple ()
    {
      int cSquared = 0;
      int c = 0;
      for (int a = 1; a <= Target; a++)
      {
        for (int b = a; b <= Target; b++)
        {
          cSquared = a * a + b * b;
          c = RootInt (cSquared);
          if (a + b + c > Target)
            break;
          if (c * c == cSquared)
          {
//            Console.WriteLine ("Triple: {0} {1} {2}", a, b, c);
            if (ValidateTriple (a, b, c)) {
              Console.WriteLine ("Found solution: {0} x {1} x {2} = {3}",
                                 a, b, c, a * b * c);
            }
          }
        }
      }
    }
  }


//----------------------------------------------------------------------------------------


  class Program
  {
    static void Main (string [] args)
    {
      Console.WriteLine ("Test");
      Pythagoras.SearchTriple ();
      Console.ReadKey();
    }
  }
}
