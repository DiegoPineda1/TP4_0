﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocheraTp.Models;

public partial class DETALLE_FACTURA
{
    [Key]
    public int id_detalle_factura { get; set; }
    [Required(ErrorMessage = "La fecha de entrada es obligatoria.")]
    public DateTime? fecha_entrada { get; set; }
    [Required(ErrorMessage = "La fecha de salida es obligatoria.")]
    public DateTime? fecha_salida { get; set; }
    public int? id_factura { get; set; }
    [Required(ErrorMessage = "El vehiculo es obligatorio.")]
    public int? id_vehiculo { get; set; }
    [Required(ErrorMessage = "Es necesario indicar el lugar ocupado.")]
    public int? id_lugar { get; set; }
    [Required(ErrorMessage = "Es necesario indicar el tipo de abono.")]
    public int? id_abono { get; set; }
    [Required(ErrorMessage = "Es necesario indicar el monto a abonar.")]
    public decimal? precio { get; set; }

    public decimal? descuento { get; set; }

    public decimal? recargo { get; set; }

    public virtual ABONO id_abonoNavigation { get; set; }

    public virtual FACTURA id_facturaNavigation { get; set; }

    public virtual LUGARE id_lugarNavigation { get; set; }

    public virtual VEHICULO id_vehiculoNavigation { get; set; }
}