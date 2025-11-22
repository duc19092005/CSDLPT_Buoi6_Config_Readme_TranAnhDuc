using System;
using System.Collections.Generic;

namespace CSDLPT_Tuan6_API.Entities;

public partial class SanphamManh3
{
    public int Masanpham { get; set; }

    public string Tensanpham { get; set; } = null!;

    public int? Giaban { get; set; }

    public int? Makhohang { get; set; }

    public Guid Rowguid { get; set; }
}
