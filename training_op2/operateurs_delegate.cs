using System;
class MyDelegate
{
    
    public MyDelegate()
    {
        System.Console.WriteLine(Method1());
    }

    public string Method1()
    {
        Func<string,string,string> express = (a,b)=> string.Join(":",a,b);
        return express("Moungari","Moustafa") ;
    }



}