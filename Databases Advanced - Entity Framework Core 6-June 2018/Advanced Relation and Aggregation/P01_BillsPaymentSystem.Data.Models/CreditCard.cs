namespace P01_BillsPaymentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   
    public class CreditCard:IEntity
    {
        [Key]
        public int CreditCardId { get; set; }

        [DataType("decimal(16 ,4")]
        public decimal Limit { get; set; }

        [DataType("decimal(16 ,4")]
        public decimal MoneyOwed { get; set; }

        [DataType("decimal(16 ,3")]
        [NotMapped]
        public decimal LimitLeft => this.Limit-this.MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

    }
}
