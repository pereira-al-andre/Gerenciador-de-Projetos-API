using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Projeto;
using Proj.Manager.Application.DTO.ViewModels;
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
            try
            {
                return Ok(ProjetoViewModel.ListaDeProjetos(_service.ListarProjetos().ToList()));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/buscar")]
        public IActionResult BuscarProjeto(Guid id)
        {
            try
            {
                return Ok(new ProjetoViewModel(_service.BuscarProjeto(id)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/tarefas")]
        public IActionResult ListarTarefasDoProjeto(Guid id)
        {
            try
            {
                return Ok(TarefaViewModel.ListaDeTarefas(_tarefaService.ListarTarefasDoProjeto(id).ToList()));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("criar")]
        public IActionResult CriarProjeto(CriarProjetoRequest request)
        {
            var projeto = new Projeto(request.GerenteId, request.Nome, request.Descricao, request.DataInicio);

            try
            {
                return Ok(new ProjetoViewModel(_service.CriarProjeto(projeto)));
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
            try
            {
                _service.DeletarProjeto(id);
                return Ok("Projeto deletado");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("{id}/finalizar")]
        public IActionResult FinalizarProjeto(Guid id)
        {
            try
            {
                _service.FinalizarProjeto(id);
                return Ok("Projeto finalizado");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("{id}/iniciar")]
        public IActionResult MarcarProjetoEmAndamento(Guid id)
        {
            try
            {
                _service.MarcarProjetoEmAndamento(id);
                return Ok("Projeto em andamento");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("{id}/cancelar")]
        public IActionResult CancelarProjeto(Guid id)
        {
            try
            {
                _service.CancelarProjeto(id);
                return Ok("Cancelado com sucesso");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult AtualizarProjeto(AtualizarProjetoRequest request)
        {
            try
            {
                var projeto = _service.BuscarProjeto(request.Id);
                projeto.Atualizar(request.Nome, request.Descricao, request.DataPrazo);

                _service.AtualizarProjeto(projeto);
                return Ok("Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("{id}/tarefa/remover")]
        public IActionResult RemoverTarefa(Guid idTarefa, Guid idProjeto)
        {
            try
            {
                _service.RemoverTarefa(idTarefa, idProjeto);
                return Ok("Removido com sucesso");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
