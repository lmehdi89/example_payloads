namespace PowerPlantProductionPlanAPI
{
    public class PowerPlants
    {
        public string? Name { get; set; }
        public PowerPlantType Type { get; set; }
        public double Efficiency { get; set; }
        public double PMin { get; set; }
        public double PMax { get; set; }
    }

    public enum PowerPlantType
    {
        gasfired,
        turbojet,
        windturbine
    }
}