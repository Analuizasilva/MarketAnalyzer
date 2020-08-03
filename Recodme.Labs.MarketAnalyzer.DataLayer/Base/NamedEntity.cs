using System;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.Base
{
    public abstract class NamedEntity : Entity
    {
        private string _name;

        [Required(ErrorMessage = "Input name")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RegisterChange();
            }
        }

        protected NamedEntity(string name)
        {
            _name = name;
        }

        protected NamedEntity(Guid id, DateTime createdAt, DateTime updatedAt, bool isDelete, string name) : base(id, createdAt, updatedAt, isDelete)
        {
            _name = name;
        }
    }
}
