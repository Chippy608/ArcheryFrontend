namespace TestAPI_Archery.DB
{
    public class PointCounting
    {
        public int Id { get; set; }

        public int user_id { get; set; }

        public int event_id { get; set; }

        public string? ring { get; set; }

        public int arrownum { get; set; }

        public int deernum { get; set; }
    }
}
