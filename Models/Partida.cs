using System;

namespace E_Playes.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }

        public int IdJogado1 { get; set; }

        public int IdJogador2 { get; set; }

        public DateTime HorarioInicio { get; set; }
    }
}