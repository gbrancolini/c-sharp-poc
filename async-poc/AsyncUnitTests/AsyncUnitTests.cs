namespace AsyncUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        /// <summary>
        /// This tests shows the importance of using async Task instead of async Void in a method.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task WhenMethodIsTaskOrVoidExceptionHandling()
        {
            // Pay close attention, with task we have rethrown the exception.
            Assert.ThrowsAsync<Exception>(async delegate { await ExceptionIntoATaskMethod(); });

            // otherwise... we wont!!!
            Assert.DoesNotThrow(delegate { ExceptionIntoAVoidMethod(); });
        }


        private async Task ExceptionIntoATaskMethod()
        {
            throw new Exception("Exception from a tasked method.");
        }

        private async void ExceptionIntoAVoidMethod()
        {
            throw new Exception("Exception from a voided method.");
        }

        private async Task<string> FakeStringMethodAsync(string message, int milliseconds)
        {
            return await Task.Run(() => { 
                Thread.Sleep(milliseconds);
                return message;
            });
        }

        /// <summary>
        /// This explains a potentially deadlock sitution using Wait()
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task WhenDeadlockHappensUsingWait()
        {
            // the main thread is waiting for the outer task to complete.

            // the outer task (potentiallyDeadlockedTask) is waiting for the inner task to complete
            Task potentiallyDeadlockedTask;
            potentiallyDeadlockedTask = Task.Run(() =>
            {
                // The inerTask is waiting for the main thread to be free, which is waitinf rot the potetiallyDeadlockedTask
                Task innerTask = Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                innerTask.Wait(); //this is the cause of deadlock.
            });
               
            // we are waiting a timeout
            Task delay = Task.Delay(TimeSpan.FromSeconds(5));
            // this potentially keeps running (if we run only this test) or waiting to run (in case we run all tests together
            Assert.IsTrue(potentiallyDeadlockedTask.Status == TaskStatus.Running || potentiallyDeadlockedTask.Status == TaskStatus.WaitingToRun);
        }

        [Test]
        public async Task WhenDeadlockHappensUsingResult()
        {
            Task<string> outerTask = Task.Run(() => {
                Task<string> innerTask = Task.Run(() =>
                {
                    return "Completed";
                });
                return innerTask.Result;
            });
            // we are waiting a timeout
            Task delay = Task.Delay(TimeSpan.FromSeconds(5));
            // this potentially keeps running
            Assert.IsTrue(outerTask.Status == TaskStatus.Running);
        }

        [Test]
        public async Task TestContinuationWithAwait()
        {
            string message = "Message";

            var task = await FakeStringMethodAsync(message, 5);
            //once the task ends, we continue in the same thread

            Assert.AreEqual(message, task);
        }

        [Test]
        public async Task TestContinuationWithContinueWith()
        {
            string message = "Message";

            var task = FakeStringMethodAsync(message, 5);

            task.ContinueWith(continuedTask =>
            {
                // we are running in a separate thread
                Assert.AreEqual(message, continuedTask.Result);
                Assert.IsTrue(continuedTask.IsCompletedSuccessfully);
            }).Wait();
        }

        [Test]
        public async Task TestAwaitContinuesDifferentThread()
        {
            var message = "Message";
            int originalThreadId = Thread.CurrentThread.ManagedThreadId;
            var task = FakeStringMethodAsync(message, 5);

            var result = await task;
            int resumedThreadId = Thread.CurrentThread.ManagedThreadId;

            Assert.AreEqual(message, result);
            Assert.AreNotEqual(originalThreadId, resumedThreadId);
            // this happens because we are running in a console app, and this unit framework does not has a pool thread by defautl (unless TaskScheduler is define)
        }

        [Test]
        public async Task TestContinueWithRunsOnDifferentThread()
        {
            var message = "Message";
            int originalThread = Thread.CurrentThread.ManagedThreadId;

            var task = FakeStringMethodAsync(message, 5);

            task.ContinueWith(continuedTask =>
            {
                int continuedThreadId = Thread.CurrentThread.ManagedThreadId;
                Assert.AreEqual(message, task.Result);
                Assert.AreNotEqual(originalThread, continuedThreadId);
            }).Wait();

            int afterContinueWithThread=Thread.CurrentThread.ManagedThreadId;

            Assert.AreEqual(originalThread, afterContinueWithThread);
        }
    }
}