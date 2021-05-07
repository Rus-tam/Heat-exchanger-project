namespace Heat_exchanger_project
{
    public class HotLiquid
    {
        private double HLInititialTemp;
        private double HLFinalTemp;
        private double HLViscosity;

        public HotLiquid(double initialTemp, double finalTemp, double Viscosity)
        {
            HLInititialTemp = initialTemp;
            HLFinalTemp = finalTemp;
            HLViscosity = Viscosity;
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
    }
}
