using dataLayer.Models;
using dataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace backLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly ILogger<Sensor> _logger;
        private readonly IRepository<Sensor> _sensorRepository;

        public SensorController(ILogger<Sensor> logger, IRepository<Sensor> sensorRepository)
        {
            _logger = logger;
            _sensorRepository = sensorRepository;
        }

        [HttpGet(Name = "GetSensorList")]
        [Route("GetSensorList")]
        public async Task<ActionResult<object>> GetSensorListAsync()
        {
            try
            {
                var dataList = _sensorRepository.GetItems();
                if (dataList.Count() == 0)
                    throw new Exception("Server has no data");
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpGet(Name = "GetSensor")]
        [Route("GetSensor")]
        public async Task<ActionResult<object>> GetSensorAsync([FromQuery] int id)
        {
            try
            {
                var data = _sensorRepository.GetItem(id);
                if (data is null)
                    throw new Exception($"Server has no data with id {id}");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpPost(Name = "AddSensor")]
        [Route("AddSensor")]
        public async Task<ActionResult> AddSensorAsync([FromForm] Sensor sensor)
        {
            try 
            {
                _sensorRepository.AddItem(sensor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);       
            }
        }

        [HttpPut(Name = "ChangeSensor")]
        [Route("ChangeSensor")]
        public async Task<ActionResult> ChangeSensorAsync([FromForm] Sensor sensor)
        {
            try 
            {
                _sensorRepository.Update(sensor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);       
            }
        }

        [HttpDelete(Name = "DeleteSensor")]
        [Route("DeleteSensor")]
        public async Task<ActionResult> DeleteSensorAsync([FromForm] Sensor sensor)
        {
            try 
            {
                _sensorRepository.Delete(sensor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);       
            }
        }

    }
}