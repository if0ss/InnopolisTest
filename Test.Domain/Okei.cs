namespace Test.Domain
{
    /// <summary>
    /// ОКЕИ (классификатор единиц измерения)
    /// </summary>
    public class Okei : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
    }
}