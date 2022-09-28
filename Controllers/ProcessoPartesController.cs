using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Processos.Context;
using Processos.Entity;
using Processos.Models.Request;
using Processos.Repository.Interfaces;

namespace Processos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoPartesController : ControllerBase
    {
        public IProcessoPartesRepository _repositoryPartes;

        public IProcessoRepository _repositoryProcesso;
        public IHistoricoRepository _repositoryHistorico;

        public ProcessoPartesController(IProcessoPartesRepository repositoryPartes,
            IProcessoRepository repositoryProcesso,
            IHistoricoRepository repositoryHistorico)
        {
            _repositoryPartes = repositoryPartes;
            _repositoryProcesso = repositoryProcesso;
            _repositoryHistorico = repositoryHistorico;
        }

        // GET: api/ProcessoPartes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var processoParte = _repositoryPartes.Get();

                return processoParte.Any()
                    ? Ok(processoParte)
                    : BadRequest("Nenhuma parte encontrada.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ProcessoPartes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var processoParte = _repositoryPartes.GetById(id);

                if (processoParte == null)
                {
                    return NotFound();
                }

                return Ok(processoParte);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/ProcessoPartes/5
        [HttpGet("{id}/Processos")]
        public IActionResult Processos(int id)
        {
            try
            {
                var processoPartes = _repositoryPartes.GetProcessoId(id);

                if (!processoPartes.Any())
                    return NotFound();

                return Ok(processoPartes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/ProcessoPartes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProcessoParteRequest processoParteRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }

                var processoParte = _repositoryPartes.GetById(id);

                if (processoParte == null)
                    return NotFound();

                if (processoParte.Id != id)
                    return NotFound();

                processoParte.Sigiloso = processoParteRequest.Sigiloso;
                processoParte.Cpf = processoParteRequest.Cpf ?? processoParte.Cpf;
                processoParte.Nome = processoParteRequest.Nome ?? processoParte.Nome;
                processoParte.Sexo = processoParteRequest.Sexo ?? processoParte.Sexo;

                _repositoryPartes.Update(processoParte);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/ProcessoPartes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post([FromBody] ProcessoParteRequest processoParteRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }

                ProcessoParte processoParte = new ProcessoParte
                {
                    ProcessoId = processoParteRequest.ProcessoId,
                    Sigiloso = processoParteRequest.Sigiloso,
                    Cpf = processoParteRequest.Cpf,
                    Nome = processoParteRequest.Nome,
                    Sexo = processoParteRequest.Sexo
                };

                _repositoryPartes.Add(processoParte);

                Processo processo = _repositoryProcesso.GetById(processoParte.ProcessoId);

                ProcessoHistorico historico = new()
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

                return Ok(processoParte);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/ProcessoPartes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var processoParte = _repositoryPartes.GetById(id);

                if (processoParte == null)
                    return NotFound();

                if (processoParte.Id != id)
                    return NotFound();

                _repositoryPartes.Delete(id);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
