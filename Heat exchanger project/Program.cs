using System;

namespace Heat_exchanger_project
{

    public class Exchanger
    {
        private double HLInitialTemp;
        public double HLFinalTemp;
        private double CLInitialTemp;
        private double CLFinalTemp;
        private double HLHeatCapacity;
        private double CLHeatCapacity;
        private double HLDensity;
        private double CLDensity;
        private double HLRate;
        private double CLRate;

        public Exchanger(ColdLiquid coldLiquid, HotLiquid hotLiquid)
        {
            HLInitialTemp = hotLiquid.InitialTemp;
            HLFinalTemp = hotLiquid.FinalTemp;
            CLInitialTemp = coldLiquid.InitialTemp;
            CLFinalTemp = coldLiquid.FinalTemp;
            HLHeatCapacity = hotLiquid.HeatCapacity;
            HLDensity = hotLiquid.Density;
            CLHeatCapacity = coldLiquid.HeatCapacity;
            CLDensity = coldLiquid.Density;
            HLRate = hotLiquid.Rate;
            CLRate = coldLiquid.Rate;
        }

        //Проверка теплонасыщенности потоков
        public virtual void HeatAmount()
        {
            var HLHeatAmount = HLHeatCapacity * HLRate * (HLInitialTemp - HLFinalTemp);
            var CLHeatAmount = CLHeatCapacity * CLRate * (CLFinalTemp - CLInitialTemp);

            if (HLHeatAmount <= CLHeatAmount)
            {
                throw new Exception("Недостаточно тепла у 'горячего' потока!");
            }

            if (HLHeatAmount > CLHeatAmount)
            {
                HLFinalTemp = 7777.0;
            }
        }

        //Вычисляем среднюю движущую силу процесса
        public virtual double LMTD()
        {
            double Tmin = 0;
            double Tmax = 0;

            var t1 = HLInitialTemp - CLFinalTemp;
            var t2 = HLFinalTemp - CLInitialTemp;

            if (t1 > t2)
            {
                Tmax = t1;
                Tmin = t2;
            }
            else
            {
                Tmax = t2;
                Tmin = t1;
            }

            return ((Tmax - Tmin) / (Math.Log(Tmax / Tmin)));
        }

    }

    public class ShellTubeExchanger : Exchanger
    {
            public ShellTubeExchanger(ColdLiquid coldLiquid, HotLiquid hotLiquid)
                :base(coldLiquid, hotLiquid)
            {

            }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HotLiquid hl = new HotLiquid(300, 200, 0.001, 2750, 865, 40);

            ColdLiquid cl = new ColdLiquid(108, 148, 0.0004, 2300, 852, 32.69);

            ShellTubeExchanger exch = new ShellTubeExchanger(cl, hl);
            Console.WriteLine(exch.LMTD());
            exch.HeatAmount();
            Console.WriteLine(exch.LMTD());

        }
    }
}
