using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeliculasITIC91.Data;
using Xamarin.Forms;
using System.ComponentModel;
using Xamarin.Forms.Xaml;

namespace PeliculasITIC91
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AddPelicula : ContentPage
    {
        private PeliculaManager manager;
        private Pelicula pelicula;

        public AddPelicula(PeliculaManager manager, Pelicula pelicula = null)
        {
            InitializeComponent();

            this.pelicula = pelicula;
            this.manager = manager;
        }

        async public void OnSavePelicula(object sender, EventArgs e)
        {
            await manager.Add(txtTitulo.Text, txtGenero.Text, int.Parse(txtDuracion.Text), int.Parse(txtAnio.Text));
            OnBackHome();

        }

        async private void OnBackHome()
        {
            await Navigation.PopToRootAsync();
        }
    }
}