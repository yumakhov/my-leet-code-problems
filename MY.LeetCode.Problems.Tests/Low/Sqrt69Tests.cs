using MY.LeetCode.Problems.Low;

namespace MY.LeetCode.Problems.Tests.Low;

public class Sqrt69Tests
{
    [Fact]
    public void MySqrt_WhenBigInput_ReturnsCorrectResult()
    {
        // Arrange
        var x = 2147483647;

        // Act
        var result = Sqrt69.MySqrt(x);

        // Assert
        Assert.Equal(46340, result);

    }
}
