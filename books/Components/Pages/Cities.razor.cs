using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MyBlazorApp.Data;
using MyBlazorApp.Data.Entities;

namespace MyBlazorApp.Components.Pages
{
    public partial class Cities : ComponentBase
    {
        [Inject] private AppDbContext Db { get; set; }
        [Inject] private IDialogService DialogService { get; set; }

        private List<City> AllElements = new();
        private string SearchString = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            AllElements = await Db.Cities.ToListAsync();
        }

        private bool FilterCity(City x)
        {
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                return true;
            }
            else
            {
                return (x.Name?.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ?? false);
            }
        }

        private async Task OpenDialogAsync()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };

            var dialog = await DialogService.ShowAsync<AddCityDialog>("Добавить Город", options);
            var result = await dialog.Result;
            if (result != null && result.Data is string cityName && !string.IsNullOrWhiteSpace(cityName))
            {
                Db.Cities.Add(new City { Name = cityName });
                await Db.SaveChangesAsync();
                AllElements = await Db.Cities.ToListAsync();
                StateHasChanged();
            }
        }

        private async Task OpenDeleteDialogAsync()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };

            var dialog = await DialogService.ShowAsync<DeleteCityDialog>("Удалить Город", options);
            var result = await dialog.Result;
            if (result != null && result.Data is string IdName && !string.IsNullOrWhiteSpace(IdName))
            {
                var city = await Db.Cities.FindAsync(int.Parse(IdName));
                Db.Cities.Remove(city);
                await Db.SaveChangesAsync();
                AllElements = await Db.Cities.ToListAsync();
                StateHasChanged();
            }
        }
    }
}
