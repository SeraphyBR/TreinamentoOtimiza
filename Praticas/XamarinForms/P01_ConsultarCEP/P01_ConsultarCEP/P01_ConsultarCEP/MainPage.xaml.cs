using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using P01_ConsultarCEP.Servico;
using P01_ConsultarCEP.Servico.Modelo;

namespace P01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ButtonBusca.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = InputCep.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPService.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        LabelResultado.Text = $"Endereço: {end.Logradouro}, Bairro {end.Bairro}, {end.Localidade}/{end.Uf}";
                    }
                    else
                    {
                        DisplayAlert("Erro", $"O endereço não foi encontrado para o CEP informado: {cep}", "Ok");
                    }
                } catch(Exception e)
                {
                    DisplayAlert("Erro crítico", e.Message, "Ok");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valid = true;
            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido! O CEP deve conter 8 caracteres.", "Ok");
                valid = false;
            }
            if (!int.TryParse(cep, out _ ))
            {
                DisplayAlert("Erro", "CEP inválido! O CEP deve ser composto apenas por números.", "Ok");
                valid = false;
            }
            return valid;
        }
    }
}
