using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.ORM.Entidades
{
    public class Jogador : BaseEntity
    {
        public string Nome { get; set; }
        public int ClubeId { get; set; }
        public Clube Clube { get; set; }
        public int PosicaoId { get; set; }
        public Posicao Posicao { get; set; }
    }
}
