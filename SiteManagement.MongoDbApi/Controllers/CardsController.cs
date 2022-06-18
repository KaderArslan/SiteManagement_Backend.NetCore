using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagement.MongoDbApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardServices _cardServices;
        public CardsController(ICardServices cardServices)
        {
            _cardServices = cardServices;
        }

        //---get
        [HttpGet]
        public IActionResult GetCards()
        {
            return Ok(_cardServices.GetCards());
        }

        [HttpGet("{id", Name = "GetCard")]
        public IActionResult GetCard(int id)
        {
            return Ok(_cardServices.GetCard(id));
        }

        //---post
        [HttpPost]
        public IActionResult AddCard(Card card)
        {
            _cardServices.AddCard(card);
            return Ok(card);
        }

        [HttpPost]
        public IActionResult AddCards(Card card)
        {
            _cardServices.AddCards(card);
            return CreatedAtRoute("GetCard", new { id = card.CardId }, card);
        }

        //---delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            _cardServices.DeleteCard(id);
            return NoContent();
        }

        //---update
        [HttpPut]
        public IActionResult UpdateCard(Card card)
        {
            return Ok(_cardServices.UpdateCard(card));
        }


    }
}
