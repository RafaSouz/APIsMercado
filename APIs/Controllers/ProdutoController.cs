using APIs.Models;
using APIs.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepositories _produtoRepositories;
    public ProdutoController(IProdutoRepositories produtoRepositorie)
    {
        _produtoRepositories = produtoRepositorie;
    }

    [HttpGet]
    public async Task<ActionResult<List<Produto>>> BuscarTodos()
    {
        return await _produtoRepositories.BuscarTodos();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> BuscarPorId(int id)
    {
        return await _produtoRepositories.BuscarPorId(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Produto>> AtualizarCategoria(int id, Produto modal)
    {
        return await _produtoRepositories.Atualizar(modal, id);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> AdicionarProduto(Produto modal)
    {
        return await _produtoRepositories.Adicionar(modal);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> RemoverProduto(int id)
    {
        await _produtoRepositories.Remover(id);

        return true;
    }
}
