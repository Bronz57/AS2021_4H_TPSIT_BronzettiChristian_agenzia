using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AS2021_4H_TPSIT_BronzettiChristian_AgenziaTuristica.Models
{
    class Agenzia
    {
        List<Escursione> elencoEscursioni;
        public Agenzia()
        {
            elencoEscursioni = new List<Escursione>();
        }
        public void InserisciNuovaEscusione(string tipo, string data, string []optional, string descrizione, double costoTipo, double []costiOptional, int nPersone)
        => elencoEscursioni.Add(new Escursione(tipo, data, descrizione, costoTipo, nPersone, costiOptional, optional));

        public void RegistraClienteAdEscursione(string nome, string cognome, string via, string codiceFiscale, string tipo, string [] optionalScelti)
        {
           
            //gira per ogni escursione già inserita
            foreach (Escursione e in elencoEscursioni)
            {
                //controllo se il tipop è coerente a quello analizzato
                if(e.Tipo.Equals(tipo))
                    if (ControlloMassimiInseriti(tipo, e.NumeroPersoneMassimo)) //controllo se oltrepassa il dimensionamento inziiale
                        throw new Exception("Hai inserito troppe persone");

                
                //se è gita in barca aumento tipo1
                if(tipo.Equals("gita in barca") && e.Tipo.Equals(tipo))
                {
                    e.elencoClientiEscursione.Add(new Cliente(nome.ToUpper(), cognome.ToUpper(), via.ToUpper(), codiceFiscale, optionalScelti));
                    Escursione.ControllaQuantiInseritiTipo1++;
                }

                //altrimenti tipo2
                if (tipo.Equals("gita a cavallo") && e.Tipo.Equals(tipo))
                {
                    e.elencoClientiEscursione.Add(new Cliente(nome.ToUpper(), cognome.ToUpper(), via.ToUpper(), codiceFiscale, optionalScelti));
                    Escursione.ControllaQuantiInseritiTipo2++;
                }


            }

            //salvo dati
            ArchiviazioneDati(codiceFiscale);
        }

        bool ControlloMassimiInseriti(string tipo, int nMax)
        {
            //controllo se il tipo è uguale e se ci sono posti

            if (tipo.Equals("gita in barca") && Escursione.ControllaQuantiInseritiTipo1 >= nMax )
                return true;

            if (tipo.Equals("gita a cavallo") && Escursione.ControllaQuantiInseritiTipo2 >= nMax)
                return true;

            return false;

        }

        //salvo i dati
        void ArchiviazioneDati(string codiceFiscale)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Escursione e in elencoEscursioni)
                foreach (Cliente c in e.elencoClientiEscursione)
                    if (c.CodiceFiscale.Equals(codiceFiscale))
                        sb.AppendLine(c.ToString());

            try
            {
                File.AppendAllText(@"ListaClienti.txt",
                               sb.ToString());
            }
            catch
            {
                throw new Exception("Errore nel salvataggio file");
            }            
        }

        //metodo che calcola il costo dell'uscursione totale
        public double CalcolaCostoEscursione(string tipo)
        {
            //prima ricerco che optinal hanno i clienti
            //devo sommare ogni costo dell'optional

            double costoOptional=0;
            foreach (Escursione e in elencoEscursioni)
                foreach(Cliente c in e.elencoClientiEscursione)
                {
                    if (e.Tipo.Equals(tipo))
                    {
                        if (!c.OptionalScelti[0].Equals(""))
                            costoOptional += e.CostiOptional[0];

                        if (!c.OptionalScelti[1].Equals(""))
                            costoOptional += e.CostiOptional[1];

                        if (!c.OptionalScelti[2].Equals(""))
                            costoOptional += e.CostiOptional[2];
                    }

                }
                   
           
           double costoTotale=0;
            foreach (Escursione e in elencoEscursioni)
                if(e.Tipo.Equals(tipo))
                costoTotale += e.CostoTipoEscursione;

            return costoTotale+costoOptional;
        }

        //è permesso camnbiare ogni dato dell'escursione tranne i costi, il tipo e l'optional.
        //Per cambiare l'optional ci sarà un metodo che agisce sul codice fiscale e quindi sul cliente
        public string ModificaEscursione(string tipo, int nPersoneEscursione, string desc, string data)
        {
            foreach(Escursione e in elencoEscursioni)
            {
                if(e.Tipo.Equals(tipo))
                {
                    e.Data = data;

                    if (e.NumeroPersoneMassimo < nPersoneEscursione)
                        e.NumeroPersoneMassimo = nPersoneEscursione;
                    else
                        throw new Exception("Non è possibile mettere un numero di persone inferiori al numero massimo stabilito precendentemente");                    e.Descrizione = desc;
                    
                    return "Dati modificati, avvisa i clienti";
                }
            }

            return "Escursione non trovata";
        }

        public string ModificaOptionalCliente(string [] optional, string cf)
        {
            foreach (Escursione e in elencoEscursioni)
                foreach (Cliente c in e.elencoClientiEscursione)
                    if (cf.Equals(c.CodiceFiscale))
                    {
                        c.OptionalScelti = optional;
                        double costoEscursione = CalcolaCostoEscursione(e.Tipo);
                        return $"Optionals modificati con successo, il costo totale dell'escursione è di euro {costoEscursione}";
                    }
            return "Non è stato possibile trovare il cliente";
        }

        public string EliminaEscursione(string tipo)
        {
            for (int i = 0; i < elencoEscursioni.Count; i++)
                if (elencoEscursioni[i].Tipo.Equals(tipo))
                {
                    elencoEscursioni.RemoveAt(i);
                    return "Escursione eliminata";
                }

            return "Escursione non trovata";
        }

        public string DisdisciEscursione(string cf)
        {

            for (int i = 0; i < elencoEscursioni.Count; i++)
                for (int j = 0; j < elencoEscursioni[i].elencoClientiEscursione.Count; j++)
                    if (elencoEscursioni[i].elencoClientiEscursione[j].CodiceFiscale.Equals(cf))
                    {
                        elencoEscursioni[i].elencoClientiEscursione.RemoveAt(j);
                        return "Escursione annullata";
                    }
            
            return "Non è stavo trovato nessun cliente col seguende codice fiscale";
        }
    }
}
