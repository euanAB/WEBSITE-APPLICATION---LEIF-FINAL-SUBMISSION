namespace Leif_Gym_Manager.Models
{
    public class CheckInOuts
    {
        public string FobNumber { get; set; } = null!;

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }


        public List<CheckInOutsList> check_IN_OUT { get; set; }
    }


    public class CheckInOutsList
    {
        public string FobNumber { get; set; } = null!;

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
