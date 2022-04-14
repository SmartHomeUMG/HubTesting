// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;
using smartBuildingClient;

var uri = "http://localhost:5108/HomeConditionHub";

await using var connection = new HubConnectionBuilder()
.WithUrl(uri).Build();

await connection.StartAsync();

await foreach(var item in connection.StreamAsync<HomeTemperature>("RecentTemperature"))
{
    //Console.WriteLine($"{item}");
    //Thread.Sleep(1000);
    Console.WriteLine($" {item.MeasureDate} : {item.TemperatureC}");
}