namespace MY.LeetCode.Problems.Low;
public class Sqrt69
{
    public static int MySqrt(int x)
    {
        if (x == 0) return 0;
        if (x == 1) return 1;

        var half = x / 2;
        var result = 0;
        for (var i = 1; i < half + 1; i++)
        {
            var pow = i * i;
            if (pow == x)
            {
                return i;
            }
            else if (pow > x || pow < 0)
            {
                return result;
            }
            else if (pow < x)
            {
                result = i;
            }
        }

        return result;
    }
}
