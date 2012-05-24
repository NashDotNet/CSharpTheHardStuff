using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPLSample
{
	class Sample3
	{
		public void DoWorkUntilToldToStop(CancellationToken token)
		{
			var task = new Task(() =>
			                    	{
			                    		Console.WriteLine("About to do work...");
			                    		while (!token.IsCancellationRequested)
			                    		{
			                    			Console.WriteLine("Working...");
			                    			Thread.Sleep(1000);
			                    		}
										Console.WriteLine("Work was cancelled.");
			                    	}, token);
			task.Start();
		}
	}
}
