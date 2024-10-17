using System.ComponentModel.DataAnnotations;


namespace Infra.UPX4.Domain.Entities
{
    public class BaseEntity
    {
        // to indentify primary key
        [Key]
        public Guid Id { get; set; }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime? UpdatedAt { get; set; }

    }
}