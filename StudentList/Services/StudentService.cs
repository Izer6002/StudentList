using StudentList.DataBase.Entity;
using StudentList.Interfaces;

namespace StudentList.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
        }
        public void AddStudent(Student student)
        {
            student.ID = students.Count + 1;
            students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            var studentToRemove = students.FirstOrDefault(s => s.ID == id);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudent(int id)
        {
            return students.FirstOrDefault(s => s.ID == id);
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.ID == student.ID);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Grade = student.Grade;
                existingStudent.Age = student.Age;
            }
        }
    }
}
