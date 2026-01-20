using Dapper;
using Microsoft.Data.SqlClient;
using TeacherManagementSystem.Models;
namespace TeacherManagementSystem.Repositories
{
    public class TeacherRepository: ITeacherRepository
    {
        private readonly string _connectionString;
        public TeacherRepository(IConfiguration configuration)
        {
            _connectionString= configuration.GetConnectionString("DefaultConnection");
        }
        public List<Teacher> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"
        SELECT 
            T.Id,
            T.Name,
            T.Email,
            T.SubjectId,
            S.Name AS SubjectName
        FROM Teachers T
        LEFT JOIN Subjects S ON T.SubjectId = S.Id
        ORDER BY T.Id DESC";
            return connection.Query<Teacher>(sql).ToList();
        }
        public Teacher GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"Select * From Teachers Where Id=@Id";
            return connection.QueryFirstOrDefault<Teacher>(sql, new { id = id });
        }
        public int Add(Teacher teacher)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"Insert into Teachers(Name,Email,SubjectId)Values(@Name,@Email,@SubjectId)";
            return connection.Execute(sql, teacher);
        }
        public int Update(Teacher teacher)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"Update Teachers Set Name=@Name,Email=@Email,SubjectId=@SubjectId Where Id=@Id";
            return connection.Execute(sql, teacher);
        }
        public int Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"Delete From Teachers Where Id=@Id";
            return connection.Execute(sql, new { id = id });
        }
        public bool IsSubjectAlreadyAssigned(int subjctId,int teacherId = 0)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"Select Count(*)From Teachers Where SubjectId=@SubjectId And Id!=@TeacherId";
            int count = connection.ExecuteScalar<int>(sql, new { SubjectId = subjctId, TeacherID = teacherId });
            return count > 0;
        }
    }
}
