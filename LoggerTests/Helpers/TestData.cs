using Xunit;

namespace Tests.Helpers {
    public class TestObject {
        public TestObject(int prop1, string prop2) {
            this.Prop1 = prop1;
            this.Prop2 = prop2;
        }
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
    }

    public class TestData : TheoryData<TestObject> {
        public TestData() {
            for (var i = 1; i <= 5; i++) {
                Add(new TestObject(i, $"Test Data {i}"));
            }
        }
    }
}
