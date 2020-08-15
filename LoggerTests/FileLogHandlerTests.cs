using Logger.Handlers.File;
using Tests.Helpers;
using Xunit;

namespace Tests {
    [Collection("LogTests")]
    public class FileLogHandlerTests {
        [Theory]
        [ClassData(typeof(TestData))]
        public void CanAddLog(TestObject data) {
            var container = new Container();

            var fileLogHandler = container.GetService<IFileLogHandler>();

            Assert.True(fileLogHandler.TryAddLog($"Test Message {data.Prop1}", data));
        }
    }
}
