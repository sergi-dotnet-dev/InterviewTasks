namespace TestTask_Developer_Tests
{
    [TestClass]
    public class ServerImitatorTests
    {
        [TestMethod]
        public void GetCount_NoExceptions()
        {
            List<Task> tasks = new();
            try
            {
                for (var index = 0; index < 10_000; index++)
                    tasks.Add(Task.Factory.StartNew(() => ServerImitator.GetCount()));

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Assert.Fail();
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void AddToCount_NoExceptions()
        {
            List<Task> tasks = new();
            try
            {
                for (var index = 0; index < 10_000; index++)
                    tasks.Add(Task.Factory.StartNew(() => ServerImitator.AddToCount(1)));

                Task.WaitAll(tasks.ToArray());

                Assert.AreEqual(10_000, ServerImitator.GetCount());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}