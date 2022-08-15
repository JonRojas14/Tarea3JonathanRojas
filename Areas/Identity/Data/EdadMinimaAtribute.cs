using System.ComponentModel.DataAnnotations;

namespace TareaNo._3_Jonathan_Rojas_3101.Areas.Identity.Data
{
    public class EdadMinimaAtribute : ValidationAttribute
    {
        int _EdadMinima;

        public EdadMinimaAtribute(int edadMinima)
        {
            _EdadMinima = edadMinima;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_EdadMinima) < DateTime.Now;
            }

            return false;
        }
    }
}
