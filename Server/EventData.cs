using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Server.SocketServer;

namespace Server
{
    public class EventData
    {
        // Loại sự kiện
        [JsonProperty("Type")]
        public EventType Type { get; set; }

        // Dữ liệu của sự kiện
        [JsonProperty("Data")]
        public Dictionary<string, object> Data { get; set; }

        public EventData()
        {
            // Khởi tạo dictionary để lưu trữ dữ liệu
            Data = new Dictionary<string, object>();
        }
    }
}
