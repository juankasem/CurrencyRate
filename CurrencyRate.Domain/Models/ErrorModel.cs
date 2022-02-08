using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRate.Domain.Models
{
   public class ErrorModel
    {
        public string Message { get; set; }

        public ErrorModel()
        {

        }

        public ErrorModel(string message)
        {
            Message = message;
        }
    }
}
