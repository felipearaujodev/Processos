using Microsoft.AspNetCore.Mvc;
using Processos.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Processos.Entity
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoHistoricoController : ControllerBase
    {
        public IHistoricoRepository _repositoryHistorico;
        public ProcessoHistoricoController(IHistoricoRepository repositoryHistorico)
        {
            _repositoryHistorico = repositoryHistorico;
        }

        // GET: api/<ProcessoHistoricoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var historico = _repositoryHistorico.Get();

                return historico.Any()
                    ? Ok(historico)
                    : BadRequest("Nenhum histórico encontrado!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProcessoHistoricoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var historico = _repositoryHistorico.GetById(id);
                return Ok(historico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("{id}/Restaurar")]
        public IActionResult Restaurar(int id) {

            return Ok();
        }


    }
}
