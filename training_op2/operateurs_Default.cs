using System;
namespace training_op2
{
    class Operateurs
    {

    //operateurs Default(T)

    public int x =default;
        public Boolean isOk = default;


        public Operateurs(){

    Console.WriteLine("valeur de x : {0} et valeur de isOk : {1}",x,isOk);


        T[] InitializeArray<T>(int length, T initialValue = default)
            {
                if (length < 0)
                {
                    return default;
                }

                var array = new T[length];

                for (var i = 0; i < length; i++)
                {
                    array[i] = initialValue;
                }
                return array;
            }

            Display(InitializeArray<int>(2));
    } 


void Display<T>(T[] values) => Console.WriteLine($"[ {string.Join("/ ", values)} ]");



    }
}
