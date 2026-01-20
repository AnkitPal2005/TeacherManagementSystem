using Dapper;
using Microsoft.Data.SqlClient;
using TeacherManagementSystem.Models;
namespace TeacherManagementSystem.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly string _connectionString;
        public SubjectRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        //Insert Subjects
        public int Add(Subject subject)
        {
            using var connection = new SqlConnection(_connectionString);
            {
                string sql = @"Insert Into Subjects(Name,Code)Values(@Name,@Code)";
                return connection.Execute(sql, subject);
            }
        }
        //GetAll
        public List<Subject> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            {
                string sql = @"Select * From Subjects Order By ID ASC";
                return connection.Query<Subject>(sql).ToList();
            }
        }
        public Subject GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"Select * From Subjects Where Id=@Id";
            return connection.QueryFirstOrDefault<Subject>(sql, new { Id = id });
        }
        public int Update(Subject subject)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"Update Subjects Set Name=@Name,Code=@Code Where Id=@Id";
            return connection.Execute(sql, subject);
        }
        public int Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"Delete From Subjects Where Id=@Id";
            return connection.Execute(sql, new { Id = id });
        }
        public bool IsSubjectUsed(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql= @"Select Count(*) From Teachers Where SubjectId=@Id";
            int count = connection.ExecuteScalar<int>(sql, new { Id = id });
            return count > 0;
        }
        public List<Subject> GetAvailableSubjects(int teacherId)
        {
            using var connection = new SqlConnection(_connectionString);

            string sql = @"SELECT * FROM Subjects WHERE Id NOT IN (SELECT SubjectId FROM Teachers WHERE Id != @TeacherId) ORDER BY Id ASC";

            return connection.Query<Subject>(sql, new { TeacherId = teacherId }).ToList();
        }
        public bool IsDuplicateSubject(string name, int id = 0)
        {
            using var connection = new SqlConnection(_connectionString);

            string sql = @" SELECT COUNT(*) FROM Subjects WHERE Name = @Name AND Id != @Id";

            int count = connection.ExecuteScalar<int>(sql,
                new { Name = name, Id = id });

            return count > 0;
        }

    }
}