namespace GonzalezF_RicaldeN_Boadad_EspinozaA.Interfaces
{
    public interface IChatBotServices
    {
        public  Task<string> GetChatbotResponse(string prompt);
    }
}
