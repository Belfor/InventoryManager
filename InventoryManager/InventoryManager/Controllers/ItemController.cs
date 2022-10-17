using Inventory.Application.Commands;
using Inventory.Application.Queries;
using Inventory.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
       
        private readonly ILogger<ItemController> _logger;
        private readonly InventoryServices _inventoryService;

        public ItemController(ILogger<ItemController> logger, InventoryServices inventoryServices)
        {
            _logger = logger;
            _inventoryService = inventoryServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddItem(CreateItemCommand createItemCommand)
        {
            _logger.LogInformation("Llamada al endpoint AddItem");
            await _inventoryService.CommandHandler(createItemCommand);
            return Ok();

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            _logger.LogInformation("Llamada al endpoint GetItem");
            var response = await _inventoryService.QueryHandler(new GetItemQuery(id));
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllItem()
        {
            _logger.LogInformation("Llamada al endpoint GetAllItem");
            var response = await _inventoryService.QueryHandler(new GetAllItemQuery());
            return Ok(response);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            _logger.LogInformation("Llamada al endpoint DeleteItem");
            await _inventoryService.CommandHandler(new DeleteItemCommand(id));
            return Ok();
        }
    }
}

