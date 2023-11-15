namespace Phonebook.Models
{
    public class AddPhoneViewModel
    {
        [R]
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Primary_phone { get; set; }
        public string Secondary_phone { get; set; }
    }
}
