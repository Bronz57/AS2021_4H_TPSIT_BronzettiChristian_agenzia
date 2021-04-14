using System;
using System.Collections.Generic;
using System.Text;

namespace AS2021_4H_TPSIT_BronzettiChristian_AgenziaTuristica.Models
{
    class Cliente
    {
        //dati cliente
        string _nome;
        string _cognome;
        string _via;
        string _codiceFiscale;
        
        //proprietà readonly per il codice fiscale
        public string CodiceFiscale { get => _codiceFiscale; }

        //proprietà automatica per gli optional scelti dal cliente
        public string [] OptionalScelti { get; set; }

        //costruttore
        public Cliente(string nome, string cognome, string via, string codiceFiscale, string []optionalScelti)
        {
            _nome = nome;
            _codiceFiscale = codiceFiscale;
            _cognome = cognome;
            _via = via;
            OptionalScelti = optionalScelti;
        }

        //stampa
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nome: {_nome}");
            sb.AppendLine($"Cognome: {_cognome}");
            sb.AppendLine($"Indirizzo: {_via}");
            sb.AppendLine($"Codice Fiscale {_codiceFiscale}");

            return sb.ToString();
        }
    }
}
