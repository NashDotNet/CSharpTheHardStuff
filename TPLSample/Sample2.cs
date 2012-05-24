using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPLSample
{
	class Sample2
	{
		public void DoMoreWork()
		{
			var task1 = new Task(() =>
			                     	{
			                     		Console.WriteLine("Starting task 1");
			                     		Thread.Sleep(3000);
										Console.WriteLine("Task 1 finished.");
			                     	});
			var task2 = new Task(() =>
			                     	{
			                     		Console.WriteLine("Starting task 2...");
			                     		Thread.Sleep(1000);
			                     		Console.WriteLine("More work in task 2");
			                     		Thread.Sleep(1000);
			                     		Console.WriteLine("More work in task 2 again");
			                     		Console.WriteLine("Task 2 finished.");
			                     	});
			task1.Start();
			task2.Start();

			Task.Factory.ContinueWhenAll(new Task[] {task1, task2}, t =>
			                                                        	{
			                                                        	
			                                                        	});


			Console.WriteLine("All tasks finished.");
		}
	}
}
