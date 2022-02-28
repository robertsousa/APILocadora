﻿namespace LocadoraAPI.Models
{
    public class LocacaoView
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdFilme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
