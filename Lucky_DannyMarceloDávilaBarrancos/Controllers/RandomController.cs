using Lucky_DannyMarceloDávilaBarrancos.Data;
using Lucky_DannyMarceloDávilaBarrancos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lucky_DannyMarceloDávilaBarrancos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
		private readonly AppDbContext _context;

		public RandomController(AppDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<Lucky>> GetCancion()
		{
			var list = await _context.Lucky.ToListAsync();

			var max = list.Count;
			var index = new Random().Next(0, max);

			var suerte = list[index];

			if (suerte == null)
			{
				return NoContent();
			}

			return suerte;
		}
	}
}
