using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TareaNo._3_Jonathan_Rojas_3101.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuarios class
public class Usuarios : IdentityUser
{
    [Required(ErrorMessage = "La identificacion del usuario es requerida para completar el registro")]
    [Display(Name = "Identificacion")]
    public int Identificacion { get; set; }

    [Required(ErrorMessage = "El Nombre Completo del usuario no puede estar vacio")]
    [Display(Name = "Nombre Completo")]
    public string? NombreCompleto { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento del usuario es requerida para completar el registro")]
    [EdadMinimaAtribute(15)]
    [Display(Name = "Fecha de nacimiento")]
    [DataType(DataType.Date)]
    public string FechaDeNacimiento { get; set; }

    [Required(ErrorMessage = "El campo metodo de pago no puede estar vacio")]
    [Display(Name = "Seleccione un metodo de pago")]
    public string? MetodoPago { get; set; }  
}

