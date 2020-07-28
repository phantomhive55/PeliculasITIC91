using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeliculasITIC91.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeliculasITIC91
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePelicula : ContentPage
    {
        private PeliculaManager manager;
        private Pelicula pelicula;
        public UpdatePelicula()
        {
            InitializeComponent();
        }


        public UpdatePelicula(PeliculaManager manager, Pelicula pelicula = null)
        {
            InitializeComponent();

            this.pelicula = pelicula;
            this.manager = manager;

            cargar(this.pelicula);
        }


        private void cargar(Pelicula pelicula)
        {
            txtTitulo.Text = pelicula.Titulo;
            txtGenero.Text = pelicula.Genero;
            txtDuracion.Text = pelicula.Duracion.ToString();
            txtAnio.Text = pelicula.Anio.ToString();
        }

        async public void OnUpdatePelicula(object sender, EventArgs e)
        {

            await manager.Update(this.pelicula.Id, txtTitulo.Text, txtGenero.Text, txtDuracion.Text, txtAnio.Text);
            OnBackHome();

        }

        async private void OnBackHome()
        {
            await Navigation.PopToRootAsync();

        }


    }


}