﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultaCEP.Servico;
using ConsultaCEP.Servico.Modelo;
namespace ConsultaCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs args)
        {
        
            // TODO - Validações
            string cep = CEP.Text.Trim();

            if(isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if(end != null)
                    {
                        Console.WriteLine(end.localidade, end.uf, end.logradouro, end.bairro);
                        System.Diagnostics.Debug.WriteLine(end.localidade, end.uf, end.logradouro, end.bairro);
                        RESULTADO.Text = string.Format("Endereço: {2} {3} {0} {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o cep informado : " + cep, "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
                
            }
        }

        private bool isValidCEP(string cep)
        {
            
            if (cep.Length != 8)
            {
                // Erro
                DisplayAlert("ERRO", "Cep inválido! O CEP Deve conter 8 caracteres!", "OK");
                return false;
            }
            int NovoCEP = 0;

            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "Cep inválido! O CEP deve conter apenas números!", "OK");
                // Erro
                return false;
            }

            return true;
        }
	}
}
