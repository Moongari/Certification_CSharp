

namespace training_op2
{

    // polymorphisme dynamique principe d'overriding

    public abstract class Vehicule
    {
        public virtual void roule()
        {
             System.Console.WriteLine("le vehicule avance !");
        }
    }





    class voiture :Vehicule
    {
        
        
        public override void roule()
        {
            base.roule(); // appel de la methode de la class Vehir
            System.Console.WriteLine("la voiture avance !");
        }
        
    }


    class voiture_2 :Vehicule
    {
        
        // ici avec l'opérateur new va integrer le principe de Hiding en C# ou shadowing en VB
        /*
            ici en utilisant le principe de hiding c'est la  methode de la classe Vehicule qui sera appele
            car la methode roule() de la classe Voiture_2 est caché.
        */
        new public void roule() 
        {
            base.roule(); // appel de la methode de la class Vehicule
            System.Console.WriteLine("la voiture 2 avance !");
        }
        
    }





    class moto :Vehicule
    {
        public override void roule()
        {
            System.Console.WriteLine("la moto roule !");
        }
    }
    
}