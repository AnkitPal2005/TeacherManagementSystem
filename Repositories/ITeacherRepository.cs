using TeacherManagementSystem.Models;
namespace TeacherManagementSystem.Repositories
{
    public interface ITeacherRepository
    {
        List<Teacher> GetAll();
        Teacher GetById(int id);
        int Add(Teacher teacher);
        int Update(Teacher teacher);
        int Delete(int id);
    }
}
