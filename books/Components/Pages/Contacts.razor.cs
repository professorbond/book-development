using Microsoft.AspNetCore.Components;
using MyBlazorApp.Data.Entities;
using MyBlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace MyBlazorApp.Components.Pages
{
    public partial class Contacts : ComponentBase
    {
        [Inject] private AppDbContext Db { get; set; } = default!;
        [Inject] private IDialogService DialogService { get; set; } = default!;
        [Inject] private ISnackbar Snackbar { get; set; } = default!;
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
        private async Task OpenContactDialogAsync()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = await DialogService.ShowAsync<AddContactDialog>(" ", options);
            var result = await dialog.Result;
            Db.People.Add((Person)result.Data);
            await Db.SaveChangesAsync();
            Snackbar.Add($"Пользователь добавлен", Severity.Success);
            AllElements = await Db.People.ToListAsync();
            StateHasChanged();
        }
    }
}    