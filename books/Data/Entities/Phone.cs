namespace MyBlazorApp.Data.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBankLinked { get; set; }
        public string PhoneType { get; set; }
        public int PersonId { get; set; }

        public Person Person { get; set; }
    }

}