using System;
using System.Security.Cryptography.X509Certificates;

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
    public class Resume{
        public string _person_name = "";
        public List<Job> _jobs = new List<Job>();
        public void display_resume(){
            Console.WriteLine($"Name: {_person_name}");
            Console.WriteLine("Jobs:");
            foreach (Job job in _jobs){
                job.display_job_information();
            }
        }
    }
    public class Job{
        public string _company = "";
        public string _job_title = "";
        public int _start_year;
        public int _end_year;
        public void display_job_information(){
            Console.WriteLine($"{_job_title} ({_company}) {_start_year}-{_end_year}");
        }
    }
}