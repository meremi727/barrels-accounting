using System.Linq.Expressions;

namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel;

public interface ISearchRepository
{
	/// <summary>
	/// Возвращает все бочки, удовлетовряющие условию предиката.
	/// </summary>
	/// <param name="predicate"> Условие отбора. </param>
	/// <returns> Коллекция бочек, согласно условию отбора. </returns>
	IReadOnlyCollection<BarrelModel> Find(Expression<Func<BarrelModel, bool>> predicate);

	/// <summary>
	/// Находит и возвращает бочки по указанным идентификаторам.
	/// </summary>
	/// <param name="ids"> Идентификаторы для поиска. </param>
	/// <returns> Коллекция бочек. </returns>
	IReadOnlyCollection<BarrelModel> FindBy(IReadOnlyCollection<string> ids);

	// /// <summary>
	// /// Возвращает бочку по указанному идентификатору.
	// /// </summary>
	// /// <param name="id"> Идентификатор бочки. </param>
	// /// <returns> Бочка, если найдена и не удалена; иначе - <c>null</c>. </returns>
	// BarrelModel? FindBy(string id);

	// /// <summary>
	// /// Выполняет проекцию данных.
	// /// </summary>
	// /// <param name="selector"> Селектор. </param>
	// /// <typeparam name="TResult"> Результат проекции. </typeparam>
	// /// <returns> Коллекция уникальных преобразованных объектов. </returns>
	// IReadOnlyCollection<TResult> SelectDistinct<TResult>(Expression<Func<BarrelModel, TResult>> selector);
}