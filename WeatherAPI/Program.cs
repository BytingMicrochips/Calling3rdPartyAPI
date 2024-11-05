using System;
using System.Collections.Generic;
//using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Linq;
using System.Buffers;
using Newtonsoft;
using Newtonsoft.Json;
//using System.Net.Http.Formatting;

namespace WeatherFetcher
{


    public class Program
    {
    public static string ApiString { get; set; } = "1530c40d49a6410cb11114941240511";
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.weatherapi.com/v1");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync($"{client.BaseAddress}/current.json?key={ApiString}&q=Bristol");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var deserializedContent = JsonConvert.DeserializeObject<dynamic>(content);
                
                Console.WriteLine(deserializedContent.location);
                Console.WriteLine(deserializedContent.current);

            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
            client.Dispose();
        }
    }
}

// What is Deserialization ?

// Deserialization is the process of reconstructing an object from a serialized form. In C#, it involves taking a stream of bytes or a serialized data format (like JSON) and converting it back into a live object that can be used in your program.

// Key points to consider:

//    Deserialization is the reverse process of serialization
//    It allows you to recreate complex data structures from a serialized state
//    Commonly used with JSON, XML, binary formats, etc.
