using FluentAssertions;

namespace Geometry.Tests
{
	public class TriangleTests
	{
		[Fact]
		public void TriangleConstructor_WithNegativeSideValue_ThrowsArgumentException()
		{
			// Arrange
			double sideNegative = -1;
			double side1 = 1;
			double side2 = 1;
			// Act
			Func<double, double, double, Triangle> action = (a, b, c) => new Triangle(a, b, c);
			// Assert
			Assert.Throws<ArgumentException>(() => action(sideNegative, side1, side2));
			Assert.Throws<ArgumentException>(() => action(side1, sideNegative, side2));
			Assert.Throws<ArgumentException>(() => action(side1, side2, sideNegative));
		}

		[Fact]
		public void TriangleConstructor_WithIncorrectSideValue_ThrowsArgumentException()
		{
			// Arrange
			double bigSide = 100;
			double side1 = 5;
			double side2 = 6;
			// Act
			Func<double, double, double, Triangle> action = (a, b, c) => new Triangle(a, b, c);
			// Assert
			Assert.Throws<ArgumentException>(() => action(bigSide, side1, side2));
			Assert.Throws<ArgumentException>(() => action(side1, bigSide, side2));
			Assert.Throws<ArgumentException>(() => action(side1, side2, bigSide));
		}

		[Fact]
		public void TriangleConstructor_WithCorrectSideSizes_ReturnsTriangle()
		{
			// Arrange
			double sideA = 4;
			double sideB = 5;
			double sideC = 6;
			// Act
			var triangle = new Triangle(sideA, sideB, sideC);
			// Assert
			triangle.Should().BeOfType<Triangle>();
			triangle.SideA.Should().Be(sideA);
			triangle.SideB.Should().Be(sideB);
			triangle.SideC.Should().Be(sideC);
		}

		[Fact]
		public void TriangleArea_WithCorrectSideSizes_ReturnsDouble()
		{
			// Arrange
			const double precision = 0.001;
			double sideA = 4;
			double sideB = 5;
			double sideC = 6;
			// Act
			var triangle = new Triangle(sideA, sideB, sideC);
			// Assert
			triangle.Area.Should().BeApproximately(HeronTriangleArea(sideA, sideB, sideC), precision);
		}

		private static double HeronTriangleArea(double a, double b, double c)
		{
			double halfPerimetr = (a + b + c) / 2;
			return Math.Sqrt(halfPerimetr * (halfPerimetr - a) * (halfPerimetr - b) * (halfPerimetr - c));
		}

		[Fact]
		public void TriangleIsRight_WithCorrectRightTriangle_ReturnsTrue()
		{
			// Arrange
			double sideA = 3;
			double sideB = 4;
			double sideC = 5;
			// Act
			var triangle = new Triangle(sideA, sideB, sideC);
			// Assert
			triangle.IsRight.Should().Be(true);
		}

		[Fact]
		public void TriangleIsRight_WithCorrectNotRightTriangle_ReturnsFalse()
		{
			// Arrange
			double sideA = 4;
			double sideB = 5;
			double sideC = 6;
			// Act
			var triangle = new Triangle(sideA, sideB, sideC);
			// Assert
			triangle.IsRight.Should().Be(false);
		}
	}
}
