using System;
using System.Collections.Generic;

namespace WEB_API_2.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaPedido { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
