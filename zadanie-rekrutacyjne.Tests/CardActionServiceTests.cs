using zadanie_rekrutacyjne.Enums;
using zadanie_rekrutacyjne.Models;
using zadanie_rekrutacyjne.Service;

namespace zadanie_rekrutacyjne.Tests
{
    [TestClass]
    public class CardActionServiceTests
    {
        private CardActionService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new CardActionService();
        }

        [TestMethod]
        public void GetAllowedActions_ReturnsCorrect_ForPrepaidClosed()
        {
            // Arrange
            var card = new CardDetails("Card", CardType.Prepaid, CardStatus.Closed, false);

            // Act
            var actions = _service.GetAllowedActions(card).ToList();

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "ACTION3", "ACTION4", "ACTION9" }, actions);
        }

        [TestMethod]
        public void GetAllowedActions_ReturnsCorrect_ForCreditBlocked_IsPinSet()
        {
            // Arrange
            var card = new CardDetails("Card", CardType.Credit, CardStatus.Blocked, true);

            // Act
            var actions = _service.GetAllowedActions(card).ToList();

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION7", "ACTION8", "ACTION9" }, actions);
        }

        [TestMethod]
        public void GetAllowedActions_ReturnsCorrect_ForPrepaidRestricted_IsPinSet()
        {
            // Arrange
            var card = new CardDetails("Card", CardType.Prepaid, CardStatus.Restricted, true);

            // Act
            var actions = _service.GetAllowedActions(card).ToList();

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "ACTION3", "ACTION4", "ACTION9" }, actions);
        }

        [TestMethod]
        public void GetAllowedActions_ReturnsCorrect_ForPrepaidActive()
        {
            // Arrange
            var card = new CardDetails("Card", CardType.Prepaid, CardStatus.Active, false);

            // Act
            var actions = _service.GetAllowedActions(card).ToList();

            // Assert
            CollectionAssert.Contains(actions, "ACTION1");
        }

        [TestMethod]
        public void GetAllowedActions_ReturnsCorrect_ForCreditExpired()
        {
            // Arrange
            var card = new CardDetails("Card", CardType.Credit, CardStatus.Ordered, false);

            // Act
            var actions = _service.GetAllowedActions(card).ToList();

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" }, actions);
        }

        [TestMethod]
        public void GetAllowedActions_ReturnsCorrect_ForCreditInactive()
        {
            // Arrange
            var card = new CardDetails("Card", CardType.Credit, CardStatus.Inactive, false);

            // Act
            var actions = _service.GetAllowedActions(card).ToList();

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "ACTION2", "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" }, actions);
        }

        [TestMethod]
        public void GetAllowedActions_ReturnsCorrect_ForCreditInactive_IsPinSet()
        {
            // Arrange
            var card = new CardDetails("Card", CardType.Credit, CardStatus.Inactive, true);

            // Act
            var actions = _service.GetAllowedActions(card).ToList();

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "ACTION2", "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" }, actions);
        }

        [TestMethod]
        public void GetAllowedActions_ReturnsCorrect_Action6()
        {
            // Arrange
            var cardWithPin = new CardDetails("Card", CardType.Debit, CardStatus.Active, true);
            var cardWithoutPin = new CardDetails("Car", CardType.Debit, CardStatus.Active, false);

            // Act
            var actionsWithPin = _service.GetAllowedActions(cardWithPin).ToList();
            var actionsWithoutPin = _service.GetAllowedActions(cardWithoutPin).ToList();

            // Assert
            CollectionAssert.Contains(actionsWithPin, "ACTION6");
            CollectionAssert.DoesNotContain(actionsWithoutPin, "ACTION6");
        }

        [TestMethod]
        public void GetAllowedActions_ReturnsCorrect_Action7()
        {
            // Arrange
            var cardWithPin = new CardDetails("Card", CardType.Debit, CardStatus.Active, true);
            var cardWithoutPin = new CardDetails("Card", CardType.Debit, CardStatus.Active, false);

            // Act
            var actionsWithPin = _service.GetAllowedActions(cardWithPin).ToList();
            var actionsWithoutPin = _service.GetAllowedActions(cardWithoutPin).ToList();

            // Assert
            CollectionAssert.DoesNotContain(actionsWithPin, "ACTION7");
            CollectionAssert.Contains(actionsWithoutPin, "ACTION7");
        }
    }
}