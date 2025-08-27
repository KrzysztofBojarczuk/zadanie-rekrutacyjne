using zadanie_rekrutacyjne.Enums;

namespace zadanie_rekrutacyjne.Models
{
    public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet);
}
