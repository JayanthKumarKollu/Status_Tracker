using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Status_Tracking_Backend.Models
{
    public class Customers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }
        //public DateOnly? Date { get; set; }
        public String? Date { get; set; }
        public String Month { get; set; }
        public String? Customer_Name { get; set; }
        public String? Mobile_Number { get; set; }
        public String? RM_Name { get; set; }

        public String? TM_Name { get; set; }

        public String? Status { get; set; }
        public int? Value { get; set;}

        public String? Remarks { get; set; }
        public String? Remarks1 { get; set; }

        public String? Remarks2 { get; set; }
    }
}
