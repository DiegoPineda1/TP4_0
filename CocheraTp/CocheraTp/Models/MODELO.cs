﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CocheraTp.Models;

public partial class MODELO
{
    public int id_modelo { get; set; }

    public string descripcion { get; set; }

    public int? id_marca { get; set; }

    public virtual ICollection<VEHICULO> VEHICULOs { get; set; } = new List<VEHICULO>();

    public virtual MARCA id_marcaNavigation { get; set; }
}