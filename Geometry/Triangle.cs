namespace Geometry
{
	public class Triangle : Figure
	{
		private double _sideA;
		private double _sideB;
		private double _sideC;

		public Triangle(double sideA, double sideB, double sideC)
		{
			CheckTriangleSizeValue(sideA, sideB, sideC);
			CheckTriangleSizeValue(sideB, sideA, sideC);
			CheckTriangleSizeValue(sideC, sideA, sideB);

			_sideA = sideA;
			_sideB = sideB;
			_sideC = sideC;
		}

		public double SideA
		{
			get => _sideA;
			set
			{
				CheckTriangleSizeValue(value, _sideB, _sideC);
				_sideA = value;
			}
		}
		public double SideB
		{
			get => _sideB;
			set
			{
				CheckTriangleSizeValue(value, _sideA, _sideC);
				_sideB = value;
			}
		}
		public double SideC
		{
			get => _sideC;
			set
			{
				CheckTriangleSizeValue(value, _sideA, _sideB);
				_sideC = value;
			}
		}

		public double Perimetr => _sideA + _sideB + _sideC;
		public override double Area => Math.Sqrt(HalfPerimetr * (HalfPerimetr - _sideA) * (HalfPerimetr - _sideB) * (HalfPerimetr - _sideC));
		public bool IsRight => 2 * MaxSide * MaxSide == _sideA * _sideA + _sideB * _sideB + _sideC * _sideC;

		private double HalfPerimetr => Perimetr / 2;
		private double MaxSide => new double[] { _sideA, _sideB, _sideC }.Max();

		private static void CheckTriangleSizeValue(double valueToCheck, double side1, double side2)
		{
			CheckSizeValue(valueToCheck);
			CheckTriangleSizeIsCorrect(valueToCheck, side1, side2);
		}
		private static void CheckTriangleSizeIsCorrect(double valueToCheck, double side1, double side2)
		{
			if (valueToCheck >= side1 + side2)
			{
				throw new ArgumentException("Sum of sides incorrect");
			}
		}
	}
}
