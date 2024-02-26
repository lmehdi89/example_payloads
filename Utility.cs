namespace PowerPlantProductionPlanAPI
{
    static public class Utility
    {
        const double CONSTVALUE = 0.01;
        static public double PowerCalculator(double pmax, double cost)
        {
            return pmax * cost * CONSTVALUE;
        }

        static public double CheckTotalPower(double totalpower,ref double singlepower, double load)
        {
            double result = totalpower + singlepower > load ? load : totalpower + singlepower;
            singlepower = totalpower + singlepower > load ? load - totalpower : singlepower;
            return result;
        }
    }
}
