using Microsoft.AspNetCore.Components;
using MyBlazorApp.Data.Entities;
using MyBlazorApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MyBlazorApp.Components.Pages
{
    public partial class Contacts : ComponentBase
    {
        [Inject] private AppDbContext Db { get; set; }
        private List<Person> AllElements = new();
        private string _searchString = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            AllElements = await Db.People.Include(p => p.Phones).ToListAsync();
        }

        private bool FilterPerson(Person x)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
            {
                return true;
            }

            return (x.Id.ToString()?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (x.FirstName?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (x.LastName?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (x.MiddleName?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (x.Note?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (x.Phones.Any(p => p.PhoneNumber.Contains(_searchString, StringComparison.OrdinalIgnoreCase)));
        }
    }
}    