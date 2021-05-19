using FastId;
using Xunit;

namespace FastID.Tests
{
    public class BasicTests
    {
        [Fact]
        public void TestIdGeneration()
        {
            var worker = new FastIdWorker(ulong.MaxValue);

            var id = worker.NextId();

            Assert.NotEqual(0, id);
        }
    }
}
