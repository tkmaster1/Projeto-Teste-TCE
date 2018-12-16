using System.Collections.Generic;

namespace Livraria.Application.Validation
{
    public class ValidationApplicationResult
    {
        public ValidationApplicationResult()
        {
            Erros = new List<string>();
        }
        public ICollection<string> Erros { get; set; }

        public string Mensagem { get; set; }
        public bool IsValid
        {
            get { return Erros.Count == 0; }
            set { var b = value; }
        }
    }
}
