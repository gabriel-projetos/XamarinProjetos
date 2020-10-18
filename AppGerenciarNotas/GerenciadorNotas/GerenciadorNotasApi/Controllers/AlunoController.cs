using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorNotas.Dominio;
using GerenciadorNotas.Repositorio;
using GerenciadorNotas.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorNotas.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IEFCoreRepositorio _repo;
        public AlunoController(IEFCoreRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("api/aluno/GetAlunoById/{ra}")]
        public async Task<IActionResult> GetAlunoById(string ra)
        {
            try
            {
                var aluno = await _repo.GetDadosAlunoByRA(ra);
                if(aluno != null)
                    return Ok(aluno);
                return NotFound("Aluno não encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/aluno/Post/{model}")]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangedAsync())
                {
                    return Ok("Incluido");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
