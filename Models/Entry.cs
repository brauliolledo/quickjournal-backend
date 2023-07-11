using System;
using System.Collections.Generic;

namespace quickjournal_backend.Models;
public partial class Entry
{
    public Guid Id { get; set; }

    public string? Body { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
