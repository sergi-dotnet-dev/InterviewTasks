public static class Solution
{
    public static Int32 solution(Int32[] array)
    {
        if (array.Length < 2) return 0;

        Int64[] rightEdges = new Int64[array.Length];
        Int32[] leftEdges = new Int32[array.Length];

        for (int index = 0; index < array.Length; index++)
        {
            leftEdges[index] = index - array[index];
            rightEdges[index] = (Int64)index + array[index];
        }

        Array.Sort(rightEdges);
        Array.Sort(leftEdges);

        return AdvancedMergeSort(leftEdges, rightEdges);

        Int32 AdvancedMergeSort(Int32[] leftNumArr, Int64[] rightNumArr)
        {
            Int32 i = 0;
            Int32 j = 0;
            Int32 result = 0;
            Int32 total = 0;

            while (i < leftNumArr.Length && j < rightNumArr.Length)
            {
                if (rightNumArr[j] >= leftNumArr[i])
                {
                    result += total;
                    total++;
                    i++;
                }
                else
                {
                    total--;
                    j++;
                }
                if (result > 10_000_000)
                    return -1;
            }
            return result;
        }
    }
}
