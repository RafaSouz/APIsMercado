using APIs.Maps;
using APIs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace APIs.Context;

public class Contexts : DbContext, IDesignTimeDbContextFactory<Contexts>
{
    public Contexts(DbContextOptions<Contexts> options) : base(options) { }

    public Contexts() { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public static string conexao = "Server=DESKTOP-85AEEOL\\SQLEXPRESS;Database=Mercadorias;TrustServerCertificate=True;User Id = sa; Password=1234";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaMap());
        modelBuilder.ApplyConfiguration(new ProdutoMap());
    }
    public Contexts CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Contexts>();
        optionsBuilder.UseSqlServer(conexao);

        return new Contexts(optionsBuilder.Options);
    }
}
