﻿namespace SdetBootcampDay2.TestObjects.Exercises
{
    public interface IPayInterface
    {
        bool PayFor(OrderItem item, int quantity); 
    }

    public class PaymentProcessor: IPayInterface
    {
        private readonly PaymentProcessorType paymentProcessorType;

        public PaymentProcessor(PaymentProcessorType paymentProcessorType)
        {
            this.paymentProcessorType = paymentProcessorType;
        }

        bool IPayInterface.PayFor(Exercises.OrderItem item, int quantity)
        {
            // With Stripe, you can pay for every order.
            if (this.paymentProcessorType.Equals(PaymentProcessorType.Stripe))
            {
                return true;
            }

            // You can use PayPal only when ordering 5 items or less.
            return quantity <= 5;
        }
    }
}