using System;
using System.Collections.Generic;

namespace CSDLPT_Tuan6_API.Entities;

public partial class SanphamManh1
{
    public int Masanpham { get; set; }

    public string Tensanpham { get; set; } = null!;

    public Guid Rowguid { get; set; }
}
