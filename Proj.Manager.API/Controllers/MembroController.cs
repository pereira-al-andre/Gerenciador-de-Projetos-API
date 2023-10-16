using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Membro;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;

namespace Proj.Manager.API.Controllers
{
    [Route("api/membro")]
    [ApiController]
    public class MembroController : ControllerBase
    {
        private readonly IMembroService _service;
        private readonly ITarefaService _tarefaService;
        private readonly IProjetoService _projetoService;
        public MembroController(
            IMembroService membroService,
            ITarefaService tarefaService,
            IProjetoService projetoService)
        {
            _service = membroService;
            _tarefaService = tarefaService;
            _projetoService = projetoService;

        }

        [HttpGet]
        [Route("listar")]
        public IActionResult ListaMembros()
        {
            return Ok(MembroViewModel.ListaDeMembros(_service.ListaMembros()));
        }

        [HttpGet]
        [Route("{id}/buscar")]
        public IActionResult BuscarMembro(Guid id)
        {
            try
            {
                return Ok(new MembroViewModel(_service.BuscarMembro(id)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/tarefas")]
        public IActionResult ListaTarefasMembro(Guid id)
        {
            return Ok(TarefaViewModel.ListaDeTarefas(_service.ListarMembrosDaTarefa(id)));
        }

        [HttpGet]
        [Route("{id}/projetos")]
        public IActionResult ListarProjetosMembro(Guid id)
        {
            return Ok(ProjetoViewModel.ListaDeProjetos(_projetoService.ListarProjetosMembro(id)));
        }

        [HttpPost]
        [Route("criar")]
        public IActionResult CriarMembro(CriarMembroRequest request)
        {
            var membro = new Membro(
                request.Nome, 
                request.Email, 
                request.Senha, 
                request.Cargo);

            try
            {
                return Ok(new MembroViewModel(_service.CriarMembro(membro)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult AtualizarMembro(AtualizarMembroRequest request)
        {
            var membro = _service.BuscarMembro(request.Id);

            membro.Atualizar(request.Nome, request.Email);

            try
            {
                _service.AtualizarMembro(membro);
                return Ok("Alterado com sucesso");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("cargo/alterar")]
        public IActionResult AlterarCargo(AlterarCargoRequest request)
        {
            var membro = _service.BuscarMembro(request.Id);

            membro.AlterarCargo(request.Cargo);

            try
            {
                _service.AlterarCargo(membro);
                return Ok("Alterado com sucesso");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("senha/alterar")]
        public IActionResult AlterarSenha(AlterarSenhaRequest request)
        {
            var membro = _service.BuscarMembro(request.Id);

            membro.AlterarSenha(request.NovaSenha);

            try
            {
                _service.AlterarSenha(membro);
                return Ok("Alterado com sucesso");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
