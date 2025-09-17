using BusinessLayer.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPayPal

    {

        private readonly PayPalSettings _settings;
        private readonly HttpClient _httpClient;

        public clsPayPal(IOptions<PayPalSettings> settings)
        {
            _settings = settings.Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
        }

        // 1️⃣ Get Access Token
        public async Task<string> GetAccessTokenAsync()
        {
            var authToken = Encoding.ASCII.GetBytes($"{_settings.ClientId}:{_settings.Secret}");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

            var request = new HttpRequestMessage(HttpMethod.Post, "/v1/oauth2/token");
            request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(result);
            return json.RootElement.GetProperty("access_token").GetString();
        }
        public async Task<string> CreatePaymentAsync(decimal amount, string currency = "USD")
        {
            var accessToken = await GetAccessTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            var payment = new
            {
                intent = "CAPTURE",
                purchase_units = new[]
                {
            new {
                amount = new {
                    currency_code = currency,
                    value = amount.ToString("F2")
                }
            }
        },
                application__context = new
                {
                    return_url = _settings.ReturnUrl,
                    cancel_url = _settings.CancelUrl
                }
            };

            var json = JsonSerializer.Serialize(payment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_settings.BaseUrl}/v2/checkout/orders", content);
            var result = await response.Content.ReadAsStringAsync();

            var doc = JsonDocument.Parse(result);
            var links = doc.RootElement.GetProperty("links");

            // Get Approval URL
            var approvalLink = links.EnumerateArray()
                                    .FirstOrDefault(l => l.GetProperty("rel").GetString() == "approve")
                                    .GetProperty("href")
                                    .GetString();

            return approvalLink;
        }
    }
}
