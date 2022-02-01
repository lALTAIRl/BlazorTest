namespace BlazorTest.Orders.Domain.Entities
{
    using System;
    using BlazorTest.Orders.Domain.Interfaces;

    public class Order : IBaseEntity
    {
        public Guid Id
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public decimal TotalPrice
        {
            get; set;
        }

        public DateTime CreatedDate
        {
            get; set;
        }

        public Guid UserId
        {
            get; set;
        }
    }
}
