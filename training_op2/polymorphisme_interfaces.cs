using System.Text.RegularExpressions;
namespace training_op2
{
    


    interface IPerimetre
    {
        double getPerimetre();
    }


    public class carre : IPerimetre
    {
       

        public double myLong { get; set; }
        public int Mylarg { get;  set; }

        public double getPerimetre()
        {
            return (myLong + Mylarg)*2;
        }
    }


    class Rectangle :IPerimetre
    {
            public double myLong { get; set; }
             public double Mylarg { get;  set; }

        public double getPerimetre()
        {
            return (myLong + Mylarg)*2;
        }
    }


    class Cercle :IPerimetre
    {
        public double myrayon { get; set; }

        // implementation implicite obligation d'implementer l'interface Iperimetre
        double IPerimetre.getPerimetre()
        {
            return (2 * System.Math.PI * myrayon);
        }
        
    }




}