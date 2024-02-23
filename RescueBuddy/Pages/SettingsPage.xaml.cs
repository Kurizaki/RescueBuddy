using Microsoft.Maui.ApplicationModel.Communication;

namespace RescueBuddy;

public partial class SettingsPage : ContentPage
{
    private const int MaxContacts = 3;
    public List<Contact> contacts = new List<Contact>();

    public SettingsPage()
    {
        InitializeComponent();
        contactListView.ItemsSource = contacts;
    }

    private async void OnVisitMyHomePageButtonClicked(object sender, EventArgs args)
    {
        try
        {
            Uri uri = new("https://kurizaki.github.io/Resume/");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex}");
            await DisplayAlert("Error", "Failed to open the website. Please try again later.", "OK");
        }


    }

    void OnAddContactClicked(object sender, EventArgs e)
    {
        if (contacts.Count >= MaxContacts)
        {
            DisplayAlert("Limit Reached", "You can only add up to 3 contacts.", "OK");
            return;
        }

        string name = nameEntry.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            DisplayAlert("Invalid Name", "Please enter a valid name.", "OK");
            return;
        }

        if (ValidatePhoneNumber(phoneEntry.Text))
        {
            contacts.Add(new Contact { Name = name, Phone = phoneEntry.Text });
            UpdateListView();
            ClearFields();
        }
        else
        {
            DisplayAlert("Invalid Phone Number", "Please enter a valid Number.", "OK");
            return;
        }
    }

    void OnChangeContactClicked(object sender, EventArgs e)
    {
        string name = nameEntry.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            DisplayAlert("Invalid Name", "Please enter a valid name.", "OK");
            return;
        }
        if (contactListView.SelectedItem != null)
        {
            if (ValidatePhoneNumber(phoneEntry.Text))
            {
                var selectedContact = (Contact)contactListView.SelectedItem;
                selectedContact.Name = name;
                selectedContact.Phone = phoneEntry.Text;
                UpdateListView();
                ClearFields();
            }
            else
            {
                DisplayAlert("Invalid Phone Number", "Please enter a valid Number.", "OK");
                return;
            }
        }
    }

    void OnDeleteContactClicked(object sender, EventArgs e)
    {
        if (contactListView.SelectedItem != null)
        {
            var selectedContact = (Contact)contactListView.SelectedItem;
            contacts.Remove(selectedContact);
            UpdateListView();
            ClearFields();
        }
    }

    void UpdateListView()
    {
        contactListView.ItemsSource = null;
        contactListView.ItemsSource = contacts;
    }

    void ClearFields()
    {
        nameEntry.Text = "";
        phoneEntry.Text = "";
    }
    void PhoneEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string phoneNumber = e.NewTextValue;
        bool isValid = ValidatePhoneNumber(phoneNumber);
        phoneValidationLabel.Text = isValid ? "" : "Invalid phone number";
    }

    bool ValidatePhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;

        string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());
        return digitsOnly.Length >= 10 && digitsOnly.Length <= 15;
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}