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
        public object GetSensorDataList()
        {
            return _sensorDataRepository.GetItems();
        }

        [HttpGet(Name = "GetSensorData")]
        public object GetSensorData([FromQuery] int id)
        {
            return _sensorDataRepository.GetItem(id);
        }

        [HttpPost(Name = "AddSensorData")]
        public bool AddSensorData([FromForm] SensorData sensorData)
        {
            try 
            {
                _sensorDataRepository.AddItem(sensorData);
            }
            catch
            {
                return false;
            }
            return true;
        }

        [HttpPut(Name = "ChangeSensorData")]
        public bool ChangeSensorData([FromForm] SensorData sensorData)
        {
            try 
            {
                _sensorDataRepository.Update(sensorData);
            }
            catch
            {
                return false;
            }
            return true;
        }

        [HttpDelete(Name = "DeleteSensorData")]
        public bool DeleteSensorData([FromForm] SensorData sensorData)
        {
            try 
            {
                _sensorDataRepository.Delete(sensorData);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}