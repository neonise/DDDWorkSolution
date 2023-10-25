namespace Domain
{
    public class Course
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int TeacherPercent { get; set; }

        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> PrerequisiteCourses { get; set; }
    }
}
