using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        Console.WriteLine("Ohm");
        List<int> numbers = new List<int> { 1, 5, 7, 5, 5, 9, 7, 9, 5, 7, 7, 9, 9, 9 };

        int mostFrequentNumber = FindMostRecentNumbers(numbers);
        Console.WriteLine($"Most Frequent Number: {mostFrequentNumber}");

        string text =  "God Flower plant plant plant flower" ;
        List<string> words = text.Split(' ').ToList();
        var mostTop3FrequentWords = FindTop3FrequentWords(words,3);
        
        Console.WriteLine("\n Top3 Most frequent Words");
        foreach ( var item in mostTop3FrequentWords)
        {
            Console.WriteLine($"{item.Word} : {item.Count}");
        }


        List<Emloyee> employees = new List<Emloyee>
        {
            new Emloyee { EmployeeName="Mohana", salary = 3000 },
            new Emloyee { EmployeeName="Ramesh", salary = 9000 },
            new Emloyee { EmployeeName="Lukesh", salary = 10000 },
            new Emloyee { EmployeeName="Paul", salary = 7000 },
            new Emloyee { EmployeeName="Harry", salary = 1500 }
        };    
     

        var listOfEmployeesEarnindAboveAverageSalary = FindListOfEmployeesEarnindAboveAverageSalary(employees);
        Console.WriteLine("listEmployeesabove average salary: "+ string.Join(", ", listOfEmployeesEarnindAboveAverageSalary));
    }

    static List<string> FindListOfEmployeesEarnindAboveAverageSalary(List<Emloyee> employees)
    {
        double aveSalary = employees.Average(e => e.salary);
        Console.WriteLine("Average Salary", aveSalary);
        var aboveAverageEmplyees =  employees.Where(e => e.salary > aveSalary).Select(e => e.EmployeeName).ToList();
        return aboveAverageEmplyees;

    }


    static int FindMostRecentNumbers(List<int> numbers)
    {
        
        return numbers
                                   .GroupBy(n => n)
                                   .OrderByDescending(g => g.Count())
                                   .First()
                                   .Key;
    }

    static List<(string Word, int Count)> FindTop3FrequentWords(List<string> words, int topN)
    {
        return words
            .GroupBy(w => w)
            .OrderByDescending(g => g.Count())
            .Take(topN)
            .Select(g => (Word: g.Key , Count: g.Count()))
            .ToList();
    }


}

class Emloyee
{
    public string EmployeeName { get; set; }
    public int salary { get; set; }
}
