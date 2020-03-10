using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.TaxasDeJuros.Domain.Base
{
    public abstract class EntityBase : ErrorBase
    {
        protected EntityBase(Guid id) => SetId(id);

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        private void SetId(Guid id)
        {
            if (default == id)
            {
                AddError("O campo ID deve ser informado.");
                return;
            }

            Id = id;
        }
    }
}