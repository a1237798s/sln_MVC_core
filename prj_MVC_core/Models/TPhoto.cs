using System;
using System.Collections.Generic;

namespace prj_MVC_core.Models;

public partial class TPhoto
{
    public int Fid { get; set; }

    public string? FDate { get; set; }

    public string? FDescription { get; set; }

    public int? FOwnerId { get; set; }

    public string? FImage { get; set; }
}
