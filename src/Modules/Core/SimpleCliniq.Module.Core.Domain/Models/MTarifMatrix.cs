﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SimpleCliniq.Module.Core.Domain.Models;

public partial class MTarifMatrix
{
    public Guid IdTarifmatrix { get; set; }

    public decimal OldIdTarifmatrix { get; set; }

    public Guid IdTarifdetail { get; set; }

    public string Kdtarifdetail { get; set; }

    public Guid IdRuang { get; set; }

    public string Koderuangan { get; set; }

    public bool? IsAktif { get; set; }
}