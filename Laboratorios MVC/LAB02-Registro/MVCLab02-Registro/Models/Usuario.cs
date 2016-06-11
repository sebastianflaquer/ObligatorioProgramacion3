using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MVCLab02_Registro.Models
{
    public class Usuario
    {
        /* A cada atributo se le agregará la anotación [Required] a la que opcionalmente
        * se le puede agregar un parámetro con nombre ErrorMessage para especificar el
        * mensaje de error en caso de no ingresar nada.
        */
        [Required(ErrorMessage = "El nombre no se puede dejar vacío")]
        //Cambiar el nombre que se desplegará en el formulario
        [DisplayName("Nombre de usuario")]
        //Indicar largo mínimo
        [StringLength(10)]
        public string Nombre { get; set; }


        //Indicar que se trata de una dirección de mail para que realice automáticamente la validación
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        //Varias validaciones
        [Required(ErrorMessage = "La contraseña no se puede dejar vacía")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Largo mínimo de la contraseña: 8"),
                MaxLength(12, ErrorMessage = "Largo máximo de la contraseña:12")]
        public string Password { get; set; }


    }
}
