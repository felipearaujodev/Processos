using Microsoft.AspNetCore.Mvc;
using Processos.Entity;
using Processos.Models.Request;
using Processos.Repository.Interfaces;


namespace Processos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        public IProcessoRepository _repositoryProcesso;
        public IHistoricoRepository _repositoryHistorico;

        public ProcessoController(IProcessoRepository repositoryProcesso,
            IHistoricoRepository repositoryHistorico)
        {
            _repositoryProcesso = repositoryProcesso;
            _repositoryHistorico = repositoryHistorico;
        }

        // GET: api/<Processo>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var processos = _repositoryProcesso.Get();

                return processos.Any()
                    ? Ok(processos)
                    : NotFound("nenhum processo encontrado!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET api/<Processo>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try {
                Processo processo = _repositoryProcesso.GetById(id);
                return processo != null 
                    ? Ok(processo) 
                    : NotFound("Processo não encontrado") ;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/<Processo>
        [HttpPost]
        public IActionResult Post([FromBody] ProcessoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Processo processo = new Processo
            {
                Numero = request.Numero.PadLeft(5, '0'),
                Data = request.Data,
                Tipo = request.Tipo,
                Partes = request.Partes,
                Observacoes = request.Observacoes,
                Documento = request.Documento

            };
            _repositoryProcesso.Add(processo);

            ProcessoHistorico historico = new ProcessoHistorico
            {
                ProcessoId = processo.Id,
                Numero = processo.Numero,
                Data = processo.Data,
                Tipo = processo.Tipo,
                Partes = processo.Partes,
                Observacoes = processo.Observacoes,
                Documento = processo.Documento

            };
            _repositoryHistorico.Add(historico);

            return Ok(processo);
        }

        // PUT api/<Processo>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Processo>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
