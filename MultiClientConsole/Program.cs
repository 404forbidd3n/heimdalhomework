using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Collections.Concurrent;

class MultiClientServer
{
    static ConcurrentBag<NamedPipeServerStream> clients = new ConcurrentBag<NamedPipeServerStream>();

    static async Task Main(string[] args)
    {
        Console.WriteLine("Server is running and waiting for clients...");

        // Continuously accept new client connections
        _ = Task.Run(() => AcceptClientsAsync());

        while (true)
        {
            // Broadcast messages from the server to all clients
            Console.Write("Server (to all): ");
            string? message = Console.ReadLine();
            if (!string.IsNullOrEmpty(message))
            {
                await BroadcastMessageAsync($"Server: {message}");
            }
        }
    }

    static async Task AcceptClientsAsync()
    {
        while (true)
        {
            var pipe = new NamedPipeServerStream("MultiClientPipe", PipeDirection.InOut, 10, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
            await pipe.WaitForConnectionAsync();
            clients.Add(pipe);
            Console.WriteLine("A client connected!");
            _ = Task.Run(() => HandleClientAsync(pipe)); // Handle client in a separate task
        }
    }

    static async Task HandleClientAsync(NamedPipeServerStream client)
    {
        var reader = new StreamReader(client);
        try
        {
            while (client.IsConnected)
            {
                string? message = await reader.ReadLineAsync();
                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine(message);
                    await BroadcastMessageAsync(message);
                }
            }
        }
        finally
        {
            client.Dispose();
            Console.WriteLine("A client disconnected.");
        }
    }

    static async Task BroadcastMessageAsync(string message)
    {
        foreach (var client in clients)
        {
            if (client.IsConnected)
            {
                var writer = new StreamWriter(client) { AutoFlush = true };
                await writer.WriteLineAsync(message);
            }
        }
    }
}
