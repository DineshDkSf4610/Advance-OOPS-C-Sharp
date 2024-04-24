using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    //Enum Declaration

    public enum Gender { Select, Male, Female, Transgender }
    public class PersonalDetails
    {
        /*
        Name, FatherName, Gender- {Select, Male, Female, Transgender}, Mobile, DOB, MailID, Location
        */

        /// <summary>
        /// This is Name Property. it is store to user name 
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// this is Fathername property. It is store to user FatherName value.
        /// </summary>
        /// <value></value>
        public string FatherName { get; set; }

        /// <summary>
        /// This is Gender Property and data type is Enum . its store to user Gender data.
        /// </summary>
        /// <value></value>
        public Gender Gender { get; set; }

        /// <summary>
        /// This is Mobile Number Property.its store to user mobile number data.
        /// </summary>
        /// <value></value>
        public string Mobile { get; set; }

        /// <summary>
        /// This is DOB Property. 
        /// </summary>
        /// <value></value>

        public DateTime DOB { get; set; }

        public string MailID { get; set; }

        public string Location { get; set; }

        //Constructors

        public PersonalDetails(string name, string fatherName, Gender gender, string mobile, DateTime dob, string mailID, string location)
        {
            //Assigin value
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            DOB = dob;
            MailID = mailID;
            Location = location;
        }

        public PersonalDetails(string student)
        {
            string[] temp = student.Split(',');
            Name = temp[1];
            FatherName = temp[2];
            Gender = Enum.Parse<Gender>(temp[3], true);
            Mobile = temp[4];
            DOB = DateTime.ParseExact(temp[5], "dd/MM/yyyy", null);
            MailID = temp[6];
            Location = temp[7];
        }
    }
}