namespace Geometry
{
	/// <summary>
	/// При создании фигур во время работы мы можем использовать этот класс, как тот, что храним,
	/// чтобы получать площадь фигуры в независимости от типа
	/// </summary>
	public abstract class Figure
	{
		public abstract double Area { get; }

		protected static void CheckSizeValue(double value)
		{
			if (value < 0)
			{
				throw new ArgumentException("Size values must be positive");
			}
		}
	}
}