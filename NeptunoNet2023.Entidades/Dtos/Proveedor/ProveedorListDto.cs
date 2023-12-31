﻿namespace NeptunoNet2023.Entidades.Dtos.Proveedor
{
    public class ProveedorListDto
    {
        public int ProveedorId { get; set; }
        public string? NombreProveedor { get; set; }
        public string? NombrePais { get; set; }
        public string? NombreCiudad { get; set; }
        public string? Telefono { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{NombreProveedor}";
        }

    }
}
