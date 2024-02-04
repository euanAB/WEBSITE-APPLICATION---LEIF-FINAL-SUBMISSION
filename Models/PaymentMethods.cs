namespace Leif_Gym_Manager.Models
{
    public class PaymentMethodss
    {
        public int PaymentMethodsId { get; set; }

        public string PaymentMethods1 { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
