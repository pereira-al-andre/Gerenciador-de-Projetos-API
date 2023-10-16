using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Tarefa;
using Proj.Manager.Application.DTO.Response;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;

namespace Proj.Manager.API.Controllers
{
    [Route("api/tarefa")]
    [ApiController]
    public class TarefaController : ControllerBase
    {

        private readonly ITarefaService _service;
        private readonly IMembroService _membroService;
        public TarefaController(ITarefaService tarefaService, IMembroService membroService)
        {
            _service = tarefaService;
            _membroService = membroService;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult ListarTarefas()
        {
            return Ok(TarefaViewModel.ListaDeTarefas(_service.ListarTarefas()));
        }

        [HttpGet]
        [Route("{id}/buscar")]
        public IActionResult BuscarTarefa(Guid id)
        {
            return Ok(new TarefaViewModel(_service.BuscarTarefa(id)));
        }

        [HttpGet]
        [Route("{id}/membros")]
        public IActionResult ListarMembrosDaTarefa(Guid id)
        {
            return Ok(MembroViewModel.ListaDeMembros(_service.BuscarTarefa(id).Membros));
        }

        [HttpPost]
        [Route("criar")]
        public IActionResult CriarTarefa(CriarTarefaRequest request)
        {
            var tarefa = new Tarefa(
                request.ProjetoId, 
                request.Nome, 
                request.Descricao, 
                request.DataInicio,
                request.DataPrazo);

            try
            {
                return Ok(new TarefaViewModel(_service.CriarTarefa(tarefa)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult AtualizarTarefa(AtualizarTarefaRequest request)
        {
            var tarefa = _service.BuscarTarefa(request.Id);
            tarefa.Atualizar(request.Nome, request.Descricao, tarefa.DataPrazo);

            _service.AtualizarTarefa(tarefa);

            return Ok("Atualizado com sucesso");
        }

        [HttpDelete]
        [Route("{id}/deletar")]
        public IActionResult DeletarTarefa(Guid id)
        {
            var tarefa = _service.BuscarTarefa(id);
            tarefa.Deletar();
            _service.AtualizarTarefa(tarefa);

            return Ok("Tarefa deletada");
        }

        [HttpPost]
        [Route("{id}/cancelar")]
        public IActionResult CacelarTarefa(Guid id)
        {
            var tarefa = _service.BuscarTarefa(id);
            tarefa.Cancelar();
            _service.AtualizarTarefa(tarefa);

            return Ok("Tarefa cancelada");
        }

        [HttpPost]
        [Route("{id}/finalizar")]
        public IActionResult FinalizarTarefa(Guid id)
        {
            var tarefa = _service.BuscarTarefa(id);
            tarefa.Finalizar();
            _service.AtualizarTarefa(tarefa);

            return Ok("Tarefa finalizada");
        }

        [HttpPost]
        [Route("{id}/iniciar")]
        public IActionResult MarcarTarefaEmAndamento(Guid id)
        {
            var tarefa = _service.BuscarTarefa(id);
            tarefa.MarcarEmAndamento();
            _service.AtualizarTarefa(tarefa);

            return Ok("Tarefa iniciada");
        }

        [HttpPut]
        [Route("{tarefaId}/membros")]
        public IActionResult AdicionarMembros(Guid membroId, Guid tarefaId)
        {
            var tarefa = _service.BuscarTarefa(tarefaId);
            var membro = _membroService.BuscarMembro(membroId);
            tarefa.AdicionarMembros(membro);
            _service.AtualizarTarefa(tarefa);

            return Ok("Membro adicionado");
        }
    }
}
