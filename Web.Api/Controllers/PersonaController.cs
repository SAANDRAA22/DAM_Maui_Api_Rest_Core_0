using CapaEntidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Web.Api.Models;
using System.Text.Json;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        //metodo recuperar por nombre completo

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

        //Metodo controlador listarPersona GET sin Filtro 

        [HttpGet]
        public List<PersonaCLS> listarPersona(int id)
        {
            List<PersonaCLS> lista = new List<PersonaCLS>();
            try
            {
                using (DbAba266BdveterinariaContext bd = new DbAba266BdveterinariaContext())
                {
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1 
                             select new PersonaCLS
                             {
                                 iipersona = persona.Iidpersona,
                                 nombrecompleto = persona.Nombre + " " + 
                                 persona.Appaterno + " " +
                                 persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToString("yyyy-MM-dd")
                             }).ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {
                return lista;
            }
        }

        //metodo recuperar por id

        [HttpGet("recuperarPersona/{id}")]
        public PersonaCLS recuperarPersona(int id)
        {
            PersonaCLS oPersonaCLS = new PersonaCLS();
            try
            {
                using (DbAba266BdveterinariaContext bd = new DbAba266BdveterinariaContext())
                {
                    oPersonaCLS = (from persona in bd.Personas
                             where persona.Bhabilitado == 1 
                             && persona.Iidpersona == id
                             select new PersonaCLS
                             {
                                 iipersona = persona.Iidpersona,
                                 nombre = persona.Nombre,
                                 appaterno = persona.Appaterno,
                                 apmaterno = persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanaccimiento = (DateTime)persona.Fechanacimiento,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToString("yyyy-MM-dd"),
                                 iidsexo = (int)persona.Iidsexo


                             }).First();
                }
                return oPersonaCLS;
            }
            catch (Exception ex)
            {
                return oPersonaCLS;
            }
        }
    }
}
    

