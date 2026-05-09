using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

public class PaymentController : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] PaymentRequest request)
    {
        var serverKey = "YOUR_SERVER_KEY";
        var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(serverKey + ":"));

        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("Authorization", "Basic " + auth);

        var body = new
        {
            transaction_details = new
            {
                order_id = Guid.NewGuid().ToString(),
                gross_amount = request.amount
            }
        };

        var json = JsonSerializer.Serialize(body);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(
            "https://app.sandbox.midtrans.com/snap/v1/transactions",
            content
        );

        var result = await response.Content.ReadAsStringAsync();

        var parsed = JsonDocument.Parse(result);
        var token = parsed.RootElement.GetProperty("token").GetString();

        return Json(new { token });
    }
}

public class PaymentRequest
{
    public int amount { get; set; }
}