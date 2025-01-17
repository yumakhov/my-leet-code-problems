namespace MY.LeetCode.Problems.Low;

/// <summary>
/// 1408. String Matching in an Array
/// </summary>
public class StringMatchingInAnArray1408
{
    public static IList<string> StringMatching(string[] words)
    {
        var result = new List<string>();

        var orderedWords = words.OrderBy(s => s.Length).ToArray();
        for (var i = 0; i < orderedWords.Length; i++)
        { 
            var substring = orderedWords[i];
            for (var j = i + 1; j < orderedWords.Length; j++)
            {
                var text = orderedWords[j];
                if (substring.Length > text.Length)
                {
                    break;
                }

                if (i == j || !text.Contains(substring))
                {
                    continue;
                }

                result.Add(substring);
                break;
            }
        }

        return result;
    }
}
