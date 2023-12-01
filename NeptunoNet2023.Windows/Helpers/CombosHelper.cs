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

    }
}
