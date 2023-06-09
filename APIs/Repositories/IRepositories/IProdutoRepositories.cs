﻿using APIs.Models;

namespace APIs.Repositories.IRepositories;

public interface IProdutoRepositories
{
    Task<Produto> BuscarPorId(int id);
    Task<List<Produto>> BuscarTodos();
    Task<bool> Adicionar(Produto model);
    Task<Produto> Atualizar(Produto model, int id);
    Task<bool> Remover(int id);
}