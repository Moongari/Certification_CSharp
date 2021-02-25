using System.Globalization;
using System.Diagnostics;
using System.ComponentModel;
using System.Numerics;
using System;
using System.Collections;
using System.Reflection;

namespace training_op2
{
    class Program
    {
        private const string Value = "tu es un humain";
        public delegate void deltrainingSomme();
        private static int? numero = null;
        static void Main(string[] args)
        {


            

            if(numero.HasValue){

                Console.WriteLine(numero);
            }else{
                Console.WriteLine("do not have value" + ""+ DateTime.Now);
            }


        TrainingEventClass t_event_1 = new TrainingEventClass();

            t_event_1.seuilEvent += t_event_1.AfficheMessageEvent;




            // Patron de concept  IOC

            Personne person = new Personne();
            Process process = new Process(person);
            process.enveloppe();

            /*
                TASK
            */
            Task_Training task_ = new Task_Training();
            System.Console.WriteLine($"le message a été lancé value : {task_.Resultat}");
             Console.ReadLine();


            /*
            TASK  asynchrone


        Task_TrainingAsync _taskAsync = new Task_TrainingAsync();

        _taskAsync.AppelVerifRight();

        _taskAsync.destroyfile();
        // _taskAsync.LancerTraitement_WithoutTask();

        System.Console.WriteLine("Demarrage...");

        _taskAsync.appelAsync();

        Stopwatch spWatch = new Stopwatch(); // on va gerer le temps de traitement

        spWatch.Start();
        while (!_taskAsync.isCompleted)
        {
            System.Console.WriteLine("traitement en cours !");
        }
        spWatch.Stop();
        var laps = spWatch.Elapsed;

        System.Console.WriteLine($"Temps de traitement : {laps}");
        System.Console.ReadLine();
        */


            /*

                Task ANNULATION TACHE

           
            TaskAnnulation annulation = new TaskAnnulation();
            System.Console.WriteLine("PRESSER F10 pour arreter le traitement !");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if(keyInfo.Key== ConsoleKey.F10){
                annulation.CancelTraitement();
            }
            System.Console.WriteLine("arreter l'application Entrée");
            System.Console.ReadLine();
            */

            /*

            Task Continuation
                TaskContinuation MySommeTask = new TaskContinuation();
            System.Console.ReadLine();
            */

           




            /*

                Training Thread

            */

            // SimpleThreadclass th = new SimpleThread();
            // SimpleThreadParametre thParam = new SimpleThreadParametre();
            //SimpleThreadWithJoin thjoin = new SimpleThreadWithJoin();
            MyBackgroundWorkerClass worker = new MyBackgroundWorkerClass();
            worker.Lancer();

            Console.ReadLine();


            /* ici on fait un test pour utiliser le DebuggerDisplay 
            Persone myTest = new Persone{nom= " "};
            */


            /*
                Gestion des exceptions 
         
          
            GestionException exception = new GestionException();
            double res;
            try
            {
               res = exception.divide();
               if(Double.IsInfinity(res)){
                    throw new DivideByZeroException();

                }else{
                    System.Console.WriteLine($"Le resultat est :{0}",res);
                }

            }
            catch (DivideByZeroException ex)
            {
                var msg = ex.Message;
                System.Console.WriteLine(msg);
                throw; // en indiquant throw nous conservons les données de la pile 

            }   
              */



            // Principe de reflexion
            System.Console.WriteLine(Assembly.GetEntryAssembly().ToString());
            System.Console.WriteLine(Assembly.GetCallingAssembly());

            // ici nous definissons un objet de type Object nous n'avons donc pas acces au propriete de l'objet animal
            // pour cela nous pouvons faire appel a la reflexion
            object animal = new AninauxClass { race = "Felin", nom = "Lion" };

            // ici principe par reflexion  nous obtenons les proprietes 
            string _race = animal.GetType().GetProperty("race").GetValue(animal).ToString();
            string _nom = animal.GetType().GetProperty("nom").GetValue(animal).ToString();

            // principe par dynamic
            dynamic animal1 = new AninauxClass { race = "Felin", nom = "Lion" };
            string _race1 = animal1.race;
            string nom = animal1.nom;







            // gestionnaire d'evenement 

            TrainingEventClass t_event = new TrainingEventClass();

            Assembly assembly = typeof(TrainingEventClass).Assembly;
            

            TrainingEventParamClass t_eventparam = new TrainingEventParamClass();
            t_eventparam.etageDemande = 3;

            int index = 0;

                for (int i = 0; i < 10; i++)
                {
                System.Threading.Thread.Sleep(500);
                if(index++ == 5){
                    t_event.seuilEvent += t_event.AfficheMessageEvent;
                   
                }else if(index > 6){
                    t_eventparam.SeuilAtteint++;
                    t_eventparam.SeuilEvent += AfficheMessageEvent_param;
                }
            }

            static void AfficheMessageEvent(object sender,EventArgs e){

                System.Console.WriteLine("Vous etes arrivé depuis le Main !");
            }

            static void AfficheMessageEvent_param(SeuilEventArgsClass args){
               
                System.Console.WriteLine("Vous etes a l'etage {0} :  ",args.Seuil);
            }

            // delegate
            Action<int, int> somme = delegate (int x, int y)
                    {
                        System.Console.WriteLine("somme : {0}",x+y);
                    };
            
            // methode anonyme avec expression lambda
            Action<int, int> somme1 = (x,y)=> System.Console.WriteLine("somme : {0}",x+y);
            
                
           

                somme.Invoke(23, 30);
                somme1.Invoke(23, 30);



            myTrainingDeleguateClass training = new myTrainingDeleguateClass();
            Action<int,int> ActSomme = training.del_Action;
            ActSomme(23,45);


            // delegate Func  return un int
            Func<int, int, int> somme3 = delegate (int x, int y)
            {
                return x+y;
            };

            Func<int, int, int> somme4 = (x, y) => x + y;

            System.Console.WriteLine("Somme 3: Delegate : {0}, expression Lambda : {1}" , somme3.Invoke(15,18),somme4.Invoke(15,18));











            Methode_1Class methode_1 = new Methode_1Class(10, 20);

            // passage de parametre determinée et indeterminée
            int[] tableau = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        
            int resultat = methode_1.somme("50",1, 2, 3, 4, 5, 6, 7, 8, 9 );
           
            




            // polymorphisme
            Humain humain = new Humain();
            // polymorphisme de class
            Humain peter = new Bob();
            Bob bob = new Bob();



            System.Console.WriteLine(String.Join(";",bob.Method1() , bob.Method2()));     

            // polymorphisme dynamique 
            Vehicule porsche = new voiture();
            Vehicule dugatti = new moto();
            Vehicule mercedes = new voiture_2();
            porsche.roule();
            dugatti.roule();
            mercedes.roule(); //hiding 

            // polymorphisme d'interface
            IPerimetre icarre = new carre { myLong = 2, Mylarg = 2 };
            IPerimetre irectangle = new Rectangle { myLong = 4, Mylarg = 2 };
            carre _carre = new carre { myLong = 2, Mylarg = 2 };
            IPerimetre icercle = new Cercle { myrayon = 2 };

            // ici il s'agit du polymorphisme d'interface seul la methode  getPerimetre() est disponible
            // par le biais de la methode getPerimetre
    
            static double getPerimetre(IPerimetre iperimetre){
                return iperimetre.getPerimetre();
            }


            System.Console.WriteLine(String.Join(";","icarre :"+getPerimetre(icarre),"carre :" + _carre.getPerimetre(),"iRectangle :"+getPerimetre(irectangle)));




            


            /*****operateurs Delegate********

            MyDelegate myDelegate = new MyDelegate();

            */

            /******operateurs Default******
                

                Operateurs op = new Operateurs();

            */
            
          




            /*****enumerateur******

            ExempleEnum exEnum = new ExempleEnum();
            exEnum.afficheColor();

            */

            /******operateur as ******

            Persone p = new Persone { nom = "Moon" };
            IPersonne ip = p as IPersonne;

            */

            //int[] tab = (int[])GetValues();



            /******** operateur x?? y ********
            int? x = getdata();
            afficheValeur(x ?? 10); // si x vaut null alors remplace la valeur de retour par 10

                static void afficheValeur(int x)
                {
                    System.Console.WriteLine("x vaut {0}", x);
                }
            */



            /******* test de l'indexeur ******

            int[] tab2 = { 1, 2, 3, 4, 5 };

            MyCollection macollection = new MyCollection(tab2);
            int y1 = macollection[2]; // grace a l'indexeur nous avons acces a la valeur 3 sans avoir a parcourir la collection
            macollection.myparam = Convert.ToString(y1);                         // par un foreach

            System.Console.WriteLine(macollection.ToString());

            foreach (var item in macollection)
            {
                ;
            }
        */

            // interfaces

            humain _humain = new humain();
            paul _paul = new paul();
            lion _lion = new lion();
            IaDesMembres[] _iadesmembres = {_humain,_paul,_lion };

     

            _lion.mb_corps = membres_corps.pattes;



            foreach (IaDesMembres item in _iadesmembres)
            {
                    if(item.Equals(_lion)){
                        _lion.mb_corps = membres_corps.pattes;
                    }
                     if(item.Equals(_paul)){
                        _paul.mb_corps = membres_corps.tete;
                        _paul.visageLong = "Mon visage est long ";
                        _paul.visageRond = "il n'est pas rond";
                    }

                    quelmembres(item);

            }



           


            // Pattern bridge 

            AbstractBridge abstractBridge = new AbstractBridge(new Bridge1());
            abstractBridge.Callmethod1(); // ici on appele l'objet Bridge1 version 1 par exemple

            abstractBridge = new AbstractBridge(new Bridge2());
            abstractBridge.Callmethod1(); // ici on appele l'objet Bridge1 version 2 par exemple
            // on remarque que l'appel a la function1 est la meme mais executer par les 2 versions différentes




        }


