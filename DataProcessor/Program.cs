using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

// README.md를 읽고 아래에 코드를 작성하세요.

DataProcessor pr = new DataProcessor(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
Console.WriteLine("=== 원본 배열 출력 ===");
pr.ForEach(x => Console.Write($"{x}, "));
Console.WriteLine("\n\n=== 2배로 변환 ===");
pr.Transform(x => x * 2);
 

Console.WriteLine("\n\n=== 짝수만 필터링 ===");
pr.Filter(x => x % 2 == 0);
Console.WriteLine("\n\n=== 합계 계산 ===");
pr.Reduce((acc, x) => acc + x, 0);
Console.WriteLine($"합계: {pr.Reduce((acc, x) => acc + x, 0)}");




public class DataProcessor
{
    private int[] data;
    public DataProcessor(int[] data)
    {
        this.data = data;
    }
    public void ForEach(Action<int> action)
    {
        foreach (var item in data)
        {
            action(item);
        }
    }
    public int[] Transform(Func<int, int> transformer)
    {
        int[] transformed = new int[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            transformed[i] = transformer(data[i]);  // 변환 후 저장
        }
        foreach (var item in transformed)           // 출력
        {
            Console.Write($"{item} ");
        }
        return transformed;
    }

    public List<int> Filter(Func<int, bool> predicate)
    {
        List<int> filtered = new List<int>();
        foreach (var item in data)//계산
        {
            if (predicate(item))
            {
                filtered.Add(item);         
                //Console.WriteLine($"{item} ");
            }
        }
        foreach (var item in filtered)// 출력
        {
            Console.Write($"{item} ");
        }
        return filtered;
    }
    public int Reduce(Func<int, int, int> reducer, int initialValue)
    {
        int result = initialValue;
        foreach (var item in data)
        {
            result = reducer(result, item);
        }
        //출력문
       
        return result;
    }
}
