namespace Heat_exchanger_project
{
    public class HotLiquid
    {
        private double HLInititialTemp;
        private double HLFinalTemp;
        private double HLViscosity;
        private double HLHeatCapacity;
        private double HLDensity;

        public HotLiquid(double initialTemp, double finalTemp, double viscosity, double heatCapacity, double density)
        {
            HLInititialTemp = initialTemp;
            HLFinalTemp = finalTemp;
            HLViscosity = viscosity;
            HLHeatCapacity = heatCapacity;
            HLDensity = density;
        }

        //Данные методы в будущем будут производить проверки исходных значений
        //к примеру есть фазовый переход или нет
        public double initialTemp()
        {
            return HLInititialTemp;
        }

        public double finalTemp()
        {
            return HLFinalTemp;
        }

        public double viscosity()
        {
            return HLViscosity;
        }

        public double heatCapacity()
        {
            return HLHeatCapacity;
        }

        public double density()
        {
            return HLDensity;
        }
    }
}
