namespace ProvaPub.Models
{
    public class EntityList<T>
    {
        //Criado uma classe do tipo generica para que os campos em comum das classes sejam listadas e os campos incomuns colocados aqui nessa classe.
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
    }
}
