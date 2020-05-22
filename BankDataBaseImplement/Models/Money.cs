using System.ComponentModel.DataAnnotations;

namespace BankDataBaseImplement.Models
{
    public class Money
    {
        public int Id { get; set; }

        [Required] 
        public string currency { get; set; }  
    }
}
