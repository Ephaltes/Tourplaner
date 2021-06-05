namespace frontend.Entities
{
    /// <summary>
    /// Response Object from the TourService Backend
    /// </summary>
    public class ResponseObject
    {
        public object data { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string traceId { get; set; }
        public object errors { get; set; }
    }
}