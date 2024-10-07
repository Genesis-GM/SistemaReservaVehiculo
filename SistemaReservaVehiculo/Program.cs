using System;

namespace SistemaReservaVehiculos
{
    // Clase principal Program para ejecutar el sistema de reserva de vehículos
    public class Program
    {
        public static void Main(string[] args)
        {
            // Mensaje de bienvenida al sistema
            Console.WriteLine("Bienvenido/a Al Sistema de Reserva de Vehículos \"GM\"");
            Console.WriteLine();

            // Listado de vehículos disponibles con modelos, colores y precios diferentes
            Vehiculo[] vehiculosDisponibles = {
                new Vehiculo("Toyota Rush", "Plateado", 50),
                new Vehiculo("Toyota Rush", "Negro", 50),
                new Vehiculo("Toyota Rush", "Blanco", 50),
                new Vehiculo("Toyota Rush", "Rojo", 50),
                new Vehiculo("Toyota Hillux", "Plateado", 80),
                new Vehiculo("Toyota Hillux", "Blanco", 80),
                new Vehiculo("Toyota Hillux", "Azul", 80),
                new Vehiculo("Mazda", "Beige", 65),
                new Vehiculo("Mazda", "Negro", 65),
                new Vehiculo("Hyundai", "Azul", 70),
                new Vehiculo("Hyundai", "Blanco", 70),
                new Vehiculo("Hyundai", "Café", 70),
                new Vehiculo("Chevrolet", "Blanco", 60)
            };

            // Ciclo principal del sistema
            while (true)
            {
                // Definir la temporada actual para aplicar posibles descuentos
                string temporada = "Invierno";

                // Mostrar los vehículos disponibles con su modelo, color y precio por día
                Console.WriteLine("Modelos de vehículos disponibles:");
                for (int i = 0; i < vehiculosDisponibles.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. Modelo: {vehiculosDisponibles[i].Modelo}, Color: {vehiculosDisponibles[i].Color}, Precio por día: {vehiculosDisponibles[i].PrecioPorDia:C}");
                }
                Console.WriteLine($"{vehiculosDisponibles.Length + 1}. Salir");

                // Solicitar al usuario que elija un modelo de vehículo
                Console.WriteLine("Elige el modelo de vehículo (1-13): ");
                string? entrada = Console.ReadLine();

                // Validar la entrada y convertir a entero
                if (!int.TryParse(entrada, out int opcion))
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
                    continue;
                }

                // Verificar si el usuario desea salir del sistema
                if (opcion == vehiculosDisponibles.Length + 1)
                {
                    Console.WriteLine("Gracias por usar el sistema de reservas. ¡Hasta luego!");
                    break;
                }

                // Ajustar la opción para que coincida con el índice del array
                opcion--;

                // Validar que la opción elegida sea válida
                if (opcion < 0 || opcion >= vehiculosDisponibles.Length)
                {
                    Console.WriteLine("Opción inválida.");
                    continue;
                }

                // Obtener el vehículo seleccionado por el usuario
                Vehiculo vehiculoSeleccionado = vehiculosDisponibles[opcion];

                // Aplicar descuento basado en la temporada y calcular el precio con descuento
                double descuento;
                double precioConDescuento = Vehiculo.Descuento.AplicarDescuento(vehiculoSeleccionado, temporada, out descuento);
                vehiculoSeleccionado.PrecioPorDia = precioConDescuento;

                // Mostrar información si se aplicó un descuento
                if (descuento > 0)
                {
                    Console.WriteLine($"Se aplicó un descuento del {descuento * 100}% por la temporada {temporada}. Precio original: {vehiculoSeleccionado.PrecioPorDia / (1 - descuento):C}, Precio con descuento: {vehiculoSeleccionado.PrecioPorDia:C}");
                }
                else
                {
                    Console.WriteLine("El modelo de vehículo que has seleccionado no aplica a ningún descuento.");
                }

                // Mostrar la información detallada del vehículo seleccionado
                vehiculoSeleccionado.MostrarInformacion();

                // Solicitar al usuario ingresar la cantidad de días para la reserva
                Console.WriteLine("Ingrese la cantidad de días para la reserva: ");
                entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out int diasReserva))
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
                    continue;
                }

                // Calcular el costo total de la reserva
                double costoTotal = CalcularReserva.CalcularCostoTotal(vehiculoSeleccionado, diasReserva);

                // Mostrar el costo total de la reserva
                Console.WriteLine($"El costo total de la reserva para {diasReserva} días es: {costoTotal:C}");

                // Opción de hacer otra reserva o salir
                Console.WriteLine("Toca cualquier tecla para hacer otra reserva o escribe 'salir' para finalizar.");
                string? decision = Console.ReadLine();
                if (decision?.ToLower() == "salir")
                {
                    Console.WriteLine("Gracias por usar el sistema de reservas. ¡Hasta luego!");
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
