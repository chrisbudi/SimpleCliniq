﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SimpleCliniq.Module.Core.Domain.Models;

public partial class MDokterNote
{
    public long IdDokterNote { get; set; }

    public decimal IdDokter { get; set; }

    public string KdDokter { get; set; }

    public string Keterangan { get; set; }

    public string By { get; set; }

    public DateTime? TglInput { get; set; }
}