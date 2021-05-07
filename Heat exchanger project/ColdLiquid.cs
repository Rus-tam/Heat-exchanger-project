namespace Heat_exchanger_project
{
    public class ColdLiquid
    {
        private double CLInititialTemp;
        private double CLFinalTemp;
        private double CLViscosity;

        public ColdLiquid(double initialTemp, double finalTemp, double Viscosity)
        {
            CLInititialTemp = initialTemp;
            CLFinalTemp = finalTemp;
            CLViscosity = Viscosity;
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
    }
}
