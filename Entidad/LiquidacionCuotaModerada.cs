using System;

namespace Entidad
{
    public abstract class LiquidacionCuotaModerada
    {
        public LiquidacionCuotaModerada() { }
        public LiquidacionCuotaModerada(double numeroLiquidacion, double identificacionPaciente, string tipoAfiliacion, double salarioPaciente,
            double valorServicio)
        {
            NumeroLiquidacion = numeroLiquidacion;
            IdentificacionPaciente = identificacionPaciente;
            TipoAfiliacion = tipoAfiliacion;
            SalarioPaciente = salarioPaciente;
            ValorServicio = valorServicio;

        }

        public double NumeroLiquidacion { get; set; }
        public double IdentificacionPaciente { get; set; }
        public string TipoAfiliacion { get; set; }
        public double SalarioPaciente { get; set; }
        public double ValorServicio { get; set; }
        public double Tarifa { get; set; }
        public double Tope { get; set; }
        public double liquidacion { get; set; }
        public double CuotaModeradora { get; set; }
        public double InicialLiqudiacionCuotaModeradora { get; set; }

        public abstract void CalcularTarifa();
        public abstract void CalcularTope();
        public void CalcularCuotaModeradora()
        {
            CalcularTarifa();
             CuotaModeradora = ValorServicio * Tarifa;
            CalcularTope();
            CuotaModeradora = DefinirCuotaModeradora();
        }

        public double DefinirCuotaModeradora()
        {
            if (CuotaModeradora > Tope)
            {
                return Tope;
            }
            return CuotaModeradora;
        }
        public override string ToString()
        {
            return $"NumeroLiquidacion: {NumeroLiquidacion}-Identificacion: {IdentificacionPaciente} - tipo afiliacion:{TipoAfiliacion}--liquidacion: {CuotaModeradora}";
        }
    }
}
