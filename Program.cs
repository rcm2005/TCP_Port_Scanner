//Educational port scanner by Rafael M.
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Threading.Tasks;

class PortScanner
{
    static async Task ScanPort(string host, int port, int timeoutMs = 500)
    {
        using var client = new TcpClient();

        try
        {
            var connectTask = client.ConnectAsync(host, port);
            var timeoutTask = Task.Delay(timeoutMs);

            var completedTask = await Task.WhenAny(connectTask, timeoutTask);

            if (completedTask == connectTask && client.Connected)
            {
                Console.WriteLine($"[OPEN ] Port {port}");

            }
        }
        catch
        {
            //Silence: port closed, filterd or error
        }

    }
    static async Task Main(string[] args)
    {
        string target = "127.0.0.1"; //change for my pc or lan
        int startPort = 1;
        int endPort = 1024;

        Console.WriteLine($"Scanning {target} ports {startPort}-{endPort}...\n");

        for (int port = startPort; port <= endPort; port++)
        {
            await ScanPort(target,port);
        }
        Console.WriteLine("\nScan finished");
    }

}