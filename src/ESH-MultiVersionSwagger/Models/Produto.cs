using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_MultiVersionSwagger.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }

        public void Validar()
        {
            StringBuilder sb = new StringBuilder();

            if (Descricao.StartsWith("s"))
                Descricao = null;


            if (string.IsNullOrWhiteSpace(Descricao))
                sb.Append($"O campo Descrição é Obrigatório.{Environment.NewLine}");
            if (Preco < 0.01m)
                sb.Append($"O campo Preço é Obrigatório.{Environment.NewLine}");

            if (sb.Length > 0)
                throw new ApplicationException(sb.ToString());
        }
    }
}
