namespace Heat_exchanger_project
{
    public class ColdLiquid
    {
        private double CLInititialTemp;
        private double CLFinalTemp;
        private double CLViscosity;
        private double CLHeatCapacity;
        private double CLDensity;

        public ColdLiquid(double initialTemp, double finalTemp, double viscosity, double heatCapacity, double density)
        {
            CLInititialTemp = initialTemp;
            CLFinalTemp = finalTemp;
            CLViscosity = viscosity;
            CLHeatCapacity = heatCapacity;
            CLDensity = density;
        }

        //Данные методы в будущем будут производить проверки исходных значений
        //к примеру есть фазовый переход или нет
        public double initialTemp()
        {
            return CLInititialTemp;
        }

        public double finalTemp()
        {
            return CLFinalTemp;
        }

        public double viscosity()
        {
            return CLViscosity;
        }

        public double heatCapacity()
        {
            return CLHeatCapacity;
        }

        public double density()
        {
            return CLDensity;
        }
    }
}
