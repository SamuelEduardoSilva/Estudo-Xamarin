using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tipos_Páginas.TiposPagina.Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pagina1 : ContentPage
	{
		public Pagina1 ()
		{
			InitializeComponent ();
		}
        private void MudarPagina2(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Página2());
        }

        private async void ChamarModal(object sender, EventArgs args)
        {
            await Navigation.PushPopupAsync(new Modal());
        }

        private void ChamarMaster(object sender, EventArgs args)
        {
            App.Current.MainPage = new MenuLateral.Master();
        }

    }
}