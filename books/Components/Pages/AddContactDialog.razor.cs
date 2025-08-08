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
        private bool IsBankLinked { get; set; } = default!;
        private string PhoneType { get; set; } = default!;
        private List<Phone> PhoneInputs { get; set; } = new() {new Phone()};

        private void AddPhone(int index)
        {
            if (!string.IsNullOrWhiteSpace(PhoneInputs[index].PhoneNumber))
            {
                if (index == PhoneInputs.Count - 1)
                {
                    PhoneInputs.Add(new Phone());
                }
            }
        }

        private string? ValidatePhoneInput(string phonenumber)
        {
            if (PhoneInputs.Count(p => p.PhoneNumber == phonenumber) > 1)
            {
                return "Данный номер уже был введен!";
            }
            if (Db.People.Any(c => c.Phones.Any(p => p.PhoneNumber == phonenumber)))
                {
                    return "Такой номер уже существует!";
                }
            return null;
        }

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
                LastName = ContactLastName,
                Phones = PhoneInputs
                
            };
            MudDialog.Close(DialogResult.Ok(person));
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }
}
