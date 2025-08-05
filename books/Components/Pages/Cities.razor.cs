using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MyBlazorApp.Data;
using MyBlazorApp.Data.Entities;

namespace MyBlazorApp.Components.Pages
{
    public partial class Cities : ComponentBase
    {
        [Inject] private ISnackbar Snackbar { get; set; } = default!;
        [Inject] private AppDbContext Db { get; set; } = default!;
        [Inject] private IDialogService DialogService { get; set; } = default!;

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

        private async Task OpenCityDialogAsync()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true};

            var dialog = await DialogService.ShowAsync<AddCityDialog>(" ", options);
            var result = await dialog.Result;
            if (result != null && result.Data is string cityName && !string.IsNullOrWhiteSpace(cityName))
            {
                Db.Cities.Add(new City { Name = cityName });   
                await Db.SaveChangesAsync();
                Snackbar.Add($"Город {cityName} добавлен", Severity.Success);
                AllElements = await Db.Cities.ToListAsync();
                StateHasChanged();
            }
        }

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
                Snackbar.Add($"Удален Город: {city.Name}", Severity.Success);
                AllElements = await Db.Cities.ToListAsync();
                StateHasChanged();
            }
        }

    }
}
