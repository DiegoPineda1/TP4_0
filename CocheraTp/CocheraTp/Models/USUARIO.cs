﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CocheraTp.Models;

public partial class USUARIO
{
    public int id_usuario { get; set; }

    public string usuario1 { get; set; }

    public string contrasenia { get; set; }

    [JsonIgnore]
    public virtual ICollection<FACTURA> FACTURAs { get; set; } = new List<FACTURA>();
}