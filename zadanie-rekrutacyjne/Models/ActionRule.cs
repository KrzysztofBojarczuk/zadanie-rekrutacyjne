using zadanie_rekrutacyjne.Enums;

namespace zadanie_rekrutacyjne.Models
{
    public record ActionRule(string Action, CardType? CardType, CardStatus[] Statuses, bool? PinRequired);
}
