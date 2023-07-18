using System;
using System.Collections.Generic;
using Sieve.Attributes;

namespace quickjournal_backend.Models;
public partial class Entry
{
    public Guid Id { get; set; }

    public string? Body { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public DateTime? CreatedAt { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public DateTime UpdatedAt { get; set; }
}
