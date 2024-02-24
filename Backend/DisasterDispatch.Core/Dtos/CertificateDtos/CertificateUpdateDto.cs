using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.CertificateDtos
{
    public class CertificateUpdateDto
    {
        public Guid Id { get; set; }
        public string Proof { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string AppUserId { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
