using FluentAssertions;

namespace Geometry.Tests
{
	public class CircleTests
	{
		[Fact]
		public void CircleConstructor_WithNegativeRadius_ThrowsArgumentException()
		{
			// Arrange
			double radius = -1;
			// Act
			Func<double, Circle> action = r => new Circle(r);
			// Assert
			Assert.Throws<ArgumentException>(() => action(radius));
		}

		[Fact]
		public void CircleConstructor_WithCorrectRadius_ReturnsCircle()
		{
			// Arrange
			double radius = 1;
			// Act
			var circle = new Circle(radius);
			// Assert
			circle.Should().BeOfType<Circle>();
			circle.Radius.Should().Be(radius);
		}

		[Fact]
		public void CircleArea_WithCorrectRadius_ReturnsDouble()
		{
			// Arrange
			double precision = 0.001;
			const double pi = 3.14;
			double radius = 1;
			double area = radius * radius * pi;
			// Act
			var circle = new Circle(radius);
			// Assert
			circle.Area.Should().BeApproximately(area, precision);
		}
	}
}