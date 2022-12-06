using kirillov_chat_api_api_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kirillov_chat_api_api_api.Response
{
    public class ResponceChatRoom
    {
        public ResponceChatRoom(ChatRoom chatroom)
        {
            id = chatroom.id;
            Topic = chatroom.Topic;
        }
        public int id { get; set; }
        public string Topic { get; set; }
    }
}