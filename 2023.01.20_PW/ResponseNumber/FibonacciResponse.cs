namespace _2023._01._20_PW.ResponseNumber
{
    public class FibonacciResponse : IResponseNumber
    {
        public ulong ResponseNumber(ushort requestNumber)
        {
            if (requestNumber == 0 || requestNumber == 1)
            {
                return requestNumber;
            }
            List<ulong> fl = new() { 0, 1 };
            for (ushort i = 0; i < requestNumber - 1; i++)
            {
                fl.Add(fl[^1] + fl[^2]);
            }
            return fl[^1];
        }
    }
}
