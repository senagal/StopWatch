// See https://aka.ms/new-console-template for more information

        Stopwatch stopwatch = new Stopwatch();

        // Subscribing to teh events
        stopwatch.OnStarted += MessageHandler;
        stopwatch.OnStopped += MessageHandler;
        stopwatch.OnReset += MessageHandler;

        Console.WriteLine("Stopwatch Application");
        Console.WriteLine("Use the following commands:");
        Console.WriteLine("S - StopwatchStarted");
        Console.WriteLine("T - StopwatchStopped");
        Console.WriteLine("R - StopwatchReseted");
        Console.WriteLine("E - ExitingStopwatch");

        while (true)
        {
            Console.Write("Enter command: ");
            char command = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (char.ToUpper(command))
            {
                case 'S':
                    stopwatch.Start();
                    break;
                case 'T':
                    stopwatch.Stop();
                    break;
                case 'R':
                    stopwatch.Reset();
                    break;
                case 'E':
                    Console.WriteLine("Goodbye.");
                    stopwatch.Stop();
                    return;
                default:
                    Console.WriteLine("Invalid command, Please retry.");
                    break;
            }
        }

    static void MessageHandler(string message)
    {
        Console.WriteLine(message);
    }

