using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message)
			: base(data, success: false, message)
		{
		}

		public ErrorDataResult(T data)
			: base(data, success: false)
		{
		}

		public ErrorDataResult(string message)
			: base(default(T), success: false, message)
		{
		}

		public ErrorDataResult()
			: base(default(T), success: false)
		{
		}
    }
}