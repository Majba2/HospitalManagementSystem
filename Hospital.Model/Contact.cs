namespace Hospital.Model
{
    public class Contact
    {
        public int ID { get; set; }
        public int HospitalID { get; set; }
        public HospitalInfo Hospital { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}