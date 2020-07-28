using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeliculasITIC91.Data;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace PeliculasITIC91
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private IList<Pelicula> peliculas = new ObservableCollection<Pelicula>();
        private PeliculaManager manager = new PeliculaManager();
        public MainPage()
        {
            BindingContext = peliculas;
            InitializeComponent();
            this.recargar();
            recarga.ItemsSource = peliculas;
            this.inicio();
        }
        public void inicio()
        {
            recarga.RefreshCommand = new Command(() => {
                recarga.IsRefreshing = true;
                this.recargar();
            });
        }

        public void OnRefresh(object sender, EventArgs e)
        {
            this.recargar();
        }

        async public void recargar()
        {
            peliculas.Clear();
            var peliculasCollection = await manager.GetAll();
            foreach (Pelicula pelicula in peliculasCollection)
            {
                
                if (peliculas.All(t => t.Id != pelicula.Id))
                {
                    peliculas.Add(pelicula);
                }
            }
            recarga.IsRefreshing = false;
        }

        async public void OnAddPelicula(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPelicula(manager));
        }

        async public void OnDeletePelicula(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            var t = menuItem.CommandParameter as Pelicula;

            bool answer = await DisplayAlert("Eliminar", $"¿Quieres eliminar {t.Titulo}?", "Sí", "No");

            if (answer)
            {
                await manager.Delete(t.Id);
                peliculas.Remove(t);

            }
        }
        private void OnUpdatePelicula(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            var l = menuItem.CommandParameter as Pelicula;

            if (l != null)
            {
                Navigation.PushAsync(new UpdatePelicula(manager, l));
            }
        }

    }
}
