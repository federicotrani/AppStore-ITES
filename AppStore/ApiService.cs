using AppStore.mvvm.Models;
using System.Net.Http;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text;


namespace AppStore;

public class ApiService
{
    private static readonly string BASE_URL = "https://localhost:7028/api/";
    static HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };

    public static async Task<List<Producto>> GetProductos()
    {       
        string FINAL_URL = BASE_URL + "productos";

        try
        {
            var response = await httpClient.GetAsync(FINAL_URL);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    // Inside the ApiService class
                    var responseObject = JsonSerializer.Deserialize<List<Producto>>(jsonData, 
                        new JsonSerializerOptions {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });
                    return responseObject!;
                }
                else
                {
                    Exception exception = new Exception("Resource Not Found");
                    throw new Exception(exception.Message);
                }
            }
            else
            {
                Exception exception = new Exception("Request failed with status code " + response.StatusCode);
                throw new Exception(exception.Message);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    public async Task<bool> ValidarLogin(string _email, string _password)
    {
        string FINAL_URL = BASE_URL + "usuarios/ValidarCredencial";
        try
        {
            var content = new StringContent(
                    //JsonConvert.SerializeObject(
                    JsonSerializer.Serialize(
                        new
                        {
                            email = _email,
                            password = _password,
                            // password = Encriptar.GetSHA256(_password),

                        }),
                        Encoding.UTF8, "application/json"
                    );

            var result = await httpClient.PostAsync(FINAL_URL, content).ConfigureAwait(false);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }

        
    }
}
