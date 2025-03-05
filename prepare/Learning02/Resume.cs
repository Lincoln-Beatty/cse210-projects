
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