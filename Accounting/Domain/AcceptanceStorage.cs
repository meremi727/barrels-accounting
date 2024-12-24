namespace Accounting.Domain;


public class AcceptanceStorage : Storage
{
    /// <summary>
    /// Взвращает МХ по умолчанию.
    /// </summary>
    public StoragePlace? DefaultStoragePlace { get; set; }
}