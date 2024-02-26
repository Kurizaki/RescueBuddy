namespace RescueBuddy.Models
{
    public class Contact(string name, string phone)
    {
        public string Name { get; set; } = name;
        public string Phone { get; set; } = phone;
    }
}
