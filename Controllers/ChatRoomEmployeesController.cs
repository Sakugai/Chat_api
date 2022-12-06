using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using kirillov_chat_api_api_api.Models;
using kirillov_chat_api_api_api.Response;

namespace kirillov_chat_api_api_api.Controllers
{
    public class ChatRoomEmployeesController : ApiController
    {
        private kirillov_apichatEntities db = new kirillov_apichatEntities();

        // GET: api/ChatRoomEmployees
        public IHttpActionResult GetChatRoomEmployee()
        {
            return Ok(db.ChatRoomEmployee.ToList().ConvertAll(i => new ResponceChatRoomEmployee(i)));
        }

      

        // GET: api/ChatRoomEmployees/5
        [ResponseType(typeof(ChatRoomEmployee))]
        public IHttpActionResult GetChatRoomEmployee(int id)
        {
            ChatRoomEmployee chatRoomEmployee = db.ChatRoomEmployee.Find(id);
            if (chatRoomEmployee == null)
            {
                return NotFound();
            }

            return Ok(chatRoomEmployee);
        }

        // PUT: api/ChatRoomEmployees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChatRoomEmployee(int id, ChatRoomEmployee chatRoomEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatRoomEmployee.id)
            {
                return BadRequest();
            }

            db.Entry(chatRoomEmployee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatRoomEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ChatRoomEmployees
        [ResponseType(typeof(ChatRoomEmployee))]
        public IHttpActionResult PostChatRoomEmployee(ChatRoomEmployee chatRoomEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatRoomEmployee.Add(chatRoomEmployee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chatRoomEmployee.id }, chatRoomEmployee);
        }

        // DELETE: api/ChatRoomEmployees/5
        [ResponseType(typeof(ChatRoomEmployee))]
        public IHttpActionResult DeleteChatRoomEmployee(int id)
        {
            ChatRoomEmployee chatRoomEmployee = db.ChatRoomEmployee.Find(id);
            if (chatRoomEmployee == null)
            {
                return NotFound();
            }

            db.ChatRoomEmployee.Remove(chatRoomEmployee);
            db.SaveChanges();

            return Ok(chatRoomEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatRoomEmployeeExists(int id)
        {
            return db.ChatRoomEmployee.Count(e => e.id == id) > 0;
        }
    }
}