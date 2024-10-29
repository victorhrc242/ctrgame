using ctrgamer._03_entidades;
using System.Data.SQLite;

namespace ctrgamer._02_Repositorio.Interfaces;
public interface IUsuariorepositor
{
    void Adicionar(usuarioS u);

    List<usuarioS> listar();

    usuarioS Buscarporid(int id);

    void Remover(int id);

    void editar(usuarioS u);
    
}
