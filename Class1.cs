using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment6.Interface;
using Assignment6.Repository;

namespace Assignment6
{
    public class Class1
    {
        static void Main()
        {
            IProcessPerson personRepoObj = new PersonRepository();

            DateTime DOB = new DateTime(1997, 06, 23);

            

            string FirstName = "Sathesh";
            string LastName = "Rangasamy";
            string EmailAddress = "sathesh.r@vernal.is";
            double DateofBirth = DOB.ToOADate();

            
            //adding New Person
            Console.WriteLine(personRepoObj.Add(new Entities.Person { FirstName = FirstName, LastName=LastName, EmailAddress=EmailAddress, DateofBirth=DateofBirth+1000 }));
            Console.WriteLine(personRepoObj.Add(new Entities.Person { FirstName = FirstName, LastName = LastName, EmailAddress = "sathesh@vernal.is", DateofBirth = DateofBirth }));

            Console.WriteLine(personRepoObj.Add(new Entities.Person { FirstName = "Harish", LastName = "Ramesh", EmailAddress = "harish@vernal.is", DateofBirth = DateofBirth }));


            //Console.WriteLine(personRepoObj.Delete(new Entities.Person { FirstName = FirstName, LastName = LastName, EmailAddress = EmailAddress, DateofBirth = DateofBirth }));
            Console.WriteLine(personRepoObj.Delete(new Entities.Person { FirstName = "Harish", LastName = "Ramesh", EmailAddress = "harish@vernal.is", DateofBirth = DateofBirth }));

            var userList = personRepoObj.GetAll();

            if(userList.Count>0)
            {
                foreach(var o in userList)
                {
                    Console.WriteLine("{0},{1},{2},{3}", o.FirstName, o.LastName, o.EmailAddress, DateTime.FromOADate(o.DateofBirth).ToShortDateString());
                }
            }
            else
            {
                Console.WriteLine("No User Details Available");
            }

            Console.WriteLine("\n-----------Fetching user details with the name Sathesh Rangasamy-----------\n");
            var nameList = personRepoObj.GetByName("Sathesh Rangasamy");
            if (nameList.Count > 0)
            {
                foreach (var o in userList)
                {
                    Console.WriteLine("{0},{1},{2},{3}", o.FirstName, o.LastName, o.EmailAddress, DateTime.FromOADate(o.DateofBirth).ToShortDateString());
                }
            }
            else
            {
                Console.WriteLine("No User Details Available");
            }

            Console.WriteLine("\n-----------Fetching min age for the name Sathesh Rangasamy-----------\n");

            int age = personRepoObj.GetMinimumAge("Sathesh Rangasamy");

            if(age!=-1)
            {
                Console.WriteLine(age);
            }
            else
            {
                Console.WriteLine("No User Details Available for the given name");
            }

            Console.Read();
        }
    }
}
