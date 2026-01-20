using TeacherManagementSystem.Models;

namespace TeacherManagementSystem.Repositories
{
    public interface ISubjectRepository
    {
        int Add(Subject subject);

        List<Subject> GetAll();
        Subject GetById(int id);
        int Update(Subject subject);
        int Delete(int id);
        bool IsSubjectUsed(int id);
    }
}