namespace Minesweeper
{
    public readonly struct Readonly<T> where T : struct
    {
        public readonly T value;

        public Readonly(T value)
        {
            this.value = value;
        }
    }
}