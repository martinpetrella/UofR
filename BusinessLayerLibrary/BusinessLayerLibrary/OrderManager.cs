namespace BusinessLayerLibrary
{
    public class OrderManager
    {
        private Order? _order;

        public OrderManager()
        {
            Orders = new List<Order>();
        }

        public void StartOrder(string customerName, DateTime orderTime, DateTime pickupTime)
        {
            _order = new Order(customerName, orderTime, pickupTime);
        }

        public void AddCookies(int numberOfDozen, params string[] mixIns)
        {
            if (_order != null)
            {
                _order.AddCookies(numberOfDozen, new List<string>(mixIns));
            }
        }

        public void EndOrder()
        {
            if (_order != null)
            {
                Orders.Add(_order);
            }
        }

        public List<Order> Orders { get; private set; }

        public List<string> Customers
        {
            get
            {
                List<string> customers = new List<string>();

                foreach(Order order in Orders)
                {
                    if (!customers.Contains(order.CustomerName))
                    {
                        customers.Add(order.CustomerName);
                    }
                }

                return customers;
            }
        }
    }
}
