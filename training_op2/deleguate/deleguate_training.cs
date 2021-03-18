using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System;
namespace training_op2
{
    class myTrainingDeleguateClass
    {


        // methode anonyme 
        public void del_Action(int x,int y){

            System.Console.WriteLine("Somme :{0}", x+y);
            
        }



        
    }




    class TrainingEventClass
    {
        EventHandler _seuilEventHandler;
       public  event EventHandler<PropertyChangedEventArgs> _EventFermeture;
        private int cpteur = default(int);

        public event EventHandler seuilEvent{

            add{
                _seuilEventHandler += value;
                OnEventHandler();
            }
            remove{
                _seuilEventHandler -= value;
            }


        }




           


        protected  void OnEventHandler( ){

            _seuilEventHandler?.Invoke(this, new EventArgs());
        }

      


        public void AfficheMessageEvent(object sender,EventArgs e){

                System.Console.WriteLine("Vous etes arrivé depuis la classe !");
            }



         public void information(object sender,EventArgs e){

            System.Console.WriteLine("message ");
           
        }   



        public void fermeture (object sender, CancelEventArgs e){

            e.Cancel = cpteur == 100 ? true : false;
        }

    }



    // delegate event avec paramatre
    class TrainingEventParamClass
    {
        public int SeuilAtteint{ get; set; }
        public int etageDemande { get; set; }
        private bool etage = default(Boolean);

        // definition personnalisé d'un delegate
        public delegate void SeuilDelEventHandler<SeuilEventArgsClass>(SeuilEventArgsClass args);
       
        private SeuilDelEventHandler<SeuilEventArgsClass> _seuilHandler;
 

        public event SeuilDelEventHandler<SeuilEventArgsClass> SeuilEvent
        {

            add{
                _seuilHandler += value;
                if(!etage){
                      OnEventHandler();
                }
              
                
            }
            remove{
                _seuilHandler -= value;
            }


        }



         protected  void OnEventHandler()
         {


            // Console.Beep(4000, 1000);
             etage = new SeuilEventArgsClass(SeuilAtteint,etageDemande).endEtage(etageDemande);

            if(!etage){
                _seuilHandler?.Invoke(new SeuilEventArgsClass(SeuilAtteint,etageDemande));   
                 
            }
            
            
        }

    }


    // cette classe va nous permettre de passé des parametre a notre evenement
    class SeuilEventArgsClass : EventArgs
    {
        public int Seuil { get; set; }
        public int etageDemande { get; set; }
        public int MaxSeuil = 5;
        public bool bArrive = false;
        public SeuilEventArgsClass(int seuil,int etageDemande){
            this.Seuil = seuil;
            this.etageDemande = etageDemande;

        }




        public bool endEtage(int iparam){

            bool bEnd = (iparam == etageDemande && etageDemande == Seuil && etageDemande <=MaxSeuil) ? true : false;
            if(bEnd){
                System.Console.WriteLine("Vous etes arrivé au Level : {0}", etageDemande);
            }else if(etageDemande >= MaxSeuil){
                System.Console.WriteLine("Vous etes arrivé au Terminal !");
            }

            return bArrive = bEnd;
        }

    }


    
}