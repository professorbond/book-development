using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MyBlazorApp.Data;
using MyBlazorApp.Data.Entities;
namespace MyBlazorApp.Components.Pages
{
    public partial class Cities : ComponentBase
    {
        private async Task ConfirmDeleteCity(City city)
        {
            var result = await DialogService.ShowMessageBox(
                "Подтверждение",
                $"Удалить город: {city.Name}?",
                yesText: "Да", cancelText: "Нет");

            if (result == true)
            {
                Db.Cities.Remove(city);
                await Db.SaveChangesAsync();
                AllElements = await Db.Cities.ToListAsync();
                StateHasChanged();
            }
        }
    }      
}