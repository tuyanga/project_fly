using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class SocketWorker : BackgroundService
{
    private readonly List<TcpClient> _agentClients = new();
    private readonly object _lock = new();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var listener = new TcpListener(IPAddress.Any, 6001);
        listener.Start();
        while (!stoppingToken.IsCancellationRequested)
        {
            var client = await listener.AcceptTcpClientAsync();
            lock (_lock) { _agentClients.Add(client); }
            // Optionally: Start a background task to remove disconnected clients
        }
    }

    public void BroadcastToAgents(string message)
    {
        lock (_lock)
        {
            foreach (var client in _agentClients.ToList())
            {
                try
                {
                    var stream = client.GetStream();
                    var data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                }
                catch
                {
                    _agentClients.Remove(client);
                }
            }
        }
    }
}