        static public void quelmembres(IaDesMembres membres)
        {

            bool quitues = membres.mb_corps == membres_corps.pattes ? true : false;

                if(quitues){
                membres.visageLong = "je n'ai pas de visage ,j'ai une gueule GRRRRRRRRRRRR";
                System.Console.WriteLine("je suis un {0},{1}" ,getNameClass(membres.GetType().ToString()),membres.visageLong);}
                


        }


        static public String getNameClass(string nameClass){

            String[] nameClas = nameClass.Split(new Char[]{'.'});
            return nameClas[1];

        }

        



        static public int? getdata()
        {

            return null;
        }


        //operateur yield retourne plusieurs valeurs
        static public IEnumerable GetValues()
        {
            int[] result = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (int item in result)
            {
                yield return item;
            }

        }


    }



    internal interface IPersonne
    {

        public string nom { get; set; }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
   
    class Persone :IPersonne
    {

        public string nom { get; set; } 
        public string prenom { get; set; } 
        public void afficher()
        {

            System.Console.WriteLine("Votre nom est : {0}", nom);
        }

        public override string ToString(){

            return $"Vos informations : {nom} {prenom}";
        }

        String valide;
        private string DebuggerDisplay{

                    

            get { return  valide = String.IsNullOrEmpty(nom) ?string.Format("votre nom est :{0}", nom):"nom invalide"; }
        }

    }



