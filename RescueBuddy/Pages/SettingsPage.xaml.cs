

namespace RescueBuddy.Pages
{
    public partial class SettingsPage
    {
        private const int MaxContacts = 3;
        private readonly string _contactsFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.txt");
        private readonly List<Models.Contact> _contacts = new();

        public SettingsPage()
        {
            InitializeComponent();
            CreateContactsFileIfNeeded();
            LoadContacts();
            ContactListView.ItemsSource = _contacts;
        }
        private void CreateContactsFileIfNeeded()
        {
            if (!File.Exists(_contactsFileName))
            {
                File.Create(_contactsFileName).Close();
            }
        }
        private void LoadContacts()
        {
            _contacts.Clear();
            string[] lines = File.ReadAllLines(_contactsFileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0];
                    string phone = parts[1];
                    _contacts.Add(new Models.Contact(name, phone));
                }
            }
        }
        private void UpdateListView()
        {
            ContactListView.ItemsSource = null;
            ContactListView.ItemsSource = _contacts;
        }

        private void ClearFields()
        {
            NameEntry.Text = "";
            PhoneEntry.Text = "";
        }
        private async void SaveContacts()
        {
            await using StreamWriter writer = new StreamWriter(_contactsFileName);
            foreach (var contact in _contacts)
            {
                await writer.WriteLineAsync($"{contact.Name},{contact.Phone}");
            }
        }

        private void ContactListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var selectedContact = (Models.Contact)e.Item;
                NameEntry.Text = selectedContact.Name;
                PhoneEntry.Text = selectedContact.Phone;
                ApplyChangesButton.IsVisible = true;
                AddContactButton.IsVisible = false;
            }
        }

        private async void OnAddContactClicked(object sender, EventArgs e)
        {
            if (_contacts.Count >= MaxContacts)
            {
                await DisplayAlert("Limit Reached", "You can only add up to 3 contacts.", "OK");
                return;
            }

            string name = NameEntry.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                await DisplayAlert("Invalid Name", "Please enter a valid name.", "OK");
                return;
            }

            if (ValidatePhoneNumber(PhoneEntry.Text))
            {
                _contacts.Add(new Models.Contact(name, PhoneEntry.Text));
                UpdateListView();
                ClearFields();
                SaveContacts();
            }
            else
            {
                await DisplayAlert("Invalid Phone Number", "Please enter a valid Number.", "OK");
            }
        }


        private async void OnApplyChangesClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text.Trim();
            if (_contacts.Count >= MaxContacts)
            {
                await DisplayAlert("Limit Reached", "You can only add up to 3 contacts.", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                await DisplayAlert("Invalid Name", "Please enter a valid name.", "OK");
                return;
            }
            if (ValidatePhoneNumber(PhoneEntry.Text))
            {
                var selectedContact = (Models.Contact)ContactListView.SelectedItem;
                selectedContact.Name = name;
                selectedContact.Phone = PhoneEntry.Text;
                UpdateListView();
                ClearFields();
                ApplyChangesButton.IsVisible = false;
                AddContactButton.IsVisible = true;
                SaveContacts();
            }
            else
            {
                await DisplayAlert("Invalid Phone Number", "Please enter a valid Number.", "OK");
            }
        }

        private void OnDeleteContactClicked(object sender, EventArgs e)
        {
            if (ContactListView.SelectedItem != null)
            {
                var selectedContact = (Models.Contact)ContactListView.SelectedItem;
                _contacts.Remove(selectedContact);
                UpdateListView();
                ClearFields();
                ApplyChangesButton.IsVisible = false; // Hide the Apply Changes button
                AddContactButton.IsVisible = true; // Show the Add Contact button
                SaveContacts();
            }
        }

        private void PhoneEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string phoneNumber = e.NewTextValue;
            bool isValid = ValidatePhoneNumber(phoneNumber);
            PhoneValidationLabel.Text = isValid ? "" : "Invalid phone number";
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());
            return digitsOnly.Length is >= 10 and <= 15;
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
    }
}
