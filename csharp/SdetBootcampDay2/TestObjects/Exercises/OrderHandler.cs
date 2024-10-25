namespace SdetBootcampDay2.TestObjects.Exercises
{
    public class OrderHandler
    {
        private IDictionary<OrderItem, int>? stock = new Dictionary<OrderItem, int>();
        public IPayInterface paymentProcessor;

        /**
         * TODO: can you apply Dependency Inversion here to make this code more flexible,
         * allowing users to inject the stock, and thereby make the code easier to test?
         * Do the same for the PaymentProcessor. You do not need to create interfaces as
         * was shown in the example (although if you want to, be my guest!)
         * After you have done that, update the existing tests and add the tests that were
         * not possible before.
         */
        public OrderHandler(IDictionary<OrderItem, int> Inventory, IPayInterface PayProc)
        {
            this.stock = Inventory;
            this.paymentProcessor = PayProc;
        }

        /**
         * TODO: this method clearly violates the Single Responsibility Principle
         * Can you refactor the code to resolve that? Don't forget to also update the tests.
         */
        public bool RequestPurchase(OrderItem item, int quantity)
        {
            Check_ItemExist(item);

            Check_ItemAvailable(item, quantity); 

            if(!this.paymentProcessor.PayFor(item, quantity))
                return false;

            return ReduceStock(item, quantity); 
        }

        public void Check_ItemExist(OrderItem item)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }
        }

        public void Check_ItemAvailable(OrderItem item, int quantity)
        {
            Check_ItemExist(item);

            if (this.stock[item] < quantity)
            {
                throw new ArgumentException($"Insufficient stock for item {item}");
            }
        }

        public bool ReduceStock(OrderItem item, int quantity)
        {
            Check_ItemExist(item);

            Check_ItemAvailable(item, quantity); 

            var temp = this.stock[item];

            this.stock[item] -= quantity;

            if(this.stock[item] == temp - quantity)
                return true;
            
            return false;
        }

        public void AddStock(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            this.stock[item] += quantity;
        }

        public int GetStockFor(OrderItem item)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            return this.stock[item]; 
        }
    }
}
