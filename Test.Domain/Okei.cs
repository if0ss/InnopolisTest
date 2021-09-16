namespace Test.Domain
{
    /// <summary>
    /// ОКЕИ (классификатор единиц измерения)
    /// </summary>
    public class Okei : IBaseEntity
    {
        public long Id { get; }

        public string Name { get; set; }
        public string Code { get; set; }
    }
}