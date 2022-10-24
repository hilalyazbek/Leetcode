public static class DsaCourseWeek3
{
    public static void MergeSort(int[] arr, int left, int mid, int right)
    {
        //get size of both subarrays
        int n1 = mid - left + 1;
        int n2 = right - mid;

        //create temp arrays
        int[] lArr = new int[n1];
        int[] rArr = new int[n2];
        int i, j;

        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
            lArr[i] = arr[left + i];
        for (j = 0; j < n2; ++j)
            rArr[j] = arr[mid + 1 + j];

        //merge temp subarrays
        //original indexes are
        i = 0;
        j = 0;

        int k = left;
        while (i < n1 && j < n2)
        {
            if (lArr[i] <= rArr[j])
            {
                arr[k] = lArr[i];
                i++;
            }
            else
            {
                arr[k] = rArr[j];
                j++;
            }
            k++;
        }
        //copy elements from left array if any items are still present
        while (i < n1)
        {
            arr[k] = lArr[i];
            i++;
            k++;
        }
        //copy elements from right array if any items are still present
        while (j < n2)
        {
            arr[k] = rArr[j];
            j++;
            k++;
        }
    }
}
