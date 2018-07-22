using System;

namespace Commons {
    public class ConsoleIO: IO {
        public void Output(string value) {
            Console.WriteLine(value);
        }

        public string Input() {
            return Console.ReadLine();
        }
    }
}