//Educational port scanner by Rafael M.
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

class PortScanner
{
    static async Task ScanPort(string host, int port, int timeoutMs = 500):
    {
        using var client = new TcpClient();

        try
        {
            var connectTask = client.ConnectAsync(host, port);
            var timeoutTask = Task.Delay(timeout)
        }
    }
}