    class ExempleEnum
    {



        //  Enum Sans FlagsAttribute.
        enum SingleHue : short
        {
            None = 0,
            Black = 1,
            Red = 2,
            Green = 4,
            Blue = 8
        };

        //  Enum avec FlagsAttribute.
        [Flags]
        enum MultiHue : short
        {
            None = 0,
            Black = 1,
            Red = 2,
            Green = 4,
            Blue = 8
        };
         public void afficheColor()
        {
                Console.WriteLine( 
           "toutes les valeurs  sans FlagsAttribute:");
      for(int val = 0; val <= 16; val++ )
         Console.WriteLine( "{0,3} - {1:G}", val, (SingleHue)val);

      // Display all combinations of values, and invalid values.
      Console.WriteLine( 
           "\ntoutes les valeurs  avec FlagsAttribute:");
      for( int val = 0; val <= 16; val++ )
         Console.WriteLine( "{0,3} - {1:G}", val, (MultiHue)val);

        }

    }



    // indexeur de classe

    class MyCollection : IEnumerable {

    

        public string myparam { get;  set; }


        int[] _collection;
        public MyCollection(int n)
        {
            _collection = new int[n];
        }

        public MyCollection(int[] collection)
        {
            _collection = collection;
        }

         public int this[int index]
         {
            get { return _collection[index]; }
            set { _collection[index] = value; }

        }
        public IEnumerator GetEnumerator()
        {
            return _collection.GetEnumerator();
        }


          public override string ToString()
          {

            return string.Format("Valeur de y1  : {0}" , myparam);


            }

    }
   


}
