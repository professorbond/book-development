using Microsoft.AspNetCore.Components;
using MyBlazorApp.Data.Entities;
using MyBlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
namespace MyBlazorApp.Components.Pages
{
    public partial class AddCityDialog : ComponentBase
    {
        [Inject] private AppDbContext Db { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }
        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }

        private string CityName { get; set; }

        private async Task Submit()
        {
            var exists = await Db.Cities.AnyAsync(c => c.Name.ToLower() == CityName.ToLower());
            if (exists == true)
            {
                Snackbar.Add("Такой город уже существует", Severity.Error);
                return;
            }

            if (CityName.All(char.IsDigit))
            {
                Snackbar.Add("Название города не может состоять из цифр", Severity.Error);
                return;
            }

            MudDialog.Close(DialogResult.Ok(CityName));
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }
} 