using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Commons;

namespace Monitor {
    public class Server: IDisposable {
        private readonly Configuration _configuration;
        private readonly IO _io;
        private readonly ManualResetEvent _holder = new ManualResetEvent(false);
        private TcpListener _server;

        public Server(Configuration configuration, IO io) {
            _configuration = configuration;
            _io = io;
        }

        public void Start() {
            _getReady();
            Task.Run(_action);
            _holder.WaitOne();
        }

        private Task _action() {
            _io.Output("Wait connection...");
            using (var client = _server.AcceptTcpClient()) {
                _io.Output("Client connected. Wait data...");

                using (var stream = client.GetStream()) {
                    while (true) {
                        if (stream.DataAvailable) {
                            var buffer = BitConverter.GetBytes(0);
                            stream.Read(buffer, 0, buffer.Length);
                            var value = BitConverter.ToInt32(buffer, 0);
                            _io.Output($"Accept {value}");
                            Thread.Sleep(3000);
                        }
                    }
                }
            }
        }

        private void _getReady() {
            if (_server == null) {
                _server = new TcpListener(IPAddress.Parse(_configuration.Hostname), _configuration.Port);
                _server.Start();
            }
        }

        public void Dispose() {
            _holder?.Dispose();
        }
    }
}