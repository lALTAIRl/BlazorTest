using NetMQ;
using NetMQ.Sockets;

Console.WriteLine("Test");

using (var server = new ResponseSocket())
{
    server.Bind("tcp://localhost:5556");
    while (true)
    {
        var message = server.ReceiveFrameString();
        Console.WriteLine("Received {0}", message);
        // processing the request
        //Thread.Sleep(100);
        //Console.WriteLine("Sending World");
        server.SendFrame("Created");
    }
}
