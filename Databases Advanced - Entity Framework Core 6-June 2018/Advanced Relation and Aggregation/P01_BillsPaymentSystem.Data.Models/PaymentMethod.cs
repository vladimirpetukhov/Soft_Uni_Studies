namespace P01_BillsPaymentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Attributes;
    using Enums;

    public class PaymentMethod:IEntity
    {
        [Key]
        public int Id { get; set; }

        public PaymentTypes Type { get; set; } //– enum (BankAccount, CreditCard)

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("BancAccount")]
        [Xor(nameof(CreditCardId))]
        public int? BankAccountId { get; set; }
        public BancAccount BancAccount { get; set; }

        [ForeignKey("CreditCard")]
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

    }
}
