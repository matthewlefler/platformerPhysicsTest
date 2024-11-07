using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace UnixSocketsIPC;

// 2 bytes for size of message  |  2 bytes for user inputs  |    |    |    |    |   
//          65536                          65536

struct message
{

}

public class Messenger
{
    private Socket socket;
    private NetworkStream networkStream;
    private readonly string path;

    private UnixDomainSocketEndPoint endpoint;

    public Messenger(string path)
    {
        this.path = path;

        try
        {
            endpoint = new UnixDomainSocketEndPoint(path);
            socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
        }
        catch
        {
            Debug.WriteLine("!! Failed to create socket and endpoint !!");
            throw;
        }

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

    public void write()
    {
        if(networkStream.CanWrite)
        {
            byte[] message = new byte[2];
            message[0] = 0;
            message[1] = 0;

            networkStream.Write(message);
        }
    }

    public void read()
    {
        if(networkStream.CanRead)
        {
            byte[] message = new byte[2];    
            networkStream.Read(message);

            Debug.WriteLine(message[0]);
        }
    }

}