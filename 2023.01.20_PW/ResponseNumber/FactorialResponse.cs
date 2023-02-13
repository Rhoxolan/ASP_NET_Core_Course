namespace _2023._01._20_PW.ResponseNumber
{
    public class FactorialResponse : IResponseNumber
    {
        public ulong ResponseNumber(ushort requestNumber)
        {
            if (requestNumber == 0 || requestNumber == 1)
            {
                return 1;
            }
            ulong factorial = 1;
            for (ulong i = 1; i <= requestNumber; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
