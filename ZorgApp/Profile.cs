using System;
using System.Collections.Generic;
using System.Text;

namespace ZorgAppOop
{
    class Profile
    {
        /*
        public — a public member can be accessed by any class
        private — a private member can only be accessed by code in the same class
        */

        //fields camel case
        //private string voorNaam;
        //private string achterNaam;
        //private int leeftijd;
        //private double gewicht;
        //private double lengte;

        /*public string size;
        public string Size
        {
            public get { return size; }
            private set { size = value; }
        }*/

        //properties pascal case. default op public
        //slaat inkomende variabels op in een field(Set) of haalt ze op uit een field(Get). get - public set - private
        private int profileId;
        //private int[] medicijnId = ForeignKey(id) van Medicijn Class
        private int[] medicijnId;
        private string voornaam;
        private string achternaam;
        private int leeftijd;
        private double gewicht;
        private double lengte;

        //constructor
        public Profile()
        {

        }
        public Profile(int inputId, int[] inputMedicijnId, string inputVoorNaam, string inputAchterNaam)
        {
            profileId = inputId;
            medicijnId = inputMedicijnId;
            voornaam = inputVoorNaam;
            achternaam = inputAchterNaam;
        }
        public Profile(int inputId, int[] inputMedicijnId, string inputVoornaam, string inputAchternaam, int inputLeeftijd, double inputGewicht, double inputLengte)
        {
            profileId = inputId;
            medicijnId = inputMedicijnId;
            voornaam = inputVoornaam;
            achternaam = inputAchternaam;
            leeftijd = inputLeeftijd;
            gewicht = inputGewicht;
            lengte = inputLengte;
        }

        //methods
        //getters lambda expression
        public int GetId() => profileId;
        public int[] GetMedicijnId() => medicijnId;
        public string GetVoornaam() => voornaam;
        public string GetAchternaam() => achternaam;
        public int GetLeeftijd() => leeftijd;
        public double GetGewicht() => gewicht;
        public double GetLengte() => lengte;
        public string GetBmi() 
        {
            double bmi = GetGewicht() / (Math.Pow(GetLengte(), 2));
            return Convert.ToString(bmi);
        } 
        //setters lambda expression
        public void SetId(int inputId) => profileId = inputId;
        public void SetMedicijnId(int[] inputMedicijnId) => medicijnId = inputMedicijnId;
        public void SetVoornaam(string inputVoornaam) => voornaam = inputVoornaam;
        public void SetAchternaam(string inputAchternaam) => achternaam = inputAchternaam;
        public void SetLeeftijd(int inputLeeftijd) => leeftijd = inputLeeftijd;
        public void SetGewicht(double inputGewicht) => gewicht = inputGewicht;
        public void SetLengte(double inputLengte) => lengte = inputLengte;


    }

    
}
