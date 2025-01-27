using BarrelsAccounting.Contracts.Dto;

namespace BarrelsAccounting.Accounting.Services;

/// <summary>
/// Интерфейс сервиса учета бочек.
/// </summary>
public interface IAccountingService
{
    /// <summary>
    /// Принятие новой бочки в систему.
    /// </summary>
    /// <param name="info"> Данные о бочке и МХ, куда ее принимают. </param>
    void Accept(AcceptanceBarrelDto info);
    
    /// <summary>
    /// Перемещение бочки между МХ.
    /// </summary>
    /// <param name="info"> Данные о бочке и новом МХ. </param>
    void Move(MovingBarrelsDto info);

    /// <summary>
    /// Списание бочки в производство.
    /// </summary>
    /// <param name="info"> Данные для операции. </param>
    void MoveToProduction(MovingToProductionBarrelsDto info);

    /// <summary>
    /// Возврат бочки с производства.
    /// </summary>
    /// <param name="info"> Данные для операции. </param>
    void Return(ReturnBarrelDto info);
}