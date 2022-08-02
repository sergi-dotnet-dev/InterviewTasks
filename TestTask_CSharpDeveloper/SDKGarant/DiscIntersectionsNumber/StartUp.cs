using System;
public static class Program
{
    private static Int32[] _radiusArray;
    private const Int32 _maxArraylength = 100_000;
    public static void Main(String[] args)
    {
       // InitializeRadiusArray();
        Console.Write(Solution.solution(new int[3] {1,int.MaxValue,0 }));

        void InitializeRadiusArray()
        {
            var arraylength = new Random().Next(0, _maxArraylength);

            _radiusArray = new Int32[arraylength];
            for (int index = 0; index < arraylength; index++)
                _radiusArray[index] = new Random().Next(0, Int32.MaxValue);

            Console.WriteLine($"Array length is {arraylength}");
        }
    }
}
