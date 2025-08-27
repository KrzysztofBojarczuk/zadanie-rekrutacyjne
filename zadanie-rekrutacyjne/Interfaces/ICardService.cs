using zadanie_rekrutacyjne.Models;

namespace zadanie_rekrutacyjne.Interfaces
{
    public interface ICardService
    {
        Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
    }
}