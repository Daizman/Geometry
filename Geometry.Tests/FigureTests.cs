using FluentAssertions;

namespace Geometry.Tests
{
	public class FigureTests
	{
		[Fact]
		public void UnknownFigureArea_WithCorrectFigures_ReturnsDouble()
		{
			// Arrange
			const double pi = 3.14;
			const double precision = 0.001;
			Circle circleR1 = new(1);
			double circleAreaR1 = pi;
			Circle circleR5 = new(5);
			double circleAreaR5 = pi * 5 * 5;
			Triangle triangle345 = new(3, 4, 5);
			double triangleArea345 = HeronTriangleArea(3, 4, 5);
			Triangle triangle678 = new(6, 7, 8);
			double triangleArea678 = HeronTriangleArea(6, 7, 8);
			List<Figure> figures = new() { circleR1, triangle678, triangle345, circleR5 };
			// Act
			// Assert
			figures[0].Area.Should().BeApproximately(circleAreaR1, precision);
			figures[1].Area.Should().BeApproximately(triangleArea678, precision);
			figures[2].Area.Should().BeApproximately(triangleArea345, precision);
			figures[3].Area.Should().BeApproximately(circleAreaR5, precision);
		}

		private static double HeronTriangleArea(double a, double b, double c)
		{
			double halfPerimetr = (a + b + c) / 2;
			return Math.Sqrt(halfPerimetr * (halfPerimetr - a) * (halfPerimetr - b) * (halfPerimetr - c));
		}
	}
}
