namespace DiscsIntersectionsNumber.Tests
{
    public class SolutionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Solution_11Returned()
        {
            var arr = new Int32[6] { 1, 5, 2, 1, 4, 0 };
            Assert.That(Solution.solution(arr), Is.EqualTo(11));
        }
        [Test]
        public void Solition_0Returned()
        {
            var arr = new Int32[5] { 0, 0, 0, 0, 0 };
            Assert.That(Solution.solution(arr), Is.EqualTo(0));
        }
        [Test]
        public void Solition_4Returned()
        {
            var arr = new Int32[5] { 0, 20, 0, 0, 0 };
            Assert.That(Solution.solution(arr), Is.EqualTo(4));
        }
        [Test]
        public void Solition_3Returned()
        {
            var arr = new Int32[5] { 3, 0, 0, 0, 0 };
            Assert.That(Solution.solution(arr), Is.EqualTo(3));
        }
        [Test]
        public void Solution_2Returned()
        {
            var arr = new Int32[3] { 1, Int32.MaxValue, 0 };
            Assert.That(Solution.solution(arr), Is.EqualTo(2));
        }
    }
}