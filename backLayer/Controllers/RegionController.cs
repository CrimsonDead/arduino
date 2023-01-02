using dataLayer.Models;
using dataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace backLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly ILogger<Region> _logger;
        private readonly IRepository<Region> _regionRepository;

        public RegionController(ILogger<Region> logger, IRepository<Region> regionRepository)
        {
            _logger = logger;
            _regionRepository = regionRepository;
        }

        [HttpGet(Name = "GetRegionList")]
        [Route("GetRegionList")]
        public async Task<ActionResult<object>> GetRegionListAsync()
        {
            try
            {
                var dataList = _regionRepository.GetItems();
                if (dataList.Count() == 0)
                    throw new Exception("Server has no data");
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpGet(Name = "GetRegion")]
        [Route("GetRegion")]
        public async Task<ActionResult<object>> GetRegionAsync([FromQuery] int id)
        {
            try
            {
                var data = _regionRepository.GetItem(id);
                if (data is null)
                    throw new Exception($"Server has no data with id {id}");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpPost(Name = "AddRegion")]
        [Route("AddRegion")]
        public async Task<ActionResult> AddRegionAsync([FromForm] Region region)
        {
            try 
            {
                _regionRepository.AddItem(region);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);       
            }
        }

        [HttpPut(Name = "ChangeRegion")]
        [Route("ChangeRegion")]
        public async Task<ActionResult> ChangeRegionAsync([FromForm] Region region)
        {
            try 
            {
                _regionRepository.Update(region);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);       
            }
        }

        [HttpDelete(Name = "DeleteRegion")]
        [Route("DeleteRegion")]
        public async Task<ActionResult> DeleteRegionAsync([FromForm] Region region)
        {
            try 
            {
                _regionRepository.Delete(region);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);       
            }
        }

    }
}