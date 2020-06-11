﻿using BankBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BankBusinessLogic.HelperModelsAdmin
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<CreditViewModel> Credits { get; set; }
        public List<RequestViewModel> Requests { get; set; }

    }
}
