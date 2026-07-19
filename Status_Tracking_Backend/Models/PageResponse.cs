using DocumentFormat.OpenXml.Wordprocessing;

namespace Status_Tracking_Backend.Models
{
    public class PageResponse
    {
        public List<Customers> Data { get; set; } = new();
        public int PageNumber { get; set; }
        public int  PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
