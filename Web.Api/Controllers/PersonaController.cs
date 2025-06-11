using CapaEntidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Web.Api.Models;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet ("{nombrecompleto}")]
        public List<PersonaCLS> listarPersona(string nombrecompleto)
        {
            List<PersonaCLS> lista = new List<PersonaCLS>();
            try
            {
                using (DbAba266BdveterinariaContext bd = new DbAba266BdveterinariaContext())
                {
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             && (persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno).Contains(nombrecompleto)
                             select new PersonaCLS
                             {
                                 iipersona = persona.Iidpersona,
                                 nombrecompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToShortDateString()


                             }).ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {
                return lista;
            }
        }
    }
}
