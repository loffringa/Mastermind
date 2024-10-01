using System;
using System.Collections.Generic;
using Mastermind.Models;
using Mastermind.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Mastermind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastermindController : ControllerBase
    {
        private readonly MastermindService service;
        public MastermindController(MastermindService service)
        {
            this.service = service;
        }

        [HttpPost("StartNewGame")]
        public ActionResult<Guid> StartNewGame()                             
        {
            return Ok(service.CreateNewGame());
        }

        [HttpPost("QuitGame/{guid}")]
        public ActionResult QuitGame(Guid guid)
        {
            return service.QuitGame(guid) ? Ok() : NotFound(guid);
        }

        [HttpPost("NextTry/{guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Score> NextTry(Guid guid, Colour[] colours)
        {
            
            if (colours.Length != 4)
            {
                return BadRequest("row must have 4 pins");
            }
            var row = new Row(colours[0], colours[1], colours[2], colours[3]);
            var game = service.GetGame(guid);
            if (game != null)
            {
                return Ok(game.PlayRow(row));
            }
            return NotFound(guid);
        }

        [HttpGet("Status/{guid}")]
        public ActionResult<GameState> GameState(Guid guid)
        {
            var game = service.GetGame(guid);
            if (game != null)
            {
                return Ok(game.State());
            }
            return NotFound(guid);
        }

        [HttpGet("AllPlayedRows/{guid}")]
        public ActionResult<List<IRow>> AllPlayedRows(Guid guid)
        {
            var game = service.GetGame(guid);
            if (game != null)
            {
                return Ok(game.PlayedRows);
            }
            return NotFound(guid);
        }
    }
}