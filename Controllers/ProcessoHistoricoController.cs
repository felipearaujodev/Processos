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
        public IProcessoRepository _repositoryProcesso;
        public ProcessoHistoricoController(IHistoricoRepository repositoryHistorico, 
            IProcessoRepository repositoryProcesso)
        {
            _repositoryHistorico = repositoryHistorico;
            _repositoryProcesso = repositoryProcesso;
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
        [HttpGet("{processoId}")]
        public IActionResult Get(int processoId)
        {
            try
            {
                var historico = _repositoryHistorico.ProcessoId(processoId);
                return Ok(historico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("{id}/Restaurar")]
        public IActionResult Restaurar(int id) {

            ProcessoHistorico historico = _repositoryHistorico.GetById(id);

            if (historico == null) return BadRequest("Histórico não encontrado");

            if (historico.Restaurado) return Unauthorized("Histórico já foi restaurado!");

            Processo processo = _repositoryProcesso.GetById(historico.ProcessoId);

            if (processo == null) return BadRequest("Processo não existe!");

            processo.Numero = historico.Numero;
            processo.Data = historico.Data;
            processo.Observacoes = historico.Observacoes;
            processo.Tipo = historico.Tipo;
            processo.Documento = historico.Documento;
            processo.DocumentoNome = historico.DocumentoNome;

            _repositoryProcesso.Update(processo);

            return Ok();
        }


    }
}
