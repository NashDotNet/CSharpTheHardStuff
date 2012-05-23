using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var states = new List<State>();
            IEnumerable<string> enumerable = states.Where(s => s.Name == "TN")
                .Select(s => s.Name);
        }
    }

    internal class State
    {
        public string Name { get; set; }
    }
}
