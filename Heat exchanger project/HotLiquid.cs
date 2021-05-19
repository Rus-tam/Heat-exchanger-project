namespace Heat_exchanger_project
{
    public class HotLiquid
    {
        public double InitialTemp { get; }
        public double FinalTemp { get;  }
        public double Viscosity { get; }
        public double HeatCapacity { get; }
        public double Density { get; }
        public double Rate { get; }


        public HotLiquid(double initialTemp, double finalTemp, double viscosity, double heatCapacity, double density, double rate)
        {
            InitialTemp = initialTemp;
            FinalTemp = finalTemp;
            Viscosity = viscosity;
            HeatCapacity = heatCapacity;
            Density = density;
            Rate = rate;
        }
    }
}
