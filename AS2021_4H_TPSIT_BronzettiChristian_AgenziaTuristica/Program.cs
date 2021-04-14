using System;
using AS2021_4H_TPSIT_BronzettiChristian_AgenziaTuristica.Models;

namespace AS2021_4H_TPSIT_BronzettiChristian_AgenziaTuristica
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenzia AriminunViaggi = new Agenzia();
            
            string[] optionalGitaBarca = new string[] { "PRANZO", "merenza", "Visita"};
            double [] costiOptionalGitaBarca = new double[] { 20, 5, 35 };

            //inserimento escursione
            AriminunViaggi.InserisciNuovaEscusione("gita in barca", "17/05/2021", optionalGitaBarca, "Gita in barca sulla costiera adriatica", 30.50, costiOptionalGitaBarca, 2);

            //registrazione del cliente3
            string[] optionalSceltiCliente1 = new string[] { "pranzo", "", ""};
            try
            {
                AriminunViaggi.RegistraClienteAdEscursione("Gianluca", "Bronzetti", "B. Buozzi, 5", "BRNGLC67S13H294R", "gita in barca", optionalSceltiCliente1);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //calcolo escursione
            Console.WriteLine($"Costo Escursione complessivo: {AriminunViaggi.CalcolaCostoEscursione("gita in barca")}");

            //modifica dati escursione
            //try
            //{
            //    Console.WriteLine($"{AriminunViaggi.ModificaEscursione("gita in barca", 1, "Gita in barca a Gabicce", "15/05/2021")}");
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
                

            //modifica optional cliente
            optionalSceltiCliente1[1] = "Merenda";
            Console.WriteLine($"{AriminunViaggi.ModificaOptionalCliente(optionalSceltiCliente1, "BRNGLC67S13H294R")}");

            Console.ReadLine();
            //disdisci escursione
            //Console.WriteLine($"{AriminunViaggi.DisdisciEscursione("BRNGLC67S13H294R")}");

            
           

            //registrazione del cliente 2
            string[] optionalSceltiCliente2 = new string[] { "pranzo", "merenda", "" };
            try
            {
                AriminunViaggi.RegistraClienteAdEscursione("Christian", "Bronzetti", "B. Buozzi, 5", "BRNCRS03S06H294W", "gita in barca", optionalSceltiCliente2);
            }
            catch (Exception e) //da errore perchè non c'è poto
            {
                
                Console.WriteLine(e.Message);
            }

            //calcolo escursione
            Console.WriteLine($"Costo Escursione complessivo: {AriminunViaggi.CalcolaCostoEscursione("gita in barca")}");

           
            //modifica optional cliente 2
            optionalSceltiCliente2[2] = "Visita";
            Console.WriteLine($"{AriminunViaggi.ModificaOptionalCliente(optionalSceltiCliente2, "BRNCRS03S06H294W")}");


            Console.WriteLine(@"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\");

            //nuova escursione
            string[] optionalGitaCavallo = new string[] { "PRANZO", "merenza", "Visita" };
            double[] costioptionalGitaCavallo = new double[] { 15, 5, 25 };

            //inserimento escursione
            AriminunViaggi.InserisciNuovaEscusione("gita a cavallo", "17/05/2021", optionalGitaCavallo, "Gita a cavallo nelle campagne", 50.50, costioptionalGitaCavallo, 3);

            //registrazione del cliente
            try
            {
                AriminunViaggi.RegistraClienteAdEscursione("Ghinelli", "Emanuela", "B. Buozzi, 5", "GHNMNL70C70294P", "gita a cavallo", optionalSceltiCliente1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //calcolo escursione
            Console.WriteLine($"Costo Escursione complessivo: {AriminunViaggi.CalcolaCostoEscursione("gita a cavallo")}");

            //modifica dati escursione
            try
            {
                Console.WriteLine($"{AriminunViaggi.ModificaEscursione("gita a cavallo", 6, "gita a cavallo", "15/05/2021")}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //modifica optional cliente
            optionalSceltiCliente1[1] = "Merenda";
            Console.WriteLine($"{AriminunViaggi.ModificaOptionalCliente(optionalSceltiCliente1, "GHNMNL70C70294P")}");

            Console.ReadLine();
            //disdisci escursione
            Console.WriteLine($"{AriminunViaggi.DisdisciEscursione("BRNGLC67S13H294R")}");




            //registrazione del cliente 2
            try
            {
                AriminunViaggi.RegistraClienteAdEscursione("Christian", "Bronzetti", "B. Buozzi, 5", "BRNCRS03S06H294W", "gita a cavallo", optionalSceltiCliente2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //calcolo escursione
            Console.WriteLine($"Costo Escursione complessivo: {AriminunViaggi.CalcolaCostoEscursione("gita a cavallo")}");


            //modifica optional cliente 2
            optionalSceltiCliente2[2] = "Visita";
            Console.WriteLine($"{AriminunViaggi.ModificaOptionalCliente(optionalSceltiCliente2, "BRNCRS03S06H294W")}");

            Console.WriteLine(AriminunViaggi.EliminaEscursione("gita a cavallo"));
        }
    }
}
