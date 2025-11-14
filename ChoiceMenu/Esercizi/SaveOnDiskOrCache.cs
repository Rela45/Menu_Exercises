#region Interface
using System.Net.WebSockets;

public interface IStorageService
{
    void SaveOnDisk();
    void SaveOnCache();
}

#endregion


#region Class Concrete
public class StorageService : IStorageService
{
    public void SaveOnCache()
    {
        Console.WriteLine($"Salvataggio in Memoria avvenuto correttamente");
        
    }

    public void SaveOnDisk()
    {
        Console.WriteLine($"Salvato su Disco correttamente");
        
    }
}

#endregion


#region Class FileUploader
public class FileUploader
{
    public IStorageService storageService { get; set; }


    public void UploadFileOnDisk()
    {
        if (storageService == null)
        {
            Console.WriteLine($"Impossibile salvare il file");
            return;
        }
        storageService.SaveOnDisk();
    }
    public void UploadFileOnCache()
    {
        if (storageService == null)
        {
            Console.WriteLine($"Impossibile salvare il file");
            return;
        }
        storageService.SaveOnCache();
    }
}

#endregion
#region MAIN
static class MainSaver 
{
    public static void Run()
    {
        var generator = new FileUploader();

        generator.storageService = new StorageService();
        Console.WriteLine($"Salvare file su disco o memoria?");

        string? input = Console.ReadLine();
        switch (input)
        {
            case "disco":
                generator.UploadFileOnDisk();
                break;
            case "memoria":
                generator.UploadFileOnCache();
                break;
            default:
                Console.WriteLine($"input non riconosciuto");
                break;
        }
    }
}
#endregion