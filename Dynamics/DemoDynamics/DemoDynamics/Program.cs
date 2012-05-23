using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace DemoDynamics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Reflection
            DoItWithDynamics();
            DoItTheOldFashionedWay();
            
            // Lots of params
            DoSomethingWithParams(new
                {
                    FirstName = "Jonathan", 
                    LastName = "Creamer",
                    Age = 23,
                    School = new
                        {
                            Name = "MTSU",
                            GradYear = 2012
                        }
                });

            DoThatStackOverflowyThing();

            dynamic expandoThingy = new ExpandoObject();
            expandoThingy.Name = "Thing";
            expandoThingy.Movies = new object[]
                {
                    new {
                            Name = "Star Wars",
                            Rating = "PG"
                        },
                    new {
                            Name = "The Matrix",
                            Rating = "R"
                        }
                };

            var bankAccounts = new List<Account> 
            {
                new Account { 
                              ID = 345678,
                              Balance = 541.27
                            },
                new Account {
                              ID = 1230221,
                              Balance = -127.44
                            }
            };

            // Display the list in an Excel spreadsheet.
//            
            Walkthrough.DisplayInExcel(bankAccounts);

            // Create a Word document that contains an icon that links to
            // the spreadsheet.
//            Walkthrough.CreateIconInWordDoc();

            dynamic x = new ExpandoObject();
            x.SomeText = "This is some text";
            x.Value = 30;
            x.Run = new Action(() => Console.WriteLine("Running a recently added method!"));
            Console.WriteLine(x.SomeText);
            Console.WriteLine(x.Value);
            x.Run();

            DoThatTwitteryThing();
        }

        private static void DoThatStackOverflowyThing()
        {
            var client = new WebClient();
            var stackRequest = new StringBuilder(string.Format("http://api.stackoverflow.com/1.1/users/{0}", 558672));

            byte[] response = client.DownloadData(stackRequest.ToString());

            if (response == null)
            {
                throw new Exception(string.Format("No response from request {0}", "Users"));
            }

            var decompress = new GZipStream(new MemoryStream(response), CompressionMode.Decompress);
            var reader = new StreamReader(decompress);
            string ret = reader.ReadToEnd();
            dynamic userResponse = JObject.Parse(ret);
            var displayName = userResponse.users[0].display_name;
            Console.Write(displayName); 
        }

        private static void DoThatTwitteryThing()
        {
            var client = new WebClient();
            var twitterRequest = client.DownloadData("http://search.twitter.com/search.json?q=@jcreamer898");
            var reader = new StreamReader(new MemoryStream(twitterRequest));
            string response = reader.ReadToEnd();
            dynamic tw = JObject.Parse(response);
            dynamic results = tw.results;
            
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();


            string text = "";
            foreach (dynamic result in results)
            {
                text += result.text + Environment.NewLine;
            }

            wordApp.ActiveDocument.Content.Text = text;
        }

        private static void DoSomethingWithParams(dynamic args)
        {
            Console.WriteLine(args.FirstName);
            Console.WriteLine(args.School.Name);
        }
        

        private static void DoItTheOldFashionedWay()
        {
            // Get the Assembly
            Assembly asm = Assembly.Load("Calculator");
            
            // Get the type of a Basic Calculator
            Type type = asm.GetType("Calculator.Basic");
            
            // Create an instance of a Basic Calculator
            object obj = Activator.CreateInstance(type);
            
            // Get the method
            MethodInfo mi = type.GetMethod("Add");
            
            // Create an object array of args
            object[] args = {1, 3};
            
            // Run the method
            var answer = (float)mi.Invoke(obj, args);
            
            // Whew, lots of lines there... Did it work?!
            Console.WriteLine(answer);
        }

        private static void DoItWithDynamics()
        {
            // Get the Assembly
            Assembly asm = Assembly.Load("Calculator");
            
            // Get the Type
            Type type = asm.GetType("Calculator.Basic");
            
            // Create an instance
            dynamic calculator = Activator.CreateInstance(type);

            // Run it!
            float answer = calculator.Add(1, 3);

            // A bit shorter this time
            Console.WriteLine(answer);
        }
    }
}
