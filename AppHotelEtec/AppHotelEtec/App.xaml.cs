using AppHotelEtec.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotelEtec
{
    public partial class App : Application
    {

        public List<Suite> lista_suites = new List<Suite>
        {
            new Suite()
            {
                Nome = "Super Lixo",
                DiariaAdulta = 110.0,
                DiariaCrianca = 55.0
            },
            new Suite()
            {
                Nome = "Executiva",
                DiariaAdulta = 90,
                DiariaCrianca = 45
            },
            new Suite()
            {
                Nome = "Crise",
                DiariaAdulta = 45.0,
                DiariaCrianca = 20.0
            }
        };

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");

            InitializeComponent();

            if (Properties.ContainsKey("usuario_load"))
            {

                MainPage = new NavigationPage(new View.ContratacaoHospedagem());
            }
            else
            {
                MainPage = new NavigationPage(new View.Login());

            }



        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
