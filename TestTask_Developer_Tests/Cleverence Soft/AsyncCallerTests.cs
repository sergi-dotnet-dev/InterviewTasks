namespace TestTask_Developer_Tests
{
    [TestClass]
    public class AsyncCallerTests
    {
        [TestMethod]
        public void Over5000MillieSeconds_Task_FailedReturned()
        {
            var eventHandler = new EventHandler((sender, args) => Thread.Sleep(6_000));
            var asyncCaller = new AsyncCaller(eventHandler);

            Assert.IsFalse(asyncCaller.Invoke(5_000, null, EventArgs.Empty));
        }
        [TestMethod]
        public void Less5000MillieSeconds_Task_SuccessedReturned()
        {
            var eventHandler = new EventHandler((sender, args) => Thread.Sleep(4_000));
            var asyncCaller = new AsyncCaller(eventHandler);

            Assert.IsTrue(asyncCaller.Invoke(5_000, null, EventArgs.Empty));
        }
        [TestMethod]
        public void Negative_TaskTimeoutParameter_ArgumentExceptionReturned()
        {
            var eventHandler = new EventHandler((sender, args) => Thread.Sleep(500));
            var asyncCaller = new AsyncCaller(eventHandler);

            try
            {
                asyncCaller.Invoke(-200, null, EventArgs.Empty);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void Zero_TaskTimeoutParameter_ArgumentExceptionReturned()
        {
            var eventHandler = new EventHandler((sender, args) => Thread.Sleep(500));
            var asyncCaller = new AsyncCaller(eventHandler);

            try
            {
                asyncCaller.Invoke(0, null, EventArgs.Empty);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}