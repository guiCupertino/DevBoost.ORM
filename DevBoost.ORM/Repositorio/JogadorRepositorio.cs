using DevBoost.ORM.Context;
using DevBoost.ORM.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.ORM.Repositorio
{
    public class JogadorRepositorio
    {
        private readonly DCDevBoostORM _contexto;

        public JogadorRepositorio(DCDevBoostORM contexto)
        {
            _contexto = contexto;
        }
        public async Task<IList<Jogador>> ObterJogadores()
        {
            return await _contexto.Jogadores
                .AsNoTracking()
                .Include(i => i.Clube)
                .Include(i => i.Posicao)
                .ToListAsync();
        }

        public async Task<Jogador> ObterJogador(int id)
        {
            return await _contexto.Jogadores
                .AsNoTracking()
                .Include(i => i.Clube)
                .Include(i => i.Posicao)
                .SingleOrDefaultAsync(j => j.Id == id);                
        }

        public async Task<bool> Adicionar(Jogador jogador)
        {
            await _contexto.Jogadores.AddAsync(jogador);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Atualizar(Jogador jogador)
        {
            _contexto.Jogadores.Update(jogador);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Deletar(Jogador jogador)
        {                        
            _contexto.Jogadores.Remove(jogador);
            return await _contexto.SaveChangesAsync() > 0;
        }

    }
}
