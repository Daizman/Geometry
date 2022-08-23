namespace Geometry
{
	public class Circle : Figure
	{
		private const double PI = 3.14;
		private double _radius;

		public Circle(double radius)
		{
			Radius = radius;
		}

		public double Radius
		{
			get => _radius;
			set
			{
				CheckSizeValue(value);
				_radius = value;
			}
		}

		public override double Area => PI * Radius * Radius;
	}
}
