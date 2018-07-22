using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Commons;

namespace Monitor {
    internal class Program {
        private static void Main(string[] args) {
            new Server(new Configuration(args), new ConsoleIO()).Start();
        }
    }
}