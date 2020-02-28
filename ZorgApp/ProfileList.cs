using System;
using System.Collections.Generic;
using System.Text;

namespace ZorgAppOop
{
    class ProfileList
    {
        //new ProfileList();
        //class zorgapp: EditProfile();
        public List<Profile> profileList { get; private set; }
        /*profileList Object #foreach number 1
            I=>profileList type of List<Profile> #foreach number 1
                    I=> Profile type of Class #foreach number 1
                            I=> VoorNaam type of String #foreach number 2
                                      I=> "Frank" type of value
        */

        //new Profile(int profileId, array medicijnId, string voornaam, string achternaam, int leeftijd, double gewicht, double lengte)
        public ProfileList() 
        {
            profileList = new List<Profile>();
            profileList.Add(new Profile(1, new int[] {3 , 4}, "Frank", "Krijnen", 26, 65.15, 1.80));
            profileList.Add(new Profile(2, new int[] {1 , 2 , 3},"Joel", "Ipenburg", 27, 83.64, 1.88));
        }
       

    }
}
