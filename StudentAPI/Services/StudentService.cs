using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Domain;
using StudentAPI.Domain.Dtos;
using StudentAPI.Domain.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;// = new StudentDbContext();
        public StudentService(StudentDbContext dbContext) { 
            _dbContext = dbContext;
        }

        public void AddStudent(StudentDto student)
        {
            _dbContext.Students.Add(new Domain.Models.Student
            {
                Name=student.Name,
                Email=student.Email,
                Phone=student.Phone,
            });

            _dbContext.SaveChanges();
        }


        public Student GetStudentById(int id)
        {
            return _dbContext.Students.Include(s=>s.Cources).FirstOrDefault(x=>x.Id==id);
        }

        public Cource GetCourceById(int id)
        {
            return _dbContext.Cources.Find(id);
        }

        public List<Cource> GetAllCources()
        {
            return _dbContext.Cources.ToList();
        }

        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.Include(s=> s.Cources).ToList();
        }

        public bool assignCource(int studentId, int courceId)
        {
            var student = _dbContext.Students.AsNoTracking().FirstOrDefault(s=> s.Id == studentId);
            var cource = _dbContext.Cources.AsNoTracking().FirstOrDefault(s => s.Id == courceId);

            if((student == null) || (cource == null))
            {
                return false;
            }
            //var newStudent = new Student
            //{
            //    Name = student.Name,
            //    Email = student.Email,
            //    Phone = student.Phone,
            //    Cources = new List<Cource>
            //    {
            //        cource,
            //    },
            //};

            student.Cources = new List<Cource>
                {
                    cource,
                };

            _dbContext.Students.Update(student);


            //var newCource = new Cource
            //{
            //    Name = cource.Name,
            //    Students = new List<Student>
            //    {
            //        student,
            //    },

            //};

            cource.Students = new List<Student>
                {
                    student,
                };

            _dbContext.Cources.Update(cource);
        
            
            

            _dbContext.SaveChanges();

            return true;
        }
    }
}
