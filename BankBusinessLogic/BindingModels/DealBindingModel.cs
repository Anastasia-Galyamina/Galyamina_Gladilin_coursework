using BankBusinessLogic.Enums;
using System;

namespace BankBusinessLogic.BindingModels
{
    public class DealBindingModel
    {
        public int? Id { get; set; }
        public int CreditId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public DealStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
