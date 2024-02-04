namespace Leif_Gym_Manager.Models
{
    public class DashboardModel
    {
        
        public List<Dashchart> charts { get; set; }
        public List<string> visislog_checkin_in_Timie_100 { get; set; }
        public List<string> visislog_checkin_in_date_100 { get; set; }
        public List<string> visislog_checkin_in_Timie_150 { get; set; }
        public List<string> visislog_checkin_in_date_150 { get; set; }
    }
    public class Dashchart
    {
        public string Y { get; set; }
        public string X { get; set; }
    }
}
