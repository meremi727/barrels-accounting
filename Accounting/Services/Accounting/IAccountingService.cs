namespace BarrelsAccounting.Accounting.Services.Accounting;

/// <summary>
/// Интерфейс сервиса учета бочек.
/// </summary>
public interface IAccountingService
{
    void Accept();
    
    void Move();

    void MoveToProduction();

    void Return();
}