using System.IO.Pipes;

class ClientApp
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Client is trying to connect to the server...");
        using (var client = new NamedPipeClientStream(".", "TestPipe", PipeDirection.InOut, PipeOptions.Asynchronous))
        {
            await client.ConnectAsync();
            Console.WriteLine("Connected to the server!");

            var reader = new StreamReader(client);
            var writer = new StreamWriter(client) { AutoFlush = true };

            // Read messages from the server in a background task
            Task.Run(async () =>
            {
                while (client.IsConnected)
                {
                    string? message = await reader.ReadLineAsync();
                    if (message != null)
                    {
                        Console.WriteLine($"Server: {message}");
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
