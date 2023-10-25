namespace Domain
{
    public class Discount
    {
        public int Code { get; set; }
        public int Percent { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
