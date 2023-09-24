using Microsoft.JSInterop;

namespace CongresoServer.Pages.Reportes;

public class Excel
{
    public async Task GenerateWeatherForecastAsync(IJSRuntime js,
                                                   Model.RegistrosViewModel[] data,
                                                   string filename)
    {
        var weatherForecast = new WeatherForecastXLS();
        var XLSStream = weatherForecast.Edition(data);

        await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
    }
    public async Task GenerateWeatherForecastAsync2(IJSRuntime js,
                                                   Model.RegistrosViewModel[] data,
                                                   string filename)
    {
        var weatherForecast = new WeatherForecastXLS();
        var XLSStream = weatherForecast.Edition2(data);

        await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
    }
}