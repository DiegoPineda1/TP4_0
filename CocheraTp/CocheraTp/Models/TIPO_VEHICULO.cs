﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CocheraTp.Models;

public partial class TIPO_VEHICULO
{
    public int id_tipo_vehiculo { get; set; }

    public string descripcion { get; set; }

    public decimal? precio { get; set; }

    public virtual ICollection<VEHICULO> VEHICULOs { get; set; } = new List<VEHICULO>();
}