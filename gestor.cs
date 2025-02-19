
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO; // Para manejar archivos


public class GestorDeTareas
{
    List<Tarea> tareas = new List<Tarea>();
    private int ContadorId = 1;
    private const string ArchivoTareas = "tareas.json"; // Nombre del archivo de almacenamiento

    public GestorDeTareas()
    {
        CargarDesdeArchivo(); // Cargar tareas al iniciar el programa
    }


    public void AgregarTarea(string titulo, string descripcion)
    {
        Tarea nuevatarea = new Tarea
        {
            Id = ContadorId++,
            Titulo = titulo,
            Descripcion = descripcion
        };
        tareas.Add(nuevatarea);
        Console.WriteLine("agregada correctamente");

    }

    public void VerTareas()
    {
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas agregadas");
            return;
        }
        foreach (var tareas in tareas)
        {
            Console.WriteLine($@"La lista de tareas es la siguiente:
                Id: {tareas.Id}
                Titulo: {tareas.Titulo}
                Descripcion: {tareas.Descripcion}
            ");
        }
    }

    public void CambiarEstado(int id)
    {
       var tarea = tareas.Find(t => t.Id == id);
        if (tarea != null)
        {
            tarea.Estado = "Completada";
            Console.WriteLine("Estado actualizado a Completada.");
        }
        else
        {
            Console.WriteLine("Tarea no encontrada.");
        }
        
    }
    public void EliminarTarea(int id)
    {
       var tarea = tareas.Find(t => t.Id == id);
        if (tarea != null)
        {
            tareas.Remove(tarea);
            Console.WriteLine("Tarea Eliminada");
        }
        else
        {
            Console.WriteLine("Tarea no encontrada.");
        }
        
    }

    public void GuardarEnArchivo()
    {
        try
        {
            string json = JsonSerializer.Serialize(tareas);
            File.WriteAllText(ArchivoTareas, json);
            Console.WriteLine("Tareas guardadas correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar tareas: {ex.Message}");
        }
    }

    
    public void CargarDesdeArchivo()
    {
        try
        {
            if (File.Exists(ArchivoTareas))
            {
                string json = File.ReadAllText(ArchivoTareas);
                tareas = JsonSerializer.Deserialize<List<Tarea>>(json) ?? new List<Tarea>();
                
                ContadorId = tareas.Count > 0 ? tareas[^1].Id + 1 : 1;
                Console.WriteLine("Tareas cargadas correctamente.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar tareas: {ex.Message}");
        }
    }
}
