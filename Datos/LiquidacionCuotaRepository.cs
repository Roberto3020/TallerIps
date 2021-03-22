using Entidad;
using System;
using System.IO;

namespace Datos
{
    public class LiquidacionCuotaRepository
    {
        String ruta = @"Liquidacion.txt";
        public void Guardar(LiquidacionCuotaModerada liquidacionCuotaModerada) {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine(liquidacionCuotaModerada.NumeroLiquidacion + ";" + liquidacionCuotaModerada.IdentificacionPaciente + ";" +
                liquidacionCuotaModerada.TipoAfiliacion + ";" + liquidacionCuotaModerada.SalarioPaciente + ";" + liquidacionCuotaModerada.ValorServicio + ";" +
                liquidacionCuotaModerada.CuotaModeradora);
            escritor.Close();
            file.Close();
        }

    }
}
