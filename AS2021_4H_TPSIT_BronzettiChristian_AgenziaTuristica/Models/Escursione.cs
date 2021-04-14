using System;
using System.Collections.Generic;
using System.Text;

namespace AS2021_4H_TPSIT_BronzettiChristian_AgenziaTuristica.Models
{
    class Escursione
    {
        //dati escursione privati
        string _tipo;
        string _data;
        string _descrizione;
        double _costoTipoEscursione;
        int _nMaxPersone;

        //prop read and write per la descrizione
        public string Descrizione { get => _descrizione; set => _descrizione = value; }

        //prop di lettura per il tipo
        public string Tipo { get => _tipo; }

        //prop read and write per la data
        public string Data { get => _data; set => _data = value; }

       //prop read and write per il costo del tipo di escursione
        public double CostoTipoEscursione { get => _costoTipoEscursione; set => _costoTipoEscursione = value; }

        //prop read and writer per il numero massimo di clienti
        public int NumeroPersoneMassimo { get => _nMaxPersone; set => _nMaxPersone = value; }


        //list poer contenere i clienti
        public List<Cliente> elencoClientiEscursione;

        //costi optinal e tipo optional
        string[] _optional = new string[3];
        double[] _costiOptional = new double[3];

        //read only per il costo degli optional
        public double[] CostiOptional { get => _costiOptional; /*set => _costiOptional = value;*/ }
        public string[] Optional { get => _optional; set => _optional = value; }


        // prop automatica che conta quanti nserimenti ci sono stati per una certa escursione
        public static int ControllaQuantiInseritiTipo1 {get; set;}
        public static int ControllaQuantiInseritiTipo2 { get; set; }

        //costruttoere
        public Escursione(string tipo, string data, string descrizione, double costoTipo, int nPersone, double [] costiOptional, string[] optional)
        {
            _tipo = tipo;
            _data = data;
            _costoTipoEscursione = costoTipo;
            _descrizione = descrizione;
            elencoClientiEscursione = new List<Cliente>();
            _optional = optional;
            _costiOptional = costiOptional;
            _nMaxPersone = nPersone;
        }

      
        //public override string ToString()
        //{
           
        //}



    }
}
