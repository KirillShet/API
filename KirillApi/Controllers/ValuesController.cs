using KirillApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;

namespace KirillApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SensorsContext _sensorsContext;
        public ValuesController(SensorsContext context)
        {
            _sensorsContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Sensors>>> GetSensors()
        {
            return await _sensorsContext.Sensors.Select(sensor => sensor).ToListAsync();
        }
        [HttpGet(template:"{id}")]
        public async Task<ActionResult<Sensors>> GetSensorItem(int id)
        {
            return await _sensorsContext.Sensors.FindAsync(id) ?? throw new InvalidOperationException();
        }
        [HttpPost]
        public async Task<ActionResult<Sensors>> AddSensor(Sensors sensor)
        {
            _sensorsContext.Add(sensor);
            await _sensorsContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<Sensors>> DeleteSensorItem(int id)
        {
            var sensorItem = await _sensorsContext.Sensors.FindAsync(id);
            if (sensorItem == null)
            {
                return NoContent();
            }
            _sensorsContext.Sensors.Remove(sensorItem);
            await _sensorsContext.SaveChangesAsync();
            return NoContent();
        }
       /* [HttpPut(template:"{id}")]
        public async Task<ActionResult<Sensors>> PutSensorItem(int id, Sensors sensor)
        {
            if (id != sensor.sensor_id)
            {
                return BadRequest();
            }
            _sensorsContext.Entry(sensor).State = EntityState.Modified;
            try { await _sensorsContext.SaveChangesAsync(); }
            catch(DbUpdateConcurrencyException) { if (!sensor.sensor_id(id)) }
        }*/
        /* private static List<Sensors> sensors = new List<Sensors>();*/
        /* [HttpGet]
         public async Task<ActionResult<List<Sensors>>> GetSensors()
         {
             return sensors;
         }
         [HttpPost]
         public async Task<ActionResult<Sensors>> AddSensor(Sensors sensor)
         {
             sensors.Add(sensor);
             return sensor;
         }
         [HttpPut(template:"{id}")]
         public async Task<ActionResult<Sensors>> UpdateSensors(int id, Sensors sensor)
         {
             Sensors? findSensors = sensors.FindLast(it => it.sensor_id == id);
             if (findSensors != null) { findSensors.sensor_name = sensor.sensor_name; }
             return NoContent();
         }
         [HttpDelete]
         public async Task<ActionResult<Sensors>> RemoveSensors(int id)
         {
             Sensors? removeSensors = sensors.FindLast(it => it.sensor_id == id);
             if (removeSensors != null) sensors.Remove(removeSensors);
             return NoContent();
         }
         [HttpGet(template: "{id}")]
         public async Task<ActionResult<Sensors>> GetSensorsItem(int id)
         {
             return sensors
                 .FindLast( it  => it.sensor_id == id)
                 ?? throw new InvalidOperationException();
         }*/
    }
}
