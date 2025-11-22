using System;
using System.Collections.Generic;

namespace CSDLPT_Tuan6_API.Entities;

public partial class SanphamManh2
{
    public int Masanpham { get; set; }

    public int? Giaban { get; set; }

    public int? Makhohang { get; set; }

    public Guid Rowguid { get; set; }
}
