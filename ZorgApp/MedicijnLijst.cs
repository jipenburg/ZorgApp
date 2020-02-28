using System;
using System.Collections.Generic;
using System.Text;

namespace ZorgAppOop
{
    class MedicijnLijst
    {
        //properties en fields
        public List<Medicijn> medicijnLijst { get; private set; }
        //constructor
        public MedicijnLijst()
        {
            //maakt de lijst wakker(initiateert) in property medicijnLijst:
            medicijnLijst = new List<Medicijn>();
            //vult property medicijn lijst in:
            //new Medicijn(medicijnId, medicijnNaam, omschrijving, soort, dosering.)
            medicijnLijst.Add(new Medicijn(1, "Paracetemol",
                "Paracetamol is een veelgebruikt pijnstillend en koortsverlagend middel.", 
                "n.v.t.", 
                "Maximaal 2 per dag"));
            medicijnLijst.Add(new Medicijn(2, "Asperine", 
                "Asperine is een medicijn dat pijnstillend, koortsverlagend en ontstekingsremmend werkt.",
                "Salicylaten",
                "Volwassenen 500-1000 mg per keer, maximaal 4000 mg per 24 uur"));
            medicijnLijst.Add(new Medicijn(3, "Ibuprofen",
                "Het werkt ontstekingsremmend, pijnstillend en koortsverlagend; de werking is vergelijkbaar met die van acetylsalicylzuur.",
                "NSAID",
                "De dosering ibuprofen voor volwassenen is maximaal 1200 mg per dag (24 uur)."));
            medicijnLijst.Add(new Medicijn(4, "Naproxen", 
                "Naproxen is een medicijn dat oorspronkelijk is ontwikkeld voor de behandeling van reumatische gewrichtsklachten.",
                "Arylpropionzuurderivaten", 
                "In Nederland is Naproxen zonder doktersrecept verkrijgbaar als pijnstiller in een dosering tot 275 mg"));
        }
    }   

}
