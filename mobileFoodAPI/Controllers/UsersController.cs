using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using mobileFoodAPI;

namespace mobileFoodAPI.Controllers
{
    public class UsersController : ApiController
    {
        private FoodEntities db = new FoodEntities();

        // GET: api/Users
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }


        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(string telephoneUser) // Поиск существования пользователя
        {
            Users users = db.Users.FirstOrDefault(x => x.Telephone_User == telephoneUser);

            if (users == null)
            {
                return NotFound();
            }
            else return Ok(users);
        }

        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(string telephoneUser, string passwordUser) // Проверка правильности введенных данных для существующего пользователя
        {
            Users users = db.Users.FirstOrDefault(x => x.Telephone_User == telephoneUser);
            
            if (users.Password_User != passwordUser)
            {
                return BadRequest();
            }
            else return Ok(users);
        }

        

        //[Route("https://ngknn.ru:5001/NGKNN/СергеичевАД/users")]
        //[HttpGet]
        //public async Task<IHttpActionResult> GetUsers(string loginUser)
        //{
        //    Users users = db.Users.Find(loginUser);
        //    if (users == null) return NotFound();
        //    else return Ok(users);
        //}



        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Code_User)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.Code_User }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Code_User == id) > 0;
        }
    }
}