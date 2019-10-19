using _01WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DevsController : Controller
    {
        static readonly List<Dev> _devs = new List<Dev>
        {
            new Dev()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Dev1"
            },
            new Dev()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Dev2"
            },
            new Dev()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Dev3"
            },
        };

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_devs);
        }

        [HttpPost]
        public IActionResult Create()
        {
            return BadRequest();
        }
    }
}
