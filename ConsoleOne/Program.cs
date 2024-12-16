using System.IO.Pipes;

class ServerApp
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Server is waiting for a connection...");
        using (var server = new NamedPipeServerStream("TestPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
        {
            await server.WaitForConnectionAsync();
            Console.WriteLine("Client connected!");

            var reader = new StreamReader(server);
            var writer = new StreamWriter(server) { AutoFlush = true };

            // Read messages from the client in a background task
            Task.Run(async () =>
            {
                while (server.IsConnected)
                {
                    string? message = await reader.ReadLineAsync();
                    if (message != null)
                    {
                        Console.WriteLine($"Client: {message}");
                        Console.Write("You: "); // Prompt for the user
                    }
                }
            });

            // Send messages to the client
            while (server.IsConnected)
            {
                Console.Write("You: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    await writer.WriteLineAsync(input);
                }
            }
        }
    }
}
