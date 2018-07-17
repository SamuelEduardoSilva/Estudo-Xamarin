using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tipos_Páginas.TiposPagina.Carrosel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TipoPagina3 : ContentPage
	{
		public TipoPagina3 ()
		{
			InitializeComponent ();
		}

        private void MudarPagina(object sender, EventArgs args)
        {
            //DisplayAlert("alou", "aaaaaaaaaaaa", "ok");
            // App.Current.MainPage = new NavigationPage( new Navigation.Pagina1());
            App.Current.MainPage = new Tabbed.Abas();
        }
	}
}