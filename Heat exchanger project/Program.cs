using System;

namespace Heat_exchanger_project
{
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
