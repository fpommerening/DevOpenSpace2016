using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FP.DevSpace2016.Logging.Caller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Logging Caller");
            try
            {
                int number;
                do
                {
                    Console.Write("Please enter the number of simultaneous calls:");
                    var numberAsString = Console.ReadLine();

                    number = 1;

                    if (Int32.TryParse(numberAsString, out number))
                    {
                        if (number > 0)
                        {
                            var task = StartRequests(number);
                            task.Wait();
                        }
                    }

                } while (number > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }

        private static async Task StartRequests(int number)
        {
            var tasks = new List<Task>();

            for (int i = 1; i <= number; i++)
            {
                var client = new HttpClient();
                var targetUrl = GetEnvironmentVariableOrDefault("TargetUrl", "http://localhost8080/Service/");

                var request = string.Format("{0}{1}", targetUrl, Guid.NewGuid());

                var t = client.GetStringAsync(request).ContinueWith(r =>
                {
                    if (r.Exception == null)
                    {
                        Console.WriteLine(r.Result);
                    }
                    else
                    {
                        Console.WriteLine(r.Exception);
                    }
                });
                tasks.Add(t);

                if (i%15 == 0)
                {
                    await Task.WhenAll(tasks);
                    tasks.Clear();
                }
            }
            await Task.WhenAll(tasks);
        }

        public static string GetEnvironmentVariableOrDefault(string key, string defaultValue)
        {
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
            {
                if (de.Key?.ToString() == key)
                {
                    return de.Value.ToString();
                }
            }
            return defaultValue;

        }
    }
}


