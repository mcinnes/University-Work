    /*************************************************************
    ** File: ArrayTimesTable.cs
    ** Author/s: Justin Rough
    ** Description:
    **     A move advanced version of the TimesTable.cs program
    ** which used loops to produce a multiplication table.  This
    ** new version uses an array to contain the times table, the
    ** size for which is obtained from the user.
    *************************************************************/
    using System;

    namespace ArrayTimesTable
    {
        class ArrayTimesTable
        {
            static void Main(string[] args)
            {
                // Determine what size times table the user wants
                Console.Write("How many rows? ");
                int rows = Convert.ToInt32(Console.ReadLine());
                Console.Write("How many columns? ");
                int columns = Convert.ToInt32(Console.ReadLine());

                // Build the array
                int[,] timesTable = new int[rows, columns];
                for (int i = 0; i < timesTable.GetLength(0); i++)
                    for (int j = 0; j < timesTable.GetLength(1); j++)
                        timesTable[i, j] = (i + 1) * (j + 1);

                // Display the array contents
                for (int i = 0; i < timesTable.GetLength(0); i++)
                {
                    for (int j = 0; j < timesTable.GetLength(1); j++)
                    {
                        Console.Write("{0,3} ", timesTable[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
