using AppHotelEtec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotelEtec.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContratacaoHospedagem : ContentPage
    {

        App propriedadesapp;

        public ContratacaoHospedagem()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            propriedadesapp = (App)Application.Current;

            lbl_usuario.Text = App.Current.Properties["usuario_logado"].ToString();

            pck_suite.ItemsSource = propriedadesapp.lista_suites;

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);


            dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(6).AddDays(1);


        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker elemento = (DatePicker)sender;

            dtpck_checkout.MinimumDate = elemento.Date.AddDays(1);
            dtpck_checkout.MaximumDate = elemento.Date.AddDays(1).AddMonths(6);
        }

        private void dtpck_checkout_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new NavigationPage(new HospedagemCalculada()
                {
                    BindingContext = new Hospedagem()
                    {
                        QntAdultos = Convert.ToInt32(lbl_qnt_adultos.Text),
                        QntCriancas = Convert.ToInt32(lbl_qnt_crianca.Text),
                        QuartoEscolhido = (Suite)pck_suite.SelectedItem,
                        DataCheckIn = dtpck_checkin.Date,
                        DataCheckOut = dtpck_checkout.Date

                    }
                });
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            bool confirme = await DisplayAlert("Tem certeza?", "Desconectar da sua conta?", "Sim", "Não");

            if (confirme)
            {
                App.Current.Properties.Remove("usuario_logado");
                App.Current.MainPage = new Login();
            }

        }
    }
}