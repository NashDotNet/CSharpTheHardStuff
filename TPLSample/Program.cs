using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var sample = new Sample4();

			Console.WriteLine("About to do work....");
			var total = sample.AddUntilToldToStop(10, 5);
			Console.WriteLine("Grand total: {0}", total);
			Console.ReadKey(true);
		}
	}
}
