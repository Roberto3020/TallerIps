using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class LiquidacionCuotaService
    {

        LiquidacionCuotaRepository liquidacionCuotaRepository = new LiquidacionCuotaRepository();
        public String Guardar(LiquidacionCuotaModerada liquidacionCuotaModerada)
        {

            try
            {
                liquidacionCuotaRepository.Guardar(liquidacionCuotaModerada);
                return "Se guardo los datos exitosamente";
            }
            catch (Exception e)
            {
                return "Se presento el siguiente error al guardar" + e.Message;
            }
            }

        public ConsultaRespuesta Consultar()
        {
            try
            {
               
                return  new ConsultaRespuesta( liquidacionCuotaRepository.Consultar());
            }
            catch (Exception e)
            {
                return new ConsultaRespuesta("Lo sentimo se presento el sgt error " + e.Message);
                
            }

        }

    }
}

public class ConsultaRespuesta
{
    public List<LiquidacionCuotaModerada> Liquidaciones { get; set; }
    public bool Error { get; set; }
    public string Mensaje { get; set; }

    public ConsultaRespuesta(string message)
    {
        Error = true;
        Mensaje = message;

    }

    public ConsultaRespuesta (List<LiquidacionCuotaModerada> liquidaciones)
    {
        Liquidaciones = liquidaciones;
        Error = false;


    }

}
