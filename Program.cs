using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_millionaires
{

        public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class Bank
    {
        public string Name {get; set;}
        public string Symbol {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
             List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=48723344.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

        List<Bank> bankNames = new List<Bank>()
        {
            new Bank(){Name="Bank of America", Symbol="BOA"},
            new Bank(){Name="Wells Fargo", Symbol="WF"},
            new Bank(){Name="CitiBank", Symbol="CITI"},
            new Bank(){Name="First Tennessee", Symbol="FTB"}, 
        };

        List<Customer> reportList = customers.Where(person => person.Balance >= 1000000).Select(
            customer => new Customer()
            {
                Name = customer.Name,
                Bank = bankNames.Find(bank => bank.Symbol == customer.Bank).Name,
                Balance = customer.Balance,
            }
        ).ToList();

        foreach (Customer customer in reportList)
        {
            System.Console.WriteLine($"{customer.Name} is a millionaire with all their money in {customer.Bank}");
        }


        // var test = customers.Where(person => person.Balance >= 1000000).GroupBy(
        //     person => person.Bank, 
        //     person => person.Name,
        //     (bank, millionaires) => new
        //         {
        //             Bank = bank,
        //             Millionaires = millionaires
        //         }
        //     ).ToList();

        //     foreach (var item in test)
        //     {
        //         System.Console.WriteLine($"{item.Bank}: {String.Join(", ", item.Millionaires)}");
        //     }

        

        // List<Customer> millionairesAgain = (from people in customers
        //     where people.Balance >= 1000000.00
        //     select people).ToList();

        // Dictionary<string, int> milsPerBank = new Dictionary<string, int>();
        // foreach (Customer person in millionairesAgain)
        // {
        //     if (milsPerBank.ContainsKey(person.Bank))
        //     {
        //         milsPerBank[person.Bank] += 1;
        //     }
        //     else
        //     {
        //         milsPerBank[person.Bank] = 1;
        //     }
        // }

        // foreach (KeyValuePair<string, int> keypair in milsPerBank)
        // {
        //     System.Console.WriteLine($"{keypair.Key}: {keypair.Value}");
        // }

        }
    }
}
