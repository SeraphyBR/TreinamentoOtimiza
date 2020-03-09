using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Tarefa.Modelos
{
    public class Tarefa
    {
        public string Nome { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public byte Prioridade { get; set; }

    }
}
