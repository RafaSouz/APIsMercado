using Microsoft.AspNetCore.Mvc;
using APIs.Models;
using APIs.Repositories.IRepositories;

namespace APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepositories _categoriaRepositories;
    public CategoriaController(ICategoriaRepositories categoriaRepositorie)
    {
        _categoriaRepositories = categoriaRepositorie;
    }

    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> BuscarTodos()
    {
        return Ok(await _categoriaRepositories.BuscarTodos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> BuscarPorId(int id)
    {
        return Ok(await _categoriaRepositories.BuscarPorId(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Categoria>> AtualizarCategoria(int id, Categoria modal)
    {
        return Ok(await _categoriaRepositories.Atualizar(modal, id));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> AdicionarCategoria(Categoria modal)
    {
        return Ok(await _categoriaRepositories.Adicionar(modal));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> RemoverCategoria(int id)
    {
        await _categoriaRepositories.Remover(id);

        return true;
    }
}
