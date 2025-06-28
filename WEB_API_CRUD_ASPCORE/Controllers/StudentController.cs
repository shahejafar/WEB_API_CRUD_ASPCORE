using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_CRUD_ASPCORE.Models;

namespace WEB_API_CRUD_ASPCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {
        private readonly studentContext db;

        public StudentController(studentContext db)
        {
            this.db = db;
        }

       
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Students()
        {
           var data = await db.Students.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var st = await db.Students.FindAsync(id);
            if(st == null)
            {
                return NotFound();
            }
            return st;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student st)
        {

            await db.Students.AddAsync(st);
            await db.SaveChangesAsync();
            return Ok(st);
            
        }

        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(Student st, int id)
        {
            if(id != st.Id)
            {
                return BadRequest();
            }
            db.Entry<Student>(st).State = EntityState.Modified;
            await db.SaveChangesAsync();
            
            return Ok(st);
            
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
             var st =await db.Students.FindAsync(id);
            if(st == null)
            {
                return NotFound();
            }
             db.Students.Remove(st);
          await  db.SaveChangesAsync();
            return Ok();
        }



        


    }
}
