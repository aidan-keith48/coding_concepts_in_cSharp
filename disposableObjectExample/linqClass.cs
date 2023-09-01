using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disposableObjectExample
{
    public class linqClass
    {
        //LINQ For Listcollection
        List<string> stringList = new List<string>()
            {
                "C# Tutorials","VB.Net Tutorials", "Learn c++", "MVC Tutorials","Java"
            };
        public void linqFunctions()
        {
            var results =from s in stringList
                         where s.Contains("Tutorial")
                         select s;

            foreach(var st in results)
            {
                Console.WriteLine(st.ToString() +"\n");
            }
        }


        //LINQ forDicotnary collection
        Dictionary<string, bool> stringDictionary = new Dictionary<string, bool>()
                {
                    { "C# Tutorials", true },
                    { "VB.Net Tutorials", true },
                    { "Learn c++", true },
                    { "MVC Tutorials", true },
                    { "Java", true }
                };

        public void linqFunctionsDictionary()
        {
            var results = from pair in stringDictionary
                          where pair.Key.Contains("Tutorial")
                          select pair.Key;

            foreach (var st in results)
            {
                Console.WriteLine(st);
            }
        }

    }
}
