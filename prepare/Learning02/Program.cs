using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization; 

class Program{
    static void Main(string[] args){
        Job job1 = new Job();
        Job job2 = new Job();
        job1._job_title = "Pest profesional";
        job2._job_title = "Cashier";
        job1._company = "Western pest control";
        job2._company = "Dairy Queen";
        job1._start_year = 2019;
        job1._end_year = 2021;
        job2._start_year = 2021;
        job2._end_year = 2022;
        Resume resume1 = new Resume();
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1._person_name = "Lincoln Beatty";
        resume1.display_resume();
    }
    
}