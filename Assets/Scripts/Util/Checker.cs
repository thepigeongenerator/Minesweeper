using System.Runtime.CompilerServices;

namespace Minesweeper.Util
{
    public static class Checker
    {
        // throws ArgumentOutOfRangeException if a is less than or equal to b
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsLessThenOrEqualTo(int a, int b, string variableName)
        {
            if (a <= b)
            {
                throw new System.ArgumentOutOfRangeException(variableName, $"{variableName} mustn't be equal or less than {b}");
            }
        }
    }
}