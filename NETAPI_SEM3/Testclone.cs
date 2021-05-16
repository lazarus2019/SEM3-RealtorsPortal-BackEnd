using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3
{
	public class Testclone
	{
		private Testclone()
		{

		}

		[Produces("application/json")]
		[HttpGet("demo1")]
		public IActionResult Demo1()
		{
			return null;
		}
	}
}
