using NUnit.Framework;
using WebAPINubimetrics.BusinessLogic;
using WebAPINubimetrics.Interface;
using WebAPINubimetrics.Models.DB;

namespace WebAPINubimetrics.TEST
{
    public class UsuariosControllerTest
    {

        private DB_Nubimetrics_APIContext _context;
        private IBSUsuarioValidaciones _usuarioValidaciones;

        [SetUp]
        public void SetUp()
        {
            _context = new DB_Nubimetrics_APIContext();
            _usuarioValidaciones = new BSUsuarioValidaciones();        
        }

        /// <summary>
        /// Prueba de validacion de usuario existente
        /// </summary>
        [Test]
        public void Usuarios_GetValidacionExistente_Success()
        {
            Assert.DoesNotThrow(() => _usuarioValidaciones.UsuarioExiste(DataUsuarioTest.GetUsuarios(), 2));
        }

        /// <summary>
        /// Prueba de validacion de un usuario null
        /// </summary>
        [Test]
        public void Usuarios_GetValidacionNulo_ReturnSuccess()
        {
            Assert.DoesNotThrow(() => _usuarioValidaciones.UsuarioNulo(DataUsuarioTest.GetUsuarioNulo()));
        }

        /// <summary>
        /// Prueba de validacion de usuario con datos correctos
        /// </summary>
        [Test]
        public void Usuarios_GetValidacionCorrecto_ReturnSuccess()
        {
            Assert.DoesNotThrow(() => _usuarioValidaciones.UsuarioValoresCorrectos(DataUsuarioTest.GetUsuario()));
        }

        /// <summary>
        /// Prueba de validacion de usuario con datos incorrectos
        /// </summary>
        [Test]
        public void Usuarios_GetValidacionCorrecto_ReturnNotSuccess()
        {
            Assert.AreNotEqual(true, _usuarioValidaciones.UsuarioValoresCorrectos(DataUsuarioTest.GetUsuarioIncorrecto()));
        }

    }
}