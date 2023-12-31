﻿using System;
using System.Collections.Generic;

namespace WEB_API_2.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
