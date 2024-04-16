﻿using EDA.Messages.PurchaseOrders;
using MassTransit;

namespace EDA.Consumer3.Handlers
{
    public class PlaceOrderHandler : IConsumer<PlaceOrder>
    {
        public Task Consume(ConsumeContext<PlaceOrder> context)
        {
            Console.WriteLine("Message Received");
            Console.WriteLine("----------------------------");
            return Task.CompletedTask;
        }
    }
}
