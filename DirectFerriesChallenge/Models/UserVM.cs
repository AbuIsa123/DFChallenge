using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DirectFerriesChallenge.Models
{
    public class UserVM
    {
        [Required]
        [Display(Name = "Name")]
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public int NoOfVowels { get; set; }
        public int Age { get; set; }
        public int DaysToNextBirthday { get; set; }
        public DateTime[] Dates { get; set; }
        public void GetFirstName()
        {
            var names = FullName.Split(' ');
            FirstName = names[0];
        }
        public void GetNumberOfVowels()
        {
            string myStr;
            int i, len;
            myStr = FirstName;
            NoOfVowels = 0;
            len = myStr.Length;
            for (i = 0; i < len; i++)
            {
                if (myStr[i] == 'a' || myStr[i] == 'e' || myStr[i] == 'i' || myStr[i] == 'o' || myStr[i] == 'u' || myStr[i] == 'A' || myStr[i] == 'E' || myStr[i] == 'I' || myStr[i] == 'O' || myStr[i] == 'U')
                {
                    NoOfVowels++;
                }
            }
        }
        public void GetAge()
        {
            Age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day)) // has not had birthday this year yet
                Age--;
        }

        public void GetDaysTillNextBirthday()
        {
            DateTime today = DateTime.Today;
            DateTime next = DateOfBirth.AddYears(today.Year - DateOfBirth.Year);

            if (next < today)
                next = next.AddYears(1);

            DaysToNextBirthday = (next - today).Days;
        }

        public void GetDates()
        {
            Dates = new DateTime[14];
            DateTime dateStart = DateOfBirth.AddDays(-14);
            int count = 0;

            for (DateTime start = dateStart; dateStart < DateOfBirth; dateStart = dateStart.AddDays(1))
            {
                Dates[count] = dateStart;
                count++;
            }
        }
    }
}