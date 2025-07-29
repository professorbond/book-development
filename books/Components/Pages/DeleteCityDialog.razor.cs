using Microsoft.AspNetCore.Components;
using MyBlazorApp.Data.Entities;
using MyBlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
namespace MyBlazorApp.Components.Pages
{
    public partial class DeleteCityDialog : ComponentBase
    {
        [Inject] private AppDbContext Db { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }

        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }

        private string IdName { get; set; }

        private async Task Submit()
        {
            var exists = await Db.Cities.AnyAsync(c => c.Id.ToString() == IdName);
            if (exists == true)
            {
                MudDialog.Close(DialogResult.Ok(IdName));
            }
            else
            {
                Snackbar.Add("Город с таким Id не найден. Попробуйте еще раз.", Severity.Error);
                return;
            }
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }
}
