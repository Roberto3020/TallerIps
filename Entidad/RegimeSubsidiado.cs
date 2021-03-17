using System;
using System.Collections.Generic;
using System.Text;

namespace Entidad
{
   public class RegimeSubsidiado:LiquidacionCuotaModerada
    {
        public RegimeSubsidiado() { }
        public RegimeSubsidiado(double numeroLiquidacion, double idPaciente, string tipoAfiliacion, double salarioPaciente, double valorServicio) :
            base(numeroLiquidacion, idPaciente, tipoAfiliacion, salarioPaciente, valorServicio)
         { }

        public override void CalcularTarifa()
        {
            Tarifa = 0.05;
        }
        public override void CalcularTope()
        {
            Tope = 200000;
        }
    }
}
