using System.ComponentModel.DataAnnotations;

namespace BankDataBaseImplement.Models
{
    public class StorageMoney
    {
        public int Id { set; get; }            
        public int MoneyId { set; get; }
        [Required]
        public int Count { set; get; } 
        public decimal? Reserved { set; get; }           
        public virtual Money Money { set; get; }        
    }
}
