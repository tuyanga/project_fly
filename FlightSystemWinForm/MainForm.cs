using System.Net.Http.Json;
using FlightSystemWinForm.dto;
namespace FlightSystemWinForm
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5269/") };
        private List<FlightDto> _flights;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            flightStatusComboBox.Items.AddRange(new[] { "CheckingIn", "Boarding", "Departed", "Delayed", "Cancelled" });
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadFlightsAsync();
        }

        private async Task LoadFlightsAsync()
        {
            _flights = await _httpClient.GetFromJsonAsync<List<FlightDto>>("api/flights");
            flightsComboBox.DataSource = _flights;
            flightsComboBox.DisplayMember = "Display";
           
        }
        private async void changeStatusBtn_Click(object sender, EventArgs e)
        {
            if (flightsComboBox.SelectedItem is FlightDto selectedFlight && flightStatusComboBox.SelectedItem is string newStatus)
            {
                var response = await _httpClient.PutAsJsonAsync($"api/flights/{selectedFlight.id}/status", newStatus);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Status updated!");
                    await LoadFlightsAsync();
                }
                else
                {
                    MessageBox.Show("Failed to update status.");
                }
            }
        }
        
    }
}
