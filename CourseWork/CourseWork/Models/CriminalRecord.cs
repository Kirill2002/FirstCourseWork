using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    [Serializable]
    public class CriminalRecord : Record
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Height { get; set; }

        public string HairColor { get; set; }

        public string EyeColor { get; set; }

        public string DistinctiveFeatures { get; set; }

        public string Citizenship { get; set; }

        public string BirthPlace { get; set; }

        public string BirthDate { get; set; }

        public string LastDomicile { get; set; }

        public string CriminalSpecialization { get; set; }

        public string LastCase { get; set; }

        public string Languages { get; set; }

        public string AdditionalInfo { get; set; }

        public string Image { get; set; }

        public string IDstring
        {
            get
            {
                return Convert.ToString(ID);
            }
        }

        public CriminalRecord(string firstName = "",
            string lastName = "", string nickName = "",
            string height = "", string hairColor = "",
            string eyeColor = "", string distinctiveFeatures = "",
            string citizenShip = "", string birthPlace = "",
            string birthDate = "", string lastDomicile = "",
            string criminalSpecialization = "", string lastCase = "",
            string languages = "", string image = ""
            )
        {
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            Height = height;
            HairColor = hairColor;
            EyeColor = eyeColor;
            DistinctiveFeatures = distinctiveFeatures;
            Citizenship = citizenShip;
            BirthPlace = birthPlace;
            BirthDate = birthDate;
            LastDomicile = lastDomicile;
            CriminalSpecialization = criminalSpecialization;
            LastCase = lastCase;
            Languages = languages;
            Image = image;

        }

        public string this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return IDstring;
                    case 1:
                        return FirstName;
                    case 2:
                        return LastName;
                    case 3:
                        return NickName;
                    case 4:
                        return Height;
                    case 5:
                        return HairColor;
                    case 6:
                        return EyeColor;
                    case 7:
                        return DistinctiveFeatures;
                    case 8:
                        return Citizenship;
                    case 9:
                        return BirthPlace;
                    case 10:
                        return BirthDate;
                    case 11:
                        return LastDomicile;
                    case 12:
                        return CriminalSpecialization;
                    case 13:
                        return LastCase;
                    case 14:
                        return Languages;


                }
                return "Error";
            }

            set
            {

            }
        }

        //public bool Equals(CriminalRecord other)
        //{
        //    for (int i = 0; i < 15; ++i)
        //        if (other[i] != this[i])
        //            return false;
        //    return true;
        //}
        public static List<string> ListOfProperties
        {
            get
            {
                List<string> res = new List<string> {"ID", "Ім'я", "Прізвище", "Прізвисько",
                    "Зріст", "Колір волосся", "Колір очей", "Особливі прикмети",
                    "Громадянство", "Місце народження", "Дата народження",
                    "Останнє місце проживання", "Кримінальна професія", "Остання справа",
                    "Мови"};
                return res;
            }
        }



    }
}
