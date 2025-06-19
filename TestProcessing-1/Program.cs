using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProcessing_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("gimmefile");
            var z = Console.ReadLine();
            var q = File.ReadAllLines(z);
            Dictionary<string,int> a = new Dictionary<string,int>();
            for (int i=0; i<q.Length; i++)
            {
                var s = Regex.Replace(q[i],@"[^\w\s]", "").ToLower();
                var t = s.Split(' ');
                for (int j=0;j<t.Length;j++) 
                {
                    var w = t[j];
                    if (w != "")
                    {
                        if (a.ContainsKey(w))
                            a[w] = a[w] + 1;    
                        else
                            a.Add(w, 1);
                    }
                }
            }
            Console.WriteLine("Done");
            foreach (var e in a)
            {
                Console.WriteLine(e.Key + ":" + e.Value);
            }
            Console.WriteLine("uniquez = " + a.Count);
            Console.ReadKey();
        }
    }
}
