using Logger;
using Tests.Helpers;
using Xunit;

namespace Tests {
    [Collection("LogTests")]
    public class LoggerTests {
        [Theory]
        [ClassData(typeof(TestData))]
        public void AddLog(TestObject data) {
            var container = new Container();

            var logger = container.GetService<ILogger>();

            logger.Add($"Test Message {data.Prop1}", data);
        }
    }
}
