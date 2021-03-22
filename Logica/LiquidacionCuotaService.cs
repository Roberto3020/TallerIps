using Datos;
using Entidad;
using System;

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
    }
}
