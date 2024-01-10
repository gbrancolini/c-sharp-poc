using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern
{
    internal class DataService
    {
        private RetryExecutor executor;

        public DataService() { 
            RetryStrategy retryStrategy = new RetryStrategy(3, TimeSpan.FromSeconds(3));
            executor = new RetryExecutor(retryStrategy);
        }

        public async void GetSomeData()
        {
            

                await executor.RetryAsync(
                    () =>
                    {
                        using (var client = new HttpClient())
                        {
                            string url = "https://httpstat.us/408";
                            Console.WriteLine("Sending request to server...");
                            try
                            {
                                _ = client.GetAsync(url).Result;
                            }
                            catch (HttpRequestException httpEx)
                            {
                                Console.WriteLine(httpEx.Message);
                            }
                            catch (TaskCanceledException tEx)
                            {
                                Console.WriteLine(tEx.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Ends");
                            }
                        }

                    }
                );
           
        }
    }
}
