using System;
using System.Collections.Generic;

namespace prj_MVC_core.Models;

public partial class Tcomment
{
    public int Fid { get; set; }

    public string? FDate { get; set; }

    public int? FUserId { get; set; }

    public int? FPost { get; set; }

    public string? FComment { get; set; }
}
