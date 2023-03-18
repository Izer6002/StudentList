using StudentList.DataBase.Entity;

namespace StudentList.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
