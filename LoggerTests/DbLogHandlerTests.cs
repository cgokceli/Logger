using Logger.Handlers.Db;
using Tests.Helpers;
using Xunit;

namespace Tests {
    [Collection("LogTests")]
    public class DbLogHandlerTests {
        [Theory]
        [ClassData(typeof(TestData))]
        public void CanAddLog(TestObject data) {
            var container = new Container();

            var dbLogHandler = container.GetService<IDbLogHandler>();

            Assert.True(dbLogHandler.TryAddLog($"Test Message {data.Prop1}", data));
        }
    }
}
