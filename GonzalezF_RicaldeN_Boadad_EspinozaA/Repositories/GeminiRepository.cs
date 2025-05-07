using GonzalezF_RicaldeN_Boadad_EspinozaA.Interfaces;
using GonzalezF_RicaldeN_Boadad_EspinozaA.Models;

namespace GonzalezF_RicaldeN_Boadad_EspinozaA.Repositories
{
    public class GeminiRepository : IChatBotServices
    {

        HttpClient _httpClient;
        private string apiKey = "AIzaSyD06_Agdv8qQhFQv2zyZobuJfxTrAzjE1U";

        public GeminiRepository()
        {
            _httpClient = new HttpClient();
            
        }

        public async Task<string> GetChatbotResponse(string prompt)
        {
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + apiKey;
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url);

            GeminiRequest request = new GeminiRequest
            {
                contents = new List<Content>
                {
                    new Content
                    {
                        parts = new List<Part>
                        {
                            new Part
                            {
                                text = prompt
                            }
                        }
                    }
                }
            };

            message.Content = JsonContent.Create<GeminiRequest>(request);

            var response = await _httpClient.SendAsync(message);
            string answer = await response.Content.ReadAsStringAsync();

            return answer;
             }
        }
}
