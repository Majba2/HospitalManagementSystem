using Hospital.Model;
namespace Hospital.ViewModels
{
    public class HospitalInfoViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }

        // Default Constructor
        public HospitalInfoViewModel()
        {
        }

        // Constructor with Model Parameter
        public HospitalInfoViewModel(HospitalInfo model)
        {
            ID = model.ID;
            Name = model.Name;
            Type = model.Type; // Added missing property
            City = model.City;
            PinCode = model.PinCode;
            Country = model.Country;
        }
        public HospitalInfo ConvertViewModel(HospitalInfoViewModel model)
        {
            return new HospitalInfo {
                ID = model.ID,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                Country = model.Country
            };
        }
    }
}
