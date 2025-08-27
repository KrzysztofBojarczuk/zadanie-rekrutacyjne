using zadanie_rekrutacyjne.Enums;
using zadanie_rekrutacyjne.Interfaces;
using zadanie_rekrutacyjne.Models;

namespace zadanie_rekrutacyjne.Service
{
    public class CardActionService : ICardActionService
    {
        private static readonly List<string> AllActions =
             Enumerable.Range(1, 13).Select(i => $"Action{i}").ToList();

        public IEnumerable<string> GetAllowedActions(CardDetails card)
        {
            var allActions = new List<ActionRule>
            {
                new ActionRule("ACTION1", null, new[] { CardStatus.Active }, null),
                new ActionRule("ACTION2", null, new[] { CardStatus.Inactive }, null),
                new ActionRule("ACTION3", null, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Restricted, CardStatus.Blocked, CardStatus.Expired, CardStatus.Closed }, null),
                new ActionRule("ACTION4", null, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Restricted, CardStatus.Blocked, CardStatus.Expired, CardStatus.Closed }, null),
                new ActionRule("ACTION5", CardType.Credit, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Restricted, CardStatus.Blocked, CardStatus.Expired, CardStatus.Closed }, null),
                new ActionRule("ACTION6", null, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active }, true),
                new ActionRule("ACTION6", null, new[] { CardStatus.Blocked }, true),
                new ActionRule("ACTION7", null, new[] { CardStatus.Blocked }, true),
                new ActionRule("ACTION7", null, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Blocked }, false),
                new ActionRule("ACTION8", null, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Blocked }, null),
                new ActionRule("ACTION9", null, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Restricted, CardStatus.Blocked, CardStatus.Expired, CardStatus.Closed }, null),
                new ActionRule("ACTION10", null, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active }, null),
                new ActionRule("ACTION11", null, new[] { CardStatus.Inactive, CardStatus.Active }, null),
                new ActionRule("ACTION12", null, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active }, null),
                new ActionRule("ACTION13", null, new[] { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active }, null)
            };

            var allowedActions = allActions.Where(action =>
            {
                bool cardTypeMatches = !action.CardType.HasValue || action.CardType == card.CardType;
                bool statusMatches = action.Statuses == null || action.Statuses.Contains(card.CardStatus);
                bool pinMatches = !action.PinRequired.HasValue || action.PinRequired == card.IsPinSet;
                return cardTypeMatches && statusMatches && pinMatches;
            })
            .Select(a => a.Action);

            return allowedActions;
        }
    }
}