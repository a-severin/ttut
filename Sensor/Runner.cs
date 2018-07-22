using System;
using System.Threading;

namespace Sensor {
    public class Runner: IDisposable {
        private readonly Client _client;
        private readonly int _period;
        private readonly Random _random;
        private readonly Timer _timer;
        private readonly ManualResetEvent _holder = new ManualResetEvent(false);

        public Runner(Client client, int period = 3000) {
            _client = client;
            _period = period;
            _random = new Random();
            _timer = new Timer(_action);
        }

        private void _action(object state) {
            var value = _random.Next();
            _client.Send(value);
        }

        public void Run() {
            _timer.Change(0, _period);
            _holder.WaitOne();
        }

        public void Dispose() {
            _timer?.Dispose();
            _holder?.Dispose();
        }
    }
}