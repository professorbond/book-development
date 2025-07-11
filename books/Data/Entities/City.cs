namespace MyBlazorApp.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public int Name { get; set; }
        
        public List<Person> People {get; set;} = new();
           
    }
}