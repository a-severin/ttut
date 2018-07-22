using Commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class ConfigurationTests {
        [TestMethod]
        [DataRow(new[] {"-p", "3000", "-h", "test.com"}, "test.com", 3000)]
        [DataRow(new[] {"-h", "test.com"}, "test.com", Configuration.DefaultPort)]
        [DataRow(new[] {"-p", "3000"}, Configuration.DefaultHost, 3000)]
        [DataRow(new[] {"-p", "qwe"}, Configuration.DefaultHost, Configuration.DefaultPort)]
        public void Configuration_CorrectParsing(string[] args, string hostname, int port) {
            var configuration = new Configuration(args);
            Assert.AreEqual(hostname, configuration.Hostname);
            Assert.AreEqual(port, configuration.Port);
        }
    }
}
