using Common.DTO;
using Services;
using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Inicio programa");
			Console.WriteLine("-----------------\r\n");

			LibreriaService service = new LibreriaService();

			bool loopear = true;
			bool primeraVuelta = true;
			do
			{
				if (!primeraVuelta) Console.Clear();

				Console.WriteLine("¿Qué desea hacer?");
				Console.WriteLine("1 - Agregar libro");
				Console.WriteLine("2 - Remover libro");
				Console.WriteLine("3 - Modificar stock");
				Console.WriteLine("4 - Modificar precio");

				var opcionesElegida = int.Parse(Console.ReadLine());
				Console.WriteLine();

				switch (opcionesElegida)
                {
                    case 1:
                        AgregarLibro(service);
                        break;
                    case 2:
                        EliminarLibro(service);
                        break;
                    case 3:
                        ModificarStock(service);
                        break;
                    case 4:
                        ModificarPrecio(service);
                        break;
                    default:
						Console.WriteLine("La opción ingresada no existe.");
						break;
                }

				Console.WriteLine("¿Desea seguir operando? (Y/N)");
				loopear = Console.ReadLine().ToUpper() == "Y";
				primeraVuelta = false;
			} while (loopear);

			Console.ReadLine();
		}

        private static void ModificarPrecio(LibreriaService service)
        {
            Console.WriteLine("Ingrese el nombre del libro");
            var nombreLibroModificarPrecio = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo precio");
            var precioLibroModificarPrecio = decimal.Parse(Console.ReadLine());

            var libroDTOModificarPrecio = new LibroDTO()
            {
                Nombre = nombreLibroModificarPrecio,
                Precio = precioLibroModificarPrecio
            };


            var respuestaModificarPrecio = service.ModificarPrecio(libroDTOModificarPrecio);

            if (!respuestaModificarPrecio.Success)
            {
                Console.WriteLine();
                Console.WriteLine(respuestaModificarPrecio.Message);
                Console.WriteLine();
            }
        }

        private static void ModificarStock(LibreriaService service)
        {
            Console.WriteLine("Ingrese el nombre del libro");
            var nombreLibroModificarStock = Console.ReadLine();
            Console.WriteLine("Ingrese el stock");
            var cantidadLibroModificarStock = int.Parse(Console.ReadLine());

            var stockDTOModificarStock = new StockDTO()
            {
                NombreLibro = nombreLibroModificarStock,
                Cantidad = cantidadLibroModificarStock
            };

            var respuestaModificarStock = service.ModificarStock(stockDTOModificarStock);

            if (!respuestaModificarStock.Success)
            {
                Console.WriteLine();
                Console.WriteLine(respuestaModificarStock.Message);
                Console.WriteLine();
            }
        }

        private static void EliminarLibro(LibreriaService service)
        {
            Console.WriteLine("Ingrese el nombre del libro a eliminar");
            var nombreLibroEliminar = Console.ReadLine();

            var libroDTOEliminar = new LibroDTO()
            {
                Nombre = nombreLibroEliminar,
                Precio = 0
            };

            var respuestaEliminar = service.RemoverLibro(libroDTOEliminar);

            if (!respuestaEliminar.Success)
            {
                Console.WriteLine();
                Console.WriteLine(respuestaEliminar.Message);
                Console.WriteLine();
            }
        }

        private static void AgregarLibro(LibreriaService service)
        {
            Console.WriteLine("Ingrese el nombre del libro a agregar");
            var nombreLibroAgregar = Console.ReadLine();
            Console.WriteLine("Ingrese el precio");
            var precioLibroAgregar = decimal.Parse(Console.ReadLine());

            var libroDTO = new LibroDTO()
            {
                Nombre = nombreLibroAgregar,
                Precio = precioLibroAgregar
            };

            var respuestaAgregar = service.AgregarLibro(libroDTO);

            if (!respuestaAgregar.Success)
            {
                Console.WriteLine();
                Console.WriteLine(respuestaAgregar.Message);
                Console.WriteLine();
            }
        }
    }
	
}