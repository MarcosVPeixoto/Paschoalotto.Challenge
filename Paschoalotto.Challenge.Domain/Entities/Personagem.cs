namespace Paschoalotto.Challenge.Domain.Entities
{
    public  class Personagem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Comic Comics { get; set; }
        public Serie Series { get; set; }        
        public Story Stories{ get; set; }        
        public Evento Events { get; set; }
    }
}
