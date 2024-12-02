namespace Hospital.Model
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalID { get; set; }
        public HospitalInfo Hospital { get; set; }
    }
}