using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using P10_Vagas.Modelos;
using Xamarin.Forms;

namespace P10_Vagas.Banco
{
    class Database
    {
        private readonly SQLiteConnection _conexao;

        public Database(string name)
        {
            var ds = DependencyService.Get<ICaminho>();
            string path = ds.GetPath($"{name}.sqlite.db");
            _conexao = new SQLiteConnection(path);
            _conexao.CreateTable<Vaga>();
        }

        public List<Vaga> Consultar()
        {
            return _conexao.Table<Vaga>().ToList();
        }

        public List<Vaga> Pesquisar(string palavra)
        {
            return _conexao.Table<Vaga>().Where(v => v.Nome.Contains(palavra)).ToList();
        }

        public Vaga GetVagaById(int id)
        {
            return _conexao.Table<Vaga>().Where(v => v.Id == id).FirstOrDefault();
        }

        public void Atualizar(Vaga v)
        {
            this._conexao.Update(v);
        }

        public void Adicionar(Vaga v)
        {
            this._conexao.Insert(v);
        }

        public void Remover(Vaga v)
        {
            this._conexao.Delete(v);
        }
    }
}
