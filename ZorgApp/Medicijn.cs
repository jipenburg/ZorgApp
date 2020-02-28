using System;
using System.Collections.Generic;
using System.Text;

namespace ZorgAppOop
{
    class Medicijn
    {
        private int medicijnId;
        private string medicijnNaam;
        private string omschrijving;
        private string soort;
        private string dosering;

        Medicijn()
        {
           
        }

        public Medicijn(int medicijnId, string medicijnNaam, string omschrijving, string soort, string dosering)
        {
            SetMedicijnId(medicijnId);
            SetMedicijnenNaam(medicijnNaam);
            SetOmschrijving(omschrijving);
            SetSoort(soort);
            SetDosering(dosering);

        }

        public void SetMedicijnId(int medicijnId) => this.medicijnId = medicijnId;
        public int GetMedicijnId(){ return this.medicijnId; }

        public void SetMedicijnenNaam(string medicijnNaam) { this.medicijnNaam = medicijnNaam; }
        public string GetMedicijnNaam() { return this.medicijnNaam; }

        public void SetOmschrijving(string omschrijving) { this.omschrijving = omschrijving; }
        public string GetOmschrijving() { return this.omschrijving; }

        public void SetSoort(string soort) { this.soort = soort; }

        public string GetSoort() { return this.soort; }

        public void SetDosering(string dosering) { this.dosering = dosering; }
        public string GetDosering() { return this.dosering; }

        




    }
}
