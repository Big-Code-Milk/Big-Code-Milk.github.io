雖然跟自身目標比較無相關...

但強制要考那就讀吧...

https://www.tutorialspoint.com/compile_csharp_online.php

## CSharp

* http://tpcg.io/vqeAXRr1
* Action<T>,Func<T> 
* Anonymous Methods 
* Lambda expressions 
* Events 

```
using System.IO;
using System;

class Program
{
    // 參考文章
    // https://ithelp.ithome.com.tw/articles/10205614
    // https://me1237guy.pixnet.net/blog/post/65140795-c%23-delegate-and-event-%E5%A7%94%E8%A8%97%E8%88%87%E4%BA%8B%E4%BB%B6
    // https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/206252/
    // https://iter01.com/137001.html
    
    // delegate 委託
    public delegate void GreetingDelegate(string Name);
    public delegate int AnonymousMethods  (int x, int y);
    public delegate void EventMethod();
    static event EventMethod DelegateEvent;
    
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
       
       // 匿名函式
       AnonymousMethods AM = delegate (int x, int y) {
                return x + y;
       };
       Console.WriteLine(AM(1,1));
       
       // 匿名 Lambda表達式
       AM = (int x, int y) => { return x * y; };
       Console.WriteLine(AM(2,2));
       
       // Event
       Program.DelegateEvent += new EventMethod(WriteName);
       Program.DelegateEvent += new EventMethod(WriteName);
       Program.DelegateEvent(); // 事件觸發
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
    
    static void WriteName()
    {
        Console.WriteLine("育誠");
    }  
            
}
```

* Stack, Heap memory https://nwpie.blogspot.com/2017/05/5-stack-heap.html
* Garbage Collection https://derjohng.doitwell.tw/533/%E9%9B%BB%E8%85%A6%E9%A1%9E%E5%88%A5/%E7%A8%8B%E5%BC%8F%E7%AD%86%E8%A8%98/c-garbage-collection-%E7%AD%86%E8%A8%98/
* using ( …) { … } 
