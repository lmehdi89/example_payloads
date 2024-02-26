using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;

namespace PowerPlantProductionPlanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerPlantController : ControllerBase
    {
        private readonly IProductionPlanCalculator _productionPlanCalculator;

        public PowerPlantController(IProductionPlanCalculator productionPlanCalculator)
        {
            _productionPlanCalculator = productionPlanCalculator;
        }

        [HttpPost("productionplan")]
        public IActionResult GetProductionPlan([FromBody] ProductionPlanRequest request)
        {
            if (request is null)
            {
                return BadRequest("Request body cannot be null.");
            }

            try
            {
                // Convert ProductionPlanRequest object to JObject
                JObject payload = JObject.FromObject(request);

                // Call CalculateProductionPlan method with the JObject payload
                var productionPlan = _productionPlanCalculator.CalculateProductionPlan(payload);
                return Ok(productionPlan);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
