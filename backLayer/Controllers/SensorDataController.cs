using dataLayer.Models;
using dataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace backLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorDataController : ControllerBase
    {
        private readonly ILogger<SensorDataController> _logger;
        private readonly IRepository<SensorData> _sensorDataRepository;

        public SensorDataController(ILogger<SensorDataController> logger, IRepository<SensorData> sensorDataRepository)
        {
            _logger = logger;
            _sensorDataRepository = sensorDataRepository;
        }

        [HttpGet(Name = "GetSensorDataList")]
        [Route("GetSensorDataList")]
        public async Task<ActionResult<object>> GetSensorDataListAsync()
        {
            try
            {
                var dataList = _sensorDataRepository.GetItems();
                if (dataList.Count() == 0)
                    throw new Exception("Server has no data");
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpGet(Name = "GetSensorData")]
        [Route("GetSensorData")]
        public async Task<ActionResult<object>> GetSensorDataAsync([FromQuery] int id)
        {
            try
            {
                var data = _sensorDataRepository.GetItem(id);
                if (data is null)
                    throw new Exception($"Server has no data with id {id}");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpPost(Name = "AddSensorData")]
        [Route("AddSensorData")]
        public async Task<ActionResult> AddSensorDataAsync([FromForm] SensorData sensorData)
        {
            try 
            {
                _sensorDataRepository.AddItem(sensorData);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);       
            }
        }

        [HttpPut(Name = "ChangeSensorData")]
        [Route("ChangeSensorData")]
        public async Task<ActionResult> ChangeSensorDataAsync([FromForm] SensorData sensorData)
        {
            try 
            {
                _sensorDataRepository.Update(sensorData);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);       
            }
        }

        [HttpDelete(Name = "DeleteSensorData")]
        [Route("DeleteSensorData")]
        public async Task<ActionResult> DeleteSensorDataAsync([FromForm] SensorData sensorData)
        {
            try 
            {
                _sensorDataRepository.Delete(sensorData);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);       
            }
        }

    }
}