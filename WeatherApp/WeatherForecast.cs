namespace WeatherApp;

public class WeatherForecast
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
