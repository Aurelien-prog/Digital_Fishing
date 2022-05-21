using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Fishing
{
    public class Pigiste
    {
        #region Champs
        private int _numPigiste;
        private string _nomPigiste;
        private string _prenomPigiste;
        private string _adressePigiste;
        private string _cpPigiste;
        private string _villePigiste;
        private string _mailPigiste;
        private string _numSecuPigiste;
        private string _contratCadrePigiste;
        #endregion

        #region Constructeur
        public Pigiste(int n, string nm, string p, string a, string cp, string v, string m, string s, string cc)
        {
            _numPigiste = n;
            _nomPigiste = nm;
            _prenomPigiste = p;
            _adressePigiste = a;
            _cpPigiste = cp;
            _villePigiste = v;
            _mailPigiste = m;
            _numSecuPigiste = s;
            _contratCadrePigiste = cc;
        }
        #endregion

        #region Accesseurs/Mutateurs
        public int NumPigiste
        {
            get { return _numPigiste; }
            set { _numPigiste = value; }
        }

        public string NomPigiste
        {
            get { return _nomPigiste; }
            set { _nomPigiste = value; }
        }

        public string PrenomPigiste
        {
            get { return _prenomPigiste; }
            set { _prenomPigiste = value; }
        }
        public string AdressePigiste
        {
            get { return _adressePigiste; }
            set { _adressePigiste = value; }
        }
        public string CPPigiste
        {
            get { return _cpPigiste; }
            set { _cpPigiste = value; }
        }

        public string VillePigiste
        {
            get { return _villePigiste; }
            set { _villePigiste = value; }
        }
        public string MailPigiste
        {
            get { return _mailPigiste; }
            set { _mailPigiste = value; }
        }

        public string NumSecuPigiste
        {
            get { return _numSecuPigiste; }
            set { _numSecuPigiste = value; }
        }
        public string ContratCadrePigiste
        {
            get { return _contratCadrePigiste; }
            set { _contratCadrePigiste = value; }
        }
        #endregion

        #region Methodes
        override public string ToString()
        {
            // Méthode ToString() surchargée qui écrase la méthode ToString() de base
          return _nomPigiste + " " + _prenomPigiste;
        }
        #endregion
    }
}
