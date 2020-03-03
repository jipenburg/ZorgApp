using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ZorgAppOop
{
    class ZorgApp
    {   //test
        //variabels fields
        private ProfileList profileList;
        private MedicijnLijst medicijnLijst;
        private Timer timer;
        private DateTime dateTimeLater;

        //constructor. voert automatisch uit na aanroep met "new ZorgApp()".
        public ZorgApp()
        {
            profileList = new ProfileList();
            medicijnLijst = new MedicijnLijst();
            StartTimer();
            DisplayMenu();
        }

        //methods
        private void StartTimer()
        {
            dateTimeLater = DateTime.Now.AddSeconds(5);
            timer = new Timer(new TimerCallback(Alarm));
            timer.Change(2000, 1000);
        }


        /*EditPatient Method: zoek naar profile in profileList matchend op id
         * en edit vervolgens de data van gezochte profile.*/
        private void EditPatient(int editId)
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

        //DisplayMenu Method: blijft altijd draaien in de console. via het menu kan je de zorgapp bedienen.
        private void DisplayMenu()
        {
            
            Menu:
            Console.Clear();
            Console.WriteLine("Welkom in het menu");
            Console.WriteLine($"Het is vandaag: {DateTime.Now}\n");
            Console.WriteLine($"Maak een keuze: \n1)Zoeken en bewerken patientgegevens.");
            Console.WriteLine($"2)Patientenlijst tonen. ");
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
                    Console.WriteLine("Wil je iets bewerken? (y/n)");
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
            else if (choice == "2")
            {
                Console.Clear();
                ShowAllProfiles();
                

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
        private bool SearchPatient(string searchValue, out Profile profileOut) 
        {
            //string searchValue = "Ipenburg"

            foreach (Profile profile in profileList.profileList)
            {
                if (profile.GetVoornaam() == searchValue || 
                    profile.GetAchternaam() == searchValue || 
                    profile.GetLeeftijd().ToString() == searchValue ||
                    profile.GetGewicht().ToString() == searchValue ||
                    profile.GetLengte().ToString() == searchValue) 
                {
                    profileOut = profile;
                    return true;
                } 

            }
            profileOut = null;
            return false;
        }
        //return de waardes van gevonden profiel zien in een string
        private string ProfileToString(Profile profile) 
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
                medicijnData += $"\n\n{medicijn.GetMedicijnNaam()}\nOmschrijving: {medicijn.GetOmschrijving()}\nSoort: {medicijn.GetSoort()}\nDosering: {medicijn.GetDosering()}";

            }
            
            return profileData + medicijnData;

        }


        //beeps by joel (c)
        private void BeepNoise()
        {
            Console.Beep();
            Console.Beep();
        }

        private void Alarm(object timerObject)
        {
            foreach (Medicijn value in medicijnLijst.medicijnLijst)
            {
                if (DateTime.Compare(DateTime.Now, value.GetDagelijkseMedicatie()) > 0)
                {
                    Console.WriteLine($"\nHet is: {DateTime.Now}\nTijd om uw medicijn {value.GetMedicijnNaam()} in te nemen.");
                    BeepNoise();
                    Timer t = (Timer)timerObject;
                    t.Dispose();
                    Console.WriteLine("Druk op enter om terug naar het menu te gaan...");
                    Console.ReadKey();
                    return;
                }

            }
        }
        private void ShowAllProfiles()
        {
            foreach (Profile profile in profileList.profileList)
            {
                Console.WriteLine($"{profile.GetVoornaam()}{profile.GetAchternaam()}");

            }
        }
    }
}
