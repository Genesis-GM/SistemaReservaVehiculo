using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaVehiculos
{
    public static class CalcularReserva
    {
        public static double CalcularCostoTotal(Vehiculo vehiculo, int dias)
        {
            return vehiculo.PrecioPorDia * dias;
        }
    }
}
