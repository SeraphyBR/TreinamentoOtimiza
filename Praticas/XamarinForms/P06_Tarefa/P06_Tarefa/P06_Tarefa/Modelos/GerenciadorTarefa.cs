using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Tarefa.Modelos
{
    public class GerenciadorTarefa
    {
        public List<Tarefa> Lista { get; private set; }

        public GerenciadorTarefa()
        {
            if (App.Current.Properties.ContainsKey("Tarefas")) {
                object o = App.Current.Properties["Tarefas"];
                if(o is List<Tarefa> l) {
                    this.Lista = l;
                }
                else {
                    this.Lista = new List<Tarefa>();
                }
            } else {
                this.Lista = new List<Tarefa>();
            }
        }

        public void Adicionar(Tarefa t)
        {
            this.Lista.Add(t);
            UpdateChangesOnProperties(this.Lista);
        }

        public void Finalizar(int idx, DateTime dataFinalizacao)
        {
            this.Lista[idx].DataFinalizacao = dataFinalizacao;
            UpdateChangesOnProperties(this.Lista);
        }

        public void Remover(int idx)
        {
            this.Lista.RemoveAt(idx);
            UpdateChangesOnProperties(this.Lista);
        }

        private void UpdateChangesOnProperties(List<Tarefa> lt)
        {
            if (App.Current.Properties.ContainsKey("Tarefas")) {
                App.Current.Properties.Remove("Tarefas");
            }
            App.Current.Properties.Add("Tarefas", lt);
        }
    }
}
