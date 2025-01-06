namespace MY.LeetCode.Problems.Medium;

/// <summary>
/// 2559. Count Vowel Strings in Ranges (https://leetcode.com/problems/count-vowel-strings-in-ranges/description)
/// </summary>
public class CountVowelStringsInRanges2559
{
    public record struct IndexRangeData(int Start, int End);

    private static readonly char[] VowelLetters = [
        'a', 'e', 'i', 'o', 'u'
    ];

    public int[] VowelStrings(string[] words, int[][] queries)
    {
        var vowelWordsMap = new Dictionary<int, bool>(words.Length);
        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            vowelWordsMap[i] = VowelLetters.Contains(word[0]) &&
                VowelLetters.Contains(word[word.Length - 1]);
        }

        var rangeDataDict = new Dictionary<IndexRangeData, int>();
        var result = new int[queries.Length];

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var startIndex = query[0];
            var endIndex = query[1];
            var internalRange = rangeDataDict
                .FirstOrDefault(kv => kv.Key.Start >= startIndex && kv.Key.End <= endIndex);
            if (internalRange.Key != default)
            {
                result[i] += internalRange.Value;

                for (var j = startIndex; j < internalRange.Key.Start; j++)
                {
                    if (vowelWordsMap[j])
                    {
                        result[i]++;
                    }
                }

                for (var j = internalRange.Key.End + 1; j <= endIndex; j++)
                {
                    if (vowelWordsMap[j])
                    {
                        result[i]++;
                    }
                }
            }
            else
            {
                for (var j = startIndex; j <= endIndex; j++)
                {
                    if (vowelWordsMap[j])
                    {
                        result[i]++;
                    }
                }
            }

            rangeDataDict.TryAdd(new IndexRangeData(startIndex, endIndex), result[i]);
        }

        return result;
    }

    public int[] VowelStringsV2(string[] words, int[][] queries)
    {
        var rightWordRanges = new HashSet<IndexRangeData>();
        int? rangeStart = null;
        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var isRightWord = VowelLetters.Contains(word[0]) &&
                VowelLetters.Contains(word[word.Length - 1]);

            if (!isRightWord || i == words.Length - 1)
            {
                if (rangeStart != null)
                {
                    var rangeEnd = i == words.Length - 1 ? i : i - 1;
                    rightWordRanges.Add(new IndexRangeData(rangeStart.Value, rangeEnd));
                }

                rangeStart = null;
            }
            else if (rangeStart == null)
            {
                rangeStart = i;
                if (i == words.Length - 1)
                {
                    rightWordRanges.Add(new IndexRangeData(rangeStart.Value, rangeStart.Value));
                }
            }
        }

        var result = new int[queries.Length];

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var startIndex = query[0];
            var endIndex = query[1];
            foreach (var rigthWordRange in rightWordRanges)
            {
                if (endIndex < rigthWordRange.Start)
                {
                    break;
                }

                if (startIndex > rigthWordRange.End)
                {
                    continue;
                }

                result[i] += Math.Min(rigthWordRange.End, endIndex) - Math.Max(startIndex, rigthWordRange.Start) + 1;
            }

        }

        return result;
    }
}
