using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Projeto;
using Proj.Manager.Application.DTO.Response;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;

namespace Proj.Manager.API.Controllers
{
    [Route("api/projeto")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _service;
        private readonly ITarefaService _tarefaService;
        private readonly IMembroService _membroService;
        public ProjetoController(
            IProjetoService projetoService, 
            ITarefaService tarefaService, 
            IMembroService membroService)
        {
            _service = projetoService;
            _tarefaService = tarefaService;
            _membroService = membroService;

        }

        [HttpGet]
        [Route("listar")]
        public IActionResult ListarProjetos()
        {
            return Ok(_service.ListarProjetos());
        }

        [HttpGet]
        [Route("{id}/buscar")]
        public IActionResult BuscarProjeto(Guid id)
        {
            return Ok(_service.BuscarProjeto(id));
        }

        [HttpGet]
        [Route("{id}/tarefas")]
        public IActionResult ListarTarefasDoProjeto(Guid id)
        {
            return Ok(_tarefaService.ListarTarefasDoProjeto(id));
        }

        [HttpPost]
        [Route("criar")]
        public IActionResult CriarProjeto(CriarProjetoRequest request)
        {
            var projeto = new Projeto(request.GerenteId, request.Nome, request.Descricao, request.DataInicio);

            try
            {
                return Ok(new NovoProjetoResponse(_service.CriarProjeto(projeto)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}/deletar")]
        public IActionResult DeletarProjeto(Guid id)
        {
            _service.DeletarProjeto(id);
            return Ok("Projeto deletado");
        }

        [HttpPost]
        [Route("{id}/finalizar")]
        public IActionResult FinalizarProjeto(Guid id)
        {
            _service.FinalizarProjeto(id);
            return Ok("Projeto finalizado");
        }

        [HttpPost]
        [Route("{id}/iniciar")]
        public IActionResult MarcarProjetoEmAndamento(Guid id)
        {
            _service.MarcarProjetoEmAndamento(id);
            return Ok("Projeto em andamento");
        }

        [HttpPost]
        [Route("{id}/cancelar")]
        public IActionResult CancelarProjeto(Guid id)
        {
            _service.CancelarProjeto(id);
            return Ok("Cancelado com sucesso");
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult AtualizarProjeto(AtualizarProjetoRequest request)
        {
            var projeto = _service.BuscarProjeto(request.Id);
            projeto.Atualizar(request.Nome, request.Descricao, request.DataPrazo);

            _service.AtualizarProjeto(projeto);
            return Ok("Atualizado com sucesso");
        }

        [HttpPost]
        [Route("{id}/tarefa/remover")]
        public IActionResult RemoverTarefa(Guid idTarefa, Guid idProjeto)
        {
            _service.RemoverTarefa(idTarefa, idProjeto);
            return Ok("Removido com sucesso");
        }
    }
}
