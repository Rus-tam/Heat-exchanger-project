using System;

namespace Heat_exchanger_project
{

    public class Exchanger
    {
        private double t1;
        private double t2;
        private double deltaTmax; //Наибольшая разность температур
        private double deltaTmin; //Наименьшая разность температур
        private double clHeatAmount; //Количество тепла холодного теплоносителя
        private double hlHeatAmount; //Количество тепла горячего теплоносителя
        private double CLReynoldsNumber; //Уточненное число Рейнольдса для холодного теплоносителя
        private double CLPrandtlNumber;
        private double CLNusseldNumber;

        //Вычисляем среднюю движущую силу процесса
        public virtual double LMTD(ColdLiquid coldLiquid, HotLiquid hotLiquid)
        {
            t1 = hotLiquid.InitialTemp - coldLiquid.FinalTemp;
            t2 = hotLiquid.FinalTemp - coldLiquid.InitialTemp;

            if (t1 >= t2)
            {
                deltaTmax = t1;
                deltaTmin = t2;
            }
            else
            {
                deltaTmax = t2;
                deltaTmin = t1;
            }

            return ((deltaTmax - deltaTmin) / (Math.Log(deltaTmax / deltaTmin)));
        }

        //Вычисляем количество передаваемого тепла, 
        public virtual void HeatCapacity(ColdLiquid coldLiquid, HotLiquid hotLiquid)
        {
            clHeatAmount = coldLiquid.Rate * coldLiquid.HeatCapacity * (coldLiquid.FinalTemp - coldLiquid.InitialTemp);
            hlHeatAmount = hotLiquid.Rate * hotLiquid.HeatCapacity * (hotLiquid.InitialTemp - hotLiquid.FinalTemp);

            if (clHeatAmount >= hlHeatAmount)
                throw new Exception("Недостаточное количество теплоносителя!");
            else
                Console.WriteLine("Тепла достаточно!");
        }

        //Вычисляем скорость холодного теплоносителя
        public virtual double CLVelocity(ColdLiquid coldLiquid, HotLiquid hotLiquid)
        {
            //Уточняем критерий Рейнольдса
            CLReynoldsNumber = 10000 * (126 / 70);
            //Определяем скорость холодного теплоносителя
            return ((CLReynoldsNumber * coldLiquid.Viscosity) / (0.016 * coldLiquid.Density));
        }

        //Вычисляем критерий Нуссельта
        public virtual double CLHeatTransCoeff(double CLLambda, ColdLiquid coldLiquid)
        {
            CLPrandtlNumber = (coldLiquid.HeatCapacity * coldLiquid.Viscosity) / (CLLambda);
            CLReynoldsNumber = 10000 * (126.0 / 70.0);
            CLNusseldNumber = 0.021 * Math.Pow(CLReynoldsNumber, 0.8) * Math.Pow(CLPrandtlNumber, 0.43) * 1.05 * 1;
            return ((CLNusseldNumber * CLLambda) / (0.016));
        }
    }

    public class ShellTubeExchanger : Exchanger
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            HotLiquid hl = new HotLiquid(300, 200, 0.001, 2750, 865, 40);

            ColdLiquid cl = new ColdLiquid(108, 148, 0.0004, 2300, 852, 32.69);

            ShellTubeExchanger exch = new ShellTubeExchanger();

            Console.WriteLine(exch.LMTD(cl, hl));
            exch.HeatCapacity(cl, hl);
            Console.WriteLine(exch.CLHeatTransCoeff(0.14, cl));

        }
    }
}
