using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Servicios;

namespace NeptunoNet2023.Windows.Helpers
{
    public static class CombosHelper
    {

        public static void CargarDatosComboPaises(ref ComboBox cbo)
        {
            var _serviciosPaises = new ServiciosPaises();
            var listaPaises = _serviciosPaises.GetAll();
            Pais defaultPais = new Pais()
            {
                PaisId = 0,
                NombrePais = "Seleccione País"
            };
            listaPaises.Insert(0, defaultPais);
            cbo.DataSource = listaPaises;
            cbo.DisplayMember = "NombrePais";
            cbo.ValueMember = "PaisId";

            cbo.SelectedIndex = 0;
        }
        public static void CargarDatosComboCiudades(ref ComboBox cbo, Pais pais)
        {
            var _serviciosCiudades=new ServiciosCiudades();
            var listaCiudades = _serviciosCiudades.GetAll(pais);
            CiudadListDto defaultCiudad = new CiudadListDto()
            {
                CiudadId = 0,
                NombreCiudad = "Seleccione Ciudad"
            };
            listaCiudades.Insert(0, defaultCiudad);

            cbo.DataSource= listaCiudades;//establezco la fuente de datos del cbo
            cbo.DisplayMember = "NombreCiudad";//establezco que muestre el nombre de la ciudad
            cbo.ValueMember = "CiudadId";//establezco el valor que se guardará
            cbo.SelectedIndex = 0;
        }
    }
}
