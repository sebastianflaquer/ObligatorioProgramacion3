﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Persona
    {
        public int Id{ get; set; }
        public string Nombre { get; set; }
        public string Apellido{ get; set; }
        public string CI { get; set; }

    }
}
