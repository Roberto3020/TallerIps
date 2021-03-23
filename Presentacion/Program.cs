using Entidad;
using Logica;
using System;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            double numeroLiquidacion;
            double idetificacionPaciente;
            String tipoAfiliacion;
            double salarioPaciente;
            double valorServicio;

            Console.WriteLine("Ingrese el numero de liquidacion:");
            numeroLiquidacion = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la identificacion del paciente");
            idetificacionPaciente = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el tipo de afiliacion: contributivo o subsidiado");
            tipoAfiliacion = Console.ReadLine();
            Console.WriteLine("Ingrese el salario devengado del paciente:");
            salarioPaciente = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor del servicio de hospitalizacion");
            valorServicio = double.Parse(Console.ReadLine());
            LiquidacionCuotaModerada liquidacionCuota;

            if (tipoAfiliacion.Equals("contributivo"))
            {
                liquidacionCuota = new RegimeContributivo(numeroLiquidacion, idetificacionPaciente, tipoAfiliacion, salarioPaciente, valorServicio);
            }
            else 
            {
                liquidacionCuota = new RegimeSubsidiado(numeroLiquidacion, idetificacionPaciente, tipoAfiliacion, salarioPaciente, valorServicio);
            }
             liquidacionCuota.CalcularCuotaModeradora();

            Console.WriteLine($"Su liquidacion es:{liquidacionCuota.CuotaModeradora}");

            LiquidacionCuotaService liquidacionCuotaService = new LiquidacionCuotaService();

            Console.WriteLine(liquidacionCuotaService.Guardar(liquidacionCuota));

            Console.WriteLine("Consultar liquidacion:");
            ConsultaRespuesta consultaRespuesta = liquidacionCuotaService.Consultar();
            if (!consultaRespuesta.Error)
            {
                foreach (var item in consultaRespuesta.Liquidaciones)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
                Console.WriteLine(consultaRespuesta.Mensaje);

            Console.ReadKey();


        }
    }
}
