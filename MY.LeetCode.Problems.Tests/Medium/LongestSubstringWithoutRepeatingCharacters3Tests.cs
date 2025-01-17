using MY.LeetCode.Problems.Medium;

namespace MY.LeetCode.Problems.Tests.Medium;

public class LongestSubstringWithoutRepeatingCharacters3Tests
{
    [Fact]
    public void LengthOfLongestSubstring_WhenMaxLengthStrIsFromStart_Returns4()
    {
        // Arrange
        var s = "jbpnbwwd";

        // Act
        var result = LongestSubstringWithoutRepeatingCharacters3.LengthOfLongestSubstring(s);

        // Assert
        Assert.Equal(4, result);
    }
}
