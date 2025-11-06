using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Weather : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; } = default!;

        protected WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("api/weather/weatherforecast");
        }

        public class WeatherForecast
        {
            public DateOnly Date { get; set; }
            public int TemperatureC { get; set; }
            public string? Summary { get; set; }
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
