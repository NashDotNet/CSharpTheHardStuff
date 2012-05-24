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
			// Code block for Sample 1

			var sample1 = new Sample1();

			Console.WriteLine("Executing Sample1.");

			sample1.DoWork();

			Console.WriteLine("Finished executing Sample1.");
			Console.ReadKey(true);

			// Code block for Sample 2

			var sample2 = new Sample2();

			Console.WriteLine("Executing Sample2.");

			sample2.DoMoreWork();

			Console.WriteLine("Finished executing Sample2.");
			Console.ReadKey(true);

			// Code block for Sample 3

			var sample3 = new Sample3();
			var cts = new CancellationTokenSource();
			var cancellationToken = cts.Token;
			sample3.DoWorkUntilToldToStop(cancellationToken);
			Console.WriteLine("Press any key to stop...");
			Console.ReadKey(true);
			Console.WriteLine("Cancelling...");
			cts.Cancel();
			Console.ReadKey(true);

			// Code block for Sample 4

			var sample4 = new Sample4();

			Console.WriteLine("About to do work....");
			var total = sample4.AddUntilToldToStop(10, 5);
			Console.WriteLine("Grand total: {0}", total);
			Console.ReadKey(true);
		}
	}
}
