using SimpleECommerce.Models;

namespace SimpleECommerce.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
#if ANDROID
            client.BaseAddress = new Uri("http://10.0.2.2:5001/api/");
#else
            client.BaseAddress = new Uri("http://localhost:5001/api/");
#endif
            var response = await client.GetAsync("products?pageNumber=1&pageSize=1");
            var contet = await response.Content.ReadAsStringAsync();
            
            var products = System.Text.Json.JsonSerializer.Deserialize<RootData>(contet, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
            });
            var firstProduct = products?.Data?.Items?.FirstOrDefault();

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                lblName.Text = firstProduct?.Name;
                lblPrice.Text = firstProduct != null ? $"${firstProduct.Price}" : string.Empty;
                imgProduct.Source = firstProduct?.ImageUrl;
            });


            
        }
    }
}
