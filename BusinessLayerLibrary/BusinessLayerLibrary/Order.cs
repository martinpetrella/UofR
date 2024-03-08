namespace BusinessLayerLibrary
{
    /// <summary>
    /// Class to manage order details
    /// An oder contains the customer name, order date, and pick-up date along
    /// with an arbitrary number of "batches" of cookies. Each batch must be
    /// in multiple number of dozen cookies with a fixed list of mix-ins.
    /// </summary>
    public class Order
    {
        public Order(string customerName, DateTime orderDateTime, DateTime pickupDateTime)
        {
            Cookies = new List<CookieDetails>();
            CustomerName = customerName;
            OrderDateTime = orderDateTime;
            PickupDateTime = pickupDateTime;
        }

        public string CustomerName { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime PickupDateTime { get; set; }
        public List<CookieDetails> Cookies { get; set; }
        
        /// <summary>
        /// Add cookies to order.
        /// </summary>
        /// <param name="numberOfDozen">The number of dozen cookies</param>
        /// <param name="mixIns">List of mix-ins for this batch of cookies</param>
        public void AddCookies(int numberOfDozen, List<string> mixIns)
        {
            Cookies.Add(new CookieDetails(numberOfDozen, mixIns));
        }
    }

    public class CookieDetails
    {
        public int NumberOfDozen { get; set; }
        public List<string> MixIns { get; set; }

        public CookieDetails(int numberOfDozen, List<string> mixIns)
        {
            NumberOfDozen = numberOfDozen;
            MixIns = mixIns;
        }
    }
}
