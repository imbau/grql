using System;

public class Program
{


    static void Main(string[] args)
    {
        // Intersect 
        //int[] arr1 = { 1, 4, 5 ,3,2,};
        //int[] arr2 = { 1, 2, 3, 4, 5 };
        string[] arr1 = { "1",  "4", "5", "3", "2" };
        string[] arr2 = {  "1", "2", "3", "4", "5" };

        var intersect = arr1.Intersect(arr2).ToList();
        double intersectLength = intersect.Count();
        double arr1Length = arr1.Length;
        //計算相似度
        int Similarity=(int) ((intersectLength/ arr1Length) *100);
        Console.WriteLine("交集: {0}-相似度:{1}", string.Join(",", intersect), Similarity);

        Console.Read();
    }
}

