using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Commons;

namespace Sensor {
    class Program {
        static void Main(string[] args) {
            new Runner(new Client(new Configuration(args), new ConsoleIO())).Run();
        }
    }
}