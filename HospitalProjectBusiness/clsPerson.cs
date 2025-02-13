using HospitalProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectBusiness
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {SecondName} {ThirdName} {LastName}";

        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; } // تم تصحيح خطأ الكتابة من "Gendor" إلى "Gender"
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
       // public clsCountry CountryInfo { get; private set; }

       // public clsPatient PatientInfo { get; private set; }

        //public clsDoctor DoctorInfo { get; private set; }

        public string ImagePath { get; set; } = string.Empty;
        private clsCountry _countryInfo;
        public clsCountry CountryInfo
        {
            get
            {
                if (_countryInfo == null)
                {
                    _countryInfo = clsCountry.Find(NationalityCountryID);
                }
                return _countryInfo;
            }
        }

        //private clsDoctor _doctorInfo;
        //public clsDoctor DoctorInfo
        //{
        //    get
        //    {
        //        if (_doctorInfo == null)
        //        {
        //            _doctorInfo = clsDoctor.GetDoctorInfoByPatientPersonID(PersonID);
        //        }
        //        return _doctorInfo;
        //    }
        //}



        public clsPerson()
        {

            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }


        private clsPerson(int PersonID, string FirstName, string SecondName, string ThirdName,
                    string LastName, string NationalNo, DateTime DateOfBirth, byte Gender,
                     string Address, string Phone, string Email,
                    int NationalityCountryID, string ImagePath)

        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
           // this.CountryInfo = clsCountry.Find(NationalityCountryID);
           // this.DoctorInfo = clsDoctor.GetDoctorInfoByPatientPersonID(PersonID);
          //  this.PatientInfo = clsPatient.GetPatientInfoByPersonID(PersonID);
            Mode = enMode.Update;
        }

        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                return _AddNewPerson();
            }
            else if (Mode == enMode.Update)
            {
                return _UpdatePerson();
            }

            return false;
        }


        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.FirstName, this.SecondName, 
                this.ThirdName,this.LastName, this.NationalNo,  this.DateOfBirth,
                this.Gender, this.Address, this.Phone, this.Email,
                this.NationalityCountryID, this.ImagePath);

            if (PersonID != -1)
            {
                Mode = enMode.Update;
                return true;
            }
            return false;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.FirstName, this.SecondName,this.ThirdName,
                this.LastName, this.NationalNo, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email,
                this.NationalityCountryID, this.ImagePath);
        }

       

        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "",
                NationalNo = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            byte Gender = 0;

            bool IsFound = clsPersonData.GetPersonInfoByID
                                            (
                                                PersonID, ref FirstName, ref SecondName,
                                                ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth,
                                                ref Gender, ref Address, ref Phone, ref Email,
                                                ref NationalityCountryID, ref ImagePath
                                            );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }



        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, NationalityCountryID = -1;
            byte Gender = 0;

            bool IsFound = clsPersonData.GetPersonInfoByNationalNo
                                (
                                    NationalNo, ref PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref DateOfBirth,
                                    ref Gender, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)

                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static DataTable GetPeopleBySelectedColumns(string columns)
        {
            return clsPersonData.GetPeopleBySelectedColumns(columns);
        }


        public static bool DeletePerson(int id)
        {
            return clsPersonData.DeletePerson(id);
        }

        public static bool IsPersonExist(int id)
        {
            return clsPersonData.IsPersonExist(id);
        }

        public static bool IsPersonExist(string nationalNo)
        {
            return clsPersonData.IsPersonExist(nationalNo);
        }
    }

}
