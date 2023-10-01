using System;
using System.Collections.Generic;

namespace WEB_API_2.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallesPedidos = new HashSet<DetallesPedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; } = null!;
        public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
