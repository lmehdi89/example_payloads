using Newtonsoft.Json.Linq;

namespace PowerPlantProductionPlanAPI
{
    public interface IProductionPlanCalculator
    {
        List<Object> CalculateProductionPlan(JObject payload);
    }
}
