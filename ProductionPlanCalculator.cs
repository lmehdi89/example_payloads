using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerPlantProductionPlanAPI
{
    public class Product
    {
        public string Name { get; set; }
        public object Productvalue { get; set; }

        public Product(string name, object value)
        {
            Name = name;
            Productvalue = value;
        }


    }
    public class ProductionPlanCalculator : IProductionPlanCalculator
    {
        public List<Object> CalculateProductionPlan(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }
            var load = payload["load"]?.ToObject <double>() ?? throw new ArgumentException("Payload is missing 'load' property.", nameof(payload));
            var fuels = payload["fuels"]?.ToObject < Fuels>() ?? throw new ArgumentException("Payload is missing 'fuels' property.", nameof(payload));
            var powerPlants = payload["powerplants"]?.ToObject<List<PowerPlants>>() ?? throw new ArgumentException("Payload is missing 'powerplants' property.", nameof(payload));
            var productionPlan = new Dictionary<string, double>();
            var totalPower = 0.0;
            var singlePower = 0.0;
            

            // Calculate how much power each powerplant should deliver
            foreach (var powerplant in powerPlants
                .Where(p => p.Type == PowerPlantType.windturbine)
                .OrderByDescending(p => p.PMax))
            {
                singlePower = Utility.PowerCalculator(powerplant.PMax , fuels.Wind);
                totalPower = Utility.CheckTotalPower(totalPower, ref singlePower, load);
                productionPlan.Add(powerplant.Name ?? "", singlePower);

            }

            
            

            foreach (var plant in powerPlants.Where(p => p.Type != PowerPlantType.windturbine).OrderByDescending(p => p.Efficiency))
            {
                // Calculate gas or kerosene power
                singlePower =Utility.PowerCalculator(plant.PMax, 100);


                totalPower = Utility.CheckTotalPower(totalPower, ref singlePower, load);
                productionPlan.Add(plant.Name ?? "", singlePower);

            }

            // Convert production plan to JSON object
            var productionPlanList = new List<object>();
            foreach (var entry in productionPlan)
            {
                Product plantObject = new Product(entry.Key, entry.Value);

                productionPlanList.Add(plantObject);
            }
            var result = productionPlanList;

            return result;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
