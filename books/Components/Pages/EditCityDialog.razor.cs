using Microsoft.AspNetCore.Components;
using MyBlazorApp.Data.Entities;
using MyBlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
namespace MyBlazorApp.Components.Pages
{
    public partial class EditCityDialog : ComponentBase
    {
        [Inject] private AppDbContext Db { get; set; } = default!;
        [Inject] private ISnackbar Snackbar { get; set; } = default!;
        [Parameter] public string CurrentName { get; set; } = string.Empty;
        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; } = default!;

        private string EditCity { get; set; } = default!;

        private bool Success { get; set; }

        protected override void OnInitialized()
        {
            EditCity = CurrentName; 
        }

        private string ValidateEditCity(string value)
        {
            if (value.Length < 2)
            {
                return "Название города слишком короткое";
            }

            if (value.Length > 50)
            {
                return "Название города слишком длинное";
            }

            if (Db.Cities.Any(c => c.Name.ToLower() == EditCity.ToLower()))
            {
                return "такой город уже существует";
            }
            return null;
        }

        private async Task Submit()
        {
            MudDialog.Close(DialogResult.Ok(EditCity));
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }
} 