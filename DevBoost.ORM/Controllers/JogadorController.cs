using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBoost.ORM.Entidades;
using DevBoost.ORM.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevBoost.ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private readonly JogadorRepositorio _jogadorRepositorio;
        public JogadorController(JogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            await _jogadorRepositorio.Adicionar(new Jogador()
            {
                Nome = "Guilherme"  ,
                Clube = new Clube { Nome = "Corinthians" },
                Posicao = new Posicao { Nome = "Atacante" }
            });

            return Ok(await _jogadorRepositorio.ObterJogadores());
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> Post(Jogador jogador)
        {
            var result = await _jogadorRepositorio.Adicionar(jogador);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> Put(Jogador jogador)
        {
            var result = await _jogadorRepositorio.Atualizar(jogador);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<IActionResult> Delete(int id)
        {
            var jogador = await _jogadorRepositorio.ObterJogador(id);

            if (jogador == null)
                return BadRequest();

            var result = await _jogadorRepositorio.Deletar(jogador);

            if(!result)
                return BadRequest();

            return Ok();
        }


    }
}