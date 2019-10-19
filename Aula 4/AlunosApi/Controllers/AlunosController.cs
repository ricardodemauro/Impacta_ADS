using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : Controller
    {
        private readonly AlunosService _alunosService;

        public AlunosController(AlunosService alunosService)
        {
            _alunosService = alunosService;
        }

        [HttpGet]
        public ActionResult<List<Aluno>> Get() => _alunosService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAluno")]
        public ActionResult<Aluno> Get(string id)
        {
            var aluno = _alunosService.Get(id);

            if (aluno == null)
                return NotFound();

            return aluno;
        }

        [HttpPost]
        public ActionResult<Aluno> Create(Aluno aluno)
        {
            _alunosService.Create(aluno);

            return CreatedAtRoute("GetAluno", new { id = aluno.Id.ToString() }, aluno);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Aluno alunoIn)
        {
            var aluno = _alunosService.Get(id);

            if (aluno == null)
                return NotFound();

            _alunosService.Update(id, alunoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var aluno = _alunosService.Get(id);

            if (aluno == null)
                return NotFound();

            _alunosService.Remove(aluno.Id);

            return NoContent();
        }
    }
}