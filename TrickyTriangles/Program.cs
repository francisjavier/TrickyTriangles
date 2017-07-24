using System;
using System.Linq;

namespace TrickyTriangles
{
    internal class Program
    {
        const string letters = "ABCDEF";

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter row and colummn for triangle: e.g. E6");
            var input = Console.ReadLine().ToCharArray();
            var row = input[0].ToString().ToUpper();

            var column = Convert.ToInt32(input.Length > 2 ? $"{input[1]}{input[2]}" : $"{input[1]}");

            FindTriangleCoordinates(row, column);

            Console.WriteLine();
            Console.WriteLine("Enter coordinates to find triangle:");
            Console.WriteLine("V1 coordinates: e.g. 30,20");
            //Coordinates are in { x, y }format
            int[] v1Coordinates = Console.ReadLine().Split(',').Select(n => Convert.ToInt32(n.ToString())).ToArray();

            Console.WriteLine("V2 coordinates: e.g. 30,30");
            int[] v2Coordinates = Console.ReadLine().Split(',').Select(n => Convert.ToInt32(n.ToString())).ToArray();

            // int[] v3Coordinates = { 50, 20 };
            FindRowAndColumn(v1Coordinates, v2Coordinates);
        }

        private static void FindRowAndColumn(int[] v1Coordinates, int[] v2Coordinates)
        {
            int x = v1Coordinates[0], y = v1Coordinates[1];
            int column, row;

            //If the Y of V2 is smaller than the Y of V1 it means that the main vertex is under it,
            //so it's an odd column with vertex on left bottom side
            if (v1Coordinates[1] > v2Coordinates[1])
            {
                column = (x + 5) / 5;
                row = (y / 10) - 1; //subtract 1 for index lookup for letter
            }
            //Otherwise the vertex is on the top right side
            else
            {
                column = x / 5;
                row = ((y + 10) / 10) - 1;
            }

            var rowLetter = letters.Skip(row).FirstOrDefault();

            Console.WriteLine($"Row:{rowLetter}, Column:{column}");
            Console.ReadLine();
        }

        private static void FindTriangleCoordinates(string row, int column)
        {
            int x1, y1, x2, y2, x3, y3;

            y1 = letters.IndexOf(row) + 1;

            //Calculations are based on whether the column is even or odd
            //If it's an even column, the vertex is on the top right side, so subtract 10 from y
            //If it's an odd column, the vertex is on the left bottom side, so subtract 5 from x
            if (column % 2 == 0)
            {
                x1 = column * 5;
                y1 = (y1 * 10) - 10;

                x2 = x1;
                y2 = y1 + 10;

                x3 = x1 - 10;
                y3 = y1;
            }
            else
            {
                x1 = (column * 5) - 5;
                y1 = y1 * 10;

                x2 = x1;
                y2 = y1 - 10;

                x3 = x1 + 10;
                y3 = y1;
            }

            Console.WriteLine($"Row:{row}, Column:{column}");
            Console.WriteLine($"X1:{x1}, Y1:{y1}");
            Console.WriteLine($"X2:{x2}, Y2:{y2}");
            Console.WriteLine($"X3:{x3}, Y3:{y3}");
        }
    }
}