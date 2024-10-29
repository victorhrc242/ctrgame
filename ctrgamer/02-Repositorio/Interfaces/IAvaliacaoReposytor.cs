using ctrgamer._03_entidades;
namespace ctrgamer._02_Repositorio.Interfaces;
public interface IAvaliacaoReposytor
{
    void Adicionar(Avaliacao u);
    List<Avaliacao> listar();
    Avaliacao Buscarporid(int id);
    void Remover(int id);
    void editar(Avaliacao u);
}

