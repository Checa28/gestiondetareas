class Program
{
    static void Main(string[] args)
    {
        GestorDeTareas gestor = new GestorDeTareas();
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Sistema de Gestión de Tareas");
            Console.WriteLine("1. Agregar nueva tarea");
            Console.WriteLine("2. Ver todas las tareas");
            Console.WriteLine("3. Actualizar estado de tarea");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título de la tarea: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese la descripción de la tarea: ");
                    string descripcion = Console.ReadLine();
                    gestor.AgregarTarea(titulo, descripcion);
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    gestor.VerTareas();
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Ingrese el ID de la tarea a completar: ");
                    int idActualizar = int.Parse(Console.ReadLine());
                    gestor.CambiarEstado(idActualizar);
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Write("Ingrese el ID de la tarea a eliminar: ");
                    int idEliminar = int.Parse(Console.ReadLine());
                    gestor.EliminarTarea(idEliminar);
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadKey();
                    break;

                case "5":
                    gestor.GuardarEnArchivo(); // Guardar tareas antes de salir
                    continuar = false;
                    Console.WriteLine("Tareas guardadas. ¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Presione Enter para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
