using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message)
			: base(success: true, message)
		{
		}

		public SuccessResult()
			: base(success: true)
		{
		}
    }
}