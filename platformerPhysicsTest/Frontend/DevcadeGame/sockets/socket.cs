using System.Diagnostics;
using System.Net.Sockets;

namespace UnixSocketsIPC;

struct message
{

}

class Messenger
{
    private Socket socket;
    private NetworkStream networkStream;
    private readonly string path;

    private UnixDomainSocketEndPoint endpoint;

    public Messenger(string path)
    {
        this.path = path;

        endpoint = new UnixDomainSocketEndPoint(path);
        socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);

         try
        {
            socket.Connect(endpoint);
            networkStream = new NetworkStream(socket, false);
         }
        catch
        {
            socket.Dispose();
            Debug.WriteLine($"!! socket at {path} could not connect !!");
            throw;
        }
    }

    public void send()
    {
        if(networkStream.CanWrite)
        {
            //networkStream.BeginWrite()
        }
    }

}