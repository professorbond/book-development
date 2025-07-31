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

        private bool Success { get; set; }

        private string ValidateCityName(string value)
        {
            if (value.Length < 2)
            {
                return "Название города слишком короткое";
            }

            if (value.Length > 50)
            {
                return "Название города слишком длинное";
            }

            if (Db.Cities.Any(c => c.Name.ToLower() == CityName.ToLower()))
            {
                return "такой город уже существует";
            }
            return null;
        }

        private async Task Submit()
        {
            MudDialog.Close(DialogResult.Ok(CityName));
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }
} 