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
    }
}