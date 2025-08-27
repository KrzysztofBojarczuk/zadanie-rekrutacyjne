using zadanie_rekrutacyjne.Models;

namespace zadanie_rekrutacyjne.Interfaces
{
    public interface ICardActionService
    {
        IEnumerable<string> GetAllowedActions(CardDetails card);
    }
}