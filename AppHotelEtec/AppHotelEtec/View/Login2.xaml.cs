﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotelEtec.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login2 : ContentPage
    {

        App PropriedadesApp;

        public Login2()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App)Application.Current;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string usuario = txt_usuario.Text;
            string senha = txt_senha.Text;

            if (usuario == "aluno" && senha == "etec")
            {
                App.Current.Properties.Add("usuario_logado", usuario);
                App.Current.MainPage = new ContratacaoHospedagem();
            }
            else
            {
                DisplayAlert("Ops!", "Usuário ou senha incorretos", "Ok");
            }

        }
    }
}