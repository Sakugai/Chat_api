using kirillov_chat_api_api_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kirillov_chat_api_api_api.Response
{
    public class ResponceChatMessage
    {
        public ResponceChatMessage(ChatMessage chatMessage)
        {
            id = chatMessage.id;
            idEmployee = (int)chatMessage.idEmployee;
            idChatRoom = (int)chatMessage.idChatRoom;
            TextMessage = (string)chatMessage.TextMessage;
            DateTime = (DateTime)chatMessage.DateTime;
        }

        public int id { get; set; }
        public int idEmployee { get; set; }
        public int idChatRoom { get; set; }
        public string TextMessage { get; set; }
        public DateTime DateTime { get; set; }
    }
}