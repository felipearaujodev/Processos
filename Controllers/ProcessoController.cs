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
            try
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
                    DocumentoNome = request.DocumentoNome,
                    Documento = request.Documento

                };
                _repositoryProcesso.Add(processo);

                ProcessoHistorico historico = new ProcessoHistorico
                {
                    ProcessoId = processo.Id,
                    Numero = processo.Numero,
                    Data = processo.Data,
                    DataLog = DateTime.Now,
                    Tipo = processo.Tipo,
                    Partes = processo.Partes,
                    Observacoes = processo.Observacoes,
                    DocumentoNome = processo.DocumentoNome,
                    Documento = processo.Documento

                };
                _repositoryHistorico.Add(historico);

                return Ok(processo);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Processo>/5
        /// <summary>
        /// Alterar processo.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProcessoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }

                Processo processo = _repositoryProcesso.GetById(id);
                if (processo == null)
                    return NotFound("Não foi possível encontrar o processo selecionado!");

                if (processo.Id != id)
                    return NotFound("o ID informado não existe!");

                processo.Numero = request.Numero.PadLeft(5, '0') ?? processo.Numero;
                processo.Data = processo.Data != request.Data ? request.Data : processo.Data;
                processo.Tipo = request.Tipo ?? processo.Tipo;
                processo.Partes = request.Partes ?? processo.Partes;
                processo.Observacoes = request.Observacoes ?? processo.Observacoes;
                processo.DocumentoNome = request.DocumentoNome ?? processo.DocumentoNome;
                processo.Documento = request.Documento ?? processo.Documento;

                _repositoryProcesso.Update(processo);

                ProcessoHistorico historico = new ProcessoHistorico
                {
                    ProcessoId = processo.Id,
                    Numero = processo.Numero,
                    Data = processo.Data,
                    DataLog = DateTime.Now,
                    Tipo = processo.Tipo,
                    Partes = processo.Partes,
                    Observacoes = processo.Observacoes,
                    DocumentoNome = processo.DocumentoNome,
                    Documento = processo.Documento

                };
                _repositoryHistorico.Add(historico);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
