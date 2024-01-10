namespace RetryPattern
{
    public class RetryExecutor
    {
        public RetryStrategy RetryStrategy { get; set; }

        public RetryExecutor(RetryStrategy retryStrategy) 
        {  
            RetryStrategy = retryStrategy; 
        }

        public async Task RetryAsync(Action logic)
        {
            int retries = 0;
            int maxRetries = RetryStrategy.MaxRetries;
            TimeSpan interval = RetryStrategy.Interval;

            while (true)
            {
                try
                {
                    retries++;
                    Console.WriteLine($"retry {retries}");

                    logic();
                    break;
                }
                catch(HttpRequestException httpEx)
                {
                    Console.WriteLine(httpEx.Message);
                }
                catch(TaskCanceledException tEx)
                {
                    Console.WriteLine(tEx.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception {e.Message}");
                    if (retries == maxRetries)
                    {
                        Console.WriteLine("Max retries, end of execution");
                        break;
                    }
                    else
                    {
                        Console.WriteLine(e.ToString());
                        _ = Task.Delay(interval);
                    }
                }

            }
        }
    }
}
