using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Miniproject
{
    public class Complaints
    {
        public string DateReceived { get; set; }
        public string Product { get; set; }
        public string SubProduct { get; set; }
        public string Issue { get; set; }
        public string Subissue { get; set; }
        public string Company { get; set; }
        public string State { get; set; }
        public string ZIPcode { get; set; }
        public string Submittedvia { get; set; }
        public string DateSentToCompany { get; set; }
        public string CompanyResponseToCustomer { get; set; }
        public string TimelyResponse { get; set; }
        public string CustomerDisputed { get; set; }
        public string Complaintid { get; set; }




    }
    public class methods
    {
        public static IEnumerable<Complaints> GetComplaintsForYear(List<Complaints> ComplaintsList, string Year)
        {
            var A = from s in ComplaintsList
                    where s.DateReceived.Contains(Year)
                    select s;
            return A;
        }

        public static IEnumerable<Complaints> GetComplaintsForName(List<Complaints> ComplaintsList, string BankName)
        {
            var A = from s in ComplaintsList
                    where s.Company == BankName
                    select s;
            return A;
        }

        public static IEnumerable<Complaints> GetComplaintsForComplaintid(List<Complaints> ComplaintsList, string Complaintid)
        {
            var A = from s in ComplaintsList
                    where s.Complaintid == Complaintid
                    select s;
            return A;
        }

        public static IEnumerable<string> NumberofDays(List<Complaints> ComplaintsList, string Complaintid)
        {
            var A = from s in ComplaintsList
                    where s.Complaintid == Complaintid
                    select s.DateSentToCompany;

            var B = from s in ComplaintsList
                    where s.Complaintid == Complaintid
                    select s.DateSentToCompany;
            return A;
        }

        public static IEnumerable<Complaints> GetComplaintsForExplanation(List<Complaints> ComplaintsList)
        {
            var A = from s in ComplaintsList
                    where s.CompanyResponseToCustomer == "Closed with Explanation" || s.CompanyResponseToCustomer == "Closed"
                    select s;
            return A;
        }

        public static IEnumerable<Complaints> GetComplaintsForTimelyResponse(List<Complaints> ComplaintsList)
        {
            var A = from s in ComplaintsList
                    where s.TimelyResponse == "Yes"
                    select s;
            return A;
        }

    }

    public class Solution
    {
        static void Main()
        {
            List<Complaints> ComplaintsList = new List<Complaints>();
            var Complaints = File.ReadAllLines(@"C:\C#Assign\MiniProject\Complaints.csv");
            var matrix = from item in Complaints
                         let data = item.Split(',')
                         select new Complaints()
                         {
                             DateReceived = data[0],
                             Product = data[1],
                             SubProduct = data[2],
                             Issue = data[3],
                             Subissue = data[4],
                             Company = data[5],
                             State = data[6],
                             ZIPcode = data[7],
                             Submittedvia = data[8],
                             DateSentToCompany = data[9],
                             CompanyResponseToCustomer = data[10],
                             TimelyResponse = data[11],
                             CustomerDisputed = data[12],
                             Complaintid = data[13]

                         };
            var ComplaintList = matrix.ToList();
            int option;

            Console.WriteLine("Welcome to the page of Complaints");
            Console.WriteLine("Press the given button to choose");

            Console.WriteLine(" Select 1 to Display all the Complaints based on Year");
            Console.WriteLine("Select 2 to Display all the Complaints based on Name of Bank");
            Console.WriteLine("Select 3 to Display all the Complaints based on Complaintid");
            Console.WriteLine("Select 4 to Display no of days took by Bank to close the Complaint");
            Console.WriteLine("Select 5 to Display all the Complaints Closed with Explanation/Closed");
            Console.WriteLine("Select 6 to Display all the Complaints which received a TimelyResponse");
            Console.WriteLine("Select 7 if you have any new Complaints");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter the year");
                    string Year = Console.ReadLine();
                    var ListDateReceived = methods.GetComplaintsForYear(ComplaintList, Year);
                    foreach (var L in ListDateReceived)
                    {
                        Console.WriteLine(L.DateReceived + " " + L.Product + " " + L.SubProduct + " " + L.Issue + " " + L.Subissue + " " +
                                           L.Company + " " + L.State + " " + L.ZIPcode + " " + L.Submittedvia + " " + L.DateSentToCompany + " " +
                                           L.CompanyResponseToCustomer + " " + L.TimelyResponse + " " + L.CustomerDisputed + " " + L.Complaintid);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the BankName");
                    string BankName = Console.ReadLine();
                    var ListBankName = methods.GetComplaintsForYear(ComplaintList, BankName);
                    foreach (var L in ListBankName)
                    {
                        Console.WriteLine(L.DateReceived + " " + L.Product + " " + L.SubProduct + " " + L.Issue + " " + L.Subissue + " " +
                                           L.Company + " " + L.State + " " + L.ZIPcode + " " + L.Submittedvia + " " + L.DateSentToCompany + " " +
                                           L.CompanyResponseToCustomer + " " + L.TimelyResponse + " " + L.CustomerDisputed + " " + L.Complaintid);
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the Complaintid");
                    string Complaintid = Console.ReadLine();
                    var ListCid = methods.GetComplaintsForYear(ComplaintList, Complaintid);
                    foreach (var L in ListCid)
                    {
                        Console.WriteLine(L.DateReceived + " " + L.Product + " " + L.SubProduct + " " + L.Issue + " " + L.Subissue + " " +
                                           L.Company + " " + L.State + " " + L.ZIPcode + " " + L.Submittedvia + " " + L.DateSentToCompany + " " +
                                           L.CompanyResponseToCustomer + " " + L.TimelyResponse + " " + L.CustomerDisputed + " " + L.Complaintid);
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the Complaintid");
                    string Complaintid1 = Console.ReadLine();
                    var ListCid1 = methods.GetComplaintsForYear(ComplaintList, Complaintid1);
                    foreach (var L in ListCid1)
                    {
                        Console.WriteLine(L.DateReceived + " " + L.Product + " " + L.SubProduct + " " + L.Issue + " " + L.Subissue + " " +
                                           L.Company + " " + L.State + " " + L.ZIPcode + " " + L.Submittedvia + " " + L.DateSentToCompany + " " +
                                           L.CompanyResponseToCustomer + " " + L.TimelyResponse + " " + L.CustomerDisputed + " " + L.Complaintid);
                    }
                    break;
                case 5:
                    var ListResponse = methods.GetComplaintsForExplanation(ComplaintList);


                    foreach (var L in ListResponse)
                    {
                        Console.WriteLine(L.DateReceived + " " + L.Product + " " + L.SubProduct + " " + L.Issue + " " + L.Subissue + " " +
                                           L.Company + " " + L.State + " " + L.ZIPcode + " " + L.Submittedvia + " " + L.DateSentToCompany + " " +
                                           L.CompanyResponseToCustomer + " " + L.TimelyResponse + " " + L.CustomerDisputed + " " + L.Complaintid);
                    }
                    break;
                case 6:


                    var TimelyResponse = methods.GetComplaintsForTimelyResponse(ComplaintList);
                    foreach (var L in TimelyResponse)
                    {
                        Console.WriteLine(L.DateReceived + " " + L.Product + " " + L.SubProduct + " " + L.Issue + " " + L.Subissue + " " +
                                           L.Company + " " + L.State + " " + L.ZIPcode + " " + L.Submittedvia + " " + L.DateSentToCompany + " " +
                                           L.CompanyResponseToCustomer + " " + L.TimelyResponse + " " + L.CustomerDisputed + " " + L.Complaintid);
                    }
                    break;
                case 7:
                    Console.WriteLine("Enter your Complaints");

                    break;

                default:

                    Console.WriteLine("Please choose valid option");
                    break;

            }

            Console.Read();


        }

    }

}                
            










        
            
    



    

    


