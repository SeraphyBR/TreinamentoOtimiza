﻿using P12_NossoChat.Utils;

namespace P12_NossoChat.Model
{
    public class Mensagem : Colors
    {
        public int id { get; set; }
        public int id_chat { get; set; }
        public int id_usuario { get; set; }
        public string mensagem { get; set; }
        public Usuario usuario { get; set; }
    }
}