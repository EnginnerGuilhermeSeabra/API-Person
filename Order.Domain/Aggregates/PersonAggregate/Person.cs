﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Domain.Aggregates.PersonAggregate
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Document { get; set; }
        public string? BirthDate { get; set; }
    }
}
