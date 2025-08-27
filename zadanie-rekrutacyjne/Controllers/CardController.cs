using Microsoft.AspNetCore.Mvc;
using zadanie_rekrutacyjne.Interfaces;

namespace zadanie_rekrutacyjne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly ICardActionService _actionService;

        public CardController(ICardService cardService, ICardActionService actionService)
        {
            _cardService = cardService;
            _actionService = actionService;
        }

        [HttpGet("{userId}/{cardNumber}/actions")]
        public async Task<IActionResult> GetAllowedActions(string userId, string cardNumber)
        {
            var realUserId = $"User{userId}";
            var realCardNumber = $"Card{userId}{cardNumber}";

            var cardDetails = await _cardService.GetCardDetails(realUserId, realCardNumber);

            if (cardDetails is null)
            {
                return NotFound(new { Message = "Didn't find card for this user." });
            }

            var actions = _actionService.GetAllowedActions(cardDetails);

            return Ok(new
            {
                Card = cardDetails,
                AllowedActions = actions
            });
        }
    }
}