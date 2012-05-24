using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPLSample
{
	class Sample4
	{
		public int AddUntilToldToStop(int initialValue, int valueToAdd)
		{
			var cts = new CancellationTokenSource();
			var task = new Task<int>(() =>
			                         	{
			                         		var total = initialValue;
			                         		Console.WriteLine("Starting to add...");
			                         		while (!cts.Token.IsCancellationRequested)
			                         		{
			                         			total += valueToAdd;
			                         			Console.WriteLine("New value: {0}", total);
			                         			Thread.Sleep(1000);
			                         		}
			                         		return total;
			                         	});
			task.Start();
			Console.ReadKey(true);
			cts.Cancel();
			return task.Result;
		}
	}
}
