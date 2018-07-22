
using System;

namespace Commons {
    public class Configuration {
        public const string DefaultHost = "127.0.0.1";
        public const int DefaultPort = 50001;

        public Configuration(string[] args) {
            for (int i = 0; i < args.Length; i++) {
                var param = args[i];
                if (param.Equals("-h", StringComparison.InvariantCultureIgnoreCase) && 
                    i + 1 < args.Length) {
                    Hostname = args[i + 1];
                }

                if (param.Equals("-p", StringComparison.CurrentCultureIgnoreCase) &&
                    i + 1 < args.Length) {
                    var portInput = args[i + 1];
                    if (int.TryParse(portInput, out var portValue)) {
                        Port = portValue;
                    }
                }
            }
        }

        public string Hostname { get; } = DefaultHost;

        public int Port { get; } = DefaultPort;
    }
}