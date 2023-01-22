using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModels.VM;

namespace Kolokwium.Web.Controllers;

[Route("api/Store/")]
public class StoreApiController : BaseController
{
    private readonly IStoreService _storeService;

    public StoreApiController(ILogger logger, IMapper mapper,
        IStoreService storeService) : base(logger, mapper)
    {
        _storeService = storeService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var storees = _storeService.GetStorees();
            return Ok(storees);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    [HttpGet("{id:int:min(1)}")]
    public IActionResult Get(int id)
    {
        try
        {
            var store = _storeService.GetStore(p => p.Id == id);
            return Ok(store);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] UpdateStoreVm updateStoreVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_storeService.UpdateStore(updateStoreVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] AddStoreVm addStoreVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_storeService.AddStore(addStoreVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }



    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _storeService.DeleteStore(p => p.Id == id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

}