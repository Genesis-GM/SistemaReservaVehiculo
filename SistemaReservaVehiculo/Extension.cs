using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaVehiculos
{
    public static class ExtensionVehiculo
    {
        public static void MostrarInformacion(this Vehiculo vehiculo)
        {
            Console.WriteLine($"Modelo: {vehiculo.Modelo}");
            Console.WriteLine($"Color: {vehiculo.Color}");
            Console.WriteLine($"Precio por día: {vehiculo.PrecioPorDia:C}");
        }
    }
}
