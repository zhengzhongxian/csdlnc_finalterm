using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointManagement_Application.Helper
{
    public class WebSocketClient
    {
        public async Task ConnectAsync()
        {
            using (var client = new ClientWebSocket())
            {
                try
                {
                    await client.ConnectAsync(new Uri("ws://localhost:5000/progressHub"), CancellationToken.None);
                    Console.WriteLine("WebSocket kết nối thành công!");

                    var message = "Hello from WebSocket client";
                    var buffer = Encoding.UTF8.GetBytes(message);
                    await client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);

                    // Đọc tin nhắn từ server
                    var receiveBuffer = new byte[1024];
                    var result = await client.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                    Console.WriteLine("Nhận tin nhắn: " + Encoding.UTF8.GetString(receiveBuffer, 0, result.Count));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi WebSocket: {ex.Message}");
                }
            }
        }
    }
}
