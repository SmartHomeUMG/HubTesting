// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;
using smartBuildingClient;

Console.WriteLine("Please select option:");
Console.WriteLine("Press 1 to monitor Temperature:");
Console.WriteLine("Press 2 to monitor Light:");
int option = System.Int16.Parse(Console.ReadLine());

if(option == 1)
{
    var uri_1 = "http://localhost:5108/HomeConditionHub";
    
    await using var connection_temperature = new HubConnectionBuilder().WithUrl(uri_1).Build();
    
    await connection_temperature.StartAsync();
    
    await foreach(var item in connection_temperature.StreamAsync<int>("RecentTemperature"))
    {
        Console.WriteLine($"Temperature status: {item}");
    }
}
else
{
    var uri_2 = "http://localhost:5108/HomeLightHub";

    await using var connection_light = new HubConnectionBuilder().WithUrl(uri_2).Build();

    await connection_light.StartAsync();

    await foreach(var item in connection_light.StreamAsync<HomeLight>("CurrentLightStatus"))
    {
    Console.WriteLine($"Light turn on status: {item.Date} : {item.TurnedOn}");
    }
}


