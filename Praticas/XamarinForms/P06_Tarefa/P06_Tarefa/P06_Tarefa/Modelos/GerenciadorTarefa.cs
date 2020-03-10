using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace P06_Tarefa.Modelos
{
    public class GerenciadorTarefa
    {
        public List<Tarefa> Lista { get; private set; }

        public GerenciadorTarefa()
        {
            if (App.Current.Properties.ContainsKey("Tarefas")) {
                object obj = App.Current.Properties["Tarefas"];
                if(obj is string json) {
                    this.Lista = JsonConvert.DeserializeObject<List<Tarefa>>(json);
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
            UpdateChangesOnProperties();
        }

        public void Finalizar(int idx, DateTime dataFinalizacao)
        {
            this.Lista[idx].DataFinalizacao = dataFinalizacao;
            UpdateChangesOnProperties();
        }

        public void Remover(int idx)
        {
            this.Lista.RemoveAt(idx);
            UpdateChangesOnProperties();
        }

        private void UpdateChangesOnProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas")) {
                App.Current.Properties.Remove("Tarefas");
            }

            string json = JsonConvert.SerializeObject(this.Lista);
            App.Current.Properties.Add("Tarefas", json);
        }
    }
}
