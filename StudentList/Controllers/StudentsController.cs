using Microsoft.AspNetCore.Mvc;
using StudentList.DataBase.Entity;
using StudentList.Interfaces;
using StudentList.Services;

namespace StudentList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Student> GetAllStudents()
        {
            var studentList = _studentService.GetAllStudents();
            return studentList;
        }

        [HttpGet("[action]/{id}")]
        public Student GetStudent(int id)
        {
            var studentById = _studentService.GetStudent(id);
            return studentById;
        }

        [HttpPost("[action]")]
        public void AddStudent(Student student)
        {
            _studentService.AddStudent(student);
        }

        [HttpPut("[action]")]
        public void UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
        }

        [HttpDelete("[action]")]
        public void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}
