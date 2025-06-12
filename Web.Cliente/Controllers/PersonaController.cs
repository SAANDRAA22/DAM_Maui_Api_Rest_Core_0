using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web.Cliente.Clases;

namespace Web.Cliente.Controllers
{
    public class PersonaController : Controller
    {
        private string urlbase;
        private string cadena;
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonaController (IConfiguration configuration, IHttpClientFactory httpClientFactory)

        {
            urlbase = configuration["baseurl"];
            cadena = "Hola";
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        //metodos

        //traer los datos a  la Data como string
        //metodo para listar personas sin filtro

        public async Task<List<PersonaCLS>> listarPersonas()
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);
            //string cadena = await cliente.GetStringAsync("api/Persona");
            //List<PersonaCLS> Lista = JsonSerializer.Deserialize<List<PersonaCLS>>(cadena);
            //return Lista;
            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory, urlbase, "/api/Persona");
        }

        //metodo para listar personas con filtro

        public async Task<List<PersonaCLS>> FiltrarPersonas(string nombrecompleto)
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);
            //string cadena = await cliente.GetStringAsync("api/Persona/"+ nombrecompleto);
            //List<PersonaCLS> Lista = JsonSerializer.Deserialize<List<PersonaCLS>>(cadena);
            //return Lista;
            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory, urlbase, "/api/Persona/" + nombrecompleto);
        }

        //metodo para filtrar personas por id 

        public async Task<PersonaCLS> RecuperarPersona(int id)
        {
            return await ClientHttp.Get<PersonaCLS>(_httpClientFactory, urlbase, "/api/Persona/recuperarPersona/" + id);
        }
    }
}
