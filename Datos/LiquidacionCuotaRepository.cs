using Entidad;
using System;
using System.Collections.Generic;
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

        public List<LiquidacionCuotaModerada> Consultar()
        {
            List<LiquidacionCuotaModerada> liquidacionCuotas = new List<LiquidacionCuotaModerada>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            String linea = " ";
            while ((linea = reader.ReadLine())!= null)
            {
                LiquidacionCuotaModerada liquidacionCuota = MapearLiquidacion(linea);
                liquidacionCuotas.Add(liquidacionCuota);
            }
            file.Close();
            reader.Close();
            return liquidacionCuotas;
        }
        private static LiquidacionCuotaModerada MapearLiquidacion(String linea)
        {
            char division = ';';
            String[] datoLiquidacion = linea.Split(division);
            LiquidacionCuotaModerada  liquidacionCuotaModerada;

            if (datoLiquidacion.Equals("contributivo"))
            {
                liquidacionCuotaModerada = new  RegimeContributivo();
            }
            else
            {
                liquidacionCuotaModerada = new  RegimeSubsidiado();
            }

           liquidacionCuotaModerada.NumeroLiquidacion = double.Parse( datoLiquidacion[0]);
            liquidacionCuotaModerada.IdentificacionPaciente = double.Parse(datoLiquidacion[1]);
            liquidacionCuotaModerada.TipoAfiliacion = datoLiquidacion[2];
            liquidacionCuotaModerada.SalarioPaciente = double.Parse(datoLiquidacion[3]);
            liquidacionCuotaModerada.ValorServicio = double.Parse(datoLiquidacion[4]);
            liquidacionCuotaModerada.Tarifa = double.Parse(datoLiquidacion[5]);
            liquidacionCuotaModerada.InicialLiqudiacionCuotaModeradora = double.Parse(datoLiquidacion[6]);
            return liquidacionCuotaModerada;

        }

    }
}
