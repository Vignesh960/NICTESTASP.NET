namespace NICRegister.Models
{
    public class AddRegister
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string AdharNumber { get; set; }
        public string District { get; set; }
        public string Mondal { get; set; }
        public string Village { get; set; }
        public string Address { get; set; }
        public IFormFile ImageFile { get; set; }
       // public string Title { get; set; }
    }
}
