namespace Leaf.Application.Results.Base
{
    public class ResultDto
    {
        public string? MensagemErro { get; set; }
        public bool Sucesso { get; set; }

        public object? Data { get; set; }

        public ResultDto(string msgErro, object data = null)
        {
            MensagemErro = msgErro;

            Sucesso = string.IsNullOrEmpty(MensagemErro);

            Data = data;
        }
    }
}