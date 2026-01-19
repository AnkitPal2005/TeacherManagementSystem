namespace TeacherManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
