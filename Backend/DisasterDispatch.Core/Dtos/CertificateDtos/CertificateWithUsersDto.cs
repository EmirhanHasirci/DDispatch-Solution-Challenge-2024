using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.CertificateDtos
{
    public class CertificateWithUsersDto
    {
        public Guid Id { get; set; }
        public string Proof { get; set; }
        public DateTime ReceivedDate { get; set; }
        public AppUserDto AppUser { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
