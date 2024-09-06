using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Domain.Shared
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new(
            "ValidationError",
            "A validation problem occurred.");

        Error[] Errors { get; }
    }
}
