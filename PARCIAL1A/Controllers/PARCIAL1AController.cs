using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PARCIAL1A.Models;
using System.Linq;

namespace PARCIAL1A.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class PARCIAL1AController : ControllerBase
    {
        private readonly PARCIAL1AContext _PARCIAL1AContexto;
        public PARCIAL1AController(PARCIAL1AContext PARCIAL1AContexto)
        {
            _PARCIAL1AContexto = PARCIAL1AContexto;
        }

        // read
        [HttpGet]
        [Route("GetAllAutores")]

        public IActionResult GetAutores()
        {

            List<Autores> listado = (from e in _PARCIAL1AContexto.Autores select e).ToList();

            if (listado.Count() == 0)
            {

                return NotFound();

            }
            return Ok(listado);

        }
        [HttpGet]
        [Route("GetAllPosts")]

        public IActionResult Get()
        {

            List<Posts> listado = (from e in _PARCIAL1AContexto.Posts select e).ToList();

            if (listado.Count() == 0)
            {

                return NotFound();

            }
            return Ok(listado);

        }
        [HttpGet]
        [Route("GetAllAutorLibro")]

        public IActionResult GetAutorLibro()
        {

            List<AutorLibro> listado = (from e in _PARCIAL1AContexto.AutorLibro select e).ToList();

            if (listado.Count() == 0)
            {

                return NotFound();

            }
            return Ok(listado);

        }
        [HttpGet]
        [Route("GetAllLibro")]

        public IActionResult GetLibro()
        {

            List<Libro> listado = (from e in _PARCIAL1AContexto.Libro select e).ToList();

            if (listado.Count() == 0)
            {

                return NotFound();

            }
            return Ok(listado);

        }
        // create

        [HttpPost]
        [Route("AddAutores")]

        public IActionResult GuardarAutor([FromBody] Autores Autores)
        {
            try
            {

                _PARCIAL1AContexto.Autores.Add(Autores);
                _PARCIAL1AContexto.SaveChanges();
                return Ok(Autores);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }
        [HttpPost]
        [Route("AddPosts")]

        public IActionResult GuardarPosts([FromBody] Posts Posts)
        {
            try
            {

                _PARCIAL1AContexto.Posts.Add(Posts);
                _PARCIAL1AContexto.SaveChanges();
                return Ok(Posts);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }

        [HttpPost]
        [Route("AddAutorLibro")]

        public IActionResult GuardarAutorLibro([FromBody] AutorLibro AutorLibro)
        {
            try
            {

                _PARCIAL1AContexto.AutorLibro.Add(AutorLibro);
                _PARCIAL1AContexto.SaveChanges();
                return Ok(AutorLibro);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }

        }
        [HttpPost]
        [Route("AddLibro")]

        public IActionResult GuardarLibro([FromBody] Libro Libro)
        {
            try
            {

                _PARCIAL1AContexto.Libro.Add(Libro);
                _PARCIAL1AContexto.SaveChanges();
                return Ok(Libro);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }

        }
        // update
        [HttpPut]
        [Route("ActualizarAutor/{Id}")]

        public IActionResult ActualizarAutores(int Id, [FromBody] Autores AutoresModificar)
        {
            // Para alterar un registro, se obtiene el registro actual de la base de datos al cual alteraremos una propiedad

            Autores? AutoresActual = _PARCIAL1AContexto.Autores.FirstOrDefault(e => e.Id == Id);

            // verificamos que exista el registro segun su id
            if (AutoresActual == null)
            {
                return NotFound();
            }

            // si se encuentra el registro se alteraran los campos modificables
            AutoresActual.Id = AutoresModificar.Id;
            AutoresActual.Nombre = AutoresModificar.Nombre;

            // se marca el registro como modificado en el contexto y se envia la modificacion a la bd
            _PARCIAL1AContexto.Entry(AutoresActual).State = EntityState.Modified;
            _PARCIAL1AContexto.SaveChanges();

            return Ok();

        }

        [HttpPut]
        [Route("ActualizarPosts/{Id}")]

        public IActionResult ActualizarPosts(int Id, [FromBody] Posts PostsModificar)
        {
            // Para alterar un registro, se obtiene el registro actual de la base de datos al cual alteraremos una propiedad

            Posts? PostsActual = _PARCIAL1AContexto.Posts.FirstOrDefault(e => e.Id == Id);

            // verificamos que exista el registro segun su id
            if (PostsActual == null)
            {
                return NotFound();
            }

            // si se encuentra el registro se alteraran los campos modificables
            PostsActual.Id = PostsModificar.Id;
            PostsActual.Titulo = PostsModificar.Titulo;
            PostsActual.Contenido = PostsModificar.Contenido;
            PostsActual.FechaPublicacion = PostsModificar.FechaPublicacion;
            PostsActual.AutorId = PostsModificar.AutorId;

            // se marca el registro como modificado en el contexto y se envia la modificacion a la bd
            _PARCIAL1AContexto.Entry(PostsActual).State = EntityState.Modified;
            _PARCIAL1AContexto.SaveChanges();

            return Ok();

        }

        [HttpPut]
        [Route("ActualizarAutorLibro/{Id}")]

        public IActionResult ActualizarAutorLibro(int Id, [FromBody] AutorLibro AutorLibroModificar)
        {
            // Para alterar un registro, se obtiene el registro actual de la base de datos al cual alteraremos una propiedad

            AutorLibro? AutorLibroActual = _PARCIAL1AContexto.AutorLibro.FirstOrDefault(e => e.AutorId == Id);

            // verificamos que exista el registro segun su id
            if (AutorLibroActual == null)
            {
                return NotFound();
            }

            // si se encuentra el registro se alteraran los campos modificables
            AutorLibroActual.AutorId = AutorLibroModificar.AutorId;
            AutorLibroActual.LibroId = AutorLibroModificar.LibroId;
            AutorLibroActual.Orden = AutorLibroModificar.Orden;
           
            // se marca el registro como modificado en el contexto y se envia la modificacion a la bd
            _PARCIAL1AContexto.Entry(AutorLibroActual).State = EntityState.Modified;
            _PARCIAL1AContexto.SaveChanges();

            return Ok();

        }
        [HttpPut]
        [Route("ActualizarLibro/{Id}")]

        public IActionResult ActualizarLibro(int Id, [FromBody] Libro LibroModificar)
        {
            // Para alterar un registro, se obtiene el registro actual de la base de datos al cual alteraremos una propiedad

            Libro? LibroActual = _PARCIAL1AContexto.Libro.FirstOrDefault(e => e.Id == Id);

            // verificamos que exista el registro segun su id
            if (LibroActual == null)
            {
                return NotFound();
            }

            // si se encuentra el registro se alteraran los campos modificables
            LibroActual.Id = LibroModificar.Id;
            LibroActual.Titulo= LibroModificar.Titulo;
            

            // se marca el registro como modificado en el contexto y se envia la modificacion a la bd
            _PARCIAL1AContexto.Entry(LibroActual).State = EntityState.Modified;
            _PARCIAL1AContexto.SaveChanges();

            return Ok();

        }

        //delete
        [HttpDelete]
        [Route("EliminarAutores/{Id}")]

        public IActionResult EliminarAutores(int Id)
        {
            //para actualizar un registro se obtiene el registro original de la base de datos al cual eliminaremos

            Autores? Autores = _PARCIAL1AContexto.Autores.FirstOrDefault(e => e.Id == Id);

            //Verificamos que existe el registro segun su id

            if (Autores == null)
            {
                return NotFound();
            }

            //ejecutamos la accion de eliminar el registro
            _PARCIAL1AContexto.Autores.Attach(Autores);
            _PARCIAL1AContexto.Autores.Remove(Autores);
            _PARCIAL1AContexto.SaveChanges();
            return Ok(Autores);
        }

        [HttpDelete]
        [Route("EliminarPosts/{Id}")]

        public IActionResult EliminarPosts(int Id)
        {
            //para actualizar un registro se obtiene el registro original de la base de datos al cual eliminaremos

            Posts? Posts = _PARCIAL1AContexto.Posts.FirstOrDefault(e => e.Id == Id);

            //Verificamos que existe el registro segun su id

            if (Posts == null)
            {
                return NotFound();
            }

            //ejecutamos la accion de eliminar el registro
            _PARCIAL1AContexto.Posts.Attach(Posts);
            _PARCIAL1AContexto.Posts.Remove(Posts);
            _PARCIAL1AContexto.SaveChanges();
            return Ok(Posts);
        }

        [HttpDelete]
        [Route("EliminarAutorLibro/{Id}")]

        public IActionResult EliminarAutorLibro(int Id)
        {
            //para actualizar un registro se obtiene el registro original de la base de datos al cual eliminaremos

            AutorLibro? AutorLibro = _PARCIAL1AContexto.AutorLibro.FirstOrDefault(e => e.AutorId == Id);

            //Verificamos que existe el registro segun su id

            if (AutorLibro == null)
            {
                return NotFound();
            }

            //ejecutamos la accion de eliminar el registro
            _PARCIAL1AContexto.AutorLibro.Attach(AutorLibro);
            _PARCIAL1AContexto.AutorLibro.Remove(AutorLibro);
            _PARCIAL1AContexto.SaveChanges();
            return Ok(AutorLibro);
        }
        [HttpDelete]
        [Route("EliminarLibro/{Id}")]

        public IActionResult EliminarLibro(int Id)
        {
            //para actualizar un registro se obtiene el registro original de la base de datos al cual eliminaremos

            Libro? Libro = _PARCIAL1AContexto.Libro.FirstOrDefault(e => e.Id == Id);

            //Verificamos que existe el registro segun su id

            if (Libro == null)
            {
                return NotFound();
            }

            //ejecutamos la accion de eliminar el registro
            _PARCIAL1AContexto.Libro.Attach(Libro);
            _PARCIAL1AContexto.Libro.Remove(Libro);
            _PARCIAL1AContexto.SaveChanges();
            return Ok(Libro);
        }

        // Búsqueda de Libros al ingresar el nombre del autor

        [HttpGet]
        [Route("busquedaAutorLibro/{nombreAutor}")]
        public IActionResult busquedaAutorLibro(string nombreAutor)
        {
            var librosDelAutor = from l in _PARCIAL1AContexto.Libro
                                 join au in _PARCIAL1AContexto.AutorLibro on l.Id equals au.LibroId
                                 join a in _PARCIAL1AContexto.Autores on au.AutorId equals a.Id
                                 where a.Nombre == nombreAutor
                                 select new { l.Titulo };

            if (librosDelAutor == null || !librosDelAutor.Any())
            {
                return NotFound();
            }

            return Ok(librosDelAutor);
        }
        //  Listado de los ultimo 20 Post al ingresar el nombre de un autor.
        [HttpGet]
        [Route("BusquedaPostAutor/{nombreA}")]
        public IActionResult BusquedaPostAutor(string nombreA)
        {
            var postsDelAutor = (from p in _PARCIAL1AContexto.Posts
                                 join a in _PARCIAL1AContexto.Autores on p.AutorId equals a.Id
                                 where a.Nombre == nombreA
                                 orderby p.FechaPublicacion descending
                                 select new { p.Titulo }).Take(20).ToList();

            if (postsDelAutor == null || !postsDelAutor.Any())
            {
                return NotFound();
            }

            return Ok(postsDelAutor);
        }
        //
        [HttpGet]
        [Route("GetListadoPostLibro")]
        public IActionResult GetListadoPostLibro()
        {
            var listadoPostsPorLibro = from l in _PARCIAL1AContexto.Libro
                                       join al in _PARCIAL1AContexto.AutorLibro on l.Id equals al.LibroId
                                       join a in _PARCIAL1AContexto.Autores on al.AutorId equals a.Id
                                       join p in _PARCIAL1AContexto.Posts on a.Id equals p.AutorId
                                       orderby l.Titulo, p.FechaPublicacion descending
                                       select new { l.Titulo, p };

            if (listadoPostsPorLibro == null || !listadoPostsPorLibro.Any())
            {
                return NotFound();
            }

            return Ok(listadoPostsPorLibro);
        }


    }
}
