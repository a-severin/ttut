using System;
using System.Net.Sockets;
using Commons;

namespace Sensor {
    public class Client : IDisposable {
        private readonly Configuration _configuration;
        private readonly IO _io;
        private TcpClient _client;
        private NetworkStream _stream;

        public Client(Configuration configuration, IO io) {
            _configuration = configuration;
            _io = io;
        }

        public void Send(int value) {
            _io.Output($"Send {value}");
            _getReady();
           
            var buffer = BitConverter.GetBytes(value);
            _stream.Write(buffer, 0, buffer.Length);
        }

        private void _getReady() {
            if (_stream == null) {
                _client = new TcpClient(_configuration.Hostname, _configuration.Port);
                _stream = _client.GetStream();
            }
        }

        public void Dispose() {
            _stream?.Dispose();
            ((IDisposable) _client)?.Dispose();
        }
    }
}