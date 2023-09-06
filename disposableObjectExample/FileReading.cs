using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disposableObjectExample
{
    public class FileReading
    {
        // FileStream stream = new FileStream("testingData.txt",);
        string[] names = new string[]
               {
                    "Aidan Keith",
                    "Hakeem Messi",
                    "Cas",
                    "Emanuel",
                    "Hazzi"
               };

        public void getFirstLetter()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("testingData.txt"))
                {
                    foreach (string s in names)
                    {
                        string fLetter = s.Substring(0,2);
                        sw.WriteLine($"this is the first letter of the name {fLetter}");
                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void writerMethod()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("testingData.txt"))
                {
                    foreach (string s in names)
                    {
                        sw.WriteLine($"{s}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void readerMethod() 
        {
            try
            {
                using (StreamReader sr = new StreamReader("testingData.txt"))
                {
                    string line;

                    while((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("This file could not be read:\n " + e);
            }
        }

        public void BinaryFiles()
        {
            FileStream fs = new FileStream("testBinary.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //Writing a for loop to writew to a bianry file
            for(int i = 1; i <= 20;i++)
            {
                fs.WriteByte((byte)i);
            }

            //Reading data from a bianry file using a for loop
            fs.Position = 0;
            for(int i = 0;i <= 20;i++)
            {
                Console.WriteLine(fs.ReadByte() + " ");
            }
            fs.Close();
            Console.ReadKey();


        }
    }
}
