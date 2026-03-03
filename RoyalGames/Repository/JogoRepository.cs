using Microsoft.EntityFrameworkCore;
using RoyalGames.Contexts;
using RoyalGames.Domains;
using RoyalGames.Interfaces;

namespace RoyalGames.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private readonly Royal_GamesContext _context;

        public JogoRepository(Royal_GamesContext context)
        {
            _context = context;
        }

        public List<Jogo> Listar()
        {
            List<Jogo> jogos = _context.Jogo
                .Include(jogo => jogo.ClassificacaoIndicativa)
                .Include(jogo => jogo.Genero)
                .Include(jogo => jogo.Plataforma)
                .ToList();

            return jogos;
        }

        public Jogo ObterPorId(int id, Jogo? jogo)
        {
            Jogo? jogo1 = _context.Jogo
                .Include(jogo => jogo.ClassificacaoIndicativa)
                .Include(jogo => jogo.Genero)
                .Include(jogo => jogo.Plataforma)
                .FirstOrDefault(jogo => jogo.JogoID == id);
            jogo = jogo1;

            return jogo;
        }

        //Jogo ObterPorNome(int id);
        //{
        //    Jogo
        //}

        //bool NomeExiste(string nome, int? jogoIdAtual = null);
        //void Adicionar(Jogo jogo);
        //void Atualizar(Jogo jogo);
        //void Remover(int id);
    }
}
