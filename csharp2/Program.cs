using System;
using System.Collections.Generic;
using System.IO;

namespace Csharp2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("address line 1: " + Print.getProperties()["addressline1"]);
            Console.WriteLine("address line 2: " + Print.getProperties()["addressline2"]);
            Console.WriteLine("city: " + Print.getProperties()["city"]);
            Console.WriteLine("state: " + Print.getProperties()["state"]);
            Console.WriteLine("zip: " + Print.getProperties()["zip"]);
            Console.ReadKey();
        }
    }

    class Print
    {
        public static Dictionary<string, string> getProperties()
        {
            string fileData = "";
            using (StreamReader streamReader = new StreamReader("address.txt"))
            {
                fileData = streamReader.ReadToEnd().Replace("\r", "");
            }
            Dictionary<string, string> Properties = new Dictionary<string, string>();
            string[] keysValues;
            string[] records = fileData.Split("\n".ToCharArray());
            foreach (string record in records)
            {
                keysValues = record.Split("=".ToCharArray());
                Properties.Add(keysValues[0], keysValues[1]);
            }
            return Properties;
        }
    }
}
