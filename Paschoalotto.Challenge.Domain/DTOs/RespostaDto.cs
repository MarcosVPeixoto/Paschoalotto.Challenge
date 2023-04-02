using Paschoalotto.Challenge.Domain.Entities;

namespace Paschoalotto.Challenge.Domain.DTOs
{
    public class RespostaDto
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public DataDto Data{ get; set; }
    }
}
