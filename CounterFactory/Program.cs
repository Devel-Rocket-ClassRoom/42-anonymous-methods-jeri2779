using System;

// README.md를 읽고 아래에 코드를 작성하세요.
CounterFactory factory = new CounterFactory();
Console.WriteLine("=== 단순 카운터 ===");
var simpleCounter = CounterFactory.CreateSimpleCounter();
for (int i = 0; i < 5; i++)
{
Console.Write(simpleCounter() + " ");
}
Console.WriteLine("\n\n=== 스텝 카운터 (step=3) ===");
var stepCounter = CounterFactory.CreateStepCounter(3);
for (int i = 0; i < 4; i++)
{
Console.Write(stepCounter() + " ");
}
Console.WriteLine("\n\n=== 범위 카운터 (1~3) ===");
var boundedCounter = CounterFactory.CreateBoundedCounter(1, 3);
for (int i = 0; i < 7; i++)
{
Console.Write(boundedCounter() + " ");
}
Console.WriteLine("\n\n=== 리셋 가능 카운터 ===");
CounterFactory.CreateResettableCounter(out Action reset, out Func<int> resettableCounter);
Console.Write("호출: ");
for (int i = 0; i < 3; i++)
{
Console.Write(resettableCounter() + " ");
}
Console.Write("\n리셋 후: ");
reset();
for (int i = 0; i < 2; i++)
{
Console.Write(resettableCounter() + " ");
}
public class CounterFactory
{
    public static Func<int> CreateSimpleCounter()
    {
        int count = 0;
        return () => ++count;
    }
    public static Func<int> CreateStepCounter(int step)
    {
        int count = 0;
        return () => count += step;
    }
    public static Func<int> CreateBoundedCounter(int min, int max)
    {
        int count = min - 1;
        return () =>
        {
            count++;
            if (count > max) count = min;
            return count;
        };
    }
    public static void CreateResettableCounter(out Action reset, out Func<int> counter)
    {
        int count = 0;
        reset = () => count = 0;
        counter = () => ++count;
    }
}