namespace PowerPlantProductionPlanAPI
{
    public class ProductionPlanRequest
    {
        public int load { get; set; }
        public PowerPlantProductionPlanAPI.Fuels fuels { get; set; } = null!;
        public PowerPlantProductionPlanAPI.PowerPlants[] powerplants { get; set; } = null!;

    }
}