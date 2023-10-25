namespace Domain
{
    public class CourseHeadline
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int Duration { get; set; }
        public string Desceription { get; set; }
        /// <summary>
        /// تعداد قسمت
        /// </summary>
        public int SectionCount { get; set; }
    }
}
