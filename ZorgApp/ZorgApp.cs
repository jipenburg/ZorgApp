using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ZorgAppOop
{
    class ZorgApp
    {
        //variabels
        private ProfileList profileList;
        private MedicijnLijst medicijnLijst;
        private Timer timer;

        //constructor. voert automatisch uit na aanroep met "new ZorgApp()".
        public ZorgApp()
        {
            profileList = new ProfileList();
            medicijnLijst = new MedicijnLijst();
            timer = new Timer(new TimerCallback(Alarm));
            timer.Change(1000, 0);
            DisplayMenu();
        }
        
        //methods
        //check in List met foreach zoekend op id match en change de data
        public void EditPatient(int editId)
        {
            
            Console.WriteLine("Wat wil je bewerken? (1, 2, 3, 4, 5)");
            string choice = Console.ReadLine();



            //profileList.profileList = List<Profile>
            //var value = Profile
            foreach (var value in profileList.profileList)
            {
                if (value.GetId() == editId) 
                {
                    switch (choice)
                    {
                        case "1":
                            value.SetVoornaam(Console.ReadLine());
                        break;
                        case "2":
                            value.SetAchternaam(Console.ReadLine());
                            break;
                        case "3":
                            value.SetLeeftijd(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case "4":
                            value.SetGewicht(Convert.ToDouble(Console.ReadLine()));
                            break;
                        case "5":
                            value.SetLengte(Convert.ToDouble(Console.ReadLine()));
                            break;
                    }
                }

            }
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            
            Menu:
            Console.Clear();
            Console.WriteLine("Welkom in het menu");
            Console.WriteLine($"Het is vandaag: {DateTime.Now}\n");
            Console.WriteLine($"Maak een keuze: \n1)Zoeken en bewerken patientgegevens.");
            Alarm(DateTime.Now.AddSeconds(10));
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Zoek op:");
                var searchValue = Console.ReadLine();
                var match = SearchPatient(searchValue, out Profile classTypeOut);
                if (match == true)
                {
                    Console.Clear();
                    Console.WriteLine(ProfileToString(classTypeOut));
                    Console.WriteLine("Wat wil iets bewerken? (y/n)");
                    var yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y")
                    {
                        Console.Clear();
                        Console.WriteLine(ProfileToString(classTypeOut));
                        EditPatient(classTypeOut.GetId());
                    }
                    else 
                    { 
                      BeepNoise();
                      goto Menu;
                    }
                }
                else 
                {
                    BeepNoise();
                    goto Menu;
                }
            }
            else
            {
                BeepNoise();
                goto Menu;
            }

        }


        // Profile gezochtePatient = zorgApp.ZoekPatient("Frank");
        //void: deze methode returned geen waarde
        //SearchPatient: vergelijkt seachValue met classType.Property van profileList.profileList
        public bool SearchPatient(string searchValue, out Profile classTypeOut) 
        {
            //string searchValue = "Ipenburg"

            foreach (Profile classType in profileList.profileList)
            {
                if (classType.GetVoornaam() == searchValue || 
                    classType.GetAchternaam() == searchValue || 
                    classType.GetLeeftijd().ToString() == searchValue ||
                    classType.GetGewicht().ToString() == searchValue ||
                    classType.GetLengte().ToString() == searchValue) 
                {
                  classTypeOut = classType;
                  return true;
                } 

            }
            classTypeOut = null;
            return false;
        }
        //return de waardes van gevonden profiel zien in een string
        public string ProfileToString(Profile profile) 
        {
            string profileData = $"1) Voornaam: {profile.GetVoornaam()}\n2) Achternaam: {profile.GetAchternaam()}\n3) Leeftijd: {profile.GetLeeftijd()}\n4) Gewicht {profile.GetGewicht()}\n5) Lengte: {profile.GetLengte()}";             
            int[] profileMedicijnIdArray = profile.GetMedicijnId();//GetMedicijnIdArray van de gezochte profile
            string medicijnData = string.Empty;//local var die leeg is
            foreach (int profileMedicijnId in profileMedicijnIdArray)
	        {
                //object van class MedicijnLijst medicijnLijst
                //List<Medicijn> medicijnLijst
                int medicijnIndex = medicijnLijst.medicijnLijst.FindIndex(objectMedicijn => objectMedicijn.GetMedicijnId() == profileMedicijnId);
                Medicijn medicijn = medicijnLijst.medicijnLijst[medicijnIndex];
                medicijnData += $"\n\n{medicijn.GetMedicijnNaam()}\n{medicijn.GetOmschrijving()}\n{medicijn.GetSoort()}\n{medicijn.GetDosering()}";

            }
            
            return profileData + medicijnData;

        }


        //beeps by joel (c)
        public void BeepNoise()
        {
            Console.Beep();
            Console.Beep();
        }

        public void Alarm(object state) 
        { 
            if (DateTime.Compare(DateTime.Now, DateTime.Now.AddSeconds(10)) > 0) 
            {
                Console.WriteLine("Het is tijd om uw medicijn {medicijnNaam} in te nemen.");
                Timer t = (Timer)state;
                t.Dispose();
            }
        }
    }
}
