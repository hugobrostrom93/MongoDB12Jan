
namespace ASPNetMongoDB.Models
{
    public class ViewModel
    {
        public string Id { get; set; } = "";
        public string KundId { get; set; } = "";
        public string Namn { get; set; } = "";
        public string Adress { get; set; } = "";
        public string Emailadress { get; set; } = "";
        public string Telefonnummer { get; set; } = "";
        public Kund Kund { get; set; }
        public List<Order> Order { get; set; }

        // För att komma åt både kund och order
        public ViewModel(Kund kund, List<Order> order)
        {
            Kund = kund;
            Order = order;
        }
    }
}
