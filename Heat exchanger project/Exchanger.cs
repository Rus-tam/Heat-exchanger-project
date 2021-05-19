using System;

namespace Heat_exchanger_project
{
    public class Exchanger
    {
        private double HLInitialTemp;
        private double HLFinalTemp;
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
}
