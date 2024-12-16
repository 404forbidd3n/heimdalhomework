using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

class MultiClientApp
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Client is trying to connect to the server...");
        using (var client = new NamedPipeClientStream(".", "MultiClientPipe", PipeDirection.InOut, PipeOptions.Asynchronous))
        {
            await client.ConnectAsync();
            Console.WriteLine("Connected to the server!");

            var reader = new StreamReader(client);
            var writer = new StreamWriter(client) { AutoFlush = true };

            // Continuously read messages from the server
            Task.Run(async () =>
            {
                while (client.IsConnected)
                {
                    string? message = await reader.ReadLineAsync();
                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine(message);
                        Console.Write("You: "); // Prompt for the user
                    }
                }
            });

            // Send messages to the server
            while (client.IsConnected)
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
