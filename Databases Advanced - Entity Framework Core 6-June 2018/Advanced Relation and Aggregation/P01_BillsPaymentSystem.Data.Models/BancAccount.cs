namespace P01_BillsPaymentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Attributes;

    public class BancAccount : IEntity
    {
        [Key]
        public int BankAccountId { get; set; }

        [DataType("decimal(16,4)")]
        public decimal Balance { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string BankName { get; set; }//(up to 50 characters, unicode)

        [Required]
        [NonUnicode]
        public string SWIFT { get; set; }//(up to 20 characters, non-unicode)

        public PaymentMethod PaymentMethod { get; set; }

    }
}
