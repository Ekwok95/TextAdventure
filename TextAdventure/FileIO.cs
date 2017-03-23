using System;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace TextAdventure
{
    public class FileIO
    {   

        //Consider getting userDetails from Player object/class...
        //Consider maintaining save file data in an object...
        public void WriteToSaveFile(string[] userDetails, int numberOfFields, string filename)
        {
            if (!FileSystem.FileExists(filename))
            {
                using (StreamWriter srread = new StreamWriter(filename))
                {
                    numberOfFields.ToString();
                    srread.WriteLine(numberOfFields);              
                    for (int i = 0; i < numberOfFields; i++)
                    {
                        srread.WriteLine(userDetails[i]);
                    }
                    Console.WriteLine("Character data saved.");
                }
            }
            else
            {
                throw new FileNotFoundException("File does not exist. Please make a new save file.");
            }
            Thread.Sleep(5000);
        }

        public void CreateNewFile(string filename)
        {
            Test.ClearLine();
        
            if (!FileSystem.FileExists(filename))
            {         
                StreamWriter writer = File.AppendText(filename);
                try
                {
                    if (FileSystem.FileExists(filename))
                    {
                        Console.WriteLine("A new save file has been created.");
                        Test.ClearLine();
                    }
                    //Probably redundant and can swap for using block instead of try-finally...
                    else if (!FileSystem.FileExists(filename))
                    {
                        throw new FileNotFoundException("There was an error in creating a new save file.");
                    }
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("A save file already exists. It would be pointless to create one.");
                Test.ClearLine();
            }

            //Thread.Sleep(5000);
        }

        public string[] ReadLines(string filename)
        {
            string tempLine = "";
            int numberOfLines = 0;
            string[] lines, outputLines = null;

            StreamReader srread = new StreamReader(filename);
            try
            {
                tempLine = srread.ReadLine();
                Int32.TryParse(tempLine, out numberOfLines);
                lines = new string[numberOfLines];

                for (int i = 0; i < numberOfLines; i++)
                {
                    lines[i] = srread.ReadLine();
                }

                outputLines = lines;

            }
            catch (FileNotFoundException FileNotFoundException)
            {
                Console.WriteLine("This file could not be read");
                Console.WriteLine(FileNotFoundException.Message);
            }
            catch (NullReferenceException NullException)
            {
                Console.WriteLine("There is nothing in this variable");
                Console.WriteLine(NullException.Message);
            }
            finally
            {
                if (srread != null)
                {
                    srread.Close();
                }
            }
            return outputLines;
        }
    }

        /*
         * Functions within this comment block has been tested and works.

            private static void testWriteToFile()
            {
            string[] playerdetails = { "Ekwok" };
            int fields = 1;
            string file = "savedata.txt";

            WriteToSaveFile(playerdetails, fields, file);
            }

        */
    
}
