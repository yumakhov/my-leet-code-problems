using System.Data.SqlTypes;

namespace MY.LeetCode.Problems.Medium;

public class LongestSubstringWithoutRepeatingCharacters3
{
    public static int LengthOfLongestSubstring(string s)
    {
        var result = 0;

        var currLength = 0;
        var prefixChars = new char[256];

        for (var j = 0; j < s.Length; j++)
            for (var i = j; i < s.Length; i++)
            {
                var currChar = s[i];
                if (currLength == 0)
                {
                    prefixChars[0] = currChar;
                    currLength++;
                    continue;
                }

                if (!IsArrayContains(prefixChars, currLength, currChar))
                {
                    prefixChars[currLength] = currChar;
                    currLength++;
                }
                else
                {
                    prefixChars[0] = currChar;
                    currLength = 1;
                }

                result = Math.Max(result, currLength);
                if (i == s.Length - 1)
                {
                    currLength = 0;
                }                
            }

        result = Math.Max(result, currLength);

        return result;
    }

    private static bool IsArrayContains(char[] arr, int maxLength, char ch)
    {
        for (var i = 0; i < maxLength; i++)
        {
            if (arr[i] == ch) return true;
        }

        return false;
    }
}