namespace MyBlazorApp.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Note { get; set; }
        public int CityId { get; set; }

        public List<Phone> Phones { get; set; } = new();
    }
}