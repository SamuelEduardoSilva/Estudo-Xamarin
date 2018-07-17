using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultaCEP.Servico;
using ConsultaCEP.Servico.Modelo;
using System.ComponentModel;

namespace ConsultaCEP
{
	public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            set
            {
                this.isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public MainPage()
		{
			InitializeComponent();
            
            loadingOverlay.IsVisible = false;
            BindingContext = this;
            BOTAO.Clicked += BuscarCEP;
		}

        private async void BuscarCEP(object sender, EventArgs args)
        {
            loadingOverlay.IsVisible = true;
            // TODO - Validações

            string cep=  CEP.Text.Trim();

            if(isValidCEP(cep))
            {
                try
                {
                    
                    loadingOverlay.IsVisible = true;
                    await Task.Delay(2000);
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    await Task.Delay(1000);
                    loadingOverlay.IsVisible = false;
                    if (end != null)
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
                    loadingOverlay.IsVisible = false;
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
       

        public async void aparece()
        {
            IsLoading = true;
        }

        public async void some()
        {
           IsLoading = false;
        }
  
        
    }
}

