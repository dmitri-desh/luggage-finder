using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ValuesController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
		/// <summary>
		/// Get All the Values
		/// </summary>
		/// <remarks>
		/// Get All the String Values
		/// </remarks>
		/// <returns></returns>
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		/// <summary>
		/// Get Value by Id
		/// </summary>
		/// <param name="id"></param>
		/// <remarks>
		/// Get Value by Id
		/// </remarks>
		/// <returns></returns>
		public string Get(int id)
		{
			return "value";
		}

		/// <summary>
		/// Create new value
		/// </summary>
		/// <remarks>
		/// Create new value
		/// </remarks>
		/// <returns></returns>
		public void Post([FromBody] string value)
		{
		}

		/// <summary>
		/// Update value by Id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="value"></param>
		/// <remarks>
		/// Update value by Id
		/// </remarks>
		/// <returns></returns>
		public void Put(int id, [FromBody] string value)
		{
		}

		/// <summary>
		/// Delete value by Id
		/// </summary>
		/// <param name="id"></param>
		/// <remarks>
		/// Delete value by Id
		/// </remarks>
		/// <returns></returns>
		public void Delete(int id)
		{
		}
	}
}
