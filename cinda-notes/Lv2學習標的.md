雖然跟自身目標比較無相關...

但強制要考那就讀吧...

https://www.tutorialspoint.com/compile_csharp_online.php

* CSharp
  * Action<T>,Func<T>
  http://tpcg.io/y0l1SWWN

```
using System.IO;
using System;

class Program
{
    // 參考文章
    // https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/206252/
    // https://iter01.com/137001.html
    
    // delegate 委託
    public delegate void GreetingDelegate(string Name);
    
    static void Main()
    {
       Program.Say("育誠",SayCN);
       Program.Say("Yucheng",SayEN);
       
       // 預設委託
       // Func<T1,T2,T3,T4,TResult> 有反傳值的委託，具有多型可丟最多4個參數
       Func<string> SaySomeThing = Program.GetName;
       Console.WriteLine(SaySomeThing());
       
       // Action<T> 無法傳值的委託
       Action<string,GreetingDelegate> SaySomeThing2 = Program.Say;
       SaySomeThing2("育誠",SayCN);
    }

    static void SayCN(string Name)
    {
        Console.WriteLine("你好,"+Name);
    }
    
    static void SayEN(string Name)
    {
        Console.WriteLine("Hollow,"+Name);
    }
    
    static void Say(string Name,GreetingDelegate Greeting)
    {
        Greeting(Name);
    }
        
    static string GetName()
    {
        return "育誠";
    }  
        
}
```
