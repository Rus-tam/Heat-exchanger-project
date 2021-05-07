﻿using System;

namespace Heat_exchanger_project
{

    public class Exchanger
    {

    }

    public class ShellTubeExchanger
    {
        private double t1;
        private double t2;
        private double deltaTmax; //Наибольшая разность температур
        private double deltaTmin; //Наименьшая разность температур

        //Вычисляем среднюю движущую силу процесса
        public double LMTD(ColdLiquid coldLiquid, HotLiquid hotLiquid)
        {
            t1 = hotLiquid.initialTemp() - coldLiquid.finalTemp();
            t2 = hotLiquid.finalTemp() - coldLiquid.initialTemp();

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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HotLiquid hl = new HotLiquid(300, 200, 0.00001);

            ColdLiquid cl = new ColdLiquid(108, 148, 0.022);

            ShellTubeExchanger sl = new ShellTubeExchanger();
            var k = sl.LMTD(cl, hl);
            Console.WriteLine(k);
            

        }
    }
}