using MY.LeetCode.Problems.Medium;

namespace MY.LeetCode.Problems.Tests.Medium;

public class CountVowelStringsInRanges2559Tests
{
    private CountVowelStringsInRanges2559 _sut = new();

    [Fact]
    public void TestV1_WhenCase1_ReturnsCorrectRespone()
    {
        // Arrange
        string[] words = ["aba", "bcb", "ece", "aa", "e"];
        int[][] queries = [[0, 2], [1, 4], [1, 1]];

        // Act
        var result = _sut.VowelStrings(words, queries);

        // Assert
        int[] expected = [2, 3, 0];
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    [Fact]
    public void TestV2_WhenCase1_ReturnsCorrectRespone()
    {
        // Arrange
        string[] words = ["aba", "bcb", "ece", "aa", "e"];
        int[][] queries = [[0, 2], [1, 4], [1, 1]];

        // Act
        var result = _sut.VowelStringsV2(words, queries);

        // Assert
        int[] expected = [2, 3, 0];
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }
}
