using Microsoft.AspNetCore.Mvc;
using StudentAPI.Domain;
using StudentAPI.Domain.Dtos;
using StudentAPI.Services;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private StudentService studentService;
        public StudentController(StudentDbContext dbContext)
        {
            studentService = new StudentService(dbContext);   
        }

        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudent()
        {
            return Ok(studentService.GetAllStudents());
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent([FromBody] StudentDto student )
        {
            try
            {
                studentService.AddStudent(student);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllCouces")]
        public IActionResult GetAllCources()
        {
            return Ok(studentService.GetAllCources());
        }

        [HttpPut("AssignCouceToStudent")]
        public IActionResult assignCource(int studentId, int courceId)
        {
            if(studentService.assignCource(studentId, courceId))
            {
                return Ok();
            }
            
            return NotFound(); 
        }
    }
}
