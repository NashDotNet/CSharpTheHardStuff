using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPLSample
{
	class Sample1
	{
		public void DoWork()
		{
			var task = new Task(() =>
			                    	{
			                    		Console.WriteLine("Starting task");
			                    		Thread.Sleep(2000);
										Console.WriteLine("Exiting task");
			                    	});
			task.Start();
		}
	}
}
