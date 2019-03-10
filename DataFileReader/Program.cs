using System;

namespace DataFileReader
{
    class Program
    {
        private static FileReader _reader;

        private static void Main(string[] args)
        {
            Console.Write("Welcome user! This little program is meant to help you read " +
                "a data file and make some simple calculations.\n");
                
            bool outerLoop = true;

            while (outerLoop)
            {
                Console.Write("\nPlease enter the path of the file that you would like to read. " +
                "Please make sure that:\n" +
                "1. You enter the full file path.\n" +
                "2. The file is a txt file which contains a single number on each row.\n" +
                "3. The file contains at least one line of data.\n" +
                "Now please go ahead and enter the path (enter x to exit the program): ");

                var input = Console.ReadLine();
                if (input.Equals("x"))
                {
                    outerLoop = false;
                    break;
                }

                _reader = new FileReader(input);
                var success = _reader.SetListNumbers();

                if (!success)
                {
                    Console.Write("\n\nThere has been an error reading the file. Make sure that the " +
                        "path is valid and that the file contains valid data.\n\n");
                }
                else
                {
                    Console.Write("\n\nExcellent news! We have been able to read your file.\n\n");
                    bool innerLoop = true;
                    while (innerLoop)
                    {
                        Console.Write("Please choose one of the following options:\n" +
                            "-Enter 1 to compute the sum.\n" +
                            "-Enter 2 to compute the average.\n" +
                            "-Enter 3 to compute the standard deviation.\n" +
                            "-Enter 4 to view the numbers in the file.\n" +
                            "-Enter 5 to enter another file path.\n" +
                            "-Enter x to exit the program.\n");                    
                        Console.Write("Enter your choice here: ");
                        var selection = Console.ReadLine();

                        switch (selection)
                        {
                            case "1":
                                Console.WriteLine(string.Format("\nThe sum is {0}\n", _reader.Sum()));
                                break;
                            case "2":
                                Console.WriteLine(string.Format("\nThe average is {0}\n", _reader.Average()));
                                break;
                            case "3":
                                Console.WriteLine(string.Format("\nThe standard deviation is {0}\n", _reader.StdDev()));
                                break;
                            case "4":
                                Console.WriteLine(string.Format("\nHere is the file:\n{0}\n", _reader.ShowFile()));
                                break;
                            case "5":
                                innerLoop = false;
                                break;
                            case "x":
                                innerLoop = false;
                                outerLoop = false;
                                break;
                            default:
                                Console.Write("\nSorry, invalid choice. Please try again.\n");
                                break;
                            
                        }
                    }
                }
            }
            Console.WriteLine("\nG'bye! Hoping to see you again soon.\n");
        }
    }
}
