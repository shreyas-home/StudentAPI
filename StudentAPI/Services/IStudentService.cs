using StudentAPI.Domain.Dtos;
using StudentAPI.Domain.Models;

namespace StudentAPI.Services
{
    public interface IStudentService
    {
        void AddStudent(StudentDto student);

        List<Student> GetAllStudents();

        List<Cource> GetAllCources();
    }
}
