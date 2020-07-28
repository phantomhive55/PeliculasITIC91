using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasITIC91.Data
{
    public class PeliculaManager
    {
        const string url = "http://192.168.1.68:3000/peliculas/";

        public async Task<IEnumerable<Pelicula>> GetAll()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Pelicula>>(result);
        }

        public async Task<Pelicula> Add(string titulo, string genero, int duracion, int anio)
        {
            Pelicula pelicula = new Pelicula()
            {
                Titulo = titulo,
                Genero = genero,
                Duracion = duracion,
                Anio = anio
            };

            HttpClient client = new HttpClient();

            
            var response = await client.PostAsync(url,
                new StringContent(
                    JsonConvert.SerializeObject(pelicula),
                    Encoding.UTF8, "application/json"));

            
            return JsonConvert.DeserializeObject<Pelicula>(
                await response.Content.ReadAsStringAsync());

        }

        public async Task<int> Delete(long Id)
        {
            HttpClient client = new HttpClient();

            var response = await client.DeleteAsync($"{url}/{Id}");

            return JsonConvert.DeserializeObject<int>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<Pelicula> Update(long id, string titulo, string genero, string duracion, string anio)
        {
            Pelicula libro = new Pelicula()
            {
                Titulo = titulo,
                Genero = genero,
                Duracion = int.Parse(duracion),
                Anio = int.Parse(anio)
            };

            HttpClient client = new HttpClient();
            var response = await client.PutAsync($"{url}/{id}",
                new StringContent(
                    JsonConvert.SerializeObject(libro),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Pelicula>(
                await response.Content.ReadAsStringAsync());

        }
    }
}
