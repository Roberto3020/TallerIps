using System;
using System.Collections.Generic;
using System.Text;

namespace Entidad
{
   public  class RegimeContributivo:LiquidacionCuotaModerada
    {
        public RegimeContributivo()
        {

        }
        public RegimeContributivo(double numeroLiquidacion, double idPaciente, string tipoAfiliacion, double salarioPaciente, double valorServicio) :
            base(numeroLiquidacion, idPaciente, tipoAfiliacion, salarioPaciente, valorServicio)
        {

        }

        public override void CalcularTarifa()
        {
            if (SalarioPaciente < 2)
            {
                Tarifa = 0.15;
            }
            else if (SalarioPaciente >= 2 && SalarioPaciente <= 5)
            {
                Tarifa = 0.20;
            }
            else if (SalarioPaciente > 5)
            {
                Tarifa = 0.25;
                     
            }
        }

        public override void CalcularTope()
        {
            if (SalarioPaciente < 2)
            {
                Tope = 250000;
            }
            else if (SalarioPaciente >= 2 && SalarioPaciente <= 5)
            {
                Tope = 9000000;
            }else if(SalarioPaciente > 5)
            {
                Tope = 1500000;
            }
        }
    }
}
