using System.Text;
using System.Text.Json;
using MisskeyDotNet.Object;

namespace MisskeyDotNet.WebAPI;

public class MiWebAPI
{
    HttpClient client = new();
    string _url = "https://misskey.io/api";
    string _token = "";

    public MiWebAPI(String token, String baseURL = "misskey.io")
    {
        _token = token;
        _url = $"https://{baseURL}/api";
    }

    public async Task<string> Note(String token, MiSendNote miSendNote)
    {

        miSendNote.i = token;
        var json_in = JsonSerializer.Serialize(miSendNote);
        Console.WriteLine(json_in);

        var content = new StringContent(json_in, Encoding.UTF8, @"application/json");

        Console.WriteLine("API Call...");

        var responce = await client.PostAsync(_url + "/notes/create", content);

        Console.WriteLine(responce.StatusCode);

        var responce_text = await responce.Content.ReadAsStringAsync();
        Console.WriteLine(responce_text);
        return responce_text;
    }
}