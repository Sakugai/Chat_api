using kirillov_chat_api_api_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kirillov_chat_api_api_api.Response
{
    public class ResponseEmployee
    {
        public ResponseEmployee(Employee employee)
        {
            id = employee.id;
            FullName = employee.FullName;
            username = employee.username;
            password = employee.password;

        }

        public int id { get; set; }
        public string FullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}