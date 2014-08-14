using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elmah.Contrib.EntityFramework
{
    [Table("ELMAH_Error")]
    public class ElmahError
    {
        public ElmahError()
        {
        }

        public ElmahError(Exception ex)
            : this(new Error(ex))
        {
        }

        public ElmahError(Error error)
        {
            ErrorId = Guid.NewGuid();
            Application = error.ApplicationName;
            Host = error.HostName;
            Type = error.Type;
            Source = error.Source;
            Message = error.Message;
            User = error.User;
            TimeUtc = error.Time;

            AllXml = ErrorXml.EncodeString(error);
        }

        [Key]
        public Guid ErrorId { get; set; }

        [Required]
        [StringLength(60)]
        public string Application { get; set; }

        [Required]
        [StringLength(50)]
        public string Host { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        [Required]
        [StringLength(60)]
        public string Source { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        [Required]
        [StringLength(50)]
        public string User { get; set; }

        [Required]
        public int StatusCode { get; set; }

        [Required]
        public DateTime TimeUtc { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sequence { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string AllXml { get; set; }
    }
}