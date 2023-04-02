using Newtonsoft.Json;
using Paschoalotto.Challenge.Domain.DTOs;
using Paschoalotto.Challenge.Domain.Entities;
using Paschoalotto.Challenge.IBusiness.IBusiness;

namespace Paschoalotto.Challenge.Business.Business
{
    public class PersonagemBusiness : IPersonagemBusiness
    {
        public async Task PreencherArquivo()
        {
            var personagens = await GetPersonagens();
            PreencherArquivo(personagens);
        }

        private async Task<List<Personagem>> GetPersonagens()
        {
            var requisicao = new HttpClient();
            var apikey = "fcca67547c8640ca110604b377c200b7";
            var timestamp = "859953844";
            var hash = "6cf63d610691b366476d4c54ada12c3c";
            var response = await requisicao.GetAsync($"https://gateway.marvel.com/v1/public/characters?apikey={apikey}&ts={timestamp}&hash={hash}");

            var conteudo = response.Content.ReadAsStringAsync();
            var respostaDto =  JsonConvert.DeserializeObject<RespostaDto>(conteudo.Result);
            return respostaDto.Data.Results;
        }

        private void PreencherArquivo(List<Personagem> personagens)
        {
            var diretorio = Directory.GetCurrentDirectory();
            var caminho = $"{diretorio}\\personagensmarvel.txt";
            var considerarConteudoAtual = false;
            using (var streamWriter = new StreamWriter(caminho, considerarConteudoAtual))
            {
                var indice = 1;
                personagens.ForEach(personagem =>
                {
                    streamWriter.WriteLine($"Character nº{indice}");
                    streamWriter.WriteLine($"Id: {personagem.Id}");
                    streamWriter.WriteLine($"Name: {personagem.Name}");
                    streamWriter.WriteLine($"Description: {personagem.Description}");
                    streamWriter.WriteLine($"Comics:");
                    personagem.Comics.Items.ForEach(item => streamWriter.WriteLine($"  - {item.Name}") );
                    streamWriter.WriteLine($"Series:");
                    personagem.Series.Items.ForEach(item => streamWriter.WriteLine($"  - {item.Name}") );
                    streamWriter.WriteLine($"Stories:");
                    personagem.Stories.Items.ForEach(item => streamWriter.WriteLine($"  - {item.Name}") );
                    streamWriter.WriteLine($"Events:");
                    personagem.Events.Items.ForEach(item => streamWriter.WriteLine($"  - {item.Name}") );
                    streamWriter.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                    streamWriter.WriteLine();
                    indice++;
                });
            }
        }
    }
}
