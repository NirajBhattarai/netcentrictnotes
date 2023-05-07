using System;
using System.IO;


class FileIOExample
{
    static void Main()
    {
        string inputFilePath = "input.txt";
        string outputFilePath = "output1.txt";

        try
        {
            // Check if the input file exists
            if (File.Exists(inputFilePath))
            {
                // Read all lines from the input file
                string[] lines = File.ReadAllLines(inputFilePath);

                // Process the lines and store them in a new array
                string[] processedLines = new string[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    processedLines[i] = $"Line {i + 1}: {lines[i]}";
                }

                // Write the processed lines to the output file
                File.WriteAllLines(outputFilePath, processedLines);

                Console.WriteLine("File processing completed. Processed content written to 'output.txt'.");
            }
            else
            {
                Console.WriteLine("Input file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while processing the file:");
            Console.WriteLine(ex.Message);
        }
    }
}
