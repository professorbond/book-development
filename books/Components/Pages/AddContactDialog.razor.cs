using Microsoft.AspNetCore.Components;
using MyBlazorApp.Data.Entities;
using MyBlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System.Text.RegularExpressions;
namespace MyBlazorApp.Components.Pages
{
    public partial class AddContactDialog : ComponentBase
    {
        [Inject] private AppDbContext Db { get; set; } = default!;
        [Inject] private ISnackbar Snackbar { get; set; } = default!;
        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; } = default!;
        private bool Success { get; set; }

        private string ContactFirstName { get; set; } = default!;
        private string ContactLastName { get; set; } = default!;
        private string ContactSecondName { get; set; } = default!;

        private string? ValidateContactName(string value)
        {
            var regex = new Regex("^[А-Я][а-я]+$");
            if (!regex.IsMatch(value))
            {
                return "Введите только русские буквы(без пробелов), первая заглавная";
            }
            return null;
        }

        private async Task Submit()
        {
            var person = new Person
            {
                FirstName = ContactFirstName,
                MiddleName = ContactSecondName,
                LastName = ContactLastName
            };
            MudDialog.Close(DialogResult.Ok(person));
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }
}
