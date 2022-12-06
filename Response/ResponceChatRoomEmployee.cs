using kirillov_chat_api_api_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kirillov_chat_api_api_api.Response
{
    public class ResponceChatRoomEmployee
    {
        public ResponceChatRoomEmployee(ChatRoomEmployee chatroomEmploee)
        {
            id = chatroomEmploee.id;
            IdChatRoom = (int)chatroomEmploee.idChatRoom;
            idEmployee = (int)chatroomEmploee.idEmployee;
        }

        public int id { get; set; }
        public int IdChatRoom { get; set; }
        public int idEmployee { get; set; }
    }
}