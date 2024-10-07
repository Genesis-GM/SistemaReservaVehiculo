using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaVehiculos
{
    public class Vehiculo
    {
        public string Modelo { get; set; }
        public string Color { get; set; }
        public double PrecioPorDia { get; set; }

        // Constructor de Vehiculo
        public Vehiculo(string modelo, string color, double precioPorDia)
        {
            Modelo = modelo;
            Color = color;
            PrecioPorDia = precioPorDia;
        }

        // Clase interna para gestionar descuentos
        public class Descuento
        {
            // Método estático para aplicar descuento según modelo y temporada
            public static double AplicarDescuento(Vehiculo vehiculo, string temporada, out double descuento)
            {
                descuento = 0;

                // Aplicar descuentos por modelo y temporada
                if (temporada == "Invierno" && vehiculo.Modelo == "Toyota Hillux")
                {
                    descuento = 0.10; // 10% de descuento para Toyota Hillux en invierno
                }
                else if (temporada == "Verano" && vehiculo.Modelo == "Mazda")
                {
                    descuento = 0.15; // 15% de descuento para Mazda en verano
                }
                else if (vehiculo.Modelo == "Hyundai" && vehiculo.Color == "Café")
                {
                    descuento = 0.05; // 5% de descuento para Hyundai color Café
                }
                else if (vehiculo.Modelo == "Chevrolet" && temporada == "Fin de Año")
                {
                    descuento = 0.20; // 20% de descuento para Chevrolet en Fin de Año
                }

                // Retornar precio con descuento aplicado
                return vehiculo.PrecioPorDia - (vehiculo.PrecioPorDia * descuento);
            }
        }
    }
}
